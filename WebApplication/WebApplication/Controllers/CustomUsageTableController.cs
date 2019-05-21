using System;
using System.Collections.Generic;
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

            // from 0.00 to 24.59
            dtStart = dtStart.Date.Add(new TimeSpan(0, 0, 0));
            dtEnd = dtEnd.Date.Add(new TimeSpan(24, 59, 59));


            List<WebApplication.Models.UsageDetail> lstUsage = new List<WebApplication.Models.UsageDetail>();

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
             
                   var lstQuery = context.sp_GetConsumerCounterDifference(dtStart, dtEnd, "", "", "", "");

                    foreach (var usage in lstQuery)
                    {
                        lstUsage.Add(new WebApplication.Models.UsageDetail() { Device = usage.DEVICE,
                                                                               Value = (Decimal)usage.USAGE,
                                                                               Location = usage.LOCATION,
                                                                               Unit = usage.UNIT,
                                                                               Name = usage.TYPE
                                                                              });

                    }
                    
            }

            return Json(lstUsage, JsonRequestBehavior.AllowGet);
        }
    }
}