using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Main.Functions;
using NetworkTypes;

namespace Main.AuthLib
{
	public class Client
	{
		public Client()
		{
			Logs.LogEntries.Add("Logging Init");
			Logs.LogEntries.Add("Client Started");
			this.Connect();
			Logs.LogEntries.Add("Client Socket Program - Server Connected ...");
		}

		public double Ping(string ip, int port, out TcpClient socket)
		{
			socket = new TcpClient();
			try
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				bool flag = !socket.ConnectAsync(ip, port).Wait(1000);
				if (flag)
				{
					return 9999.0;
				}
				Logs.LogEntries.Add(string.Concat(new string[]
				{
					"Socket Pinged {",
					ip,
					":",
					port.ToString(),
					"} - ",
					stopwatch.Elapsed.TotalMilliseconds.ToString()
				}));
				return stopwatch.Elapsed.TotalMilliseconds;
			}
			catch (Exception ex)
			{
				Logs.LogEntries.Add("Socket Not Available : " + ex.ToString());
			}
			Logs.LogEntries.Add("Server Unavailable");
			return 9999.0;
		}

		public bool Connect()
		{
			for (int i = 0; i <= 5; i++)
			{
				try
				{
					TcpClient tcpClient;
                    double num = this.Ping("158.69.253.172", (int)Brand.Company, out tcpClient);
                    //double num = this.Ping("127.0.0.1", (int)Brand.Company, out tcpClient);
                    TcpClient tcpClient2;
                    double num2 = this.Ping("94.23.27.204", (int)Brand.Company, out tcpClient2);
                    //double num2 = this.Ping("127.0.0.1", (int)Brand.Company, out tcpClient2);
                    bool flag = num < num2;
					if (flag)
					{
						Logs.LogEntries.Add("Connecting to North American Server");
						try
						{
							tcpClient2.Close();
						}
						catch (Exception ex)
						{
							Logs.LogEntries.Add("Disconnecting from EU Server Server Error: " + ex.ToString());
						}
						this.clientSocket = tcpClient;
					}
					else
					{
						Logs.LogEntries.Add("Connecting to EU Server");
						try
						{
							tcpClient.Close();
						}
						catch (Exception ex2)
						{
							Logs.LogEntries.Add("Disconnecting from NA Server Server Error: " + ex2.ToString());
						}
						this.clientSocket = tcpClient2;
					}
					Logs.LogEntries.Add("Socket Connected");
					bool flag2 = this.IsConnected();
					if (flag2)
					{
						Logs.LogEntries.Add("Server Connected");
						this.clientSocket.SendBufferSize = 10000000;
						this.clientSocket.ReceiveBufferSize = 10000000;
						this.clientSocket.NoDelay = true;
						return true;
					}
					Logs.LogEntries.Add("Server not Connected");
					return false;
				}
				catch (Exception ex3)
				{
					Logs.LogEntries.Add("Error Connecting to Server Sync Socket");
				}
			}
			Logs.LogEntries.Add("Server Unavailable");
			return false;
		}

