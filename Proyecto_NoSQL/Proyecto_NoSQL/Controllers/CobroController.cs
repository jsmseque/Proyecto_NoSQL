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

                   CorreoElectronico.EnviarEmail(cliente.Nombre + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido, cliente.Email,"Información de factura");
         

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