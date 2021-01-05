using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using BunifuAnimatorNS;
using CustomTheme;
using Main.AuthLib;
using NetworkTypes;
using ns1;
using Resources;

namespace Main
{
	public partial class MainForm : Form
	{
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);

		public MainForm(Client client, Token token)
		{
			this.client = client;
			this.token = token;
			this.InitializeComponent();
			loading.Image = Image.FromStream(new MemoryStream(EmbeddedResource.EmbeddedResources.First((KeyValuePair<string, byte[]> resource) => resource.Key == "Logo (40x40).gif").Value));
			this.headerPicture.Location = new Point(15, 0);
			this.headerPicture.Image = Image.FromStream(new MemoryStream(EmbeddedResource.EmbeddedResources.First((KeyValuePair<string, byte[]> resource) => resource.Key == Brand.Company.ToString() + "_Header.png").Value));
			bool flag = token.Member != null && token.Member.Avatar != null;
			if (flag)
			{
				this.memberAvatar.Image = token.Member.Avatar;
				this.memberUsername.Text = token.Member.Username;
			}
			this.bunifuTransition2.Show(this.memberAvatar, false, null);
			this.productsPanel.MouseWheel += this.ProductsPanel_MouseWheel;
			this.SupportTicketList.MouseWheel += this.SupportTicketList_MouseWheel;
			this.NotificationList.MouseWheel += this.NotificationList_MouseWheel;
			new Thread(delegate()
			{
				Client client2 = new Client();
				for (;;)
				{
					client2.Authenticate(token, 0);
					Thread.Sleep(30000);
				}
			}).Start();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			this.Busy = true;
			new Thread(delegate()
			{
				Token obj = this.token;
				Token token;
				lock (obj)
				{
					token = this.token.Copy();
				}
				base.BeginInvoke(new MethodInvoker(delegate()
				{
					this.requestFailed.Text = "";
					this.requestFailed.Visible = false;
				}));
				base.BeginInvoke(new MethodInvoker(delegate()
				{
					this.bunifuTransition3.ShowSync(this.loading, false, null);
				}));
				object GroupsObj;
				bool flag2 = this.client.Groups(token, out GroupsObj);
				if (flag2)
				{
					this.groups = (List<Group>)GroupsObj;
				}
				else
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.requestFailed.Text = "Groups Error: " + (string)GroupsObj;
						this.requestFailed.Visible = true;
					}));
				}
				object ProductObj;
				bool flag3 = this.client.Products(token, out ProductObj);
				if (flag3)
				{
					this.products = (List<Product>)ProductObj;
				}
				else
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.requestFailed.Text = "Products Error: " + (string)ProductObj;
						this.requestFailed.Visible = true;
					}));
				}
				token.Dispose();
				foreach (Group group in this.groups)
				{
					Logs.LogEntries.Add(string.Concat(new string[]
					{
						group.ID.ToString(),
						", ",
						group.Name,
						",",
						((long)group.Image.Length).ToString()
					}));
					BunifuFlatButton CheatListTab = new BunifuFlatButton();
					CheatListTab.Tag = new GroupControl(true, group, false);
					CheatListTab.Activecolor = Color.FromArgb(0, 102, 204);
					CheatListTab.BackColor = Color.FromArgb(30, 37, 47);
					CheatListTab.BackgroundImageLayout = ImageLayout.Stretch;
					CheatListTab.BorderRadius = 0;
					CheatListTab.Cursor = Cursors.Hand;
					this.bunifuTransition1.SetDecoration(CheatListTab, 0);
					CheatListTab.DisabledColor = Color.Gray;
					CheatListTab.Iconcolor = Color.Transparent;
					CheatListTab.Iconimage = Image.FromStream(new MemoryStream(group.Image));
					CheatListTab.Iconimage_right = Image.FromStream(new MemoryStream(EmbeddedResource.EmbeddedResources.First((KeyValuePair<string, byte[]> resource) => resource.Key == "DropDown.png").Value));
					CheatListTab.Iconimage_right_Selected = null;
					CheatListTab.Iconimage_Selected = null;
					CheatListTab.IconMarginLeft = 0;
					CheatListTab.IconMarginRight = 0;
					CheatListTab.IconRightVisible = true;
					CheatListTab.IconRightZoom = 65.0;
					CheatListTab.IconVisible = true;
					CheatListTab.IconZoom = 65.0;
					CheatListTab.IsTab = true;
					CheatListTab.Name = "button";
					CheatListTab.Normalcolor = Color.FromArgb(30, 37, 47);
					CheatListTab.OnHovercolor = Color.FromArgb(0, 102, 204);
					CheatListTab.OnHoverTextColor = Color.White;
					CheatListTab.Size = new Size(300, 49);
					CheatListTab.TabIndex = group.UID;
					CheatListTab.Text = "  " + group.Name;
					CheatListTab.TextAlign = ContentAlignment.MiddleLeft;
					CheatListTab.Textcolor = Color.Silver;
					CheatListTab.TextFont = new Font("Calibri", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
					CheatListTab.Click += this.CheatListTab_Click;
					CheatListTab.MouseDown += this.CheatListTab_MouseDown;
					CheatListTab.MouseEnter += this.CheatListTabs_Enter;
					CheatListTab.MouseLeave += this.CheatListTabs_Leave;
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.flowLayoutPanel1.Controls.Add(CheatListTab);
					}));
				}
				base.BeginInvoke(new MethodInvoker(delegate()
				{
					this.bunifuTransition3.HideSync(this.loading, false, null);
				}));
				Logs.LogEntries.Add("Loading Icon: Invisible");
				this.Busy = false;
			}).Start();
			new Thread(delegate()
			{
				Token obj = this.token;
				Token token;
				lock (obj)
				{
					token = this.token.Copy();
				}
				Client client = new Client();
				object NotificationsObj;
				bool flag2 = client.Notifications(token, out NotificationsObj);
				if (flag2)
				{
					this.notifications = (List<Notification>)NotificationsObj;
					bool flag3 = this.notifications.Count((Notification x) => x.readDate == default(DateTime)) > 0;
					if (flag3)
					{
						base.BeginInvoke(new MethodInvoker(delegate()
						{
							this.NotificationsNumber.Text = this.notifications.Count((Notification x) => x.readDate == default(DateTime)).ToString();
							this.NotificationsNumber.Visible = true;
						}));
					}
				}
				else
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.requestFailed.Text = "Notifications Error: " + (string)NotificationsObj;
						this.requestFailed.Visible = true;
					}));
				}
				client.Disconnect();
				token.Dispose();
			}).Start();
			new Thread(delegate()
			{
				Token obj = this.token;
				Token token;
				lock (obj)
				{
					token = this.token.Copy();
				}
				Client client = new Client();
				object SupportTicketsObj;
				bool flag2 = client.SupportTickets(token, out SupportTicketsObj);
				if (flag2)
				{
					this.supporttickets = (List<SupportTicket>)SupportTicketsObj;
					bool flag3 = this.supporttickets.Count > 0;
					if (flag3)
					{
						base.BeginInvoke(new MethodInvoker(delegate()
						{
							this.SupportTicketsNumber.Text = this.supporttickets.Count.ToString();
							this.SupportTicketsNumber.Visible = true;
						}));
					}
				}
				else
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.requestFailed.Text = "Support Tickets Error: " + (string)SupportTicketsObj;
						this.requestFailed.Visible = true;
					}));
				}
				client.Disconnect();
				token.Dispose();
			}).Start();
			new Thread(delegate()
			{
				Token obj = this.token;
				Token token;
				lock (obj)
				{
					token = this.token.Copy();
				}
				Client client = new Client();
				object NewsfeedObj;
				bool flag2 = client.Newsfeed(token, out NewsfeedObj);
				if (flag2)
				{
					this.newsfeed = (List<News>)NewsfeedObj;
					bool flag3 = this.newsfeed.Count > 0;
					if (flag3)
					{
						base.BeginInvoke(new MethodInvoker(delegate()
						{
							this.NewsfeedNumber.Text = this.newsfeed.Count.ToString();
							this.NewsfeedNumber.Visible = true;
							foreach (News news in this.newsfeed)
							{
								this.NewsfeedList.Items.Add(news.Content);
							}
						}));
					}
				}
				else
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.requestFailed.Text = "Newsfeed Error: " + (string)NewsfeedObj;
						this.requestFailed.Visible = true;
					}));
				}
				client.Disconnect();
				token.Dispose();
			}).Start();
		}

		private void ProductsPanel_MouseWheel(object sender, MouseEventArgs e)
		{
			Console.WriteLine("Height {0}, Width {1}, Top: {2}, Bottom: {3}", new object[]
			{
				this.flowLayoutPanel1.Size.Height,
				this.flowLayoutPanel1.Size.Width,
				this.flowLayoutPanel1.Top,
				this.flowLayoutPanel1.Bottom
			});
			bool flag = e.Delta > 0;
			if (flag)
			{
				bool flag2 = this.flowLayoutPanel1.Top < 0;
				if (flag2)
				{
					this.flowLayoutPanel1.Top += 25;
				}
				else
				{
					Console.WriteLine("No Scroll Up for you! -> Height {0}, Width {1}, Top: {2}, Bottom: {3}", new object[]
					{
						this.flowLayoutPanel1.Size.Height,
						this.flowLayoutPanel1.Size.Width,
						this.flowLayoutPanel1.Top,
						this.flowLayoutPanel1.Bottom
					});
				}
				this.flowLayoutPanel1.PerformLayout();
			}
			else
			{
				bool flag3 = this.flowLayoutPanel1.Bottom - 25 > 50;
				if (flag3)
				{
					this.flowLayoutPanel1.Top -= 25;
				}
				else
				{
					bool flag4 = Math.Abs(this.flowLayoutPanel1.Bottom - 50) > 0;
					if (flag4)
					{
						this.flowLayoutPanel1.Top -= Math.Abs(this.flowLayoutPanel1.Bottom - 50);
					}
					else
					{
						Console.WriteLine("No Scroll Down for you! -> Height {0}, Width {1}, Top: {2}, Bottom: {3}", new object[]
						{
							this.flowLayoutPanel1.Size.Height,
							this.flowLayoutPanel1.Size.Width,
							this.flowLayoutPanel1.Top,
							this.flowLayoutPanel1.Bottom
						});
					}
				}
				this.flowLayoutPanel1.PerformLayout();
			}
		}

		private void launchButton_Click(object sender, EventArgs e)
		{
			bool busy = this.Busy;
			if (!busy)
			{
				new Thread(delegate()
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.requestFailed.Text = "";
						this.requestFailed.Visible = false;
					}));
					this.Busy = true;
					bool flag = !this.flowLayoutPanel1.Controls.Cast<BunifuFlatButton>().ToList<BunifuFlatButton>().Any((BunifuFlatButton control) => control.selected);
					if (!flag)
					{
						bool flag2 = !(this.flowLayoutPanel1.Controls.Cast<BunifuFlatButton>().ToList<BunifuFlatButton>().Find((BunifuFlatButton control) => control.selected).Tag is Product);
						if (flag2)
						{
							base.BeginInvoke(new MethodInvoker(delegate()
							{
								this.requestFailed.Text = "The Selected Tab is not a Cheat, Open the Group and select a Product!";
								this.requestFailed.Visible = true;
							}));
						}
						else
						{
							Product product = (Product)this.flowLayoutPanel1.Controls.Cast<BunifuFlatButton>().ToList<BunifuFlatButton>().Find((BunifuFlatButton control) => control.selected).Tag;
							Logs.LogEntries.Add("Product ID: " + product.ID.ToString() + ", " + product.Name);
							bool flag3 = product.ID <= 0 || product.UID <= 0 || product.Name == null || product.File == null || product.ProcessName == null;
							if (!flag3)
							{
								bool flag4 = product.Status == 0;
								if (flag4)
								{
									base.BeginInvoke(new MethodInvoker(delegate()
									{
										this.requestFailed.Text = "We're sorry, this cheat is being updated by the Development Team.";
										this.requestFailed.Visible = true;
									}));
								}
								else
								{
									base.BeginInvoke(new MethodInvoker(delegate()
									{
										this.bunifuTransition3.ShowSync(this.loading, false, null);
									}));
									string text = product.BattlEye ? (Path.GetTempPath() + Path.GetRandomFileName() + "\\") : (Environment.CurrentDirectory + "\\" + product.Name + "\\");
									object Output;
									bool flag5 = this.client.Download(this.token, product, out Output);
									if (!flag5)
									{
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											this.requestFailed.Text = "Download Error: " + (string)Output;
											this.requestFailed.Visible = true;
										}));
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											this.bunifuTransition3.HideSync(this.loading, false, null);
										}));
										this.Busy = false;
										return;
									}
									bool flag6 = !Directory.Exists(text);
									if (flag6)
									{
										Directory.CreateDirectory(text);
									}
									else
									{
										try
										{
											foreach (string path in Directory.GetFiles(text))
											{
												try
												{
													Process.GetProcessesByName(Path.GetFileNameWithoutExtension(path)).ToList<Process>().ForEach(delegate(Process process)
													{
														process.Kill();
													});
												}
												catch (Exception ex)
												{
													bool flag7 = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(path)).Count<Process>() > 0;
													if (flag7)
													{
														Logs.LogEntries.Add(ex.ToString());
													}
													else
													{
														Logs.LogEntries.Add("Handled Exception: " + Environment.NewLine + ex.ToString());
													}
												}
												try
												{
													File.Delete(path);
												}
												catch (Exception ex2)
												{
													Logs.LogEntries.Add(Environment.NewLine + ex2.ToString());
												}
											}
										}
										catch (Exception ex3)
										{
											Logs.LogEntries.Add("Error: Directory unable to be deleted\n" + ex3.ToString());
										}
									}
									Thread.Sleep(100);
									File.SetAttributes(text, FileAttributes.Hidden | FileAttributes.System);
									string randomFileName = Path.GetRandomFileName();
									string Run_FileName = Path.GetRandomFileName();
									using (ZipArchive zipArchive = new ZipArchive((MemoryStream)Output, ZipArchiveMode.Read))
									{
										foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
										{
											bool flag8 = !File.Exists(text + zipArchiveEntry.FullName);
											if (flag8)
											{
												bool flag9 = zipArchiveEntry.Name.ToLower().Contains("start");
												if (flag9)
												{
													using (FileStream fileStream = new FileStream(text + zipArchiveEntry.Name.Replace("start", randomFileName), FileMode.Create, FileAccess.Write))
													{
														using (Stream stream = zipArchiveEntry.Open())
														{
															stream.CopyTo(fileStream);
														}
													}
													File.SetAttributes(text + randomFileName + ".exe", FileAttributes.Hidden | FileAttributes.System);
												}
												else
												{
													bool flag10 = zipArchiveEntry.Name.ToLower().Contains("run");
													if (flag10)
													{
														using (FileStream fileStream2 = new FileStream(text + zipArchiveEntry.Name.Replace("run", Run_FileName), FileMode.Create, FileAccess.Write))
														{
															using (Stream stream2 = zipArchiveEntry.Open())
															{
																stream2.CopyTo(fileStream2);
															}
														}
														File.SetAttributes(text + Run_FileName + ".exe", FileAttributes.Hidden | FileAttributes.System);
													}
													else
													{
														zipArchiveEntry.ExtractToFile(text + zipArchiveEntry.Name);
														File.SetAttributes(text + zipArchiveEntry.Name, FileAttributes.Hidden | FileAttributes.System);
													}
												}
											}
										}
									}
									bool battlEye = product.BattlEye;
									if (battlEye)
									{
										bool flag11 = !File.Exists(text + randomFileName + ".exe");
										if (flag11)
										{
											MessageBox.Show("Start Error: {MissingStartFile}");
											goto IL_8FF;
										}
										Logs.LogEntries.Add("Starting Cheat");
										Process process3 = new Process();
										ProcessStartInfo startInfo = new ProcessStartInfo
										{
											WorkingDirectory = text,
											FileName = text + randomFileName + ".exe",
											Arguments = string.Concat(new string[]
											{
												this.token.AuthToken,
												" ",
												product.UID.ToString(),
												" ",
												(product.BattlEye ? 1 : 0).ToString(),
												" ",
												Environment.CurrentDirectory,
												"\\",
												Process.GetCurrentProcess().ProcessName,
												".exe"
											}),
											RedirectStandardOutput = false,
											UseShellExecute = false,
											Verb = "runas"
										};
										process3.StartInfo = startInfo;
										process3.Start();
										process3.WaitForExit();
										bool flag12 = process3.ExitCode > 0;
										if (flag12)
										{
											MessageBox.Show("Launch Failed: " + process3.ExitCode.ToString());
											goto IL_8FF;
										}
										int num = 0;
										bool flag13;
										do
										{
											try
											{
												File.Delete(text + randomFileName + ".exe");
												break;
											}
											catch (Exception ex4)
											{
												Logs.LogEntries.Add(Environment.NewLine + ex4.ToString());
											}
											Thread.Sleep(1000);
											flag13 = (num++ > 5);
										}
										while (!flag13);
									}
									bool flag14 = !File.Exists(text + Run_FileName + ".exe");
									if (flag14)
									{
										MessageBox.Show("Injection Error: {MissingInjector}");
									}
									else
									{
										Logs.LogEntries.Add("Starting Cheat");
										Process process2 = new Process();
										ProcessStartInfo startInfo2 = new ProcessStartInfo
										{
											WorkingDirectory = text,
											FileName = text + Run_FileName + ".exe",
											Arguments = string.Concat(new string[]
											{
												this.token.AuthToken,
												" ",
												product.UID.ToString(),
												" ",
												(product.BattlEye ? 1 : 0).ToString(),
												" ",
												Environment.CurrentDirectory,
												"\\",
												Process.GetCurrentProcess().ProcessName,
												".exe"
											}),
											RedirectStandardOutput = false,
											UseShellExecute = false,
											Verb = "runas"
										};
										process2.StartInfo = startInfo2;
										process2.Start();
										Logs.LogEntries.Add("Started Cheat");
										Thread.Sleep(2500);
										new Thread(delegate()
										{
											bool @internal = product.Internal;
											if (@internal)
											{
												MessageBox.Show("Injector: " + ((Process.GetProcessesByName(Run_FileName).Length != 0) ? ("Pre-Loaded\n" + ((Process.GetProcessesByName(product.ProcessName).Length == 0) ? "You have 60 seconds to start your game!\n" : "") + "Press'Ok' to close the Launcher, this Auto Closes after 5s!") : "Failed to Launch\n( Make sure your AntiVirus is Disabled and that you start your game AFTER you Inject )"));
											}
											else
											{
												MessageBox.Show("External Execution: " + ((Process.GetProcessesByName(Run_FileName).Length != 0) ? "Successful\nPlease Launch your Game" : "Failed\n- Make sure your game is Fullscreen Windowed or Windowed\n- Make sure any Security or AntiVirus's you have are 'FULLY' disabled\n- If you're on Windows 7, set your Windows 7 Desktop Theme as an 'Aero' Theme\n\nNote: In 'UNSUAL' cases, you 'MAY' need to 'UNINSTALL' your AntiVirus as it is possible some AntiVirus's will not 'DISABLE' completely even if the AntiVirus is set as 'DISABLED'."));
											}
											Environment.Exit(0);
										}).Start();
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											this.bunifuTransition3.HideSync(this.loading, false, null);
										}));
										Thread.Sleep(5000);
									}
									IL_8FF:
									Environment.Exit(0);
								}
							}
						}
					}
					this.Busy = false;
				}).Start();
			}
		}

		private void ShowLogs_Click(object sender, EventArgs e)
		{
			new Logs().Show();
		}

		private void slidingPanel_Click(object sender, EventArgs e)
		{
			bool flag = this.sideBar.Width == 50;
			if (flag)
			{
				this.sideBar.Visible = true;
				this.sideBar.Width = 300;
				this.productsPanel.Height = 400;
				this.panel1.Width -= 250;
				this.bunifuTransition1.ShowSync(this.sideBar, false, null);
				this.bunifuTransition2.ShowSync(this.memberAvatar, false, null);
			}
			else
			{
				this.bunifuTransition2.Hide(this.memberAvatar, false, null);
				this.sideBar.Visible = false;
				this.sideBar.Width = 50;
				this.productsPanel.Height = 500;
				this.panel1.Width += 250;
				this.bunifuTransition1.ShowSync(this.sideBar, false, null);
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool flag = keyData == Keys.Down;
			if (flag)
			{
				bool flag2 = this.flowLayoutPanel1.Bottom > 50;
				if (flag2)
				{
					this.flowLayoutPanel1.Top -= 25;
				}
				this.flowLayoutPanel1.PerformLayout();
			}
			else
			{
				bool flag3 = keyData == Keys.Up;
				if (flag3)
				{
					bool flag4 = this.flowLayoutPanel1.Top < 0;
					if (flag4)
					{
						this.flowLayoutPanel1.Top += 25;
					}
					this.flowLayoutPanel1.PerformLayout();
				}
			}
			return true;
		}

		private void CheatListTab_Click(object sender, EventArgs e)
		{
			this.flowLayoutPanel1.Focus();
			BunifuFlatButton bunifuFlatButton = (BunifuFlatButton)sender;
			foreach (object obj in this.flowLayoutPanel1.Controls)
			{
				BunifuFlatButton bunifuFlatButton2 = (BunifuFlatButton)obj;
				bool flag = bunifuFlatButton2.selected && bunifuFlatButton != bunifuFlatButton2;
				if (flag)
				{
					bunifuFlatButton2.selected = false;
				}
			}
			bool flag2 = bunifuFlatButton.Tag is GroupControl;
			if (flag2)
			{
				GroupControl GroupControl = (GroupControl)bunifuFlatButton.Tag;
				bool isProductGroup = GroupControl.IsProductGroup;
				if (isProductGroup)
				{
					bool flag3 = !GroupControl.GroupExpanded;
					if (flag3)
					{
						bunifuFlatButton.Iconimage_right = Image.FromStream(new MemoryStream(EmbeddedResource.EmbeddedResources.First((KeyValuePair<string, byte[]> resource) => resource.Key == "DropUp.png").Value));
						int num = this.flowLayoutPanel1.Controls.IndexOf(bunifuFlatButton) + 1;
						IEnumerable<Product> source = this.products;
						Func<Product, bool> predicate = null;
						Func<Product, bool> tmp;
						if (predicate == null)
						{
							predicate = (tmp = ((Product product) => product.ProductGroup == GroupControl.Group.UID));
						}
						foreach (Product product2 in source.Where(predicate))
						{
							BunifuFlatButton CheatListTab = new BunifuFlatButton();
							CheatListTab.Tag = product2;
							CheatListTab.Activecolor = Color.FromArgb(0, 102, 204);
							CheatListTab.BackColor = Color.FromArgb(30, 37, 47);
							CheatListTab.BackgroundImageLayout = ImageLayout.Stretch;
							CheatListTab.BorderRadius = 0;
							CheatListTab.Cursor = Cursors.Hand;
							CheatListTab.DisabledColor = Color.Gray;
							CheatListTab.Iconcolor = Color.Transparent;
							CheatListTab.Iconimage = Image.FromStream(new MemoryStream(product2.Image));
							CheatListTab.Iconimage_right = null;
							CheatListTab.Iconimage_right_Selected = null;
							CheatListTab.Iconimage_Selected = null;
							CheatListTab.IconMarginLeft = 0;
							CheatListTab.IconMarginRight = 0;
							CheatListTab.IconRightVisible = true;
							CheatListTab.IconRightZoom = 65.0;
							CheatListTab.IconVisible = true;
							CheatListTab.IconZoom = 65.0;
							CheatListTab.IsTab = true;
							CheatListTab.Name = "button";
							CheatListTab.Normalcolor = Color.FromArgb(30, 37, 47);
							CheatListTab.OnHovercolor = Color.FromArgb(0, 102, 204);
							CheatListTab.OnHoverTextColor = Color.White;
							CheatListTab.Size = new Size(300, 49);
							CheatListTab.TabIndex = num++;
							CheatListTab.Text = "  " + product2.Name;
							CheatListTab.TextAlign = ContentAlignment.MiddleLeft;
							CheatListTab.Textcolor = Color.White;
							CheatListTab.TextFont = new Font("Calibri", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
							CheatListTab.Click += this.CheatListTab_Click;
							CheatListTab.MouseDown += this.CheatListTab_MouseDown;
							CheatListTab.MouseEnter += this.CheatListTabs_Enter;
							CheatListTab.MouseLeave += this.CheatListTabs_Leave;
							base.BeginInvoke(new MethodInvoker(delegate()
							{
								this.flowLayoutPanel1.Controls.Add(CheatListTab);
								this.flowLayoutPanel1.Controls.SetChildIndex(CheatListTab, CheatListTab.TabIndex);
								GroupControl.GroupChildren.Add(CheatListTab);
							}));
						}
						GroupControl.GroupExpanded = true;
						bunifuFlatButton.Tag = GroupControl;
					}
					else
					{
						bunifuFlatButton.Iconimage_right = Image.FromStream(new MemoryStream(EmbeddedResource.EmbeddedResources.First((KeyValuePair<string, byte[]> resource) => resource.Key == "DropDown.png").Value));
						foreach (Control value in GroupControl.GroupChildren)
						{
							this.flowLayoutPanel1.Controls.Remove(value);
						}
						GroupControl.GroupExpanded = false;
						bunifuFlatButton.Tag = GroupControl;
					}
				}
			}
			else
			{
				bool flag4 = bunifuFlatButton.Tag is Product;
				if (flag4)
				{
				}
			}
		}

		private void CheatListTab_MouseDown(object sender, EventArgs e)
		{
			BunifuFlatButton bunifuFlatButton = (BunifuFlatButton)sender;
			foreach (object obj in this.flowLayoutPanel1.Controls)
			{
				BunifuFlatButton bunifuFlatButton2 = (BunifuFlatButton)obj;
				bool flag = bunifuFlatButton2.selected && bunifuFlatButton != bunifuFlatButton2;
				if (flag)
				{
					bunifuFlatButton2.selected = false;
				}
			}
			bool flag2 = ((MouseEventArgs)e).Clicks < 2;
			if (!flag2)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					new Thread(delegate()
					{
						base.BeginInvoke(new MethodInvoker(delegate()
						{
							this.requestFailed.Text = "";
							this.requestFailed.Visible = false;
						}));
						this.Busy = true;
						bool flag3 = !this.flowLayoutPanel1.Controls.Cast<BunifuFlatButton>().ToList<BunifuFlatButton>().Any((BunifuFlatButton control) => control.selected);
						if (!flag3)
						{
							bool flag4 = !(this.flowLayoutPanel1.Controls.Cast<BunifuFlatButton>().ToList<BunifuFlatButton>().Find((BunifuFlatButton control) => control.selected).Tag is Product);
							if (flag4)
							{
								base.BeginInvoke(new MethodInvoker(delegate()
								{
									this.requestFailed.Text = "The Selected Tab is not a Cheat, Open the Group and select a Product!";
									this.requestFailed.Visible = true;
								}));
							}
							else
							{
								Product product = (Product)this.flowLayoutPanel1.Controls.Cast<BunifuFlatButton>().ToList<BunifuFlatButton>().Find((BunifuFlatButton control) => control.selected).Tag;
								Logs.LogEntries.Add("Product ID: " + product.ID.ToString() + ", " + product.Name);
								bool flag5 = product.ID <= 0 || product.UID <= 0 || product.Name == null || product.File == null || product.ProcessName == null;
								if (!flag5)
								{
									bool flag6 = product.Status == 0;
									if (flag6)
									{
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											this.requestFailed.Text = "We're sorry, this cheat is being updated by the Development Team.";
											this.requestFailed.Visible = true;
										}));
									}
									else
									{
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											this.bunifuTransition3.ShowSync(this.loading, false, null);
										}));
										string text = product.BattlEye ? (Path.GetTempPath() + Path.GetRandomFileName() + "\\") : (Environment.CurrentDirectory + "\\" + product.Name + "\\");
										object Output;
										bool flag7 = this.client.Download(this.token, product, out Output);
										if (!flag7)
										{
											base.BeginInvoke(new MethodInvoker(delegate()
											{
												this.requestFailed.Text = "Download Error: " + (string)Output;
												this.requestFailed.Visible = true;
											}));
											base.BeginInvoke(new MethodInvoker(delegate()
											{
												this.bunifuTransition3.HideSync(this.loading, false, null);
											}));
											this.Busy = false;
											return;
										}
										bool flag8 = !Directory.Exists(text);
										if (flag8)
										{
											Directory.CreateDirectory(text);
										}
										else
										{
											try
											{
												foreach (string path in Directory.GetFiles(text))
												{
													try
													{
														Process.GetProcessesByName(Path.GetFileNameWithoutExtension(path)).ToList<Process>().ForEach(delegate(Process process)
														{
															process.Kill();
														});
													}
													catch (Exception ex)
													{
														bool flag9 = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(path)).Count<Process>() > 0;
														if (flag9)
														{
															Logs.LogEntries.Add(ex.ToString());
														}
														else
														{
															Logs.LogEntries.Add("Handled Exception: " + Environment.NewLine + ex.ToString());
														}
													}
													try
													{
														File.Delete(path);
													}
													catch (Exception ex2)
													{
														Logs.LogEntries.Add(Environment.NewLine + ex2.ToString());
													}
												}
											}
											catch (Exception ex3)
											{
												Logs.LogEntries.Add("Error: Directory unable to be deleted\n" + ex3.ToString());
											}
										}
										Thread.Sleep(100);
										File.SetAttributes(text, FileAttributes.Hidden | FileAttributes.System);
										string randomFileName = Path.GetRandomFileName();
										string Run_FileName = Path.GetRandomFileName();
										using (ZipArchive zipArchive = new ZipArchive((MemoryStream)Output, ZipArchiveMode.Read))
										{
											foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
											{
												bool flag10 = !File.Exists(zipArchiveEntry.FullName);
												if (flag10)
												{
													bool flag11 = zipArchiveEntry.Name.ToLower().Contains("start");
													if (flag11)
													{
														using (FileStream fileStream = new FileStream(text + zipArchiveEntry.Name.Replace("start", randomFileName), FileMode.Create, FileAccess.Write))
														{
															using (Stream stream = zipArchiveEntry.Open())
															{
																stream.CopyTo(fileStream);
															}
														}
														File.SetAttributes(text + randomFileName + ".exe", FileAttributes.Hidden | FileAttributes.System);
													}
													else
													{
														bool flag12 = zipArchiveEntry.Name.ToLower().Contains("run");
														if (flag12)
														{
															using (FileStream fileStream2 = new FileStream(text + zipArchiveEntry.Name.Replace("run", Run_FileName), FileMode.Create, FileAccess.Write))
															{
																using (Stream stream2 = zipArchiveEntry.Open())
																{
																	stream2.CopyTo(fileStream2);
																}
															}
															File.SetAttributes(text + Run_FileName + ".exe", FileAttributes.Hidden | FileAttributes.System);
														}
														else
														{
															zipArchiveEntry.ExtractToFile(text + zipArchiveEntry.Name);
															File.SetAttributes(text + zipArchiveEntry.Name, FileAttributes.Hidden | FileAttributes.System);
														}
													}
												}
											}
										}
										bool battlEye = product.BattlEye;
										if (battlEye)
										{
											bool flag13 = !File.Exists(text + randomFileName + ".exe");
											if (flag13)
											{
												MessageBox.Show("Start Error: {MissingStartFile}");
												goto IL_8F9;
											}
											Logs.LogEntries.Add("Starting Cheat");
											Process process3 = new Process();
											ProcessStartInfo startInfo = new ProcessStartInfo
											{
												WorkingDirectory = text,
												FileName = text + randomFileName + ".exe",
												Arguments = string.Concat(new string[]
												{
													this.token.AuthToken,
													" ",
													product.UID.ToString(),
													" ",
													(product.BattlEye ? 1 : 0).ToString(),
													" ",
													Environment.CurrentDirectory,
													"\\",
													Process.GetCurrentProcess().ProcessName,
													".exe"
												}),
												RedirectStandardOutput = false,
												UseShellExecute = false,
												Verb = "runas"
											};
											process3.StartInfo = startInfo;
											process3.Start();
											process3.WaitForExit();
											bool flag14 = process3.ExitCode > 0;
											if (flag14)
											{
												MessageBox.Show("Launch Failed: " + process3.ExitCode.ToString());
												goto IL_8F9;
											}
											int num = 0;
											bool flag15;
											do
											{
												try
												{
													File.Delete(text + randomFileName + ".exe");
													break;
												}
												catch (Exception ex4)
												{
													Logs.LogEntries.Add(Environment.NewLine + ex4.ToString());
												}
												Thread.Sleep(1000);
												flag15 = (num++ > 5);
											}
											while (!flag15);
										}
										bool flag16 = !File.Exists(text + Run_FileName + ".exe");
										if (flag16)
										{
											MessageBox.Show("Injection Error: {MissingInjector}");
										}
										else
										{
											Logs.LogEntries.Add("Starting Cheat");
											Process process2 = new Process();
											ProcessStartInfo startInfo2 = new ProcessStartInfo
											{
												WorkingDirectory = text,
												FileName = text + Run_FileName + ".exe",
												Arguments = string.Concat(new string[]
												{
													this.token.AuthToken,
													" ",
													product.UID.ToString(),
													" ",
													(product.BattlEye ? 1 : 0).ToString(),
													" ",
													Environment.CurrentDirectory,
													"\\",
													Process.GetCurrentProcess().ProcessName,
													".exe"
												}),
												RedirectStandardOutput = false,
												UseShellExecute = false,
												Verb = "runas"
											};
											process2.StartInfo = startInfo2;
											process2.Start();
											Logs.LogEntries.Add("Started Cheat");
											Thread.Sleep(2500);
											new Thread(delegate()
											{
												bool @internal = product.Internal;
												if (@internal)
												{
													MessageBox.Show("Injector: " + ((Process.GetProcessesByName(Run_FileName).Length != 0) ? ("Pre-Loaded\n" + ((Process.GetProcessesByName(product.ProcessName).Length == 0) ? "You have 60 seconds to start your game!\n" : "") + "Press'Ok' to close the Launcher, this Auto Closes after 5s!") : "Failed to Launch\n( Make sure your AntiVirus is Disabled and that you start your game AFTER you Inject )"));
												}
												else
												{
													MessageBox.Show("External Execution: " + ((Process.GetProcessesByName(Run_FileName).Length != 0) ? "Successful\nPlease Launch your Game" : "Failed\n- Make sure your game is Fullscreen Windowed or Windowed\n- Make sure any Security or AntiVirus's you have are 'FULLY' disabled\n- If you're on Windows 7, set your Windows 7 Desktop Theme as an 'Aero' Theme\n\nNote: In 'UNSUAL' cases, you 'MAY' need to 'UNINSTALL' your AntiVirus as it is possible some AntiVirus's will not 'DISABLE' completely even if the AntiVirus is set as 'DISABLED'."));
												}
												Environment.Exit(0);
											}).Start();
											base.BeginInvoke(new MethodInvoker(delegate()
											{
												this.bunifuTransition3.HideSync(this.loading, false, null);
											}));
											Thread.Sleep(5000);
										}
										IL_8F9:
										Environment.Exit(0);
									}
								}
							}
						}
						this.Busy = false;
					}).Start();
				}
			}
		}

		private void CheatListTabs_Enter(object sender, EventArgs e)
		{
			((BunifuFlatButton)sender).IconZoom = ((BunifuFlatButton)sender).IconZoom + 10.0;
		}

		private void CheatListTabs_Leave(object sender, EventArgs e)
		{
			((BunifuFlatButton)sender).IconZoom = ((BunifuFlatButton)sender).IconZoom - 10.0;
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

		private void Title_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				this.MouseDownLocation = e.Location;
			}
		}

		private void Title_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left = e.X + base.Left - this.MouseDownLocation.X;
				base.Top = e.Y + base.Top - this.MouseDownLocation.Y;
			}
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}

		private void memberAvatar_Click(object sender, EventArgs e)
		{
			Process.Start(Brand.ProfileLink + this.token.Member.UserID.ToString() + "-" + this.token.Member.Username);
		}

		private void bunifuImageButton1_Click(object sender, EventArgs e)
		{
			Environment.Exit(1);
		}

		private void NotificationList_MouseWheel(object sender, MouseEventArgs e)
		{
			MainForm.SendMessage(this.NotificationList.Handle, 277U, (e.Delta <= 0) ? ((UIntPtr)1UL) : ((UIntPtr)0UL), (IntPtr)0);
		}

		private void SupportTicketList_MouseWheel(object sender, MouseEventArgs e)
		{
			MainForm.SendMessage(this.SupportTicketList.Handle, 277U, (e.Delta <= 0) ? ((UIntPtr)1UL) : ((UIntPtr)0UL), (IntPtr)0);
		}

		private void NewsfeedImage_Click(object sender, EventArgs e)
		{
			bool flag = this.newsfeed == null;
			if (!flag)
			{
				bool visible = this.dropdownPanel.Visible;
				if (visible)
				{
					bool visible2 = this.NewsfeedList.Visible;
					if (visible2)
					{
						this.dropdownPanel.Visible = false;
						this.NewsfeedList.Visible = false;
						this.NotificationList.Visible = false;
						this.SupportTicketList.Visible = false;
						return;
					}
					this.dropdownPanel.Visible = true;
					this.NewsfeedList.Visible = true;
					this.NotificationList.Visible = false;
					this.SupportTicketList.Visible = false;
				}
				else
				{
					this.dropdownPanel.Visible = true;
					this.NewsfeedList.Visible = true;
					this.NotificationList.Visible = false;
					this.SupportTicketList.Visible = false;
				}
				this.NewsfeedList.Items.Clear();
				foreach (News news in this.newsfeed)
				{
					this.NewsfeedList.Items.Add(news.Content);
				}
				this.label2.Text = "Newsfeed";
				this.dropdownPanel.Visible = true;
				this.NewsfeedList.Visible = true;
				this.dropdownPanel.Refresh();
			}
		}

		private void NotificationsImage_Click(object sender, EventArgs e)
		{
			bool flag = this.notifications == null;
			if (!flag)
			{
				bool visible = this.dropdownPanel.Visible;
				if (visible)
				{
					bool visible2 = this.NotificationList.Visible;
					if (visible2)
					{
						this.dropdownPanel.Visible = false;
						this.NotificationList.Visible = false;
						return;
					}
					this.NotificationList.Visible = true;
					this.NewsfeedList.Visible = false;
					this.SupportTicketList.Visible = false;
				}
				this.NotificationList.Items.Clear();
				foreach (Notification notification in this.notifications)
				{
					this.NotificationList.Items.Add(notification.notificationData.title);
				}
				this.label2.Text = "Notifications";
				this.dropdownPanel.Visible = true;
				this.NotificationList.Visible = true;
				this.dropdownPanel.Refresh();
			}
		}

		private void SupportTicketsImage_Click(object sender, EventArgs e)
		{
			bool flag = this.supporttickets == null;
			if (!flag)
			{
				bool visible = this.dropdownPanel.Visible;
				if (visible)
				{
					bool visible2 = this.SupportTicketList.Visible;
					if (visible2)
					{
						this.dropdownPanel.Visible = false;
						this.SupportTicketList.Visible = false;
						return;
					}
					this.SupportTicketList.Visible = true;
					this.NewsfeedList.Visible = false;
					this.NotificationList.Visible = false;
				}
				this.SupportTicketList.Items.Clear();
				foreach (SupportTicket supportTicket in this.supporttickets)
				{
					this.SupportTicketList.Items.Add(supportTicket.title);
				}
				this.label2.Text = "Support Tickets";
				this.dropdownPanel.Visible = true;
				this.SupportTicketList.Visible = true;
				this.dropdownPanel.Refresh();
			}
		}

		private void SupportTicketList_DrawItem(object sender, DrawItemEventArgs e)
		{
			bool flag = e == null || e.Index < 0 || e.Index > this.supporttickets.Count - 1;
			if (!flag)
			{
				bool flag2 = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
				if (flag2)
				{
					e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.FromArgb(0, 102, 204));
				}
				e.DrawBackground();
				e.Graphics.DrawRectangle(new Pen(Color.FromArgb(36, 46, 59), 0.01f), e.Bounds);
				e.Graphics.DrawString(this.SupportTicketList.Items[e.Index].ToString(), e.Font, Brushes.White, (float)(e.Bounds.Left + 60), (float)(e.Bounds.Top + e.Bounds.Height / 2 - 20), StringFormat.GenericDefault);
				e.Graphics.DrawString(this.supporttickets[e.Index].firstMessage.content_clean, new Font(e.Font.FontFamily, 10f, FontStyle.Regular), Brushes.White, (float)(e.Bounds.Left + 60), (float)(e.Bounds.Top + e.Bounds.Height / 2), StringFormat.GenericDefault);
				e.Graphics.DrawImage(this.supporttickets[e.Index].firstMessage.author.photo, e.Bounds.Left + 10, e.Bounds.Top + e.Bounds.Height / 2 - 20, 40, 40);
				e.DrawFocusRectangle();
			}
		}

		private void SupportTicketList_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = 50;
		}

		private void NotificationList_DrawItem(object sender, DrawItemEventArgs e)
		{
			bool flag = e == null || e.Index < 0 || e.Index > this.notifications.Count - 1;
			if (!flag)
			{
				bool flag2 = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
				if (flag2)
				{
					e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.FromArgb(0, 102, 204));
				}
				e.DrawBackground();
				e.Graphics.DrawRectangle(new Pen(Color.FromArgb(36, 46, 59), 0.01f), e.Bounds);
				RectangleF layoutRectangle = default(RectangleF);
				layoutRectangle.Location = new Point(e.Bounds.Left + 60, e.Bounds.Top + e.Bounds.Height / 2 - 20);
				layoutRectangle.Size = new Size(e.Bounds.Width - (e.Bounds.Left + 60), 50);
				e.Graphics.DrawString(this.NotificationList.Items[e.Index].ToString(), new Font(e.Font.FontFamily, 10f, FontStyle.Regular), Brushes.White, layoutRectangle, StringFormat.GenericDefault);
				e.Graphics.DrawImage(this.notifications[e.Index].notificationData.author.photo, e.Bounds.Left + 10, e.Bounds.Top + e.Bounds.Height / 2 - 20, 40, 40);
				e.DrawFocusRectangle();
			}
		}

		private void NotificationList_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = 50;
		}

		private void NewsfeedList_DrawItem(object sender, DrawItemEventArgs e)
		{
			bool flag = e == null || e.Index < 0 || e.Index > this.newsfeed.Count - 1;
			if (!flag)
			{
				bool flag2 = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
				if (flag2)
				{
					e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.FromArgb(0, 102, 204));
				}
				e.DrawBackground();
				e.Graphics.DrawRectangle(new Pen(Color.FromArgb(36, 46, 59), 0.01f), e.Bounds);
				string[] array = this.newsfeed[e.Index].Content.Split(new string[]
				{
					"\\n"
				}, StringSplitOptions.None);
				int num = 0;
				foreach (string s in array)
				{
					int height = e.Bounds.Top + e.Bounds.Height;
					RectangleF layoutRectangle = default(RectangleF);
					layoutRectangle.Location = new Point(e.Bounds.Left + 10, e.Bounds.Top + num * 15);
					layoutRectangle.Size = new Size(e.Bounds.Width - (e.Bounds.Left + 10), height);
					e.Graphics.DrawString(s, new Font(e.Font.FontFamily, 10f, FontStyle.Regular), Brushes.White, layoutRectangle, StringFormat.GenericDefault);
					num++;
				}
				e.DrawFocusRectangle();
			}
		}

		private void NewsfeedList_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = 50;
		}

		private void requestFailed_VisibleChanged(object sender, EventArgs e)
		{
			bool visible = this.requestFailed.Visible;
			if (visible)
			{
				this.launchButton.Location = new Point(this.launchButton.Location.X, 410);
			}
			else
			{
				this.launchButton.Location = new Point(this.launchButton.Location.X, 445);
			}
		}

		public bool Busy = false;

		public Client client;

		public Token token;

		public List<Group> groups;

		public List<Product> products;

		public List<Notification> notifications;

		public List<SupportTicket> supporttickets;

		public List<News> newsfeed;

		private Point MouseDownLocation;
	}
}
