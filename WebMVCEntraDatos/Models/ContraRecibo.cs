using System;
using System.ComponentModel.DataAnnotations;

namespace WebMVCEntraDatos.Models
{
    public class ContraRecibo
    {
        public int IdContrarecibo { get; set; }

        [Required(ErrorMessage = "La fecha es requerida.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El nombre de la obra es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre de la obra no puede tener más de 100 caracteres.")]
        public string Obra { get; set; }

        [StringLength(255, ErrorMessage = "La información extra no puede tener más de 255 caracteres.")]
        public string Extra { get; set; }
    }
}
