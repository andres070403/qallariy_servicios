﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qallariy_servicios.Models
{
    public class Negocio
    {
        public string idNegocio { get; set; }
        public string nombreNegocio { get; set; }
        public string descripcionNegocio { get; set; }
        public int vendedor { get; set; }
        public string categoria { get; set; }
        public int distrito { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string imagen { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string tiktok { get; set; }
        public string correo { get; set; }
        public string whatsapp { get; set; }
        public string website { get; set; }
        public string verificado { get; set; }
    }
    public class NegocioListar
    {
        public string id { get;  set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string nom_vendedor { get; set; }
        public string desc_categoria { get; set; }
        public string direccion { get; set; }
        public byte[] imagen { get; set; } 
    }
}