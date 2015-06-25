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

		public JsonResult GeoReport(string keyword = null, DateTime? startDate = null, DateTime? endDate = null)
		{
			GeoReportViewModel geo = new GeoReportViewModel ();
			geo.GetGeoReport (keyword, startDate, endDate);

			return Json(geo, JsonRequestBehavior.AllowGet);
		}

        public JsonResult FinancialReport(string keyword = null, string state = null, DateTime? startDate = null, DateTime? endDate = null)
		{
			FinancialReportViewModel fin = new FinancialReportViewModel ();
            fin.GetFinancialReport (keyword, state, startDate, endDate);

			return Json(fin, JsonRequestBehavior.AllowGet);
		}

        public JsonResult BusinessReport(string keyword = null, string state = null)
        {
            BusinessReportViewModel bus = new BusinessReportViewModel();
            bus.GetFinancialReport(keyword, state);

            return Json(bus, JsonRequestBehavior.AllowGet);
        }
    
    }
}
