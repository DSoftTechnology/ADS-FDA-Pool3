using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			return View ();
		}

		public ActionResult About()
		{
			return View ();
		}

        public ActionResult GeographicReport ()
		{
			ViewData ["HideStateFilter"] = true;
            return View(new BaseViewModel(true));
		}

        public ActionResult BusinessReport () 
		{
            ViewData["HideDateFilter"] = true;
            return View (new BaseViewModel(true));
		}

        public ActionResult FinancialReport ()
		{
            ViewData["HideDateFilter"] = true;
            return View (new BaseViewModel(true));
		}

        public async Task<ActionResult> ReportList (string sortOrder, int? page, int? pageSize, string keyword = null, string state = null, DateTime? startDate = null, DateTime? endDate = null)
		{
            ReportListViewModel report = new ReportListViewModel();
            await report.GetReportList(sortOrder, page, pageSize, keyword, state, startDate, endDate);
            return View(report);
		}

        public async Task<ActionResult> ReportDetails (string id, string eventid)
		{
            ReportDetailsViewModel report = new ReportDetailsViewModel();
            await report.GetReportDetails(id, eventid);
            return View (report);
		}
	}
}

