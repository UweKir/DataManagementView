using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DayUsageChartsController : Controller
    {
        // GET: DayUsageCharts
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDevices()
        {
            List<ProdDevice> lstDevices = new List<ProdDevice>();
            lstDevices.Add(new ProdDevice() { Key = "all", Name = "*" });

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var devList = from d in context.device
                              select d;

                
                foreach(var dev in devList)
                {
                    ProdDevice pDevice = new ProdDevice() { Key = dev.dev_id.ToString(), Name = dev.dev_name };

                    if ((dev.dev_name != "Einspeisung") && (dev.dev_name != "Tag") && (!dev.dev_name.ToUpper().Contains("SYS-")))
                        lstDevices.Add(pDevice);
                }

            }


            return Json(lstDevices, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetDayUsageList(String startDate, String endDate, String device)
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

            if (String.IsNullOrEmpty(device) || device == "*")
                return getUsageComplete(dtStart, dtEnd);


            List<UsageDetail> lstResult = new List<UsageDetail>();
            

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var usageList = from usage in context.view_dailyUsage
                                where usage.UNIT.ToLower() == "kwh" &&
                                      usage.use_date >= dtStart.Date &&
                                      usage.use_date <= dtEnd.Date &&
                                      usage.DEVICE == device
                                select new
                                {
                                    Unit = usage.UNIT,
                                    Value = usage.VALUE,
                                    Date = usage.use_date,
                                    ArticleName = usage.ARTICLE,
                                    Location = usage.LOCATION
                                };


                foreach(var use in usageList)
                {
                    UsageDetail detail = new UsageDetail();
                    detail.Name = use.ArticleName;
                    detail.UsageDate = use.Date;
                    detail.StrUsageDate = use.Date.ToString("dd.MM.yyyy");

                    if (use.Value.HasValue)
                        detail.Value = use.Value.Value;

                    detail.Location = use.Location;

                    lstResult.Add(detail);

 
                }

            }

            return Json(lstResult, JsonRequestBehavior.AllowGet);
        }

        private JsonResult getUsageComplete(DateTime startDate, DateTime endDate)
        {

            List<UsageDetail> lstResult = new List<UsageDetail>();

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var usageList = from u in context.view_dailyUsage
                               where  u.UNIT.ToLower() == "kwh"
                                      && u.use_date >= startDate.Date
                                      && u.use_date <= endDate.Date
                               group u by new { u.use_date } into g
                               select new
                               {
                                   Date = g.Key.use_date,
                                   Value = g.Sum(p => p.VALUE)

                               };

                foreach (var use in usageList)
                {
                    UsageDetail detail = new UsageDetail();
                   
                    detail.UsageDate = use.Date;
                    detail.StrUsageDate = use.Date.ToString("dd.MM.yyyy");

                    if (use.Value.HasValue)
                        detail.Value = use.Value.Value;

                    detail.Location = "";

                    lstResult.Add(detail);


                }
            }

            return Json(lstResult, JsonRequestBehavior.AllowGet);
        }
    }
}