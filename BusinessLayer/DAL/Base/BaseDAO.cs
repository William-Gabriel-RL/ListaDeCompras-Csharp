using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL.Base
{
    public class BaseDAO
    {
        public string ConnectionString { get; set; } = "Data Source=MAGNATI-10865-F;Initial Catalog = ListaCompras; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SqlConnection Con { get; set; }
        public string SqlString { get; set; } = string.Empty;

        public BaseDAO()
        {
            Con = new(ConnectionString);
        }
    }
}
