using System.ComponentModel.DataAnnotations;

namespace WebMVCEntraDatos.Models
{
    public class CategoriaMaterial
    {
        public int Idcategoria { get; set; }

     
        public string NomCategoria { get; set; }

        public string Extra { get; set; }
    }
}
