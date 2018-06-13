//////////////////////////////////////////////////////////////
//
// Implementation of a TCP network client.
//
// 06-Jun-2018   Created.
//
//////////////////////////////////////////////////////////////

using System;
using System.Net;
using System.Net.Sockets;

namespace NeoDesk
{
namespace Network
{
    
public class TcpNetworkClient : BaseNetworkClient
{

    /// <summary>Constructor.</summary>
    public TcpNetworkClient()
    {
        m_TcpClient = new TcpClient();
    }

    /// <summary>Returns a handle of the client.</summary>
    public TcpClient GetHandle()
    {
        return m_TcpClient;
    }

    /// <summary>Tries to connect to a server.</summary>
    /// <param name="serverIpAddress">Server's IP address.</param>
    /// <param name="serverPort">Server's port.</param>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    override protected bool TryToConnect( IPAddress ipAddress, UInt16 serverPort )
    {
        try
        {
            m_TcpClient.Connect( ipAddress, serverPort );
        }
        catch
        {
            return false;
        }

        m_NetworkStream = m_TcpClient.GetStream();
        try
        {
            m_NetworkStream.BeginRead( m_ReadBuffer, 0, m_ReadBuffer.Length, new AsyncCallback( ReadCallback ), null );
        }
        catch
        {
            TryToDisconnect();
            return false;
        }

        return true;
    }

    /// <summary>Tries to disconnect.</summary>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    override protected bool TryToDisconnect()
    {
        try
        {
            m_TcpClient.Close();
            m_NetworkStream = null;
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <summary>Tries to send a packet to the server.</summary>
    /// <param name="buffer">Data to be sent.</param>
    /// <param name="size">Data size to be sent.</param>
    /// <returns>Amount of sent bytes.</returns>
    override protected UInt32 TryToSendPacket( Byte[] buffer, UInt32 size )
    {
        try
        {
            m_NetworkStream.Write( buffer, 0, ( int )size );
        }
        catch
        {
            return 0;
        }

        return size;
    }

    /// <summary>Callback after receiving a packet of data.</summary>    
    /// <param name="result">Result of the operation.</param>
    private void ReadCallback( IAsyncResult result )
    {
        if ( ( m_ReadCallback != null ) && ( IsConnected() == true ) )
        {
            int dataSize = m_NetworkStream.EndRead( result );
            m_ReadCallback( this, m_ReadBuffer, ( UInt32 )dataSize );
            m_NetworkStream.BeginRead( m_ReadBuffer, 0, m_ReadBuffer.Length, new AsyncCallback( ReadCallback ), m_NetworkStream );
        }
    }

    /// <summary>Client's class.</summary>
    private TcpClient m_TcpClient;
    /// <summary>Network stream.</summary>
    private NetworkStream m_NetworkStream;

}

}  // namespace Network
}  // namespace NeoDesk
