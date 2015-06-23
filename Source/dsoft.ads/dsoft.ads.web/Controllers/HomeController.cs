using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using dsoft.ads.web.Models;

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
	}
}

