namespace ClientApp
{
	partial class ClientForm
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtServerIP = new System.Windows.Forms.TextBox();
			this.txtServerPort = new System.Windows.Forms.TextBox();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSavePath = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnDownload = new System.Windows.Forms.Button();
			this.btnChange = new System.Windows.Forms.Button();
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server IP";
			// 
			// txtServerIP
			// 
			this.txtServerIP.Location = new System.Drawing.Point(135, 12);
			this.txtServerIP.Name = "txtServerIP";
			this.txtServerIP.Size = new System.Drawing.Size(171, 34);
			this.txtServerIP.TabIndex = 1;
			this.txtServerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServerIP_KeyPress);
			// 
			// txtServerPort
			// 
			this.txtServerPort.Location = new System.Drawing.Point(135, 52);
			this.txtServerPort.Name = "txtServerPort";
			this.txtServerPort.Size = new System.Drawing.Size(74, 34);
			this.txtServerPort.TabIndex = 4;
			this.txtServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServerPort_KeyPress);
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(135, 92);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(171, 34);
			this.txtFileName.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(21, 95);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 25);
			this.label3.TabIndex = 2;
			this.label3.Text = "File Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 55);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 25);
			this.label2.TabIndex = 3;
			this.label2.Text = "Server Port";
			// 
			// txtSavePath
			// 
			this.txtSavePath.Location = new System.Drawing.Point(135, 132);
			this.txtSavePath.Name = "txtSavePath";
			this.txtSavePath.ReadOnly = true;
			this.txtSavePath.Size = new System.Drawing.Size(446, 34);
			this.txtSavePath.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(25, 135);
			this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(102, 25);
			this.label4.TabIndex = 2;
			this.label4.Text = "Save Path";
			// 
			// btnDownload
			// 
			this.btnDownload.Location = new System.Drawing.Point(691, 172);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(131, 34);
			this.btnDownload.TabIndex = 6;
			this.btnDownload.Text = "Download";
			this.btnDownload.UseVisualStyleBackColor = true;
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			// 
			// btnChange
			// 
			this.btnChange.Location = new System.Drawing.Point(585, 132);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(100, 34);
			this.btnChange.TabIndex = 7;
			this.btnChange.Text = "Change";
			this.btnChange.UseVisualStyleBackColor = true;
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			// 
			// txtStatus
			// 
			this.txtStatus.Location = new System.Drawing.Point(135, 172);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.ReadOnly = true;
			this.txtStatus.Size = new System.Drawing.Size(550, 34);
			this.txtStatus.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(58, 175);
			this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 25);
			this.label5.TabIndex = 2;
			this.label5.Text = "Status";
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(834, 211);
			this.Controls.Add(this.btnChange);
			this.Controls.Add(this.btnDownload);
			this.Controls.Add(this.txtStatus);
			this.Controls.Add(this.txtServerPort);
			this.Controls.Add(this.txtSavePath);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtServerIP);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "ClientForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ClientApp";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtServerIP;
		private System.Windows.Forms.TextBox txtServerPort;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSavePath;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnDownload;
		private System.Windows.Forms.Button btnChange;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.Label label5;
	}
}

