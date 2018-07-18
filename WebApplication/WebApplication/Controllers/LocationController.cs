using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            /*
             * DayProductionModel model = new DayProductionModel();
            model.SelectedDate = DateTime.Now;

            DayProduction dProd = new DayProduction();
            dProd.Location = "Sülm";

            dProd.LstProdDetail = new List<Detail>();

            model.Production = dProd;


            view_dailyProduction prodList = new view_dailyProduction();

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var prod = from p in context.view_dailyProduction
                           where p.PROD_DATE == new DateTime(2018, 4, 27).Date
                           select new
                           {
                               article = p.ARTICLE,
                               unit = p.UNIT,
                               value = p.VALUE,
                               location = p.LOCATION


                           };
                foreach (var pr in prod)
                {
                    dProd.LstProdDetail.Add(new Detail() { Name = pr.article, Unit = pr.unit, Value = (decimal)pr.value });
                }
            }

            return View(model); 
             */

            LocationModel model = new LocationModel() { LstLocations = new List<Location>() };
                 ;

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var lstLoc = from loc in context.location
                             where loc.loc_active == true
                             select loc;
                            
                foreach (var l in lstLoc)
                {
                    bool alive = false;

                    TimeSpan span = DateTime.Now - (DateTime) l.loc_lastKeepAlive;

                    if (span.TotalHours < 12)
                        alive = true;

                    model.LstLocations.Add(new Location() { Name = l.loc_name, Online = alive, LastAlive = (DateTime)l.loc_lastKeepAlive });
                }
            }


            return View(model);
        }
    }
}