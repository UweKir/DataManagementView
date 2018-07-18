using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DayUsageController : Controller
    {
        // GET: DayUsage
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLstDayUsage(String selectedDate)
        {

            List<UsageDetail> lstResult = new List<UsageDetail>();

            DateTime d = DateTime.Now;


            if (!String.IsNullOrEmpty(selectedDate))
            {
                d = DateTime.ParseExact(selectedDate,
                 General.DateTimeFormat,
                 System.Globalization.CultureInfo.InvariantCulture);

            }

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var usage = from p in context.view_dailyUsage
                           where p.use_date == d.Date
                           orderby p.UNIT
                           select new
                           {
                               device = p.DEVICE,
                               article = p.ARTICLE,
                               unit = p.UNIT,
                               value = p.VALUE,
                               location = p.LOCATION


                           };
                foreach (var pr in usage)
                {
                    lstResult.Add(new UsageDetail { Device = pr.device, Name = pr.article, Location = pr.location, Unit = pr.unit, Value = (decimal)pr.value });
                }

            }

            //JsonResult res = JsonConvert.SerializeObject(lstResult);
            return Json(lstResult, JsonRequestBehavior.AllowGet);

        }
    }
}