using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NetworkTypes;

namespace Resources
{
	public class GroupControl
	{
		public GroupControl(bool GroupExpanded)
		{
			this.IsProductGroup = false;
			this.GroupExpanded = GroupExpanded;
		}

		public GroupControl(bool IsProductGroup, Group Group, bool GroupExpanded)
		{
			this.IsProductGroup = IsProductGroup;
			this.Group = Group;
			this.GroupExpanded = GroupExpanded;
		}

		public bool IsProductGroup;

		public Group Group;

		public bool GroupExpanded;

		public List<Control> GroupChildren = new List<Control>();
	}
}
