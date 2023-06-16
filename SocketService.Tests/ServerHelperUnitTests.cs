using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocketService.Providers;
using System.Net;
using System.Text;
using System.Threading;

namespace SocketService.Tests
{
	[TestClass]
	public class ServerHelperUnitTests
	{
		[TestMethod]
		public void TestHandleClientRequest_FileExists_ReturnsFileContent()
		{
			// Arrange
			Mock<ISocket> socketMock = new Mock<ISocket>();
			int serverPort = 8080;
			string fileName = "test.txt";
			string expectedResponse = "File found";
			string expectedFileContent = "TEST";
			byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
			byte[] expectedResponseBytes = Encoding.UTF8.GetBytes(expectedResponse);
			byte[] expectedFileContentBytes = Encoding.UTF8.GetBytes(expectedFileContent);

			socketMock.SetupGet(s => s.RemoteEndPoint).Returns(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
			socketMock.Setup(s => s.Receive(It.IsAny<byte[]>()))
				.Callback<byte[]>(buffer => fileNameBytes.CopyTo(buffer, 0))
				.Returns(fileNameBytes.Length);
			socketMock.Setup(s => s.Send(expectedResponseBytes))
				.Returns(expectedResponseBytes.Length);
			socketMock.Setup(s => s.Send(expectedFileContentBytes))
				.Returns(expectedFileContentBytes.Length);

			ServerHelper serverHelper = new ServerHelper(serverPort, socketMock.Object);

			// Act
			serverHelper.HandleClientRequest(socketMock.Object);

			// Assert
			socketMock.Verify(s => s.Send(expectedResponseBytes), Times.Once);
			socketMock.Verify(s => s.Send(expectedFileContentBytes), Times.Once);
		}

		[TestMethod]
		public void TestHandleClientRequest_FileDoesNotExist_ReturnsFileNotFound()
		{
			// Arrange
			Mock<ISocket> socketMock = new Mock<ISocket>();
			int serverPort = 8080;
			string fileName = "nonexistent.txt";
			string expectedResponse = "File not found";
			byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
			byte[] expectedResponseBytes = Encoding.UTF8.GetBytes(expectedResponse);

			socketMock.SetupGet(s => s.RemoteEndPoint).Returns(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
			socketMock.Setup(s => s.Receive(It.IsAny<byte[]>()))
				.Returns(fileNameBytes.Length)
				.Callback<byte[]>(buffer => fileNameBytes.CopyTo(buffer, 0));
			socketMock.Setup(s => s.Send(expectedResponseBytes))
				.Returns(expectedResponseBytes.Length);

			ServerHelper serverHelper = new ServerHelper(serverPort, socketMock.Object);

			// Act
			serverHelper.HandleClientRequest(socketMock.Object);

			// Assert
			socketMock.Verify(s => s.Send(expectedResponseBytes), Times.Once);
		}

		[TestMethod]
		public void TestHandleClientRequest_NoDataReceived_ReturnsNoDataReceived()
		{
			// Arrange
			Mock<ISocket> socketMock = new Mock<ISocket>();
			int serverPort = 8080;
			string expectedResponse = "No data received";
			byte[] expectedResponseBytes = Encoding.UTF8.GetBytes(expectedResponse);

			socketMock.SetupGet(s => s.RemoteEndPoint).Returns(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
			socketMock.Setup(s => s.Receive(It.IsAny<byte[]>()))
				.Returns(0);
			socketMock.Setup(s => s.Send(expectedResponseBytes))
				.Returns(expectedResponseBytes.Length);

			ServerHelper serverHelper = new ServerHelper(serverPort, socketMock.Object);

			// Act
			serverHelper.HandleClientRequest(socketMock.Object);

			// Assert
			socketMock.Verify(s => s.Send(expectedResponseBytes), Times.Once);
		}

		[TestMethod]
		public void TestListenForClients()
		{
			// Arrange
			int maxClients = 2;
			int serverPort = 8080;
			Mock<ISocket> socketMock = new Mock<ISocket>();
			Mock<ISocket> mockClient1 = new Mock<ISocket>();
			Mock<ISocket> mockClient2 = new Mock<ISocket>();

			socketMock.Setup(x => x.Bind(It.IsAny<IPEndPoint>()));
			socketMock.Setup(x => x.Listen(maxClients));
			socketMock.SetupSequence(x => x.Accept())
				.Returns(() =>
				{
					Thread.Sleep(100); // 延遲 100 毫秒以測試多個客戶端同時連接的情況
					return mockClient1.Object;
				})
				.Returns(() =>
				{
					Thread.Sleep(100); // 延遲 100 毫秒以測試多個客戶端同時連接的情況
					return mockClient2.Object;
				});

			ServerHelper serverHelper = new ServerHelper(serverPort, socketMock.Object);

			// Act
			serverHelper.ListenForClients(maxClients);

			// Assert
			socketMock.Verify(x => x.Bind(It.IsAny<IPEndPoint>()), Times.Once);
			socketMock.Verify(x => x.Listen(maxClients), Times.Once);
			socketMock.Verify(x => x.Accept(), Times.Exactly(maxClients));
			mockClient1.Verify(x => x.Close(), Times.Once);
			mockClient2.Verify(x => x.Close(), Times.Once);
		}
	}
}
