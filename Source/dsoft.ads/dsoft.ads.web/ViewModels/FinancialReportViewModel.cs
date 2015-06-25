using System;
using System.Collections.Generic;
using System.Linq;
using dsoft.ads.web.Helpers;
using dsoft.ads.web.Models;

namespace dsoft.ads.web.ViewModels
{
	public class FinancialReportViewModel
	{
		public string ErrorMsg { get; set; }
		public List<CompanyCount> data { get; set; }

		public FinancialReportViewModel ()
		{
		}

		public void GetFinancialReport()
		{
			this.data = new List<CompanyCount> ();

			OpenFDAQuery query = new OpenFDAQuery ();
			query.source = OpenFDAQuery.FDAReportSource.food;
			query.type = OpenFDAQuery.FDAReportType.enforcement;
			query.queryCount = "recalling_firm.exact";
			query.querySearch = String.Format ("recall_initiation_date:[20080101+TO+{0}0101]", DateTime.Today.Year+1);
			bool success = query.RunQuery ();

			if (!success)
				this.ErrorMsg = "An error occurred executing the query.  Please try again.";
			else {
				this.ErrorMsg = String.Empty;

				int resultLimit = 0;
				foreach (OpenFDAResult result in query.response.results) {

					resultLimit++;
					if (resultLimit > 20)
						break;

					string name = result.term;

					int totalcount = 0;
					Int32.TryParse (result.count, out totalcount);

					CompanyCount companyCount = new CompanyCount (name, totalcount);

					int countNonZero = 0;
					for (int yr = 2008; yr <= DateTime.Today.Year; yr++)
					{
						OpenFDAQuery subquery = new OpenFDAQuery ();
						subquery.source = OpenFDAQuery.FDAReportSource.food;
						subquery.type = OpenFDAQuery.FDAReportType.enforcement;
						subquery.queryCount = "recalling_firm.exact";
						subquery.querySearch = String.Format ("recall_initiation_date:[{0}0101+TO+{1}0101]+AND+recalling_firm:\"{2}\"", yr, yr + 1, name);
						success = subquery.RunQuery ();						

						int yrcount = 0;
						if ((success) && (subquery.response != null) && (subquery.response.results.Count > 0))
						{
							var yrresult = subquery.response.results.Where(r => r.term.Equals(name)).FirstOrDefault();
							if (yrresult == null) {
								int max = subquery.response.results.Max (r => r.countNumeric);
								if (max > 0)
									yrresult = subquery.response.results.Where (r => r.countNumeric == max).FirstOrDefault ();
							}
							if (yrresult == null)
								yrresult = subquery.response.results[0];
							if (yrresult != null)
								Int32.TryParse(yrresult.count, out yrcount);
						}
						companyCount.YearlyCounts.Add(yr.ToString(), yrcount);

						if (yrcount > 0)
							countNonZero++;
					}

					companyCount.CountNonZero = countNonZero;
					this.data.Add(companyCount);
				}
			}
		}

	}
}

