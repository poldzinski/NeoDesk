//////////////////////////////////////////////////////////////
//
// Unit tests within TcpNetworkClient and TcpNetworkServer.
//
// 06-Jun-2018   Created.
//
//////////////////////////////////////////////////////////////

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Net;
using System.Net.Sockets;

using NeoDesk.Network;

namespace UnitTests
{
namespace Network
{

[TestClass]
public class TcpNetworkClientTests
{

    const string m_CorrectAddress = "127.0.0.1";
    const string m_IncorrectAddress = "123";
    const System.UInt16 m_CorrectPort = 3000;
    const System.UInt16 m_IncorrectPort = 0;
    Byte[] m_ServerTestData = { 1, 2, 3, 4, 5 };
    Byte[] m_ClientTestData = { 6, 7, 8, 9, 0 };
    bool m_ReadResult = false;

    [TestMethod]
    public void ConnectHappyPath()
    {
        TcpNetworkServer server = new TcpNetworkServer();
        TcpNetworkClient client = new TcpNetworkClient();

        Assert.IsTrue( server.Bind( m_CorrectPort ) );
        Assert.IsTrue( client.Connect( m_CorrectAddress, m_CorrectPort ) );
        Assert.IsTrue( client.Disconnect() );
        Assert.IsTrue( server.Disconnect() );
    }


    [TestMethod]
    public void ConnectToIncorrectAddress()
    {
        TcpNetworkServer server = new TcpNetworkServer();
        TcpNetworkClient client = new TcpNetworkClient();

        Assert.IsTrue( server.Bind( m_CorrectPort ) );
        Assert.IsFalse( client.Connect( m_IncorrectAddress, m_CorrectPort ) );
        Assert.IsTrue( server.Disconnect() );
    }

    [TestMethod]
    public void ConnectToIncorrectPort()
    {
        TcpNetworkServer server = new TcpNetworkServer();
        TcpNetworkClient client = new TcpNetworkClient();

        Assert.IsTrue( server.Bind( m_CorrectPort ) );
        Assert.IsFalse( client.Connect( m_CorrectAddress, m_IncorrectPort ) );
        Assert.IsTrue( server.Disconnect() );
    }

    private void ServerReadCallback( BaseNetworkServer networkServer, TcpClient client, Byte[] buffer, UInt32 size )
    {
        m_ReadResult = false;
        if ( m_ServerTestData.Length == size )
        {
            for ( UInt32 index = 0; index < size; ++index )
            {
                if ( buffer[ index ] != m_ServerTestData[ index ] )
                {
                    return;
                }
            }
            m_ReadResult = true;
        }
    }

    private void ClientReadCallback( BaseNetworkClient networkClient, Byte[] buffer, UInt32 size )
    {
        m_ReadResult = false;
        if ( m_ClientTestData.Length == size )
        {
            for ( UInt32 index = 0; index < size; ++index )
            {
                if ( buffer[ index ] != m_ClientTestData[ index ] )
                {
                    return;
                }
            }
            m_ReadResult = true;
        }
    }

    [TestMethod]
    public void ReadHappyPath()
    {
        TcpNetworkServer server = new TcpNetworkServer();
        TcpNetworkClient client = new TcpNetworkClient();

        Assert.IsTrue( server.Bind( m_CorrectPort, ServerReadCallback ) );
        Assert.IsTrue( client.Connect( m_CorrectAddress, m_CorrectPort, ClientReadCallback ) );

        System.Threading.Thread.Sleep( 1000 );
        m_ReadResult = false;
        Assert.AreEqual( server.SendPacket( ( IPEndPoint )client.GetHandle().Client.LocalEndPoint, 
                                            m_ClientTestData, 
                                            ( UInt32 )m_ClientTestData.Length ), 
                                            ( UInt32 )m_ClientTestData.Length );
        System.Threading.Thread.Sleep( 1000 );
        Assert.IsTrue( m_ReadResult );
        m_ReadResult = false;
        Assert.AreEqual( client.SendPacket( m_ServerTestData, ( UInt32 )m_ServerTestData.Length ), ( UInt32 )m_ServerTestData.Length );
        System.Threading.Thread.Sleep( 1000 );
        Assert.IsTrue( m_ReadResult );
        Assert.IsTrue( client.Disconnect() );
        Assert.IsTrue( server.Disconnect() );
    }

}

}  // namespace Network
}  // namespace UnitTests
