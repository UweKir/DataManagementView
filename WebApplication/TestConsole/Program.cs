using System;
using WebApplication;
using System.Data.Entity;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            

            String strNow = "Fri Jun 15 2018 00:00:00 GMT+0200 (Mitteleuropäische Sommerzeit)";

            DateTime dt = DateTime.ParseExact(strNow.Substring(0, 24),
                  "ddd MMM dd yyyy HH:mm:ss",
                  System.Globalization.CultureInfo.InvariantCulture);

           




            Console.WriteLine("Hello World!");
        }
    }
}
