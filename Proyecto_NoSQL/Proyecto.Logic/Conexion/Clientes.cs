using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logic.Conexion
{
    class Clientes
    {
        public async Task Insert<T>(T[] clientes, string dbName, string tableName)
        {
            var laConexion = new BdMongo();
            var db = laConexion.GetDatabaseReference("localhost", dbName);
            var moviesCollection = db.GetCollection<T>(tableName);
            await moviesCollection.InsertManyAsync(clientes);
        }

    }
}
