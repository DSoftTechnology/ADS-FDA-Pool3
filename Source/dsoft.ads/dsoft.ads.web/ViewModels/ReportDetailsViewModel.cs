using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using dsoft.ads.web.Models;

namespace dsoft.ads.web.ViewModels
{
	public class ReportDetailsViewModel
	{
		public EnforcementReport Report { get; set; }

		public ReportDetailsViewModel (string id)
		{
			this.Report = null;

			OpenFDAQuery query = new OpenFDAQuery ();
			query.source = OpenFDAQuery.FDAReportSource.food;
			query.type = OpenFDAQuery.FDAReportType.enforcement;
			query.querySearch = "report_date:[20150101+TO+20150430]";
			query.queryLimit = 100;
			bool result = query.RunQuery ();
			if (result) {
				this.Report = query.response.results.Where (r => r.id.Equals(id)).FirstOrDefault ();
			}
		}
	}
}

