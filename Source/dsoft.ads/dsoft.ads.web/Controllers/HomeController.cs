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
			return View(new ReportListViewModel(sortOrder, page, pageSize));
		}

		public ActionResult ReportDetails (string id)
		{
			return View (new ReportDetailsViewModel(id));
		}
	}
}

