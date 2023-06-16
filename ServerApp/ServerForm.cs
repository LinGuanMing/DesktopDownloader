using SocketService;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ServerApp
{
	public partial class ServerForm : Form
	{
		private readonly ServerHelper serverHelper;

		public ServerForm()
		{
			InitializeComponent();
			serverHelper = new ServerHelper(8080);
			serverHelper.OnRequestReceived += UpdateClientInfo;
			Thread listenerThread = new Thread(() => serverHelper.ListenForClients(10));
			listenerThread.Start();
		}

		private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Environment.Exit(Environment.ExitCode);
		}

		private void UpdateClientInfo()
		{
			txtClientIP.Invoke(new Action(() => txtClientIP.Text = serverHelper.clientIP));
			txtClientPort.Invoke(new Action(() => txtClientPort.Text = serverHelper.clientPort));
			txtFileName.Invoke(new Action(() => txtFileName.Text = serverHelper.fileName));
		}
	}
}