		public void Disconnect()
		{
			try
			{
				this.clientSocket.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private bool IsConnected()
		{
			bool flag = (this.clientSocket.Client.Poll(1000, SelectMode.SelectRead) && this.clientSocket.Client.Poll(1000, SelectMode.SelectWrite) && this.clientSocket.Client.Available == 0) || !this.clientSocket.Connected;
			return !flag;
		}

		public bool Version(out string Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Logs.LogEntries.Add("Thread is Busy");
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Version");
			Request graph = new Request("Version", null);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Recieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = "Unknown Error - " + response.Message + ", " + ((response.Object is string) ? ((string)response.Object) : "");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (string)response.Object;
				this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool OnlineCount(out string Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Logs.LogEntries.Add("Thread is Busy");
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - OnlineCount");
			Request graph = new Request("OnlineCount", null);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			stopwatch.Stop();
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = ((response.Object is string) ? ((string)response.Object) : "N/A");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (string)response.Object;
				this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool Updater(out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Logs.LogEntries.Add("Thread is Busy");
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Updater");
			Request graph = new Request("Updater", null);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			stopwatch.Stop();
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = "Unknown Error - " + response.Message + ", " + ((response.Object is string) ? ((string)response.Object) : "");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (MemoryStream)response.Object;
				this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool Update(out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Logs.LogEntries.Add("Thread is Busy");
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Update");
			Request graph = new Request("Update", null);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			stopwatch.Stop();
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = "Unknown Error - " + response.Message + ", " + ((response.Object is string) ? ((string)response.Object) : "");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (MemoryStream)response.Object;
				this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool Login(string Username, string Password, string HWID, ref Token Token, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Logs.LogEntries.Add("Thread is Busy");
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Login");
			Request graph = new Request("Login", null, new NetworkTypes.Login(Username, Password, HWID));
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			bool error = response.Error;
			if (error)
			{
				bool flag3 = response.Object is string;
				if (flag3)
				{
					Output = (string)response.Object;
					this.Busy = false;
					return false;
				}
				bool flag4 = response.Object is HWID;
				if (flag4)
				{
					Output = (HWID)response.Object;
					this.Busy = false;
					return false;
				}
			}
			Token = (Token)response.Object;
			Output = "Logged In";
			this.Busy = false;
			return true;
		}

		public bool OAuth2_Setup(string Code, string State, string HWID, ref string PermaToken, out string Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Logs.LogEntries.Add("Thread is Busy");
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - OAuth2_Setup");
			Request request = new Request("OAuth2_Setup", new OAuth2_Setup(Code, State, FingerPrint.Value()));
			Logs.LogEntries.Add("Processing Request Message - " + request.Command);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, request);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Collection<string> logEntries = Logs.LogEntries;
			string str = "Recieved: ";
			string message = response.Message;
			string str2 = " - ";
			object @object = response.Object;
			logEntries.Add(str + message + str2 + ((@object != null) ? @object.ToString() : null));
			bool error = response.Error;
			if (error)
			{
				bool flag3 = response.Object is string;
				if (flag3)
				{
					Output = (string)response.Object;
					this.Busy = false;
					return false;
				}
				bool flag4 = response.Object is HWID;
				if (flag4)
				{
					Output = ((HWID)response.Object).HWIDStatus + ": " + ((HWID)response.Object).HWIDResets.ToString();
					this.Busy = false;
					return false;
				}
				bool flag5 = response.Object is Error;
				if (flag5)
				{
					Output = ((Error)response.Object).error + ": " + ((Error)response.Object).error_description;
					this.Busy = false;
					return false;
				}
			}
			PermaToken = (string)response.Object;
			Output = "";
			this.Busy = false;
			return true;
		}

		public bool OAuth2_Auth(string PermaToken, ref Token Token, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - OAuth2_Auth");
			Request request = new Request("OAuth2_Auth", new OAuth2_Auth(PermaToken, FingerPrint.Value()));
			Logs.LogEntries.Add("Processing Request Message - " + request.Command);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, request);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Collection<string> logEntries = Logs.LogEntries;
			string str = "Recieved: ";
			string message = response.Message;
			string str2 = " - ";
			object @object = response.Object;
			logEntries.Add(str + message + str2 + ((@object != null) ? @object.ToString() : null));
			bool error = response.Error;
			if (error)
			{
				bool flag3 = response.Object is string;
				if (flag3)
				{
					Output = (string)response.Object;
					this.Busy = false;
					return false;
				}
				bool flag4 = response.Object is HWID;
				if (flag4)
				{
					Output = (HWID)response.Object;
					this.Busy = false;
					return false;
				}
				bool flag5 = response.Object is Error;
				if (flag5)
				{
					Output = ((Error)response.Object).error + ": " + ((Error)response.Object).error_description;
					this.Busy = false;
					return false;
				}
			}
			Token = (Token)response.Object;
			Output = "";
			this.Busy = false;
			return true;
		}

		public bool c(string Username, string Password, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - HWID");
			Request graph = new Request("HWID", null, new NetworkTypes.Login(Username, Password, ""));
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			bool error = response.Error;
			if (error)
			{
				bool flag3 = response.Object is string;
				if (flag3)
				{
					Output = (string)response.Object;
					this.Busy = false;
					return false;
				}
			}
			Output = (HWID)response.Object;
			this.Busy = false;
			return true;
		}

		public bool HWID_Reset(HWID HWID, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - HWID_Reset");
			Request graph = new Request("HWID_Reset", HWID);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			bool error = response.Error;
			if (error)
			{
				bool flag3 = response.Object is string;
				if (flag3)
				{
					Output = (string)response.Object;
					this.Busy = false;
					return false;
				}
			}
			Output = (bool)response.Object;
			this.Busy = false;
			return true;
		}

		public bool Groups(Token token, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Groups");
			Request graph = new Request("Groups", token, null);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			binaryFormatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)binaryFormatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			stopwatch.Stop();
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = ((response.Object is string) ? ((string)response.Object) : "");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (List<Group>)response.Object;
				this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool Products(Token token, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Products");
			Request graph = new Request("Products", token, null);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			stopwatch.Stop();
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = ((response.Object is string) ? ((string)response.Object) : "");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (List<Product>)response.Object;
				this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool Download(Token token, Product product, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Download");
			Request graph = new Request("Download", token, product);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			stopwatch.Stop();
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = ((response.Object is string) ? ((string)response.Object) : "");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (MemoryStream)response.Object;
                this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool Notifications(Token token, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Notifications");
			Request graph = new Request("Notifications", token, null);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			stopwatch.Stop();
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = ((response.Object is string) ? ((string)response.Object) : "");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (List<Notification>)response.Object;
				this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool SupportTickets(Token token, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - SupportTickets");
			Request graph = new Request("SupportTickets", token, null);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			stopwatch.Stop();
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = ((response.Object is string) ? ((string)response.Object) : "");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (List<SupportTicket>)response.Object;
				this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool Newsfeed(Token token, out object Output)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Output = "Server Unavailable";
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Newsfeed");
			Request graph = new Request("Newsfeed", token, null);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			binaryFormatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)binaryFormatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Reciieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Logs.LogEntries.Add("Recieved: " + response.Message);
			stopwatch.Stop();
			bool error = response.Error;
			bool result;
			if (error)
			{
				bool flag3 = response.Message == "RateLimited";
				if (flag3)
				{
					TimeSpan timeSpan = DateTime.SpecifyKind((DateTime)response.Object, DateTimeKind.Utc).ToLocalTime().Subtract(DateTime.Now);
					Output = string.Concat(new string[]
					{
						"Rate Limited for ",
						timeSpan.Minutes.ToString(),
						"m  ",
						timeSpan.Seconds.ToString(),
						"s"
					});
					this.Busy = false;
					result = false;
				}
				else
				{
					Output = ((response.Object is string) ? ((string)response.Object) : "");
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Output = (List<News>)response.Object;
				this.Busy = false;
				result = true;
			}
			return result;
		}

		public bool Authenticate(Token Token, int ProductID)
		{
			for (;;)
			{
				bool busy = this.Busy;
				if (!busy)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			this.Busy = true;
			bool flag = !this.IsConnected();
			if (flag)
			{
				bool flag2 = !this.Connect();
				if (flag2)
				{
					Logs.LogEntries.Add("Server Unavailable");
					this.Busy = false;
					return false;
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logs.LogEntries.Add("Starting Request - Authenticate");
			Request graph = new Request("Authenticate", Token, ProductID);
			IFormatter formatter = new BinaryFormatter();
			this.serverStream = this.clientSocket.GetStream();
			Logs.LogEntries.Add("Stream Instance Obtained - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			formatter.Serialize(this.serverStream, graph);
			Logs.LogEntries.Add("Request Sent and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			Response response = (Response)formatter.Deserialize(this.serverStream);
			Logs.LogEntries.Add("Response Recieved and Serialized - " + stopwatch.Elapsed.TotalMilliseconds.ToString());
			bool flag3 = !response.Error;
			bool result;
			if (flag3)
			{
				bool flag4 = (string)response.Object == "Authenticated";
				if (flag4)
				{
					this.Busy = false;
					result = true;
				}
				else
				{
					Collection<string> logEntries = Logs.LogEntries;
					string[] array = new string[5];
					array[0] = response.Message;
					array[1] = ", ";
					int num = 2;
					object @object = response.Object;
					array[num] = ((@object != null) ? @object.ToString() : null);
					array[3] = ",";
					array[4] = (response.Error ? "true" : "false");
					logEntries.Add(string.Concat(array));
					this.Busy = false;
					result = false;
				}
			}
			else
			{
				Collection<string> logEntries2 = Logs.LogEntries;
				string[] array2 = new string[5];
				array2[0] = response.Message;
				array2[1] = ", ";
				int num2 = 2;
				object object2 = response.Object;
				array2[num2] = ((object2 != null) ? object2.ToString() : null);
				array2[3] = ",";
				array2[4] = (response.Error ? "true" : "false");
				logEntries2.Add(string.Concat(array2));
				this.Busy = false;
				result = false;
			}
			return result;
		}

		private TcpClient clientSocket = null;

		private NetworkStream serverStream = null;

		private bool Busy = false;
	}
}
