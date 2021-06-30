using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raldy_P2_APL2.Models
{
    public class Ventas
    {

        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public float Monto { get; set; }
        public double Balance { get; set; }
        public bool CobroNoPerdiente { get; set; }
        public double Cobrado { get; set; }
        public virtual Clientes Clientes { get; set; }


        [ForeignKey("VentaId")]
        public virtual List<CobrosDetalle> Detalle { get; set; } = new List<CobrosDetalle>();


    }
}
