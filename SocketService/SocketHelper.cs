using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SocketService.Providers;

namespace SocketService
{
	public class SocketHelper : ISocket
	{
		private readonly Socket _socket;

		public SocketHelper(Socket socket)
		{
			_socket = socket;
		}

		public void Bind(EndPoint localEP)
		{
			_socket.Bind(localEP);
		}

		public void Listen(int backlog)
		{
			_socket.Listen(backlog);
		}

		public ISocket Accept()
		{
			var clientSocket = _socket.Accept();
			return new SocketHelper(clientSocket);
		}

		public void Connect(EndPoint remoteEP)
		{
			_socket.Connect(remoteEP);
		}

		public int Send(byte[] buffer)
		{
			return _socket.Send(buffer);
		}

		public int Send(byte[] buffer, int offset, int size, SocketFlags flags)
		{
			return _socket.Send(buffer, offset, size, flags);
		}

		public int Receive(byte[] buffer)
		{
			return _socket.Receive(buffer);
		}

		public EndPoint RemoteEndPoint => _socket.RemoteEndPoint;

		public EndPoint LocalEndPoint => _socket.LocalEndPoint;

		public void Close()
		{
			_socket.Close();
		}
	}
}
