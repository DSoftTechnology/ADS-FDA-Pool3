using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

					string name = result.term;

					/*
					 * TODO:  FDA API contains a bug which does not permit string text search queries containing single-quote
					 * whether or not it is URL-encoded properly.  For demonstration purposes, names with single-quote/apostrophes
					 * will be excluded from the top-ten list.
					 * 
					 */
					if (!name.Contains("'"))
					{
						resultLimit++;
						if (resultLimit > 10)
							break;

						if (name.Contains(","))
							name = name.Substring(0, name.IndexOf(","));
						name = HttpUtility.UrlEncode(name);

						int totalcount = 0;
						Int32.TryParse(result.count, out totalcount);

						CompanyCount companyCount = new CompanyCount(name, totalcount);

						int countNonZero = 0;
						for (int yr = 2008; yr <= DateTime.Today.Year; yr++)
						{
							OpenFDAQuery subquery = new OpenFDAQuery();
							subquery.source = OpenFDAQuery.FDAReportSource.food;
							subquery.type = OpenFDAQuery.FDAReportType.enforcement;
							subquery.queryCount = "recalling_firm.exact";
							subquery.querySearch = String.Format("recall_initiation_date:[{0}0101+TO+{1}0101]+AND+recalling_firm:\"{2}\"", yr, yr + 1, name);
							success = subquery.RunQuery();						

							int yrcount = 0;
							if ((success) && (subquery.response != null) && (subquery.response.results.Count > 0))
							{
								foreach (var yrresult in subquery.response.results)
								{
									yrcount += yrresult.countNumeric;
								}
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
}

