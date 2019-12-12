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
        [Display(Name = "Número de factura")]
        public string factura;
        [Display(Name = "Cédula")]
        public int cedula;
        [Display(Name = "Descripción")]
        public string descripcion;
        [Display(Name = "Medio de pago")]
        public string medioPago;
        [Display(Name = "Costo")]
        public double valor;
        [Display(Name = "IVA")]
        public double iva;
        [Display(Name = "Monto pagado")]
        public double montoCancelado;
        [Display(Name = "Cámbio")]
        public double cambio;

        public Cobro()
        {
        }
    }
}
