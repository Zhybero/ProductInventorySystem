namespace PISWEBAPI.FldrClass
{
    public class ClsGetConnection
    {

        public string PlsConnect()
        { 
            return "Data Source=YTTRIUM\\SQLEXPRESS; Initial Catalog=PIS_BE; Integrated Security=SSPI; TrustServerCertificate=True;"; 
        }
    }
}
