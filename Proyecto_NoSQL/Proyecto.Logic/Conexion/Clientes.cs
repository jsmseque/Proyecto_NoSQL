using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Proyecto.Model.MisModelos;
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
       

        
        public  List<Cliente> FindClientesAsDocuments(string dbName, string collName)
        {
            var laConexion = new BdMongo();
            var db = laConexion.GetDatabaseReference("localhost", dbName);
           
        
            List<Cliente> clientes = new List<Cliente>();
            var filter = new BsonDocument();
            var collection = db.GetCollection<Cliente>(collName);
            using (var cursor =  collection.FindSync<BsonDocument>(filter))
            {
                while ( cursor.MoveNext())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        var myObj = BsonSerializer.Deserialize<Cliente>(document);
                        clientes.Add(myObj);                      
                    }
                }
            }
            return clientes;
        }

        
        public void UpdateClientes(string dbName, string collName,int id,Cliente cliente)
        {
            var laConexion = new BdMongo();
            var db = laConexion.GetDatabaseReference("localhost", dbName);
            // var collection = db.GetCollection<Cliente>(collName);
            //var collection = db.GetCollection<BsonDocument>(collName);

            var expresssionFilter = Builders<Cliente>.Filter.Eq(x => x.Cedula, id);
            var collection = db.GetCollection<Cliente>(collName);
            var builder = Builders<Cliente>.Filter;
            var filter = builder.Eq("cedula", id);
            var findclientes =  collection.Find(filter);
            var elCliente = findclientes.FirstOrDefault();
            var idAnterior = elCliente.ClienteId;
            cliente.ClienteId=idAnterior;


            collection.ReplaceOne(filter, cliente);
          

        }




        public  void DeleteClientesDocument(string dbName, string collName,int id)
        {
         
            var laConexion = new BdMongo();
            var db = laConexion.GetDatabaseReference("localhost", dbName);
            var collection = db.GetCollection<Cliente>(collName);

          
            DeleteResult result = collection.DeleteOne(m => m.Cedula== id );

            
        }


        public Cliente FindClienteDocument(string dbName, string collName, int id)
        {

            var laConexion = new BdMongo();
            var db = laConexion.GetDatabaseReference("localhost", dbName);
            var collection = db.GetCollection<Cliente>(collName);          
           var expresssionFilter = Builders<Cliente>.Filter.Eq(x => x.Cedula,id );

            Cliente cliente = new Cliente();
            using (var cursor = collection.FindSync<BsonDocument>(expresssionFilter))
            {
                while (cursor.MoveNext())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        var myObj = BsonSerializer.Deserialize<Cliente>(document);
                        cliente = myObj;
                    }
                }
            }

            return cliente;

        }

    }
}
