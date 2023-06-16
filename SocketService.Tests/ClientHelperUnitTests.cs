using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocketService;
using SocketService.Providers;

namespace SocketService.Tests
{
	[TestClass]
	public class ClientHelperUnitTests
	{
		[TestMethod]
		public void TestDownloadData_WhenSocketThrowsSocketException_ReturnsErrorMessage()
		{
			// Arrange
			Mock<ISocket> socketMock = new Mock<ISocket>();
			IPAddress serverIP = IPAddress.Parse("127.0.0.1");
			int serverPort = 8080;
			string fileName = "test.txt";
			string savePath = Environment.CurrentDirectory;

			socketMock.Setup(s => s.Connect(It.IsAny<EndPoint>())).Throws(new SocketException());

			ClientHelper clientHelper = new ClientHelper(socketMock.Object);

			// Act
			string actualMsg = "";
			byte[] buffer = new byte[1024];
			clientHelper.DownloadData(serverIP, serverPort, fileName, savePath, ref buffer, ref actualMsg);

			// Assert
			Assert.IsTrue(buffer == null);
			Assert.IsTrue(actualMsg != "");
		}

		[TestMethod]
		public void TestDownloadData_Should_Return_Error_Message_When_File_Does_Not_Exist()
		{
			// Arrange
			Mock<ISocket> socketMock = new Mock<ISocket>();
			IPAddress serverIP = IPAddress.Parse("127.0.0.1");
			int serverPort = 8080;
			string fileName = "nonexistent.txt";
			string expectedMsg = $"Error：File {fileName} does not exist";
			byte[] serverResponse = new byte[1024];
			int bytesRead = 0;

			// 模擬成功連線伺服端
			socketMock.Setup(s => s.Connect(It.IsAny<IPEndPoint>()));
			// 模擬伺服端回應檔案不存在
			serverResponse = Encoding.UTF8.GetBytes(expectedMsg);
			bytesRead = serverResponse.Length;
			socketMock.Setup(s => s.Receive(It.IsAny<byte[]>()))
				.Returns(bytesRead)
				.Callback<byte[]>(response => serverResponse.CopyTo(response, 0));

			ClientHelper clientHelper = new ClientHelper(socketMock.Object);

			// Act
			string actualMsg = "";
			byte[] buffer = new byte[1024];
			clientHelper.DownloadData(serverIP, serverPort, fileName, Directory.GetCurrentDirectory(), ref buffer, ref actualMsg);

			// Assert
			Assert.AreEqual(expectedMsg, actualMsg);
		}

		[TestMethod]
		public void TestDownloadData_FileFound()
		{
			// Arrange
			Mock<ISocket> socketMock = new Mock<ISocket>();
			IPAddress serverIP = IPAddress.Parse("127.0.0.1");
			int serverPort = 8080;
			string fileName = "test.txt";
			string savePath = Environment.CurrentDirectory;
			string expectedMsg = "Successful：Download complete";
			byte[] serverResponse = Encoding.UTF8.GetBytes("File found");
			byte[] expectedBuffer = Encoding.UTF8.GetBytes("TEST");
			byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);

			MockSequence sequence = new MockSequence();
			// 模擬伺服端回應 File found
			socketMock.InSequence(sequence).Setup(m => m.Receive(It.IsAny<byte[]>()))
				.Callback<byte[]>(buff => { serverResponse.CopyTo(buff, 0); })
				.Returns(serverResponse.Length);
			// 模擬伺服端回應檔案
			socketMock.InSequence(sequence).Setup(m => m.Receive(It.IsAny<byte[]>()))
				.Callback<byte[]>(buff => { expectedBuffer.CopyTo(buff, 0); })
				.Returns(expectedBuffer.Length);

			byte[] buffer = null;
			string actualMsg = "";

			ClientHelper clientHelper = new ClientHelper(socketMock.Object);

			// Act
			clientHelper.DownloadData(serverIP, serverPort, fileName, savePath, ref buffer, ref actualMsg);

			// Assert
			Assert.AreEqual(expectedMsg, actualMsg);
			CollectionAssert.AreEqual(expectedBuffer, buffer);
		}
	}
}
