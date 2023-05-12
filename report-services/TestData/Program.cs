using BussinessLayer.QLKS_System;
using System;
using System.Threading.Tasks;

namespace TestData
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Report_Subsystem report_Subsystem = new Report_Subsystem();

            await report_Subsystem.SeedDatabase();

            Console.ReadLine();
        }
    }
}
