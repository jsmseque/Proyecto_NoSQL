using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Logic.Conexion;
using ConsoleApp1.Utiles;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Creando la colección clientes.");
            var bdMongo = new BdMongo();
            bdMongo.CreateDatabase("localhost", "proyectoDb", "clientes_bson");
            var laInsercion = new InsertarCliente();
            laInsercion.InserteLosClientes();


        }
    }
}
