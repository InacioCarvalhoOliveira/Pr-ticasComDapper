using PraticasComDapper.MaoNaMassa.Imersao;

namespace PraticasComDapper.MaoNaMassa
{
    public class Program : DbConnection
    {
        public static void Main(string[] args)
        {
            DbConnection con = new DbConnection();
            con.connection();         
        }
    }
}





