using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using dsoft.ads.web.Models;
using dsoft.ads.web.Helpers;
using PagedList;

namespace dsoft.ads.web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			var mvcName = typeof(Controller).Assembly.GetName ();
			var isMono = Type.GetType ("Mono.Runtime") != null;

			ViewData ["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData ["Runtime"] = isMono ? "Mono" : ".NET";

			OpenFDAQuery query = new OpenFDAQuery ();
			query.source = OpenFDAQuery.FDAReportSource.food;
			query.type = OpenFDAQuery.FDAReportType.enforcement;
			query.querySearch = "report_date:[20150101+TO+20150430]";
			query.queryLimit = 100;
			bool result = query.RunQuery ();
			if (result) {
				string test = query.response.GetStateCounts ();
				ViewData ["RawJson"] = query.response.results.Count.ToString();
			}
			else
				ViewData ["RawJson"] = "fail";

			return View ();
		}

		public ActionResult About()
		{
			return View ();
		}

		public ActionResult GeographicReport ()
		{
			ViewData ["HideStateFilter"] = true;
			return View ();
		}

		public ActionResult BusinessReport () 
		{
			return View ();
		}

		public ActionResult FinancialReport ()
		{
			return View ();
		}

		public ActionResult ReportList (string sortOrder, int? page, int? pageSize)
		{
			ViewBag.CurrentSort = sortOrder;	
			ViewBag.EnfRepEventIdSortParm = (sortOrder == "eventid" ? "eventid_desc" : "eventid");
			ViewBag.EnfRepRecallNumSortParm = (sortOrder == "recallnum" ? "recallnum_desc" : "recallnum");
			ViewBag.EnfRepReasonSortParm = (sortOrder == "reason" ? "reason_desc" : "reason");
			ViewBag.EnfRepStatusSortParm = (sortOrder == "status" ? "status_desc" : "status");

			OpenFDAQuery query = new OpenFDAQuery ();
			query.source = OpenFDAQuery.FDAReportSource.food;
			query.type = OpenFDAQuery.FDAReportType.enforcement;
			query.querySearch = "report_date:[20150101+TO+20150430]";
			query.queryLimit = 100;
			bool result = query.RunQuery ();
			if (result) 
				ViewBag.ErrorMsg = String.Empty;
			else
				ViewBag.ErrorMsg = "An error occurred executing the query.  Please try again.";

			var reports = query.response.results.AsQueryable ();

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
			ViewBag.PageSize = displayPageSize;
			SessionHelper.SetSession("PubsPageSize", displayPageSize);

			// paging options
			List<SelectListItem> items = new List<SelectListItem>();
			items.Add(new SelectListItem { Text = "10", Value = "10", Selected = (displayPageSize == 10) });
			items.Add(new SelectListItem { Text = "25", Value = "25", Selected = (displayPageSize == 25) });
			items.Add(new SelectListItem { Text = "50", Value = "50", Selected = (displayPageSize == 50) });
			items.Add(new SelectListItem { Text = "100", Value = "100", Selected = (displayPageSize == 100) });
			//items.Add(new SelectListItem { Text = "All", Value = "-1", Selected = (displayPageSize == -1) });       // TODO: only for admin
			ViewBag.PageSizeOptions = items;

			if (displayPageSize == -1)
				displayPageSize = query.response.results.Count();

			ViewBag.PubCount = query.response.results.Count();

			return View(reports.ToPagedList(displayPageNumber, displayPageSize));
		}

		public ActionResult ReportDetails (int eventId)
		{
			EnforcementReport report = null;

			OpenFDAQuery query = new OpenFDAQuery ();
			query.source = OpenFDAQuery.FDAReportSource.food;
			query.type = OpenFDAQuery.FDAReportType.enforcement;
			query.querySearch = "report_date:[20150101+TO+20150430]";
			query.queryLimit = 100;
			bool result = query.RunQuery ();
			if (result) {
				report = query.response.results.Where (r => r.event_id == eventId).FirstOrDefault ();
			}

			return View (report);
		}
	}
}

