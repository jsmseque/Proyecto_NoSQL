using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logic.Conexion
{
    public class Clientes
    {
        public async Task Insert<T>(T[] clientes, string dbName, string tableName)
        {
            var laConexion = new BdMongo();
            var db = laConexion.GetDatabaseReference("localhost", dbName);
            var clientesCollection = db.GetCollection<T>(tableName);
            await clientesCollection.InsertManyAsync(clientes);
        }


        public async static void FindClientesAsDocuments(string dbName, string collName)
        {
            var db = DatabaseHelper.GetDatabaseReference("localhost", dbName);
            var collection = db.GetCollection<BsonDocument>(collName);
            var filter = new BsonDocument();
            int count = 0;
            using (var cursor = await collection.FindAsync<BsonDocument>(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        var clienteName = document.GetElement("name").Value.ToString(
                        );
                        Console.WriteLine("Clientes Name: {0}", clienteName);
                        count++;
                    }
                }
            }
        }

        public static void UpdateClientes(string dbName, string collName)
        {
            var db = DatabaseHelper.GetDatabaseReference("localhost", dbName);
            var collection = db.GetCollection<Clientes>(collName);
            var builder = Builders<Clientes>.Filter;
            var filter = builder.Eq("name", "Nombre");
            var update = Builders<Clientes>.Update
             .Set("name", "new name")
             .Set(d => d.Year, 1900);
            UpdateResult result = collection.UpdateOne(filter, update);
            Console.WriteLine(result.ToBsonDocument());
        }

        var collection = db.GetCollection<Clientes>(collName);
        DeleteResult result = await collection.DeleteOneAsync(m => m.Name == "The Seven Samurai");



}
}
