using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication.Models;
using Newtonsoft.Json;

namespace WebApplication.Controllers
{
    public class DayProductionController : Controller
    {
        // GET: DayProduction
        public ActionResult Index(String selectedDate)
        {
           
            return View();
        }

       

        public JsonResult GetLstDayProduction(String selectedDate)
        {

            List<ProductionDetail> lstResult = new List<ProductionDetail>();

            DateTime d = DateTime.Now;

            
            if (!String.IsNullOrEmpty(selectedDate))
            {
                d = DateTime.ParseExact(selectedDate,
                 General.DateTimeFormat,
                 System.Globalization.CultureInfo.InvariantCulture);

            }
            

            

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var prod = from p in context.view_dailyProduction
                           where p.PROD_DATE == d.Date
                           orderby p.UNIT
                           select new
                           {
                               article = p.ARTICLE,
                               unit = p.UNIT,
                               value = p.VALUE,
                               location = p.LOCATION


                           };
                foreach (var pr in prod)
                {
                    lstResult.Add(new ProductionDetail { Name = pr.article, Location = pr.location, Unit = pr.unit, Value = (decimal)pr.value });
                }

            }

            //JsonResult res = JsonConvert.SerializeObject(lstResult);
            return Json(lstResult, JsonRequestBehavior.AllowGet);
            
        }

        
    }
}