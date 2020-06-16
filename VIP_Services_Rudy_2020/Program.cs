using System;
using VIP_Services_Rudy_2020.BusinessLayer;
using VIP_Services_Rudy_2020.BusinessLayer.Models;
using VIP_Services_Rudy_2020.DataLayer;

namespace VIP_Services_Rudy_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm alive!");
            /*
            using (Context ctx = new Context())
            {
                DataInitializer newdata = new DataInitializer(ctx);
                newdata.AddDataToDatabase();
            }*/
        }
    }
}
