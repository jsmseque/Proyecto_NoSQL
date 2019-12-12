using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Logic.Conexion;
using Proyecto.Logic.Utilitarias;
using Proyecto.Model.MisModelos;

namespace Proyecto_NoSQL.Controllers
{
    public class CobroController : Controller
    {
        // GET: Cobro
        public ActionResult Index()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Index(Cobro factura)
        {
            try
            {

                var laConexion = new Clientes();
                Cliente cliente = laConexion.FindClienteDocument("proyectoDb", "clientes_bson", factura.cedula);


                if (cliente != null)
                {
                    double impuestos = (factura.iva / 100) * factura.valor;
                    double total = factura.valor + impuestos;
                    double cambio =  factura.montoCancelado- total ;
                    CorreoElectronico.EnviarEmail(cliente.Nombre + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido, cliente.Email,
                        "Información de factura:\n" +
                        "Cédula:" + cliente.Cedula + "\n" +
                        "Descripción: " + factura.descripcion + "\n" +
                        "Costo del sercio= ¢" + factura.valor + "\n" +
                       "IVA(" + factura.iva +"%) = ¢" + impuestos + "\n" +
                       "Total= ¢" +  total + "\n" +
                       "Método de Pago: ¢" + factura.medioPago + "\n" +
                       "Monto Cancelado= ¢" + factura.montoCancelado + "\n" +
                       "Cambio= ¢" + cambio
                       );
         

                   // ViewBag.mensaje = "Nueva factura";
                    return RedirectToAction("Index");     
                }
                else
                {
                    ViewBag.mensaje = "Usuario no registrado";
                    return View(factura);
                }

               
            }
            catch
            {
                return View(factura);
            }
        }

    }
}