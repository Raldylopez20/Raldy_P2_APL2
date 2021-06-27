using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;


namespace Raldy_P2_APL2.Models
{
    public class CobrosDetalles
    {

        [Key]
        public int CobroDetalleId { get; set; }
        public int CobroId { get; set; }
        public int VentaId { get; set; }
        public float Cobrado { get; set; }
        public virtual Cobros Cobro { get; set; }
        public virtual Ventas Venta { get; set; }

    }
}
