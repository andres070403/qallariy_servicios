using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace qallariy_servicios.DAO
{
    public class conexionDAO
    {
        SqlConnection cn = new SqlConnection(@"server= DESKTOP-FFL9BBK; database=qallariy; Trusted_Connection=true; " +
            "MultipleActiveResultSets=true; TrustServerCertificate=False; Encrypt=False ");
        public SqlConnection getcn
        {
            get { return cn; }

        }
    }
}
