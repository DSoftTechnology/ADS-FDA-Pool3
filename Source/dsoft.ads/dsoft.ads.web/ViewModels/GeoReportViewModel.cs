using System;
using System.Collections.Generic;
using System.Linq;
using dsoft.ads.web.Helpers;
using dsoft.ads.web.Models;

namespace dsoft.ads.web.ViewModels
{
	public class GeoReportViewModel
	{
		public string ErrorMsg { get; set; }
		public List<StateCount> data { get; set; }

		public GeoReportViewModel ()
		{
		}

		public void GetGeoReport()
		{
			/*
			 * Note:  the OpenFDA API has a bug/limitation that it will not support a count on distribution_pattern.exact 
			 * which would return complete distribution_pattern strings and allow more accurate parsing.  Just counting
			 * distribution_pattern splits on individual words, so there is no reliable way to distinguish between e.g.
			 * IN for Indiana and the preposition "in". It will also fail to count two-word state names such as "South
			 * Dakota" because the words wil be split. Due to the time constraints on this prototype, this view model 
			 * will accept this limitation of the API and return demonstrative but inaccurate results.
			 * 
			 */

			// create state count list with all states and zero counts
			int cnt = 0;
			this.data = new List<StateCount> ();
			foreach (KeyValuePair<string, string> kvp in StateNames.stateNames) 
			{
				cnt++;
				StateCount stateCount = new StateCount (cnt, kvp.Key, kvp.Value);
				this.data.Add (stateCount);
			}

			OpenFDAQuery query = new OpenFDAQuery ();
			query.source = OpenFDAQuery.FDAReportSource.food;
			query.type = OpenFDAQuery.FDAReportType.enforcement;
			query.queryCount = "distribution_pattern";
			bool success = query.RunQuery ();

			if (!success)
				this.ErrorMsg = "An error occurred executing the query.  Please try again.";
			else {
				this.ErrorMsg = String.Empty;

				foreach (OpenFDAResult result in query.response.results) {
					var statecount = this.data.Where (s => s.StateAbbr.ToLower().Equals (result.term) || s.StateName.ToLower().Equals (result.term)).FirstOrDefault ();
					if (statecount != null)
					{
						int c = 0;
						Int32.TryParse(result.count, out c);
						statecount.Count += c;
					}
				}
			}
		}

	}
}

