using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

using System.Globalization;

using System.Data.SqlClient;
using System.Data.Common;
using DataManagementWebApp.Models;


namespace DataManagementWebApp.Controllers
{
   

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var prod = null;

            HomeData data = new HomeData();
            data.Today = DateTime.Now;

            
            DayProduction dProd = new DayProduction();
            dProd.Location = "Sülm";

            dProd.LstProdDetail = new List<Detail>();

            data.Production = dProd;

           
            view_dailyProduction prodList = new view_dailyProduction();

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var prod = from p in context.view_dailyProduction where p.PROD_DATE == new DateTime(2018, 4, 27).Date
                           select new
                           {
                               article = p.ARTICLE,
                               unit  = p.UNIT,
                               value = p.VALUE,
                               location = p.LOCATION
                               
                                
                           };
                foreach(var pr in prod)
                {
                    dProd.LstProdDetail.Add(new Detail() { Name = pr.article, Unit = pr.unit, Value = (decimal)pr.value });
                }
            }
            
            return View(data);
        }
    }
}