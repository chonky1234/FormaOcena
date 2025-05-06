using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace FormaOcena
{
    internal class Konekcija
    {
        public static SqlConnection Connect()
        {
            string cs = ConfigurationManager.ConnectionStrings["home"].ConnectionString;
            
            SqlConnection veza = new SqlConnection(cs);
            return veza;
        }

    }
}
