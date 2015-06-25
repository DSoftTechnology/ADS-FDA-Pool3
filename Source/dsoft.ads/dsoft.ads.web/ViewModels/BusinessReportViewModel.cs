using System;
using System.Collections.Generic;
using System.Web;
using dsoft.ads.web.Helpers;
using dsoft.ads.web.Models;

namespace dsoft.ads.web.ViewModels
{
    public class BusinessReportViewModel
    {
        public string ErrorMsg { get; set; }
        public string Subtitle { get; set; }
        public List<CompanyCount> data { get; set; }

        public BusinessReportViewModel()
        {
        }

        public void GetFinancialReport(string keyword, string state, DateTime? start, DateTime? end)
        {
            this.data = new List<CompanyCount>();
            this.Subtitle = ReportHelper.GetReportSubtitle(keyword, state, start, end);

            OpenFDAQuery query = new OpenFDAQuery();
            query.source = OpenFDAQuery.FDAReportSource.food;
            query.type = OpenFDAQuery.FDAReportType.enforcement;
            query.queryCount = "recalling_firm.exact";

            var searchQuery = new List<string>();

            if (!String.IsNullOrWhiteSpace(keyword))
                searchQuery.Add(HttpUtility.UrlEncode(keyword));

            if (!String.IsNullOrWhiteSpace(state))
                searchQuery.Add(String.Format("state:{0}", HttpUtility.UrlEncode(state)));

            if ((start != null) && (end != null))
                searchQuery.Add(String.Format("recall_initiation_date:[{0:yyyyMMdd}+TO+{1:yyyyMMdd}]", start.Value, end.Value));
            else
                searchQuery.Add(String.Format("recall_initiation_date:[20080101+TO+{0}0101]", DateTime.Today.Year + 1));

            if (searchQuery.Count > 0)
                query.querySearch = string.Join("+AND+", searchQuery);

            bool success = query.RunQuery();

            if (!success)
                this.ErrorMsg = "An error occurred executing the query.  Please try again.";

        }
    
    }
}

