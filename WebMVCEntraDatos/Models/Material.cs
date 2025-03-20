using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCEntraDatos.Models
{

    public class Material
    {
        public int Idmaterial { get; set; }
        public string NombreMat { get; set; }
        public string Marca { get; set; }
        public int Categoria { get; set; }
        public string UnidadMedida { get; set; }
    }
}