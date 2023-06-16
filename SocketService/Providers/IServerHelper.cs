namespace SocketService.Providers
{
	public interface IServerHelper
	{
		void ListenForClients(int maxClient);
	}
}