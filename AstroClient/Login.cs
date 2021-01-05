using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BunifuAnimatorNS;
using Main.AuthLib;
using Main.Functions;
using Microsoft.Win32;
using NetworkTypes;
using ns1;
using WindowsFormsControlLibrary1;

namespace Main
{
	public partial class Login : Form
	{
		public Login()
		{
			this.InitializeComponent();
			this.pictureBox1.Image = Image.FromStream(new MemoryStream(EmbeddedResource.EmbeddedResources.First((KeyValuePair<string, byte[]> resource) => resource.Key == "Logo (40x40).gif").Value));
			Logs.LogEntries.Add("Form Loaded");
			this.headerPicture.Location = new Point(15, 0);
			this.headerPicture.Image = Image.FromStream(new MemoryStream(EmbeddedResource.EmbeddedResources.First((KeyValuePair<string, byte[]> resource) => resource.Key == Brand.Company.ToString() + "_Header.png").Value));
			this.headerIcon.Image = Image.FromStream(new MemoryStream(EmbeddedResource.EmbeddedResources.First((KeyValuePair<string, byte[]> resource) => resource.Key == Brand.Company.ToString() + "_Icon.png").Value));
		}

		private void Login_Load(object sender, EventArgs e)
		{
			Login.Busy = true;
			Task task = Task.Run(delegate()
			{
				base.BeginInvoke(new MethodInvoker(delegate()
				{
					this.pictureBox1.Visible = true;
				}));
				string Response;
				bool flag = this.client.Version(out Response);
				if (flag)
				{
					bool flag2 = Brand.Version != Response;
					if (flag2)
					{
						MessageBox.Show("Updating! - 'Updater.exe'");
						for (;;)
						{
							foreach (Process process3 in new List<Process>(from process in Process.GetProcesses()
							where process.ProcessName.ToLower() == "updater" || process.ProcessName.ToLower() == "run"
							select process))
							{
								try
								{
									process3.CloseMainWindow();
									process3.Close();
									process3.Kill();
								}
								catch
								{
								}
							}
							Logs.LogEntries.Add("Starting Update Protocol");
							object obj;
							bool flag3 = this.client.Updater(out obj);
							if (flag3)
							{
								using (ZipArchive zipArchive = new ZipArchive((MemoryStream)obj, ZipArchiveMode.Read))
								{
									foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
									{
										bool flag4 = File.Exists(Environment.CurrentDirectory + "\\" + zipArchiveEntry.Name);
										if (flag4)
										{
											try
											{
												File.Delete(Environment.CurrentDirectory + "\\" + zipArchiveEntry.Name);
											}
											catch (Exception ex)
											{
												Logs.LogEntries.Add("Failed to Delete the File: " + zipArchiveEntry.FullName + "\nERROR:\n" + ex.ToString());
												continue;
											}
										}
										zipArchiveEntry.ExtractToFile(Environment.CurrentDirectory + "\\" + zipArchiveEntry.Name);
										Logs.LogEntries.Add("Extracting File: " + zipArchiveEntry.Name);
									}
								}
							}
							else
							{
								MessageBox.Show("Update Failure - " + (string)obj);
								Environment.Exit(0);
							}
							bool flag5 = File.Exists(Environment.CurrentDirectory + "\\Updater.exe");
							if (flag5)
							{
								break;
							}
							Logs.LogEntries.Add("AutoUpdater Executable Missing! -> Recovery: Trying to download AutoUpdater");
						}
						Logs.LogEntries.Add("Updater Executable Found!");
						Process process2 = new Process();
						ProcessStartInfo startInfo = new ProcessStartInfo
						{
							WorkingDirectory = Environment.CurrentDirectory + "\\",
							FileName = Environment.CurrentDirectory + "\\Updater.exe",
							UseShellExecute = true,
							Verb = "runas"
						};
						process2.StartInfo = startInfo;
						process2.Start();
						Environment.Exit(0);
					}
					string OnlineCount;
					bool flag6 = this.client.OnlineCount(out OnlineCount);
					if (flag6)
					{
						base.BeginInvoke(new MethodInvoker(delegate()
						{
							this.UsersOnline.Text = OnlineCount + " Users Online";
						}));
					}
					bool flag7 = Environment.GetCommandLineArgs().Length != 0;
					if (flag7)
					{
						Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
						foreach (string text in Environment.GetCommandLineArgs())
						{
							Logs.LogEntries.Add(text);
							bool flag8 = Login.Contains(text, "code") && Login.Contains(text, "state");
							if (flag8)
							{
								string text2 = Login.Get(text, "code");
								string text3 = Login.Get(text, "state");
								Logs.LogEntries.Add("Code: " + text2);
								Logs.LogEntries.Add("State: " + text3);
								string text4 = "";
								string item;
								bool flag9 = this.client.OAuth2_Setup(text2, text3, FingerPrint.Value(), ref text4, out item);
								if (flag9)
								{
									Logs.LogEntries.Add(text2);
									Logs.LogEntries.Add(text3);
									Logs.LogEntries.Add(FingerPrint.Value());
									Logs.LogEntries.Add(text4);
									StreamWriter streamWriter = new StreamWriter("autologin.data");
									streamWriter.WriteLine("True");
									streamWriter.WriteLine("True");
									streamWriter.WriteLine(Encryption.crypt(text4));
									streamWriter.WriteLine("False");
									streamWriter.WriteLine("");
									streamWriter.WriteLine("");
									streamWriter.Close();
									Logs.LogEntries.Add("Wrote AutoLogin Data");
								}
								else
								{
									Logs.LogEntries.Add(item);
								}
							}
						}
					}
					bool flag10 = File.Exists("autologin.data");
					if (flag10)
					{
						bool flag11 = File.ReadAllLines("autologin.data").Length < 6;
						if (flag11)
						{
							try
							{
								Logs.LogEntries.Add("autologin.data is outdated");
								File.Delete("autologin.data");
								Logs.LogEntries.Add("autologin.data deleted");
							}
							catch
							{
								MessageBox.Show("AutoLogin File cannot be removed");
							}
							base.BeginInvoke(new MethodInvoker(delegate()
							{
								this.pictureBox1.Visible = false;
							}));
							Login.Busy = false;
							return;
						}
						Logs.LogEntries.Add("Loading AutoLogin Data");
						StreamReader streamReader = new StreamReader("autologin.data");
						string useAutoLogin = streamReader.ReadLine();
						string value = streamReader.ReadLine();
						string text5 = streamReader.ReadLine();
						string value2 = streamReader.ReadLine();
						string username = streamReader.ReadLine();
						string password = streamReader.ReadLine();
						streamReader.Close();
						streamReader.Dispose();
						base.BeginInvoke(new MethodInvoker(delegate()
						{
							this.rememberMeCheckBox.Checked = !Convert.ToBoolean(useAutoLogin);
							this.autoLoginCheckBox.Checked = Convert.ToBoolean(useAutoLogin);
						}));
						Logs.LogEntries.Add("Decrypting AutoLogin Data");
						username = Encryption.decrypt(username);
						password = Encryption.decrypt(password);
						Logs.LogEntries.Add("Decrypted AutoLogin Data");
						bool flag12 = username == "" || password == "";
						if (flag12)
						{
							base.BeginInvoke(new MethodInvoker(delegate()
							{
								this.Password.PasswordChar = '\0';
								this.Username.Text = "Username";
								this.Password.Text = "Password";
							}));
							Logs.LogEntries.Add("Username and Password are not included in the AutoLogin File!");
						}
						else
						{
							base.BeginInvoke(new MethodInvoker(delegate()
							{
								this.Password.PasswordChar = '*';
								this.Username.Text = username;
								this.Password.Text = password;
							}));
						}
						bool flag13 = Convert.ToBoolean(useAutoLogin) && Convert.ToBoolean(value);
						if (flag13)
						{
							Logs.LogEntries.Add("OAuth2 Login Method!");
							bool flag14 = text5 != "";
							if (flag14)
							{
								Token token = null;
								object Output;
								bool flag15 = this.client.OAuth2_Auth(Encryption.decrypt(text5), ref token, out Output);
								if (flag15)
								{
									Login.token = token;
									Logs.LogEntries.Add("Login Found-" + Login.token.AuthToken);
									base.BeginInvoke(new MethodInvoker(delegate()
									{
										new MainForm(this.client, Login.token).Show();
										base.Hide();
									}));
								}
								else
								{
									bool flag16 = Output is HWID;
									if (flag16)
									{
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											new HWIDReset(this.client, (HWID)Output).Show();
										}));
									}
									else
									{
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											this.failedLogin.Text = (string)Output;
										}));
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											this.failedLogin.Visible = true;
										}));
									}
								}
							}
						}
						else
						{
							bool flag17 = Convert.ToBoolean(useAutoLogin) && !Convert.ToBoolean(value2);
							if (flag17)
							{
								Token token2 = null;
								object Output;
								bool flag18 = this.client.Login(username, password, FingerPrint.Value(), ref token2, out Output);
								if (flag18)
								{
									Login.token = token2;
									Logs.LogEntries.Add("Login Found-" + Login.token.AuthToken);
									base.BeginInvoke(new MethodInvoker(delegate()
									{
										new MainForm(this.client, Login.token).Show();
										base.Hide();
									}));
								}
								else
								{
									bool flag19 = Output is HWID;
									if (flag19)
									{
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											new HWIDReset(this.client, (HWID)Output).Show();
											this.Hide();
										}));
									}
									else
									{
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											this.failedLogin.Text = (string)Output;
										}));
										base.BeginInvoke(new MethodInvoker(delegate()
										{
											this.failedLogin.Visible = true;
										}));
									}
								}
							}
							else
							{
								base.BeginInvoke(new MethodInvoker(delegate()
								{
									this.rememberMeCheckBox.Checked = true;
									this.Username.Text = username;
									this.Password.Text = password;
								}));
							}
						}
					}
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.pictureBox1.Visible = false;
					}));
					Login.Busy = false;
				}
				else
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.failedLogin.Text = Response;
						this.failedLogin.Visible = true;
					}));
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.pictureBox1.Visible = false;
					}));
					Login.Busy = false;
				}
			});
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			bool busy = Login.Busy;
			if (!busy)
			{
				Login.Busy = true;
				new Thread(delegate()
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.failedLogin.Text = "";
						this.failedLogin.Visible = false;
					}));
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.pictureBox1.Visible = true;
					}));
					Token token = null;
					object Output = "";
					bool flag = this.client.Login(this.Username.Text, this.Password.Text, FingerPrint.Value(), ref token, out Output);
					if (flag)
					{
						bool flag2 = File.Exists("autologin.data");
						if (flag2)
						{
							try
							{
								Logs.LogEntries.Add("Deleting AutoLogin.data");
								File.Delete("autologin.data");
								Logs.LogEntries.Add("Deleted AutoLogin.data");
							}
							catch
							{
								MessageBox.Show("Auto Login File cannot be removed");
							}
						}
						bool @checked = this.autoLoginCheckBox.Checked;
						if (@checked)
						{
							StreamWriter streamWriter = new StreamWriter("autologin.data");
							streamWriter.WriteLine("True");
							streamWriter.WriteLine("False");
							streamWriter.WriteLine("");
							streamWriter.WriteLine("False");
							streamWriter.WriteLine(Encryption.crypt(this.Username.Text));
							streamWriter.WriteLine(Encryption.crypt(this.Password.Text));
							streamWriter.Close();
						}
						else
						{
							bool checked2 = this.rememberMeCheckBox.Checked;
							if (checked2)
							{
								StreamWriter streamWriter2 = new StreamWriter("autologin.data");
								streamWriter2.WriteLine("False");
								streamWriter2.WriteLine("False");
								streamWriter2.WriteLine("");
								streamWriter2.WriteLine("False");
								streamWriter2.WriteLine(Encryption.crypt(this.Username.Text));
								streamWriter2.WriteLine(Encryption.crypt(this.Password.Text));
								streamWriter2.Close();
							}
							else
							{
								bool flag3 = File.Exists("autologin.data");
								if (flag3)
								{
									try
									{
										Logs.LogEntries.Add("Deleting AutoLogin.data");
										File.Delete("autologin.data");
										Logs.LogEntries.Add("Deleted AutoLogin.data");
									}
									catch
									{
										MessageBox.Show("Auto Login File cannot be removed");
									}
								}
							}
						}
						base.BeginInvoke(new MethodInvoker(delegate()
						{
							new MainForm(this.client, token).Show();
							this.Hide();
						}));
					}
					else
					{
						bool flag4 = Output is HWID;
						if (flag4)
						{
							base.BeginInvoke(new MethodInvoker(delegate()
							{
								new HWIDReset(this.client, (HWID)Output).Show();
								this.Hide();
							}));
						}
						else
						{
							base.BeginInvoke(new MethodInvoker(delegate()
							{
								this.failedLogin.Text = (string)Output;
							}));
							base.BeginInvoke(new MethodInvoker(delegate()
							{
								this.failedLogin.Visible = true;
							}));
						}
					}
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.pictureBox1.Visible = false;
					}));
					Login.Busy = false;
				}).Start();
			}
		}

		private void loginForum_Click(object sender, EventArgs e)
		{
			bool busy = Login.Busy;
			if (!busy)
			{
				Login.Busy = true;
				new Thread(delegate()
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.failedLogin.Text = "";
						this.failedLogin.Visible = false;
					}));
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.bunifuTransition2.ShowSync(this.pictureBox1, false, null);
					}));
					RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software", true).OpenSubKey("Classes", true).CreateSubKey("alert");
					registryKey.SetValue("URL Protocol", "mcauth");
					registryKey.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Process.GetCurrentProcess().MainModule.FileName + "\" \"%1\"");
					Thread.Sleep(1000);
					Logs.LogEntries.Add("Attempting to AutoLogin with OAuth");
					string text = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("+", "").Replace("=", "").Replace("/", "");
					Process process = Process.Start(Brand.OAuthLink);
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.Notification.Text = "Check your Web Browser";
						this.Notification.Visible = true;
					}));
					Login.Busy = false;
				}).Start();
			}
		}

		private void loginForum_MouseEnter(object sender, EventArgs e)
		{
			this.loginForum.ForeColor = Color.FromArgb(0, 102, 204);
		}

		private void loginForum_MouseLeave(object sender, EventArgs e)
		{
			this.loginForum.ForeColor = Color.White;
		}

		private void Username_Enter(object sender, EventArgs e)
		{
			bool flag = this.Username.Text == "" || this.Username.Text == "Username";
			if (flag)
			{
				this.Username.Text = "";
			}
			this.bunifuSeparator1.Visible = false;
			this.bunifuSeparator1.LineColor = Color.FromArgb(0, 102, 204);
			this.bunifuTransition1.ShowSync(this.bunifuSeparator1, false, null);
		}

		private void Username_Leave(object sender, EventArgs e)
		{
			bool flag = this.Username.Text == "";
			if (flag)
			{
				this.Username.Text = "Username";
			}
			this.bunifuSeparator1.LineColor = Color.Gray;
		}

		private void Password_Enter(object sender, EventArgs e)
		{
			bool flag = this.Password.Text == "" || this.Password.Text == "Password";
			if (flag)
			{
				this.Password.PasswordChar = '*';
				this.Password.Text = "";
			}
			this.bunifuSeparator2.Visible = false;
			this.bunifuSeparator2.LineColor = Color.FromArgb(0, 102, 204);
			this.bunifuTransition1.ShowSync(this.bunifuSeparator2, false, null);
		}

		private void Password_Leave(object sender, EventArgs e)
		{
			bool flag = this.Password.Text == "";
			if (flag)
			{
				this.Password.PasswordChar = '\0';
				this.Password.Text = "Password";
			}
			this.bunifuSeparator2.LineColor = Color.Gray;
		}

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				this.MouseDownLocation = e.Location;
			}
		}

		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left = e.X + base.Left - this.MouseDownLocation.X;
				base.Top = e.Y + base.Top - this.MouseDownLocation.Y;
			}
		}

		private void RememberMeLabel_Click(object sender, EventArgs e)
		{
			this.rememberMeCheckBox.Checked = !this.rememberMeCheckBox.Checked;
		}

		private void AutoLoginLabel_Click(object sender, EventArgs e)
		{
			this.autoLoginCheckBox.Checked = !this.autoLoginCheckBox.Checked;
		}

		private void ShowLogs_Click(object sender, EventArgs e)
		{
			new Logs().Show();
		}

		private void bunifuImageButton5_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		public static bool Contains(string Data, string Variable)
		{
			bool flag = !Data.Contains(Variable + "=");
			return !flag;
		}

		public static string Get(string Data, string Variable)
		{
			bool flag = !Data.Contains(Variable + "=");
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				Data = Data.Remove(0, Data.IndexOf('?') + 1);
				string[] array = Data.Split(new char[]
				{
					'&'
				});
				foreach (string text in array)
				{
					bool flag2 = text.Contains(Variable + "=");
					if (flag2)
					{
						return text.Replace(Variable + "=", "");
					}
				}
				result = Data;
			}
			return result;
		}

		public static bool Busy = true;

		public Client client = new Client();

		public static Token token;

		private Point MouseDownLocation;
	}
}
