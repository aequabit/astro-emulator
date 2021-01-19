namespace Main
{
	public partial class Login : global::System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            BunifuAnimatorNS.Animation animation4 = new BunifuAnimatorNS.Animation();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.rememberMeCheckBox = new ns1.BunifuCheckbox();
            this.RememberMeLabel = new ns1.BunifuCustomLabel();
            this.AutoLoginLabel = new ns1.BunifuCustomLabel();
            this.autoLoginCheckBox = new ns1.BunifuCheckbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headerPicture = new ns1.BunifuImageButton();
            this.bunifuImageButton5 = new ns1.BunifuImageButton();
            this.ShowLogs = new ns1.BunifuImageButton();
            this.bunifuImageButton3 = new ns1.BunifuImageButton();
            this.failedLogin = new ns1.BunifuCustomLabel();
            this.loginForum = new ns1.BunifuCustomLabel();
            this.Username = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuSeparator1 = new ns1.BunifuSeparator();
            this.bunifuSeparator2 = new ns1.BunifuSeparator();
            this.Password = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Notification = new ns1.BunifuCustomLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginButton = new ns1.BunifuThinButton2();
            this.bunifuImageButton1 = new ns1.BunifuImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UsersOnline = new System.Windows.Forms.Label();
            this.headerIcon = new ns1.BunifuImageButton();
            this.bunifuImageButton2 = new ns1.BunifuImageButton();
            this.ShowLogsButton = new ns1.BunifuImageButton();
            this.bunifuTransition2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowLogsButton)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Silver;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(398, 40);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(162, 58);
            this.bunifuCustomLabel1.TabIndex = 10;
            this.bunifuCustomLabel1.Text = "Login";
            // 
            // rememberMeCheckBox
            // 
            this.rememberMeCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.rememberMeCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.rememberMeCheckBox.Checked = false;
            this.rememberMeCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.rememberMeCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.rememberMeCheckBox, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.rememberMeCheckBox, BunifuAnimatorNS.DecorationType.None);
            this.rememberMeCheckBox.ForeColor = System.Drawing.Color.White;
            this.rememberMeCheckBox.Location = new System.Drawing.Point(409, 312);
            this.rememberMeCheckBox.Name = "rememberMeCheckBox";
            this.rememberMeCheckBox.Size = new System.Drawing.Size(20, 20);
            this.rememberMeCheckBox.TabIndex = 2;
            // 
            // RememberMeLabel
            // 
            this.RememberMeLabel.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.RememberMeLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.RememberMeLabel, BunifuAnimatorNS.DecorationType.None);
            this.RememberMeLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RememberMeLabel.ForeColor = System.Drawing.Color.Silver;
            this.RememberMeLabel.Location = new System.Drawing.Point(432, 314);
            this.RememberMeLabel.Name = "RememberMeLabel";
            this.RememberMeLabel.Size = new System.Drawing.Size(90, 15);
            this.RememberMeLabel.TabIndex = 100;
            this.RememberMeLabel.Text = "Remember Me";
            this.RememberMeLabel.Click += new System.EventHandler(this.RememberMeLabel_Click);
            // 
            // AutoLoginLabel
            // 
            this.AutoLoginLabel.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.AutoLoginLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.AutoLoginLabel, BunifuAnimatorNS.DecorationType.None);
            this.AutoLoginLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoLoginLabel.ForeColor = System.Drawing.Color.Silver;
            this.AutoLoginLabel.Location = new System.Drawing.Point(432, 365);
            this.AutoLoginLabel.Name = "AutoLoginLabel";
            this.AutoLoginLabel.Size = new System.Drawing.Size(66, 15);
            this.AutoLoginLabel.TabIndex = 15;
            this.AutoLoginLabel.Text = "Auto Login";
            this.AutoLoginLabel.Click += new System.EventHandler(this.AutoLoginLabel_Click);
            // 
            // autoLoginCheckBox
            // 
            this.autoLoginCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.autoLoginCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.autoLoginCheckBox.Checked = false;
            this.autoLoginCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.autoLoginCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.autoLoginCheckBox, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.autoLoginCheckBox, BunifuAnimatorNS.DecorationType.None);
            this.autoLoginCheckBox.ForeColor = System.Drawing.Color.White;
            this.autoLoginCheckBox.Location = new System.Drawing.Point(409, 363);
            this.autoLoginCheckBox.Name = "autoLoginCheckBox";
            this.autoLoginCheckBox.Size = new System.Drawing.Size(20, 20);
            this.autoLoginCheckBox.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.headerPicture);
            this.panel1.Controls.Add(this.bunifuImageButton5);
            this.panel1.Controls.Add(this.ShowLogs);
            this.panel1.Controls.Add(this.bunifuImageButton3);
            this.bunifuTransition2.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 40);
            this.panel1.TabIndex = 16;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // headerPicture
            // 
            this.headerPicture.BackColor = System.Drawing.Color.Transparent;
            this.headerPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.headerPicture, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.headerPicture, BunifuAnimatorNS.DecorationType.None);
            this.headerPicture.Image = ((System.Drawing.Image)(resources.GetObject("headerPicture.Image")));
            this.headerPicture.ImageActive = null;
            this.headerPicture.Location = new System.Drawing.Point(15, 0);
            this.headerPicture.Margin = new System.Windows.Forms.Padding(2);
            this.headerPicture.Name = "headerPicture";
            this.headerPicture.Size = new System.Drawing.Size(210, 40);
            this.headerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.headerPicture.TabIndex = 30;
            this.headerPicture.TabStop = false;
            this.headerPicture.Zoom = 10;
            // 
            // bunifuImageButton5
            // 
            this.bunifuImageButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.bunifuImageButton5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuImageButton5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton5.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton5.Image")));
            this.bunifuImageButton5.ImageActive = null;
            this.bunifuImageButton5.Location = new System.Drawing.Point(715, 5);
            this.bunifuImageButton5.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuImageButton5.Name = "bunifuImageButton5";
            this.bunifuImageButton5.Size = new System.Drawing.Size(30, 30);
            this.bunifuImageButton5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton5.TabIndex = 25;
            this.bunifuImageButton5.TabStop = false;
            this.bunifuImageButton5.Zoom = 10;
            this.bunifuImageButton5.Click += new System.EventHandler(this.bunifuImageButton5_Click);
            // 
            // ShowLogs
            // 
            this.ShowLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowLogs.BackColor = System.Drawing.Color.Transparent;
            this.ShowLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.ShowLogs, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.ShowLogs, BunifuAnimatorNS.DecorationType.None);
            this.ShowLogs.Image = ((System.Drawing.Image)(resources.GetObject("ShowLogs.Image")));
            this.ShowLogs.ImageActive = null;
            this.ShowLogs.Location = new System.Drawing.Point(683, 5);
            this.ShowLogs.Margin = new System.Windows.Forms.Padding(2);
            this.ShowLogs.Name = "ShowLogs";
            this.ShowLogs.Size = new System.Drawing.Size(31, 30);
            this.ShowLogs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShowLogs.TabIndex = 17;
            this.ShowLogs.TabStop = false;
            this.ShowLogs.Zoom = 10;
            this.ShowLogs.Click += new System.EventHandler(this.ShowLogs_Click);
            // 
            // bunifuImageButton3
            // 
            this.bunifuImageButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.bunifuImageButton3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuImageButton3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton3.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton3.Image")));
            this.bunifuImageButton3.ImageActive = null;
            this.bunifuImageButton3.Location = new System.Drawing.Point(-195, 6);
            this.bunifuImageButton3.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuImageButton3.Name = "bunifuImageButton3";
            this.bunifuImageButton3.Size = new System.Drawing.Size(31, 30);
            this.bunifuImageButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton3.TabIndex = 6;
            this.bunifuImageButton3.TabStop = false;
            this.bunifuImageButton3.Zoom = 10;
            // 
            // failedLogin
            // 
            this.failedLogin.BackColor = System.Drawing.Color.Red;
            this.bunifuTransition1.SetDecoration(this.failedLogin, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.failedLogin, BunifuAnimatorNS.DecorationType.None);
            this.failedLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.failedLogin.ForeColor = System.Drawing.Color.White;
            this.failedLogin.Location = new System.Drawing.Point(374, 414);
            this.failedLogin.Name = "failedLogin";
            this.failedLogin.Size = new System.Drawing.Size(375, 34);
            this.failedLogin.TabIndex = 17;
            this.failedLogin.Text = "Login Failed";
            this.failedLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.failedLogin.Visible = false;
            // 
            // loginForum
            // 
            this.loginForum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.loginForum, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.loginForum, BunifuAnimatorNS.DecorationType.None);
            this.loginForum.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.loginForum.ForeColor = System.Drawing.Color.White;
            this.loginForum.Location = new System.Drawing.Point(575, 312);
            this.loginForum.Name = "loginForum";
            this.loginForum.Size = new System.Drawing.Size(139, 28);
            this.loginForum.TabIndex = 18;
            this.loginForum.Text = "Login with Forum";
            this.loginForum.Click += new System.EventHandler(this.loginForum_Click);
            this.loginForum.MouseEnter += new System.EventHandler(this.loginForum_MouseEnter);
            this.loginForum.MouseLeave += new System.EventHandler(this.loginForum_MouseLeave);
            // 
            // Username
            // 
            this.Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.Username.BorderColor = System.Drawing.Color.SeaGreen;
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuTransition1.SetDecoration(this.Username, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.Username, BunifuAnimatorNS.DecorationType.None);
            this.Username.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.Username.ForeColor = System.Drawing.Color.Silver;
            this.Username.Location = new System.Drawing.Point(412, 175);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(286, 16);
            this.Username.TabIndex = 0;
            this.Username.Text = "Username";
            this.Username.Enter += new System.EventHandler(this.Username_Enter);
            this.Username.Leave += new System.EventHandler(this.Username_Leave);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition2.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator1.ForeColor = System.Drawing.Color.Gray;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bunifuSeparator1.LineThickness = 4;
            this.bunifuSeparator1.Location = new System.Drawing.Point(407, 192);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(297, 13);
            this.bunifuSeparator1.TabIndex = 22;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition2.SetDecoration(this.bunifuSeparator2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuSeparator2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator2.ForeColor = System.Drawing.Color.Gray;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bunifuSeparator2.LineThickness = 4;
            this.bunifuSeparator2.Location = new System.Drawing.Point(407, 265);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(297, 13);
            this.bunifuSeparator2.TabIndex = 22;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.Password.BorderColor = System.Drawing.Color.SeaGreen;
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuTransition1.SetDecoration(this.Password, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.Password, BunifuAnimatorNS.DecorationType.None);
            this.Password.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.Password.ForeColor = System.Drawing.Color.Silver;
            this.Password.HideSelection = false;
            this.Password.Location = new System.Drawing.Point(412, 249);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(286, 16);
            this.Password.TabIndex = 1;
            this.Password.Text = "Password";
            this.Password.Enter += new System.EventHandler(this.Password_Enter);
            this.Password.Leave += new System.EventHandler(this.Password_Leave);
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Leaf;
            this.bunifuTransition1.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 1F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation3;
            this.bunifuTransition1.MaxAnimationTime = 1000;
            // 
            // tabPage1
            // 
            this.bunifuTransition2.SetDecoration(this.tabPage1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.tabPage1, BunifuAnimatorNS.DecorationType.None);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.bunifuTransition2.SetDecoration(this.tabPage2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.tabPage2, BunifuAnimatorNS.DecorationType.None);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Notification
            // 
            this.Notification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.bunifuTransition1.SetDecoration(this.Notification, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.Notification, BunifuAnimatorNS.DecorationType.None);
            this.Notification.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notification.ForeColor = System.Drawing.Color.White;
            this.Notification.Location = new System.Drawing.Point(374, 414);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(375, 34);
            this.Notification.TabIndex = 101;
            this.Notification.Text = "Notification Message";
            this.Notification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Notification.Visible = false;
            // 
            // pictureBox1
            // 
            this.bunifuTransition1.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Location = new System.Drawing.Point(709, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.ActiveBorderThickness = 1;
            this.loginButton.ActiveCornerRadius = 30;
            this.loginButton.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.loginButton.ActiveForecolor = System.Drawing.Color.White;
            this.loginButton.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.loginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loginButton.BackgroundImage")));
            this.loginButton.ButtonText = "Login";
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.loginButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.loginButton, BunifuAnimatorNS.DecorationType.None);
            this.loginButton.Font = new System.Drawing.Font("Corbel", 18F);
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.IdleBorderThickness = 1;
            this.loginButton.IdleCornerRadius = 30;
            this.loginButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.loginButton.IdleForecolor = System.Drawing.Color.White;
            this.loginButton.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.loginButton.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.loginButton.Location = new System.Drawing.Point(581, 349);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(112, 52);
            this.loginButton.TabIndex = 4;
            this.loginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(-38, 6);
            this.bunifuImageButton1.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(31, 30);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 7;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.UsersOnline);
            this.panel2.Controls.Add(this.headerIcon);
            this.panel2.Controls.Add(this.bunifuImageButton2);
            this.panel2.Controls.Add(this.ShowLogsButton);
            this.bunifuTransition2.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 410);
            this.panel2.TabIndex = 2;
            // 
            // UsersOnline
            // 
            this.UsersOnline.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.UsersOnline, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.UsersOnline, BunifuAnimatorNS.DecorationType.None);
            this.UsersOnline.ForeColor = System.Drawing.Color.Silver;
            this.UsersOnline.Location = new System.Drawing.Point(12, 246);
            this.UsersOnline.Name = "UsersOnline";
            this.UsersOnline.Size = new System.Drawing.Size(352, 16);
            this.UsersOnline.TabIndex = 11;
            this.UsersOnline.Text = "0 Online Users";
            this.UsersOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerIcon
            // 
            this.headerIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.headerIcon.BackColor = System.Drawing.Color.Transparent;
            this.headerIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.headerIcon, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.headerIcon, BunifuAnimatorNS.DecorationType.None);
            this.headerIcon.Image = ((System.Drawing.Image)(resources.GetObject("headerIcon.Image")));
            this.headerIcon.ImageActive = null;
            this.headerIcon.Location = new System.Drawing.Point(112, 112);
            this.headerIcon.Name = "headerIcon";
            this.headerIcon.Size = new System.Drawing.Size(150, 150);
            this.headerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.headerIcon.TabIndex = 10;
            this.headerIcon.TabStop = false;
            this.headerIcon.Zoom = 10;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.bunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.bunifuImageButton2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuImageButton2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(-358, 5);
            this.bunifuImageButton2.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(31, 30);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 8;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            // 
            // ShowLogsButton
            // 
            this.ShowLogsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowLogsButton.BackColor = System.Drawing.Color.Transparent;
            this.ShowLogsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.ShowLogsButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.ShowLogsButton, BunifuAnimatorNS.DecorationType.None);
            this.ShowLogsButton.Image = ((System.Drawing.Image)(resources.GetObject("ShowLogsButton.Image")));
            this.ShowLogsButton.ImageActive = null;
            this.ShowLogsButton.Location = new System.Drawing.Point(-570, 6);
            this.ShowLogsButton.Margin = new System.Windows.Forms.Padding(2);
            this.ShowLogsButton.Name = "ShowLogsButton";
            this.ShowLogsButton.Size = new System.Drawing.Size(10, 30);
            this.ShowLogsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShowLogsButton.TabIndex = 6;
            this.ShowLogsButton.TabStop = false;
            this.ShowLogsButton.Zoom = 10;
            // 
            // bunifuTransition2
            // 
            this.bunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate;
            this.bunifuTransition2.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(30);
            animation4.RotateCoeff = 0.5F;
            animation4.RotateLimit = 0.2F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 0F;
            this.bunifuTransition2.DefaultAnimation = animation4;
            this.bunifuTransition2.MaxAnimationTime = 1000;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.Notification);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.loginForum);
            this.Controls.Add(this.failedLogin);
            this.Controls.Add(this.AutoLoginLabel);
            this.Controls.Add(this.autoLoginCheckBox);
            this.Controls.Add(this.RememberMeLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.rememberMeCheckBox);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowLogsButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.Panel panel2;

		private global::ns1.BunifuImageButton ShowLogsButton;

		private global::ns1.BunifuImageButton bunifuImageButton1;

		private global::ns1.BunifuImageButton bunifuImageButton2;

		private global::ns1.BunifuImageButton headerIcon;

		private global::ns1.BunifuCustomLabel bunifuCustomLabel1;

		private global::ns1.BunifuCheckbox rememberMeCheckBox;

		private global::ns1.BunifuThinButton2 loginButton;

		private global::ns1.BunifuCustomLabel RememberMeLabel;

		private global::ns1.BunifuCustomLabel AutoLoginLabel;

		private global::ns1.BunifuCheckbox autoLoginCheckBox;

		private global::System.Windows.Forms.Panel panel1;

		private global::ns1.BunifuImageButton bunifuImageButton3;

		private global::ns1.BunifuImageButton ShowLogs;

		private global::ns1.BunifuCustomLabel failedLogin;

		private global::System.Windows.Forms.PictureBox pictureBox1;

		private global::ns1.BunifuCustomLabel loginForum;

		private global::WindowsFormsControlLibrary1.BunifuCustomTextbox Username;

		private global::ns1.BunifuSeparator bunifuSeparator1;

		private global::ns1.BunifuSeparator bunifuSeparator2;

		private global::WindowsFormsControlLibrary1.BunifuCustomTextbox Password;

		private global::BunifuAnimatorNS.BunifuTransition bunifuTransition1;

		private global::BunifuAnimatorNS.BunifuTransition bunifuTransition2;

		private global::ns1.BunifuImageButton bunifuImageButton5;

		private global::System.Windows.Forms.Label UsersOnline;

		private global::System.Windows.Forms.TabPage tabPage1;

		private global::System.Windows.Forms.TabPage tabPage2;

		private global::ns1.BunifuCustomLabel Notification;

		private global::ns1.BunifuImageButton headerPicture;
	}
}
