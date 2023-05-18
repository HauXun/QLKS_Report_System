namespace BussinessLayer.MethodObjects
{
    public class SqlDataProvider
    {
        public DBAccess.QLKS_System GetContext()
        {
            return new DBAccess.QLKS_System();
        }
    }
}
