using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Proyecto.Logic.Conexion;
using Proyecto.Logic.Mappers;
using Proyecto.Model;

namespace ConsoleApp1.Utiles
{
    public class InsertarCliente
    {
        public void InserteLosClientes()
        {
            var losClientes = new ClienteManager();
            BsonDocument[] clientes = losClientes.GetBsonClientes();
            var laConexion = new Clientes();
            laConexion.Insert<BsonDocument>(clientes, "proyectoDb", "clientes_bson").Wait();
        }

    }
}
