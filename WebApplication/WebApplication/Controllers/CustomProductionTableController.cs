using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.ProductionTable;

namespace WebApplication.Controllers
{
    public class CustomProductionTableController : Controller
    {
        #region Class Members

        private Decimal runTime = 0m;

        private Decimal es16_22 = 0m;

        private Decimal es2_8 = 0m;

        private Decimal es8_16 = 0m;

        private Decimal es8_22 = 0m;

        private Decimal p40_100 = 0m;

        private Decimal brecher = 0m;

        private Decimal vorsieb = 0m;

        private Decimal brechsand = 0m;

        private Decimal abfall = 0m;

        private Decimal deponie = 0m;

        private Decimal totalEdelSplit = 0m;

        #endregion

        // GET: CustomProductionTable
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCustomProductionTableData(String startDate, String endDate)
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

            // first load the data from DB
            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var prodTime = from p in context.view_dailyProduction
                               where p.UNIT.ToLower() == "h"
                                      && p.PROD_DATE >= dtStart
                                      && p.PROD_DATE <= dtEnd
                               group p by new { p.UNIT } into g
                               select new
                               {
                                   Unit = g.Key.UNIT,
                                   Sum = g.Sum(p => p.VALUE)

                               };
                foreach (var pt in prodTime)
                {
                    runTime = (Decimal)pt.Sum;
                }

                var prodTons = from p in context.view_dailyProduction
                               where p.UNIT.ToLower() == "t"
                                     && p.PROD_DATE >= dtStart
                                     && p.PROD_DATE <= dtEnd
                               group p by new { p.ARTICLE } into g
                               select new
                               {
                                   Article = g.Key.ARTICLE,
                                   Sum = g.Sum(p => p.VALUE)

                               };
                foreach (var art in prodTons)
                {
                    Decimal v = (Decimal)art.Sum;

                    switch (art.Article)
                    {
                        case "16/22":
                            es16_22 = v;
                            totalEdelSplit += v;
                            break;
                        case "2/8":
                            es2_8 = v;
                            totalEdelSplit += v;
                            break;
                        case "8/16":
                            es8_16 = v;
                            totalEdelSplit += v;
                            break;
                        case "8/22":
                            es8_22 = v;
                            totalEdelSplit += v;
                            break;
                        case "0/2":
                            brechsand = v;
                            break;
                        case "0/80":
                            vorsieb = v;
                            break;
                        case "40/100":
                            p40_100 = v;
                            break;
                        case "0/200":
                            brecher = v;
                            break;
                        default:
                            continue;

                    }



                }

                deponie = vorsieb - p40_100;
                abfall = (brecher + vorsieb) - totalEdelSplit - brechsand - deponie;


                return Json(GetProductionTableLines(), JsonRequestBehavior.AllowGet);

            }

        }

        private List<WebApplication.Models.ProductionTable.ProductionTableLine> GetProductionTableLines()
        {
            List<ProductionTableLine> lstResult = new List<ProductionTableLine>();

            // Brecher
            lstResult.Add(new ProductionTableLine() { Group = "Brecher", Tons = brecher, Name = "Brecher" });
            lstResult.Add(new ProductionTableLine() { Group = "Brecher", Tons = vorsieb, Name = "Vorsieb" });

            //Deponie
            lstResult.Add(new ProductionTableLine() { Group = "Deponie", Tons = brechsand, Name = "Brechsand 0/2" });
            lstResult.Add(new ProductionTableLine() { Group = "Deponie", Tons = p40_100, Name = "40/100" });
            lstResult.Add(new ProductionTableLine() { Group = "Deponie", Tons = deponie, Name = "Deponie" });
            lstResult.Add(new ProductionTableLine() { Group = "Deponie", Tons = abfall, Name = "Abfall" });

            //Edelsplit
            lstResult.Add(new ProductionTableLine() { Group = "EdelSplitt", Tons = es16_22, Name = "Edelsplitt 16/22" });
            lstResult.Add(new ProductionTableLine() { Group = "EdelSplitt", Tons = es2_8, Name = "Edelsplitt 2/8" });
            lstResult.Add(new ProductionTableLine() { Group = "EdelSplitt", Tons = es8_16, Name = "Edelsplitt 8/16" });
            lstResult.Add(new ProductionTableLine() { Group = "EdelSplitt", Tons = es8_22, Name = "Edelsplitt 8/22" });


            // set runtime and average
            foreach (ProductionTableLine line in lstResult)
            {
                if (line.Tons > 0 && runTime > 0)
                {
                    line.Runtime = runTime;
                    line.TonsInHour = line.Tons / runTime;
                }
            }

            return lstResult;
        }

        
    }
}