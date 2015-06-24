using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using dsoft.ads.web.Models;
using dsoft.ads.web.Helpers;
using PagedList;

namespace dsoft.ads.web.ViewModels
{
	public class ReportListViewModel
	{
		public string CurrentSort { get; set; }	
		public string EventIdSortParm { get; set; }
		public string RecallNumSortParm { get; set; }
		public string ReasonSortParm { get; set; }
		public string StatusSortParm { get; set; }
		public string ErrorMsg {get; set; }
		public int Count { get; set; }
		public int PageSize { get; set; }
		public PagedList.IPagedList<EnforcementReport> Reports { get; set; }
		public List<SelectListItem> PageSizeOptions { get; set; }

		public ReportListViewModel (string sortOrder, int? page, int? pageSize)
		{
			this.CurrentSort = sortOrder;	
			this.EventIdSortParm = (sortOrder == "eventid" ? "eventid_desc" : "eventid");
			this.RecallNumSortParm = (sortOrder == "recallnum" ? "recallnum_desc" : "recallnum");
			this.ReasonSortParm = (sortOrder == "reason" ? "reason_desc" : "reason");
			this.StatusSortParm = (sortOrder == "status" ? "status_desc" : "status");

			// paging
			int displayPageSize = 10;
			int displayPageNumber = (page ?? 1);
			int sessionPageSize = SessionHelper.GetSessionInt("PubsPageSize");
			if (sessionPageSize != 0)
				displayPageSize = sessionPageSize;
			if (pageSize != null)
			{
				displayPageNumber = 1;
				Int32.TryParse(pageSize.ToString(), out displayPageSize);
			}
			this.PageSize = displayPageSize;
			SessionHelper.SetSession("PubsPageSize", displayPageSize);

			// paging options
			this.PageSizeOptions = new List<SelectListItem>();
			this.PageSizeOptions.Add(new SelectListItem { Text = "10", Value = "10", Selected = (displayPageSize == 10) });
			this.PageSizeOptions.Add(new SelectListItem { Text = "25", Value = "25", Selected = (displayPageSize == 25) });
			this.PageSizeOptions.Add(new SelectListItem { Text = "50", Value = "50", Selected = (displayPageSize == 50) });
			this.PageSizeOptions.Add(new SelectListItem { Text = "100", Value = "100", Selected = (displayPageSize == 100) });

			OpenFDAQuery query = new OpenFDAQuery ();
			query.source = OpenFDAQuery.FDAReportSource.food;
			query.type = OpenFDAQuery.FDAReportType.enforcement;
			query.querySearch = "report_date:[20150101+TO+20150430]";
			query.queryLimit = 100;
			bool result = query.RunQuery ();

			if (result)
				this.ErrorMsg = String.Empty;
			else
				this.ErrorMsg = "An error occurred executing the query.  Please try again.";
					
			var reports = query.response.results.AsQueryable ();
			this.Count = reports.Count ();

			// sort
			switch (sortOrder) {
			case "eventid":
				reports = reports.OrderBy (r => r.event_id);
				break;
			case "eventid_desc":
				reports = reports.OrderByDescending (r => r.event_id);
				break;
			case "recallnum":
				reports = reports.OrderBy (r => r.recall_number);
				break;
			case "recallnum_desc":
				reports = reports.OrderByDescending (r => r.recall_number);
				break;
			case "reason":
				reports = reports.OrderBy (r => r.reason_for_recall);
				break;
			case "reason_desc":
				reports = reports.OrderByDescending (r => r.reason_for_recall);
				break;
			case "status":
				reports = reports.OrderBy (r => r.status);
				break;
			case "status_desc":
				reports = reports.OrderByDescending (r => r.status);
				break;
			}

			if (displayPageSize == -1)
				displayPageSize = query.response.results.Count();

			this.Reports = reports.ToPagedList (displayPageNumber, displayPageSize);
		}
	}
}

