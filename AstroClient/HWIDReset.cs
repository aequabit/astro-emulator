using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BunifuAnimatorNS;
using Main.AuthLib;
using NetworkTypes;
using ns1;

namespace Main
{
	public partial class HWIDReset : Form
	{
		public HWIDReset(Client client, HWID HWIDInfo)
		{
			this.client = client;
			this.HWIDInfo = HWIDInfo;
			this.InitializeComponent();
			this.loading.Image = Image.FromStream(new MemoryStream(EmbeddedResource.EmbeddedResources.First((KeyValuePair<string, byte[]> resource) => resource.Key == "Logo (40x40).gif").Value));
		}

		private void HWID_Load(object sender, EventArgs e)
		{
			this.Busy = true;
			new Thread(delegate()
			{
				base.BeginInvoke(new MethodInvoker(delegate()
				{
					this.requestFailed.Text = "";
					this.requestFailed.Visible = false;
				}));
				base.BeginInvoke(new MethodInvoker(delegate()
				{
					this.bunifuTransition2.ShowSync(this.loading, false, null);
				}));
				base.BeginInvoke(new MethodInvoker(delegate()
				{
					this.HWIDResetsRemaining.Text = this.HWIDInfo.HWIDResets.ToString();
				}));
				base.BeginInvoke(new MethodInvoker(delegate()
				{
					this.bunifuTransition2.HideSync(this.loading, false, null);
				}));
				this.Busy = false;
			}).Start();
		}

		private void yesButton_Click(object sender, EventArgs e)
		{
			bool busy = this.Busy;
			if (!busy)
			{
				this.Busy = true;
				new Thread(delegate()
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.requestFailed.Text = "";
						this.requestFailed.Visible = false;
					}));
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.bunifuTransition2.ShowSync(this.loading, false, null);
					}));
					object HWIDResetStatus;
					bool flag = this.client.HWID_Reset(this.HWIDInfo, out HWIDResetStatus);
					if (flag)
					{
						bool flag2 = (bool)HWIDResetStatus;
						if (flag2)
						{
							base.BeginInvoke(new MethodInvoker(delegate()
							{
								new Login().Show();
								base.Hide();
							}));
						}
					}
					else
					{
						base.BeginInvoke(new MethodInvoker(delegate()
						{
							this.requestFailed.Text = (string)HWIDResetStatus;
							this.requestFailed.Visible = true;
						}));
					}
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.HWIDResetsRemaining.Text = this.HWIDInfo.HWIDResets.ToString();
					}));
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.bunifuTransition2.HideSync(this.loading, false, null);
					}));
					this.Busy = false;
				}).Start();
			}
		}

		private void ShowLogs_Click(object sender, EventArgs e)
		{
			base.Close();
			Environment.Exit(0);
		}

		private void topBar_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				this.MouseDownLocation = e.Location;
			}
		}

		private void topBar_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left = e.X + base.Left - this.MouseDownLocation.X;
				base.Top = e.Y + base.Top - this.MouseDownLocation.Y;
			}
		}

		private void bunifuThinButton21_Click(object sender, EventArgs e)
		{
			base.Close();
			Environment.Exit(0);
		}

		public bool Busy = false;

		public int UserID = 0;

		public string Username = "";

		public string Password = "";

		public Client client;

		public HWID HWIDInfo;

		private Point MouseDownLocation;
	}
}
