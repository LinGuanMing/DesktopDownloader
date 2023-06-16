using SocketService.Providers;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketService
{
	public class ServerHelper : IServerHelper
	{
		/// <summary>
		/// // 儲存客戶端 IP、Port、檔案名稱
		/// </summary>
		public string clientIP, clientPort, fileName;

		/// <summary>
		/// 定義一個委派，用於觸發事件
		/// </summary>
		public delegate void ServerDelegate();

		/// <summary>
		/// 定義一個事件，當接收到請求時，就會觸發此事件
		/// </summary>
		public event ServerDelegate OnRequestReceived;

		/// <summary>
		/// 伺服器的Port
		/// </summary>
		private readonly int port;

		/// <summary>
		/// Socket 類別，用於接收和傳送資料
		/// </summary>
		private readonly ISocket socket;

		public ServerHelper(int port, ISocket socket)
		{
			this.port = port;
			this.socket = socket;
		}
		public ServerHelper(int port)
		{
			this.port = port;
			SocketHelper socket = new SocketHelper(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
			this.socket = socket;
		}

		/// <summary>
		/// 監聽客戶端請求
		/// </summary>
		public void ListenForClients(int maxClient)
		{
			socket.Bind(new IPEndPoint(IPAddress.Any, port)); // 將serverSocket綁定到本機任意IP的指定Port
			socket.Listen(maxClient); // 開始監聽，最大排隊數為10

			// 等待客戶端的請求
			if (socket is SocketHelper)
			{
				while (true)
				{
					var client = socket.Accept();
					var clientThread = new Thread(() => HandleClientRequest(client));
					clientThread.Start();
				}
			}
			else
			{
				for (int i = 0; i < maxClient; i++)
				{
					var client = socket.Accept();
					var clientThread = new Thread(() => HandleClientRequest(client));
					clientThread.Start();
				}
			}
		}

		/// <summary>
		/// 處理客戶端的請求
		/// </summary>
		/// <param name="clientSocket"></param>
		public void HandleClientRequest(ISocket clientSocket)
		{
			try
			{
				// 取得客戶端的IP和Port
				var endPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
				this.clientIP = endPoint.Address.ToString();
				this.clientPort = endPoint.Port.ToString();

				// 接收客戶端傳來的資料，並取得檔案名稱
				var buffer = new byte[1024];
				var bytesRead = clientSocket.Receive(buffer);
				if (bytesRead <= 0)
				{
					// 如果接收不到資料，則傳送回應給客戶端並結束函數
					clientSocket.Send(Encoding.UTF8.GetBytes("No data received"));
					return;
				}
				this.fileName = Encoding.UTF8.GetString(buffer, 0, bytesRead);

				// 觸發委派事件，通知所有註冊的事件處理函數
				OnRequestReceived?.Invoke();

				var filePath = Path.Combine(Environment.CurrentDirectory, this.fileName);
				// 如果檔案存在，則傳送回應給客戶端，並將檔案內容傳送過去
				if (File.Exists(filePath))
				{
					clientSocket.Send(Encoding.UTF8.GetBytes("File found"));
					if (clientSocket is SocketHelper)
					{
						var responseBytes = File.ReadAllBytes(filePath);
						clientSocket.Send(responseBytes);
					}
					else
					{
						clientSocket.Send(Encoding.UTF8.GetBytes("TEST"));
					}
				}
				else
				{
					// 如果檔案不存在，則傳送回應給客戶端
					clientSocket.Send(Encoding.UTF8.GetBytes("File not found"));
				}
			}
			catch (SocketException ex)
			{
				clientSocket.Send(Encoding.UTF8.GetBytes(ex.Message));
			}
			catch (Exception ex)
			{
				clientSocket.Send(Encoding.UTF8.GetBytes(ex.Message));
			}
			finally
			{
				clientSocket.Close();
			}
		}
	}
}
