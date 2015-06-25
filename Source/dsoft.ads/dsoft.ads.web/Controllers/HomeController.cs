using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using dsoft.ads.web.Models;
using dsoft.ads.web.Helpers;
using dsoft.ads.web.ViewModels;

namespace dsoft.ads.web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			GeoReportViewModel geo = new GeoReportViewModel ();

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

        public ActionResult ReportList (string sortOrder, int? page, int? pageSize, string keyword = null, string state = null, DateTime? startDate = null, DateTime? endDate = null)
		{
            if (!String.IsNullOrWhiteSpace(keyword))
                ViewBag.keyword = keyword;
            if (!String.IsNullOrWhiteSpace(state))
                ViewBag.state = state;
            if (startDate != null)
                ViewBag.startDate = ((DateTime)startDate).ToShortDateString();
            if (endDate != null)
                ViewBag.endDate = ((DateTime)endDate).ToShortDateString();

            return View(new ReportListViewModel(sortOrder, page, pageSize, keyword, state, startDate, endDate));
		}

        public ActionResult ReportDetails (string id, string eventid)
		{
            return View (new ReportDetailsViewModel(id, eventid));
		}
	}
}

