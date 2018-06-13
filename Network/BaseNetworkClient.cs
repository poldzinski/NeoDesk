//////////////////////////////////////////////////////////////
//
// Interface of a network client.
//
// 06-Jun-2018   Created.
//
//////////////////////////////////////////////////////////////

using System;
using System.Net;

namespace NeoDesk
{
namespace Network
{

/// <summary>Delegate for handling client's read operations.</summary>
/// <param name="networkClient">Parent client.</param>
/// <param name="buffer">Data buffer.</param>
/// <param name="size">Data size.</param>
public delegate void ClientReadCallback( BaseNetworkClient networkClient, Byte[] buffer, UInt32 size );
    
abstract public class BaseNetworkClient
{

    /// <summary>Destructor.</summary>
    ~BaseNetworkClient()
    {
        Disconnect();
    }

    /// <summary>Connects to a server.</summary>
    /// <param name="serverIpAddress">Server's IP address.</param>
    /// <param name="serverPort">Server's port.</param>
    /// <param name="readCallback">Callback for read operations.</param>
    /// <param name="disconnect">Whether to disconnect if already connected.</param>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    public bool Connect( string serverIpAddress, UInt16 serverPort, ClientReadCallback readCallback = null, bool disconnect = true )
    {
        IPAddress ipAddress;
        bool parsingResult = IPAddress.TryParse( serverIpAddress, out ipAddress );

        if ( parsingResult == false )
        {
            ipAddress = Dns.GetHostEntry( serverIpAddress ).AddressList[ 0 ];
        }

        return Connect( ipAddress, serverPort, readCallback, disconnect );
    }

    /// <summary>Connects to a server.</summary>
    /// <param name="serverIpAddress">Server's IP address.</param>
    /// <param name="serverPort">Server's port.</param>
    /// <param name="readCallback">Callback for read operations.</param>
    /// <param name="disconnect">Whether to disconnect if already connected.</param>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    public bool Connect( IPAddress serverIpAddress, UInt16 serverPort, ClientReadCallback readCallback = null, bool disconnect = true )
    {
        m_ReadCallback = null;        

        if ( disconnect == true )
        {
            Disconnect();
        }

        if ( m_Connected == true )
        {
            return false;
        }

        if ( TryToConnect( serverIpAddress, serverPort ) == true )
        {
            m_Connected = true;
            m_ReadCallback = readCallback;
            return true;
        }

        return false;
    }

    /// <summary>Disconnects.</summary>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    public bool Disconnect()
    {
        if ( m_Connected == false )
        {
            return false;
        }

        if ( TryToDisconnect() == true )
        {
            m_Connected = false;
            return true;
        }

        return false;
    }

    /// <summary>Returns the state of the connection.</summary>
    /// <returns>True if connected, false otherwise.</returns>
    public bool IsConnected()
    {
        return m_Connected;
    }

    /// <summary>Sends a packet to the server.</summary>
    /// <param name="buffer">Data to be sent.</param>
    /// <param name="size">Data size to be sent.</param>
    /// <returns>Amount of sent bytes.</returns>
    public UInt32 SendPacket( Byte[] buffer, UInt32 size )
    {
        if ( m_Connected == false )
        {
            return 0;
        }

        return TryToSendPacket( buffer, size );
    }

    /// <summary>Returns current read operations callback.</summary>
    /// <returns>Callback.</returns>
    public ClientReadCallback GetReadCallback()
    {
        return m_ReadCallback;
    }

    /// <summary>Sets read operations callback.</summary>
    /// <param name="readCallback">Callback for read operations.</param>
    public void SetReadCallback( ClientReadCallback readCallback )
    {
        m_ReadCallback = readCallback;
    }

    /// <summary>Tries to connect to a server.</summary>
    /// <param name="serverIpAddress">Server's IP address.</param>
    /// <param name="serverPort">Server's port.</param>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    abstract protected bool TryToConnect( IPAddress ipAddress, UInt16 serverPort );

    /// <summary>Tries to disconnect.</summary>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    abstract protected bool TryToDisconnect();

    /// <summary>Tries to send a packet to the server.</summary>
    /// <param name="buffer">Data to be sent.</param>
    /// <param name="size">Data size to be sent.</param>
    /// <returns>Amount of sent bytes.</returns>
    abstract protected UInt32 TryToSendPacket( Byte[] buffer, UInt32 size );

    /// <summary>Size of buffers for read operations.</summary>
    public const UInt32 READ_BUFFER_SIZE = 1024;

    /// <summary>Callback to handle read operations.</summary>
    protected ClientReadCallback m_ReadCallback;
    /// <summary>Buffer for read operations.</summary>
    protected Byte[] m_ReadBuffer = new Byte[ READ_BUFFER_SIZE ];
    /// <summary>Keeps current connection state.</summary>
    private bool m_Connected = false;

}

}  // namespace Network
}  // namespace NeoDesk
