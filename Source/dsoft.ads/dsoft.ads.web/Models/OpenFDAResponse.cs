using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using dsoft.ads.web.Helpers;

namespace dsoft.ads.web.Models
{
	public class OpenFDAResponse
	{
		public OpenFDAResponse ()
		{
			results = new List<EnforcementReport> ();
		}

		#region Properties
		public OpenFDAResponseMeta meta { get; set; }
		public List<EnforcementReport> results {get; set;}
		public int count 
		{ 
			get {
				if (this.results != null)
					return this.results.Count;
				else
					return 0;
			}
		}
		#endregion

		public void SetStateLists()
		{
			foreach (EnforcementReport report in this.results) 
			{
				report.SetStateList ();
			}
		}

		public string GetStateCounts() 
		{
			List<StateCount> stateCounts = new List<StateCount> ();

			int cnt = 0;
			foreach (KeyValuePair<string, string> kvp in StateNames.stateNames) 
			{
				cnt++;
				StateCount stateCount = new StateCount (cnt, kvp.Key, kvp.Value);
				foreach (EnforcementReport report in this.results) 
				{
					if (report.stateList.Contains (kvp.Value))
						stateCount.count++;
				}
				stateCounts.Add (stateCount);
			}

			return JsonConvert.SerializeObject (stateCounts);
		}
	}
}

