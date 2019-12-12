using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using Proyecto.Logic.Conexion;
using Proyecto.Model.MisModelos;

namespace Proyecto_NoSQL.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ///Cliente clientes;
            ///

            var laConexion = new Clientes();
            List<Cliente> clientes = new List<Cliente>();
            clientes = laConexion.FindClientesAsDocuments("proyectoDb", "clientes_bson");


            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var laConexion = new Clientes();
            Cliente cliente = laConexion.FindClienteDocument("proyectoDb", "clientes_bson", id);
          
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente,string tipoTef,string numeroTef)
        {
            if (cliente != null)
            {
                try
                {
                    List<Telefono> nuevosTelef = new List<Telefono>();
                    Telefono[] telefonoExistentes = cliente.Telefonos;
                    if (telefonoExistentes!=null)
                    {
                        List<Telefono> telefonoExistentesList = telefonoExistentes.ToList();
                        nuevosTelef = telefonoExistentesList;
                        nuevosTelef.Add(new Telefono(tipoTef, numeroTef));
                    }
                    else
                    {
                        nuevosTelef.Add(new Telefono(tipoTef, numeroTef));
                    }

                    cliente.Telefonos= nuevosTelef.ToArray();

                     BsonDocument[] clienteNuevo = new BsonDocument[] { cliente.ToBsonDocument() };

                    var laConexion = new Clientes();
                    laConexion.Insert<BsonDocument>(clienteNuevo, "proyectoDb", "clientes_bson");

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else { return View(); }

        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var laConexion = new Clientes();
            Cliente cliente = laConexion.FindClienteDocument("proyectoDb", "clientes_bson", id);
            TempData["telefonos"]=cliente.Telefonos;
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente, string tipoTef, string numeroTef)
        {
            try
            {
                
                List<Telefono> nuevosTelef = new List<Telefono>();
                Telefono[] telefonoExistentes = (Telefono[])TempData["telefonos"];
                if (telefonoExistentes != null)
                {
                    List<Telefono> telefonoExistentesList = telefonoExistentes.ToList();
                    nuevosTelef = telefonoExistentesList;
                    nuevosTelef.Add(new Telefono(tipoTef, numeroTef));
                }
                else
                {
                    nuevosTelef.Add(new Telefono(tipoTef, numeroTef));
                }

                cliente.Telefonos = nuevosTelef.ToArray();

                var laConexion = new Clientes();
                laConexion.UpdateClientes("proyectoDb", "clientes_bson", id,cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var laConexion = new Clientes();
            Cliente cliente = laConexion.FindClienteDocument("proyectoDb", "clientes_bson", id);
                
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Cliente cliente)
        {
            try
            {
                
                var laConexion = new Clientes();
                laConexion.DeleteClientesDocument("proyectoDb", "clientes_bson",id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
