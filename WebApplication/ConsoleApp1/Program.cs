using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var date = DateTime.Now.Date.Add(new TimeSpan(0, 0, 0));


            DateTime beginDate = DateTime.Parse("2018-04-02");
            beginDate = beginDate.Date.Add(new TimeSpan(0, 0, 0));
            DateTime endDate = DateTime.Parse("2018-04-25");
            endDate = endDate.Date.Add(new TimeSpan(24, 59, 59));

            List<WebApplication.Models.UsageDetail> lstUsage = new List<WebApplication.Models.UsageDetail>();

            using (KTBDataManagerEntities context = new KTBDataManagerEntities())
            {
                var s = context.sp_GetConsumerCounterDifference(beginDate, endDate, null, null, null, null);

                foreach(var g in s)
                {
                    lstUsage.Add(new WebApplication.Models.UsageDetail() { Device = g.DEVICE,
                                                                           Value = (Decimal)g.USAGE,
                                                                           Location = g.LOCATION,
                                                                           Unit = g.UNIT
                                                                         });
                   
                }

                /*
                var prodTons = from p in context.sp_GetConsumerCounterDifference(beginDate.Date, endDate.Date, "", "", "","","")
                               where p>= beginDate.Date && p.use_date <= endDate.Date
                               select new
                               {
                                   
                                   Unit = p.UNIT,
                                   Value = p.VALUE,
                                   Location = p.LOCATION,
                                   Device = p.DEVICE

                               };

                foreach (var prod in prodTons)
                {
                    lstUsage.Add(new WebApplication.Models.UsageDetail() { Device = prod.Device, Location = prod.Location, Unit = prod.Unit, Value = (Decimal)prod.Value });
                    
                }
                */
            }

            



                /*
                Decimal runTime = 0m;

                Decimal es16_22 = 0m;
                Decimal es2_8 = 0m;
                Decimal es8_16 = 0m;
                Decimal es8_22 = 0m;
                Decimal p40_100 = 0m;

                Decimal brecher = 0m;
                Decimal vorsieb = 0m;
                Decimal brechsand = 0m;
                Decimal abfall = 0m;

                Decimal deponie = 0m;

                Decimal totalEdelSplit = 0m;




                using (KTBDataManagerEntities context = new KTBDataManagerEntities())
                {
                    var prodTime = from p in context.view_dailyProduction
                               where p.UNIT.ToLower() == "h"
                               group p by new { p.UNIT } into g
                               select new
                               {
                                   Unit = g.Key.UNIT,
                                   Sum = g.Sum(p=>p.VALUE)

                               };
                    foreach (var pt in prodTime)
                    {
                        runTime = (Decimal) pt.Sum;
                    }

                    var prodTons = from p in context.view_dailyProduction
                                   where p.UNIT.ToLower() == "t"
                                   group p by new { p.ARTICLE } into g
                                   select new
                                   {
                                       Article = g.Key.ARTICLE,
                                       Sum = g.Sum(p => p.VALUE)

                                   };
                    foreach (var art in prodTons)
                    {
                        Decimal v = (Decimal)art.Sum;

                        switch(art.Article)
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
                    


            }
            */
        }
    }
}
