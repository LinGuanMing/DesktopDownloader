namespace ServerApp
{
	partial class ServerForm
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
			this.txtClientIP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtClientPort = new System.Windows.Forms.TextBox();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Client IP";
			// 
			// txtClientIP
			// 
			this.txtClientIP.Location = new System.Drawing.Point(131, 12);
			this.txtClientIP.Name = "txtClientIP";
			this.txtClientIP.ReadOnly = true;
			this.txtClientIP.Size = new System.Drawing.Size(171, 34);
			this.txtClientIP.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 55);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(109, 25);
			this.label2.TabIndex = 0;
			this.label2.Text = "Client Port";
			// 
			// txtClientPort
			// 
			this.txtClientPort.Location = new System.Drawing.Point(131, 52);
			this.txtClientPort.Name = "txtClientPort";
			this.txtClientPort.ReadOnly = true;
			this.txtClientPort.Size = new System.Drawing.Size(74, 34);
			this.txtClientPort.TabIndex = 2;
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(131, 92);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.ReadOnly = true;
			this.txtFileName.Size = new System.Drawing.Size(171, 34);
			this.txtFileName.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 95);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 25);
			this.label3.TabIndex = 0;
			this.label3.Text = "FileName";
			// 
			// ServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(323, 142);
			this.Controls.Add(this.txtClientPort);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.txtClientIP);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "ServerForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ServerApp";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtClientIP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtClientPort;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Label label3;
	}
}

