using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qallariy_servicios.Models
{
    public class Producto
    {
        public string idProducto { get; set; }
        public int idnegocio { get; set; }
        public string negocio { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public int visitas { get; set; }
        public int meInteresa { get; set; }
        public int idestado { get; set; }
        public string estado { get; set; }
        public string imagen1 { get; set; }
        public string imagen2 { get; set; }
        public string imagen3 { get; set; }
        public string fecha_creacion { get; set; }
        public string fecha_modificacion { get; set; }

    }
}
