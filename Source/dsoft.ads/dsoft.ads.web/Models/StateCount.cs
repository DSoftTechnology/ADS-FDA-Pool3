using System;

namespace dsoft.ads.web
{
	public class StateCount
	{
		public StateCount (int idx, string name, string abbr)
		{
			this.index = idx;
			this.StateName = name;
			this.StateAbbr = abbr;
			this.count = 0;
		}

		#region Properties
		public int index { get; set; }
		public string StateName { get; set; }
		public string StateAbbr { get; set; }
		public int count { get; set; }
		#endregion
	}
}

