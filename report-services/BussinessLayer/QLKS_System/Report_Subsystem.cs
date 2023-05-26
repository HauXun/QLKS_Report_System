using System.Threading.Tasks;

namespace BussinessLayer.QLKS_System
{
    public class Report_Subsystem : QLKS_System
    {
        public async Task SeedDatabase()
        {
            await dataSedder.Initialize();
        }
    }
}
