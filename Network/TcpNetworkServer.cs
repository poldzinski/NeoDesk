//////////////////////////////////////////////////////////////
//
// Implementation of a TCP network server.
//
// 07-Jun-2018   Created.
//
//////////////////////////////////////////////////////////////

using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace NeoDesk
{
namespace Network
{

struct ServerClientPair
{
    
    /// <summary>Constructor.</summary>
    /// <param name="server">Server.</param>
    /// <param name="client">Client.</param>
    public ServerClientPair( TcpNetworkServer server, 
                             TcpClient client, 
                             ServerReadCallback readCallback,
                             Byte[] buffer )
    {
        Server = server;
        Client = client;
        ReadCallback = readCallback;
        Buffer = buffer;
    }

    /// <summary>Server.</summary>
    public TcpNetworkServer Server { get; set; }
    /// <summary>Client.</summary>
    public TcpClient Client { get; set; }
    /// <summary>Callback for read operations.</summary>
    public ServerReadCallback ReadCallback { get; set; }
    /// <summary>Buffer for read operations.</summary>
    public Byte[] Buffer { get; set; }

}

public class TcpNetworkServer : BaseNetworkServer
{

    /// <summary>Disconnects a client.</summary>
    /// <param name="client">Client.</param>
    public void DisconnectClient( TcpClient client )
    {
        int clientIndex = m_Clients.IndexOf( client );        

        client.Close();
        m_Clients.RemoveAt( clientIndex );
        m_ReadBuffers.RemoveAt( clientIndex );
    }

    /// <summary>Returns a handle of the client.</summary>
    public TcpListener GetHandle()
    {
        return m_TcpServer;
    }

    /// <summary>Tries to connect to a server.</summary>
    /// <param name="serverPort">Server's port.</param>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    override protected bool TryToBind( UInt16 serverPort )
    {
        try
        {
            IPAddress ipAddress = IPAddress.Parse( "127.0.0.1" );

            m_TcpServer = new TcpListener( ipAddress, serverPort );
            m_TcpServer.Start();
        }
        catch
        {
            return false;
        }

        m_TcpServer.BeginAcceptTcpClient( new AsyncCallback( AcceptCallback ), m_TcpServer );

        return true;
    }

    /// <summary>Tries to disconnect.</summary>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    override protected bool TryToDisconnect()
    {
        try
        {
            m_TcpServer.Stop();
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <summary>Tries to send a packet to the server.</summary>
    /// <param name="clientIpAddress">Destination client's IP address.</param>
    /// <param name="buffer">Data to be sent.</param>
    /// <param name="size">Data size to be sent.</param>
    /// <returns>Amount of sent bytes.</returns>
    override protected UInt32 TryToSendPacket( IPEndPoint destinationClient, Byte[] buffer, UInt32 size )
    {
        foreach ( TcpClient client in m_Clients )
        {
            IPEndPoint endPoint = ( IPEndPoint )client.Client.RemoteEndPoint;

            if ( endPoint.Equals( destinationClient ) )
            {
                try
                {
                    client.Client.Send( buffer, ( int )size, SocketFlags.None );
                    return size;
                }
                catch
                {
                    return 0;
                }
            }
        }
        return 0;
    }

    /// <summary>Callback after receiving a request to accept.</summary>    
    /// <param name="result">Result of the operation.</param>
    private void AcceptCallback( IAsyncResult result )
    {
        if ( IsConnected() )        
        {
            TcpClient client = m_TcpServer.EndAcceptTcpClient( result );
            m_TcpServer.BeginAcceptTcpClient( new AsyncCallback( AcceptCallback ), m_TcpServer );

            m_Clients.Add( client );
            m_ReadBuffers.Add( new Byte[ READ_BUFFER_SIZE ] );

            Int32 clientIndex = m_Clients.Count - 1;

            ServerClientPair pair = new ServerClientPair( this, client, m_ReadCallback, m_ReadBuffers[ clientIndex ] );
            client.Client.BeginReceive( m_ReadBuffers[ clientIndex ], 
                                        0, 
                                        ( int )READ_BUFFER_SIZE, 
                                        SocketFlags.None, 
                                        new AsyncCallback( ReadCallback ), 
                                        pair );
        }
    }

    /// <summary>Callback after receiving a packet of data.</summary>    
    /// <param name="result">Result of the operation.</param>
    private static void ReadCallback( IAsyncResult result )
    {
        ServerClientPair pair = ( ServerClientPair )result.AsyncState;

        if ( pair.ReadCallback != null )
        {
            TcpNetworkServer server = pair.Server;
            TcpClient client = pair.Client;
            Byte[] buffer = pair.Buffer;

            Int32 dataReceived = client.Client.EndReceive( result );

            if ( dataReceived == 0 )
            {
                server.DisconnectClient( client );
            }
            else if ( dataReceived > 0 )
            {
                pair.ReadCallback( server, client, buffer, ( UInt32 )dataReceived );
                client.Client.BeginReceive( buffer, 0, ( int )READ_BUFFER_SIZE, SocketFlags.None, ReadCallback, pair );
            }
        }
    }

    /// <summary>Server's class.</summary>
    private TcpListener m_TcpServer;
    /// <summary>Socket of connected clients.</summary>
    private List< TcpClient > m_Clients = new List< TcpClient >();

}

}  // namespace Network
}  // namespace NeoDesk
