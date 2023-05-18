using BussinessLayer.MethodObjects;

namespace BussinessLayer.QLKS_System
{
    public class QLKS_System
    {
        //Khai bao cac doi tuong lien quan den he thong
        protected SeedData dataSedder;

        public QLKS_System()
        {
            this.Init();
        }

        public void Init()
        {
            dataSedder = new SeedData();
        }
    }
}
