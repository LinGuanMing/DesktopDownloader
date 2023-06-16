using System.Net;
using System.Net.Sockets;

namespace SocketService.Providers
{
	public interface ISocket
	{
		void Bind(EndPoint localEP);
		void Listen(int backlog);
		ISocket Accept();
		void Connect(EndPoint remoteEP);
		int Send(byte[] buffer);
		int Send(byte[] buffer, int offset, int size, SocketFlags flags);
		int Receive(byte[] buffer);
		EndPoint RemoteEndPoint { get; }
		EndPoint LocalEndPoint { get; }
		void Close();
	}
}
