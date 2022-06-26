using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qallariy_servicios.Models
{
    public class Distrito
    {
        public int idDistrito { get; set; }
        public int idProvincia { get; set; }
        public int idDepartamento { get; set; }
        public string descripcion { get; set; }
    }
}
