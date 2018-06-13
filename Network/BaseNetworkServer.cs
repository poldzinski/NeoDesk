//////////////////////////////////////////////////////////////
//
// Interface of a network server.
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

/// <summary>Delegate for handling server's read operations.</summary>
/// <param name="networkServer">Parent server.</param>
/// <param name="clientIpAddress">Connected client.</param>
/// <param name="buffer">Data buffer.</param>
/// <param name="size">Data size.</param>
public delegate void ServerReadCallback( BaseNetworkServer networkServer, TcpClient client, Byte[] buffer, UInt32 size );
    
abstract public class BaseNetworkServer
{

    /// <summary>Destructor.</summary>
    ~BaseNetworkServer()
    {
        Disconnect();
    }

    /// <summary>Returns the state of the connection.</summary>
    /// <returns>True if connected, otherwise false.</returns>
    public bool IsConnected()
    {
        return m_Bound;
    }

    /// <summary>Binds to a port.</summary>
    /// <param name="serverPort">Server's port.</param>
    /// <param name="readCallback">Callback for read operations.</param>
    /// <param name="disconnect">Whether to disconnect if already connected.</param>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    public bool Bind( UInt16 serverPort, ServerReadCallback readCallback = null, bool disconnect = true )
    {
        m_ReadCallback = null;        

        if ( disconnect == true )
        {
            Disconnect();
        }

        if ( m_Bound == true )
        {
            return false;
        }

        if ( TryToBind( serverPort ) == true )
        {
            m_Bound = true;
            m_ReadCallback = readCallback;
            return true;
        }

        return false;
    }

    /// <summary>Disconnects.</summary>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    public bool Disconnect()
    {
        if ( m_Bound == false )
        {
            return false;
        }

        m_Bound = false;
        return TryToDisconnect();
    }

    /// <summary>Sends a packet to the server.</summary>
    /// <param name="client">Destination client.</param>
    /// <param name="buffer">Data to be sent.</param>
    /// <param name="size">Data size to be sent.</param>
    /// <returns>Amount of sent bytes.</returns>
    public UInt32 SendPacket( IPEndPoint client, Byte[] buffer, UInt32 size )
    {
        if ( m_Bound == false )
        {
            return 0;
        }

        return TryToSendPacket( client, buffer, size );
    }

    /// <summary>Returns current read operations callback.</summary>
    /// <returns>Callback.</returns>
    public ServerReadCallback GetReadCallback()
    {
        return m_ReadCallback;
    }

    /// <summary>Sets read operations callback.</summary>
    /// <param name="readCallback">Callback for read operations.</param>
    public void SetReadCallback( ServerReadCallback readCallback )
    {
        m_ReadCallback = readCallback;
    }

    /// <summary>Tries to connect to a server.</summary>
    /// <param name="serverPort">Server's port.</param>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    abstract protected bool TryToBind( UInt16 serverPort );

    /// <summary>Tries to disconnect.</summary>
    /// <returns>True if the operation was successful, False otherwise.</returns>
    abstract protected bool TryToDisconnect();

    /// <summary>Tries to send a packet to the server.</summary>
    /// <param name="client">Destination client.</param>
    /// <param name="buffer">Data to be sent.</param>
    /// <param name="size">Data size to be sent.</param>
    /// <returns>Amount of sent bytes.</returns>
    abstract protected UInt32 TryToSendPacket( IPEndPoint client, Byte[] buffer, UInt32 size );

    /// <summary>Size of buffers for read operations.</summary>
    public const UInt32 READ_BUFFER_SIZE = 256;

    /// <summary>Callback to handle read operations.</summary>
    protected ServerReadCallback m_ReadCallback;
    /// <summary>Buffers for read operations.</summary>
    protected List< Byte[] > m_ReadBuffers = new List< Byte[] >();
    /// <summary>Keeps current connection state.</summary>
    private bool m_Bound = false;

}

}  // namespace Network
}  // namespace NeoDesk
