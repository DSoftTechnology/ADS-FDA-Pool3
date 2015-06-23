using System;
using System.Collections.Generic;
using dsoft.ads.web.Helpers;

namespace dsoft.ads.web.Models
{
	public class EnforcementReport
	{
		public EnforcementReport ()
		{
		}

		#region Properties
		public string id { get; set; }
		public int event_id { get; set; }
		public string recall_number { get; set; }
		public string report_date { get; set; }
		public string recall_initiation_date { get; set; }
		public string classification { get; set; }
		public string voluntary_mandated { get; set; }
		public string reason_for_recall { get; set; }
		public string status { get; set; }
		public string recalling_firm { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string country { get; set; }
		public string distribution_pattern { get; set; }
		public string product_type { get; set; }
		public string product_quantity { get; set; }
		public string product_description { get; set; }
		public string code_info { get; set; }
		public string initial_firm_notification { get; set; }

		public DateTime report_date_full { get; set; }
		public DateTime recall_initiation_date_full { get; set; }
		public List<string> stateList { get; set; }
		#endregion

		public void SetStateList()
		{
			this.stateList = StateNames.GetStateList (this.distribution_pattern);
		}
	}
}

