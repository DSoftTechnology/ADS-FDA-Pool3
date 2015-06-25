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
        public List<RecallCount> data { get; set; }

        public BusinessReportViewModel()
        {
        }

        public void GetFinancialReport(string keyword, string state)
        {
            this.data = new List<RecallCount>();
            this.Subtitle = ReportHelper.GetReportSubtitle(keyword, state, null, null);
            this.ErrorMsg = String.Empty;

            int loopStart = 2008;
            int loopEnd = DateTime.Today.Year;
            for (int yr = loopStart; yr <= loopEnd; yr++)
            {
                OpenFDAQuery query = new OpenFDAQuery();
                query.source = OpenFDAQuery.FDAReportSource.food;
                query.type = OpenFDAQuery.FDAReportType.enforcement;

                var searchQuery = new List<string>();

                if (!String.IsNullOrWhiteSpace(keyword))
                    searchQuery.Add(HttpUtility.UrlEncode(keyword));

                if (!String.IsNullOrWhiteSpace(state))
                    searchQuery.Add(String.Format("state:{0}", HttpUtility.UrlEncode(state)));

                searchQuery.Add(String.Format("recall_initiation_date:[{0}0101+TO+{1}0101]", yr, yr + 1));

                if (searchQuery.Count > 0)
                    query.querySearch = string.Join("+AND+", searchQuery);

                bool success = query.RunQuery();

                int cnt = 0;
                if (success && (query.response != null))
                    cnt = query.response.meta.results.total;

                this.data.Add(new RecallCount(yr, cnt));
            }
        }
   
    }
}

