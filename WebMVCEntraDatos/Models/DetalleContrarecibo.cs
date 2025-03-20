using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCEntraDatos.Models
{
    public class DetalleContrarecibo
    {
        public int IdDetalleContrar { get; set; }
        public int ContraReciboId { get; set; } // Referencia al id del contra recibo
        public int NotaCompraId { get; set; } // Referencia al id de la nota de compra
        public float Total { get; set; }
        public bool Pagada { get; set; }
        public string Extra { get; set; } // Campo adicional opcional
    }
}