namespace IdleBreaker
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonMinimize = new System.Windows.Forms.Button();
			this.buttonExit = new System.Windows.Forms.Button();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.checkBoxIB = new System.Windows.Forms.CheckBox();
			this.checkBoxSS = new System.Windows.Forms.CheckBox();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Visible = true;
			this.notifyIcon.DoubleClick += new System.EventHandler(this.EventShow);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(104, 26);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
			this.toolStripMenuItem1.Text = "Show";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.EventShow);
			// 
			// buttonMinimize
			// 
			this.buttonMinimize.Location = new System.Drawing.Point(13, 13);
			this.buttonMinimize.Name = "buttonMinimize";
			this.buttonMinimize.Size = new System.Drawing.Size(75, 23);
			this.buttonMinimize.TabIndex = 0;
			this.buttonMinimize.Text = "Minimize";
			this.buttonMinimize.UseVisualStyleBackColor = true;
			this.buttonMinimize.Click += new System.EventHandler(this.EventMinimize);
			// 
			// buttonExit
			// 
			this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExit.Location = new System.Drawing.Point(197, 12);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 23);
			this.buttonExit.TabIndex = 1;
			this.buttonExit.Text = "Exit";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.EventExit);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 30000;
			this.timer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxLog.Location = new System.Drawing.Point(12, 42);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.richTextBoxLog.Size = new System.Drawing.Size(260, 275);
			this.richTextBoxLog.TabIndex = 2;
			this.richTextBoxLog.Text = "";
			// 
			// checkBoxIB
			// 
			this.checkBoxIB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxIB.AutoSize = true;
			this.checkBoxIB.Checked = true;
			this.checkBoxIB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxIB.Location = new System.Drawing.Point(12, 323);
			this.checkBoxIB.Name = "checkBoxIB";
			this.checkBoxIB.Size = new System.Drawing.Size(83, 17);
			this.checkBoxIB.TabIndex = 3;
			this.checkBoxIB.Text = "Idle Breaker";
			this.checkBoxIB.UseVisualStyleBackColor = true;
			// 
			// checkBoxSS
			// 
			this.checkBoxSS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxSS.AutoSize = true;
			this.checkBoxSS.Checked = true;
			this.checkBoxSS.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSS.Location = new System.Drawing.Point(101, 323);
			this.checkBoxSS.Name = "checkBoxSS";
			this.checkBoxSS.Size = new System.Drawing.Size(126, 17);
			this.checkBoxSS.TabIndex = 4;
			this.checkBoxSS.Text = "Screensaver Breaker";
			this.checkBoxSS.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 352);
			this.Controls.Add(this.checkBoxSS);
			this.Controls.Add(this.checkBoxIB);
			this.Controls.Add(this.richTextBoxLog);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.buttonMinimize);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(300, 390);
			this.MinimumSize = new System.Drawing.Size(300, 390);
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "IdleBreaker";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.Button buttonMinimize;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.CheckBox checkBoxIB;
		private System.Windows.Forms.CheckBox checkBoxSS;
	}
}

