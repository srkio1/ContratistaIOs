﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contratistas_iOS.Datos
{
    public class Calificacion_profesional
    {
        public int id_calificacion_p { get; set; }
        public string valor { get; set; }
        public string comentarios { get; set; }
        public int telefono { get; set; }
        public int id_profesional { get; set; }
    }
}
