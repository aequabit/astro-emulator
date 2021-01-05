namespace Main
{
	public partial class HWIDReset : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::BunifuAnimatorNS.Animation animation = new global::BunifuAnimatorNS.Animation();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Main.HWIDReset));
			this.bunifuElipse1 = new global::ns1.BunifuElipse(this.components);
			this.topBar = new global::System.Windows.Forms.Panel();
			this.ShowLogs = new global::ns1.BunifuImageButton();
			this.Title = new global::ns1.BunifuCustomLabel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.yesButton = new global::ns1.BunifuThinButton2();
			this.bunifuThinButton21 = new global::ns1.BunifuThinButton2();
			this.label2 = new global::System.Windows.Forms.Label();
			this.loading = new global::System.Windows.Forms.PictureBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.HWIDResetsRemaining = new global::System.Windows.Forms.Label();
			this.requestFailed = new global::ns1.BunifuCustomLabel();
			this.bunifuTransition2 = new global::BunifuAnimatorNS.BunifuTransition(this.components);
			this.topBar.SuspendLayout();
			this.ShowLogs.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.loading).BeginInit();
			base.SuspendLayout();
			this.bunifuElipse1.ElipseRadius = 5;
			this.bunifuElipse1.TargetControl = this;
			this.topBar.BackColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.topBar.Controls.Add(this.ShowLogs);
			this.topBar.Controls.Add(this.Title);
			this.bunifuTransition2.SetDecoration(this.topBar, 0);
			this.topBar.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.topBar.Location = new global::System.Drawing.Point(0, 0);
			this.topBar.Margin = new global::System.Windows.Forms.Padding(2);
			this.topBar.Name = "topBar";
			this.topBar.Size = new global::System.Drawing.Size(400, 40);
			this.topBar.TabIndex = 3;
			this.topBar.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
			this.topBar.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
			this.ShowLogs.BackColor = global::System.Drawing.Color.Transparent;
			this.ShowLogs.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition2.SetDecoration(this.ShowLogs, 0);
			this.ShowLogs.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("ShowLogs.Image");
			this.ShowLogs.ImageActive = null;
			this.ShowLogs.Location = new global::System.Drawing.Point(358, 2);
			this.ShowLogs.Margin = new global::System.Windows.Forms.Padding(2);
			this.ShowLogs.Name = "ShowLogs";
			this.ShowLogs.Size = new global::System.Drawing.Size(31, 30);
			this.ShowLogs.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ShowLogs.TabIndex = 24;
			this.ShowLogs.TabStop = false;
			this.ShowLogs.Zoom = 10;
			this.ShowLogs.Click += new global::System.EventHandler(this.ShowLogs_Click);
			this.Title.BackColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.bunifuTransition2.SetDecoration(this.Title, 0);
			this.Title.Font = new global::System.Drawing.Font("Arial", 15.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Title.ForeColor = global::System.Drawing.Color.White;
			this.Title.Location = new global::System.Drawing.Point(2, 0);
			this.Title.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Title.Name = "Title";
			this.Title.Size = new global::System.Drawing.Size(247, 40);
			this.Title.TabIndex = 0;
			this.Title.Text = "MaverickCheats - HWID";
			this.Title.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.AutoSize = true;
			this.bunifuTransition2.SetDecoration(this.label1, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Silver;
			this.label1.Location = new global::System.Drawing.Point(63, 80);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(268, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Your last know Hardware Identification does not match!";
			this.yesButton.ActiveBorderThickness = 1;
			this.yesButton.ActiveCornerRadius = 30;
			this.yesButton.ActiveFillColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.yesButton.ActiveForecolor = global::System.Drawing.Color.White;
			this.yesButton.ActiveLineColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.yesButton.BackColor = global::System.Drawing.Color.FromArgb(60, 70, 73);
			this.yesButton.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("yesButton.BackgroundImage");
			this.yesButton.ButtonText = "Yes";
			this.yesButton.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition2.SetDecoration(this.yesButton, 0);
			this.yesButton.Font = new global::System.Drawing.Font("Corbel", 18f);
			this.yesButton.ForeColor = global::System.Drawing.Color.White;
			this.yesButton.IdleBorderThickness = 1;
			this.yesButton.IdleCornerRadius = 30;
			this.yesButton.IdleFillColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.yesButton.IdleForecolor = global::System.Drawing.Color.White;
			this.yesButton.IdleLineColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.yesButton.ImeMode = global::System.Windows.Forms.ImeMode.Off;
			this.yesButton.Location = new global::System.Drawing.Point(13, 134);
			this.yesButton.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
			this.yesButton.Name = "yesButton";
			this.yesButton.Size = new global::System.Drawing.Size(112, 52);
			this.yesButton.TabIndex = 5;
			this.yesButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.yesButton.Click += new global::System.EventHandler(this.yesButton_Click);
			this.bunifuThinButton21.ActiveBorderThickness = 1;
			this.bunifuThinButton21.ActiveCornerRadius = 30;
			this.bunifuThinButton21.ActiveFillColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.bunifuThinButton21.ActiveForecolor = global::System.Drawing.Color.White;
			this.bunifuThinButton21.ActiveLineColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.bunifuThinButton21.BackColor = global::System.Drawing.Color.FromArgb(60, 70, 73);
			this.bunifuThinButton21.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("bunifuThinButton21.BackgroundImage");
			this.bunifuThinButton21.ButtonText = "No";
			this.bunifuThinButton21.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition2.SetDecoration(this.bunifuThinButton21, 0);
			this.bunifuThinButton21.Font = new global::System.Drawing.Font("Corbel", 18f);
			this.bunifuThinButton21.ForeColor = global::System.Drawing.Color.White;
			this.bunifuThinButton21.IdleBorderThickness = 1;
			this.bunifuThinButton21.IdleCornerRadius = 30;
			this.bunifuThinButton21.IdleFillColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.bunifuThinButton21.IdleForecolor = global::System.Drawing.Color.White;
			this.bunifuThinButton21.IdleLineColor = global::System.Drawing.Color.FromArgb(0, 102, 204);
			this.bunifuThinButton21.ImeMode = global::System.Windows.Forms.ImeMode.Off;
			this.bunifuThinButton21.Location = new global::System.Drawing.Point(275, 134);
			this.bunifuThinButton21.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
			this.bunifuThinButton21.Name = "bunifuThinButton21";
			this.bunifuThinButton21.Size = new global::System.Drawing.Size(112, 52);
			this.bunifuThinButton21.TabIndex = 6;
			this.bunifuThinButton21.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.bunifuThinButton21.Click += new global::System.EventHandler(this.bunifuThinButton21_Click);
			this.label2.AutoSize = true;
			this.bunifuTransition2.SetDecoration(this.label2, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Silver;
			this.label2.Location = new global::System.Drawing.Point(138, 93);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(129, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Would you like to reset it?";
			this.loading.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.loading.BackColor = global::System.Drawing.Color.FromArgb(60, 70, 73);
			this.bunifuTransition2.SetDecoration(this.loading, 0);
			this.loading.Location = new global::System.Drawing.Point(360, 40);
			this.loading.Name = "loading";
			this.loading.Size = new global::System.Drawing.Size(40, 40);
			this.loading.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.loading.TabIndex = 8;
			this.loading.TabStop = false;
			this.loading.Visible = false;
			this.label3.AutoSize = true;
			this.bunifuTransition2.SetDecoration(this.label3, 0);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(138, 147);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(126, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "HWID Resets Remaining";
			this.HWIDResetsRemaining.AutoSize = true;
			this.bunifuTransition2.SetDecoration(this.HWIDResetsRemaining, 0);
			this.HWIDResetsRemaining.ForeColor = global::System.Drawing.Color.Silver;
			this.HWIDResetsRemaining.Location = new global::System.Drawing.Point(188, 161);
			this.HWIDResetsRemaining.Name = "HWIDResetsRemaining";
			this.HWIDResetsRemaining.Size = new global::System.Drawing.Size(27, 13);
			this.HWIDResetsRemaining.TabIndex = 10;
			this.HWIDResetsRemaining.Text = "N/A";
			this.requestFailed.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.requestFailed.BackColor = global::System.Drawing.Color.Red;
			this.bunifuTransition2.SetDecoration(this.requestFailed, 0);
			this.requestFailed.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.requestFailed.ForeColor = global::System.Drawing.Color.White;
			this.requestFailed.Location = new global::System.Drawing.Point(0, 40);
			this.requestFailed.Name = "requestFailed";
			this.requestFailed.Size = new global::System.Drawing.Size(400, 40);
			this.requestFailed.TabIndex = 21;
			this.requestFailed.Text = "Request Failed";
			this.requestFailed.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.requestFailed.Visible = false;
			this.bunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate;
			this.bunifuTransition2.Cursor = null;
			animation.AnimateOnlyDifferences = true;
			animation.BlindCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.BlindCoeff");
			animation.LeafCoeff = 0f;
			animation.MaxTime = 1f;
			animation.MinTime = 0f;
			animation.MosaicCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.MosaicCoeff");
			animation.MosaicShift = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.MosaicShift");
			animation.MosaicSize = 0;
			animation.Padding = new global::System.Windows.Forms.Padding(30);
			animation.RotateCoeff = 0.5f;
			animation.RotateLimit = 0.2f;
			animation.ScaleCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.ScaleCoeff");
			animation.SlideCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.SlideCoeff");
			animation.TimeCoeff = 0f;
			animation.TransparencyCoeff = 0f;
			this.bunifuTransition2.DefaultAnimation = animation;
			this.bunifuTransition2.Interval = 1;
			this.bunifuTransition2.MaxAnimationTime = 5000;
			this.bunifuTransition2.TimeStep = 0.01f;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(60, 70, 73);
			base.ClientSize = new global::System.Drawing.Size(400, 200);
			base.Controls.Add(this.loading);
			base.Controls.Add(this.requestFailed);
			base.Controls.Add(this.HWIDResetsRemaining);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.bunifuThinButton21);
			base.Controls.Add(this.yesButton);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.topBar);
			this.bunifuTransition2.SetDecoration(this, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "HWID";
			this.Text = "Logs";
			base.Load += new global::System.EventHandler(this.HWID_Load);
			this.topBar.ResumeLayout(false);
			this.ShowLogs.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.loading).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components = null;

		private global::ns1.BunifuElipse bunifuElipse1;

		private global::System.Windows.Forms.Panel topBar;

		private global::ns1.BunifuCustomLabel Title;

		private global::ns1.BunifuImageButton ShowLogs;

		private global::System.Windows.Forms.Label label1;

		private global::ns1.BunifuThinButton2 bunifuThinButton21;

		private global::ns1.BunifuThinButton2 yesButton;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.PictureBox loading;

		private global::System.Windows.Forms.Label HWIDResetsRemaining;

		private global::System.Windows.Forms.Label label3;

		private global::ns1.BunifuCustomLabel requestFailed;

		private global::BunifuAnimatorNS.BunifuTransition bunifuTransition2;
	}
}
