using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;


namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
          
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetDayCurrentProductionByUnit()
        {
            List<ProductionDetail> lstResult = new List<ProductionDetail>();

            String unit = "t";


            DateTime day = DateTime.Now;

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var prodTime = from p in context.view_dailyProduction
                               where p.UNIT.ToLower() == unit && p.PROD_DATE == day.Date
                               select new
                               {
                                   Unit = p.UNIT,
                                   Value = p.VALUE,
                                   ProdDate = p.PROD_DATE,
                                   ArticleName = p.ARTICLE,
                                   Location = p.LOCATION


                               };
                foreach (var item in prodTime)
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

                    lstResult.Add(prod);

                }
            }

            return Json(lstResult, JsonRequestBehavior.AllowGet);
        }
    }
}