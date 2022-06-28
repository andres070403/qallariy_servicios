using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace qallariy_servicios.DAO
{
    public class conexionDAO
    {
        SqlConnection cn = new SqlConnection(@"server=.\SQLEXPRESS;database=qallariy;Trusted_Connection=True;" +
                "MultipleActiveResultSets=True;TrustServerCertificate=False;Encrypt=False");
        public SqlConnection getcn
        {
            get { return cn; }

        }
    }
}
