using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dsoft.ads.web.ViewModels;
using Newtonsoft.Json;

namespace dsoft.ads.web.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

		public ActionResult GeoReport()
		{
			GeoReportViewModel geo = new GeoReportViewModel ();
			geo.GetGeoReport ();

			return Json(JsonConvert.SerializeObject (geo), JsonRequestBehavior.AllowGet);
		}
    }
}
