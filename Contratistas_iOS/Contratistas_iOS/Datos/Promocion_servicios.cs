﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contratistas_iOS.Datos
{
    public class Promocion_servicios
    {
        public int id_promocion_s { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public int id_servicio { get; set; }
    }
}
