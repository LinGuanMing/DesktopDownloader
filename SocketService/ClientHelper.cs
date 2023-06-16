using SocketService.Providers;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketService
{
	public class ClientHelper : IClientHelper, IDisposable
	{
		/// <summary>
		/// Socket 類別，用於接收和傳送資料
		/// </summary>
		private ISocket socket;

		public ClientHelper(ISocket socket)
		{
			this.socket = socket;
		}

		public void DownloadData(IPAddress serverIP, int serverPort, string fileName, string savePath, ref byte[] buffer, ref string strMsg)
		{
			try
			{
				socket.Connect(new IPEndPoint(serverIP, serverPort));

				byte[] request = Encoding.UTF8.GetBytes(fileName);
				socket.Send(request);

				byte[] response = new byte[1024];
				int bytesRead = socket.Receive(response);
				var status = Encoding.UTF8.GetString(response, 0, bytesRead);
				if (status == "File found")
				{
					GetBytesFromSocket(out buffer);
					strMsg = "Successful：Download complete";
				}
				else
				{
					if (socket is SocketHelper)
					{
						strMsg = "Error：" + status;
					}
					else
					{
						strMsg = status;
					}
				}
			}
			catch (SocketException ex)
			{
				buffer = null;
				strMsg = "Error：" + ex.Message;
			}
		}

		private void GetBytesFromSocket(out byte[] buffer)
		{
			using (var memoryStream = new MemoryStream())
			{
				byte[] buff = new byte[1024];
				int bytesRead = 0;
				while (true)
				{
					bytesRead = socket.Receive(buff);
					if (bytesRead == 0) break;
					memoryStream.Write(buff, 0, bytesRead);
				}
				buffer = memoryStream.ToArray();
			}
		}

		#region IDisposable Support
		private bool disposedValue = false; // 偵測多餘的呼叫

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: 處置受控狀態 (受控物件)。
					socket.Close();
				}

				// TODO: 釋放非受控資源 (非受控物件) 並覆寫下方的完成項。
				// TODO: 將大型欄位設為 null。

				disposedValue = true;
			}
		}

		// TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放非受控資源的程式碼時，才覆寫完成項。
		// ~ClientHelper() {
		//   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
		//   Dispose(false);
		// }

		// 加入這個程式碼的目的在正確實作可處置的模式。
		void IDisposable.Dispose()
		{
			// 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
			Dispose(true);
			// TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
