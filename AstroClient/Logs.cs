using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ns1;
using WindowsFormsControlLibrary1;

namespace Main
{
	public partial class Logs : Form
	{
		public Logs()
		{
			Logs.LogEntries.CollectionChanged += this.OnListChanged;
			this.InitializeComponent();
		}

		private void Logs_Load(object sender, EventArgs e)
		{
			Logs.LogEntries.ToList<string>().ForEach(delegate(string Log)
			{
				this.LogsTextBox.AppendText(Log + Environment.NewLine);
			});
		}

		private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			bool visible = base.Visible;
			if (visible)
			{
				base.BeginInvoke(new MethodInvoker(delegate()
				{
					foreach (object obj in args.NewItems)
					{
						this.LogsTextBox.AppendText(((obj != null) ? obj.ToString() : null) + Environment.NewLine);
					}
					this.LogsTextBox.Refresh();
					Console.WriteLine("Added New Text to Logs");
				}));
			}
		}

		private void ShowLogs_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		public static ObservableCollection<string> LogEntries = new ObservableCollection<string>();
	}
}
