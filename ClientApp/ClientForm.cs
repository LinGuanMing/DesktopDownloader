using SocketService;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClientApp
{
	public partial class ClientForm : Form
	{
		public ClientForm()
		{
			InitializeComponent();
			txtServerIP.Text = "127.0.0.1";
			txtServerPort.Text = "8080";
			txtSavePath.Text = Application.StartupPath;
			txtFileName.Text = "test.txt";
		}

		private void btnChange_Click(object sender, EventArgs e)
		{
			using (var folderDialog = new FolderBrowserDialog())
			{
				folderDialog.SelectedPath = txtSavePath.Text;
				if (folderDialog.ShowDialog() == DialogResult.OK)
				{
					txtSavePath.Text = folderDialog.SelectedPath;
				}
			}
		}

		private void btnDownload_Click(object sender, EventArgs e)
		{
			if (IPAddress.TryParse(txtServerIP.Text, out IPAddress serverIP) == false)
			{
				MessageBox.Show("請輸入正確伺服端連線IP位址", "提示");
				return;
			}

			if (int.TryParse(txtServerPort.Text, out int serverPort) == false ||
				(int.Parse(txtServerPort.Text) >= 0 && int.Parse(txtServerPort.Text) <= 65535) == false)
			{
				MessageBox.Show("請輸入正確伺服端連線Port", "提示");
				return;
			}

			if (string.IsNullOrWhiteSpace(txtFileName.Text))
			{
				MessageBox.Show("檔案名稱不可空白", "提示");
				return;
			}

			if (string.IsNullOrWhiteSpace(txtSavePath.Text))
			{
				MessageBox.Show("檔案儲存路徑不可空白", "提示");
				return;
			}

			string strMsg = "";
			using (ClientHelper clientHelper = new ClientHelper(new SocketHelper(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))))
			{
				byte[] buffer = null;
				string filepath = Path.Combine(txtSavePath.Text, txtFileName.Text);
				clientHelper.DownloadData(serverIP, serverPort, txtFileName.Text, txtSavePath.Text, ref buffer, ref strMsg);
				if (buffer != null)
				{
					File.WriteAllBytes(filepath, buffer);
				}
				txtStatus.Text = strMsg;
			}
		}

		private void txtServerIP_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != '.' && (int)e.KeyChar != 8 &&
				(int)e.KeyChar != 1 && (int)e.KeyChar != 3 && (int)e.KeyChar != 22)
			{
				e.Handled = true;
			}
		}

		private void txtServerPort_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 &&
				(int)e.KeyChar != 1 && (int)e.KeyChar != 3 && (int)e.KeyChar != 22)
			{
				e.Handled = true;
			}
		}
	}
}
