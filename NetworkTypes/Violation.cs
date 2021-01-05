using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetworkTypes
{
	[Serializable]
	public class Violation
	{
		public Violation(int SigMethod, int DetectionID, List<Process> ProcessList, List<Window> WindowList)
		{
			this.SigMethod = SigMethod;
			this.DetectionID = DetectionID;
			foreach (Process process in ProcessList)
			{
				this.Processes = this.Processes + process.ProcessName + ", ";
			}
			foreach (Window window in WindowList)
			{
				this.Windows = this.Windows + window.WindowTitle + ", ";
			}
		}

		public int SigMethod;

		public int DetectionID;

		public string Processes = "";

		public string Windows = "";
	}
}
