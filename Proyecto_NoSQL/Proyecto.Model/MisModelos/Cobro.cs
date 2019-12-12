using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model.MisModelos
{
    public class Cobro
    {
        public Cobro()
        {
        }

        [Display(Name = "Número de factura")]
        public int factura { get; set; }
        [Display(Name = "Cédula")]
        public int cedula { get; set; }
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Display(Name = "Medio de pago")]
        public string medioPago { get; set; }
        [Display(Name = "Costo")]
        public double valor { get; set; }
        [Display(Name = "IVA(%)")]
        public double iva { get; set; }
        [Display(Name = "Monto pagado")]
        public double montoCancelado { get; set; }
        [Display(Name = "Cámbio")]
        public double cambio{ get; set; }


}
}
