using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityEnvio
    {
        public string cod_orden { get; }
        public int iduser { get; set; }
        //public string nombre { get; set; }
       // public string apellido { get; set; }
        public string src_add { get; set; }
        public string dest_add { get; set; }
        public decimal price { get; set; }
        public decimal weight { get; set; }
        public string paquete { get; set; }
        public string nombre_estado { get; }

    }
}
