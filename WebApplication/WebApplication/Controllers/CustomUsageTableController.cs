using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;


namespace WebApplication.Controllers
{
    public class CustomUsageTableController : Controller
    {
        // GET: CustomUsageTable
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCustomUsageTableData(String startDate, String endDate)
        {

            DateTime dtStart = DateTime.Now;
            DateTime dtEnd = DateTime.Now;


            if (!String.IsNullOrEmpty(startDate))
            {
                dtStart = DateTime.ParseExact(startDate,
                 General.DateTimeFormat,
                 System.Globalization.CultureInfo.InvariantCulture);

            }

            if (!String.IsNullOrEmpty(endDate))
            {
                 dtEnd = DateTime.ParseExact(endDate,
                 General.DateTimeFormat,
                 System.Globalization.CultureInfo.InvariantCulture);

            }

            List<WebApplication.Models.UsageDetail> lstUsage = new List<WebApplication.Models.UsageDetail>();

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var prodTons = from p in context.view_dailyUsage
                               where p.use_date >= dtStart.Date && p.use_date <= dtEnd.Date
                               group p by new { p.DEVICE } into g
                               select new
                               {
                                   Unit = g.Key.DEVICE,
                                   Value = g.Sum(p => p.VALUE)

                               };
                /*
                select new
                               {

                                   Unit = p.UNIT,
                                   Value = p.VALUE,
                                   Location = p.LOCATION,
                                   Device = p.DEVICE

                               };*/

                foreach (var prod in prodTons)
                {
                    lstUsage.Add(new WebApplication.Models.UsageDetail() { Device = prod.Unit, Value = (Decimal)prod.Value });

                }
            }

            return Json(lstUsage, JsonRequestBehavior.AllowGet);

        }
    }
}