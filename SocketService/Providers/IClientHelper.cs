using System.Net;

namespace SocketService.Providers
{
	public interface IClientHelper
	{
		void DownloadData(IPAddress serverIP, int serverPort, string fileName, string savePath, ref byte[] buffer, ref string msg);
	}
}