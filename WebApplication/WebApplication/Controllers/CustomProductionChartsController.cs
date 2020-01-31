using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CustomProductionChartsController : Controller
    {
        // GET: CustomProductionCharts
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDayProductionList(String startDate, String endDate, String article)
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


            List<ProductionDetail> lstResult = new List<ProductionDetail>();

            String unit = "t";


            DateTime day = dtStart;

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var prodList = from p in context.view_dailyProduction
                               where p.UNIT.ToLower() == unit &&  
                                     p.PROD_DATE >= dtStart.Date &&
                                     p.PROD_DATE <= dtEnd.Date &&
                                     p.ARTICLE == article
                               select new
                               {
                                   Unit = p.UNIT,
                                   Value = p.VALUE,
                                   ProdDate = p.PROD_DATE,
                                   ArticleName = p.ARTICLE,
                                   Location = p.LOCATION
                               };


                foreach (var item in prodList)
                {
                    WebApplication.Models.ProductionDetail prod = new WebApplication.Models.ProductionDetail();
                    prod.Unit = item.Unit;

                    prod.Value = 0;

                    if (item.Value.HasValue)
                    {
                        prod.Value = item.Value.Value;
                    }

                    prod.Name = item.ArticleName;
                    prod.Location = item.Location;
                    prod.ProdDate = item.ProdDate;
                    prod.StrProdDate = item.ProdDate.ToString("dd.MM.yyyy");

                    lstResult.Add(prod);

                }
            }

            return Json(lstResult, JsonRequestBehavior.AllowGet);
        }
    }
}