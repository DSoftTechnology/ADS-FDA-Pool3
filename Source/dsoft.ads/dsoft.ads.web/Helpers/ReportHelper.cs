using System;
using System.Globalization;
using System.Text;
using System.Web;

namespace dsoft.ads.web.Helpers
{
    public class ReportHelper
    {

        public static string GetReportSubtitle(string keyword, string state, DateTime? start, DateTime? end)
        {
            StringBuilder subtitle = new StringBuilder();

            if (!String.IsNullOrEmpty(keyword))
                subtitle.Append(String.Format("Keyword: {0}; ", HttpUtility.HtmlEncode(keyword)));

            if (!String.IsNullOrEmpty(state))
                subtitle.Append(String.Format("State: {0}; ", HttpUtility.HtmlEncode(state)));

            if ((start != null) && (end != null))
            {
                DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
                subtitle.Append(String.Format("Date Range: {0} - {1}; ", ((DateTime)start).ToString("d", dtfi), ((DateTime)end).ToString("d", dtfi)));
            }

            return subtitle.ToString();
        }


    }
}

