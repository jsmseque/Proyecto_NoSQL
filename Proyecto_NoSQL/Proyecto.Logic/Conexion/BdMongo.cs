using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Proyecto.Logic.Conexion
{
    class BdMongo
    {

        public void ConnectWithoutAuthentication()
        {
            var defaultConnectionString = Properties.Settings.Default.DefaultConnectionString;

            string connectionString = string.Format(defaultConnectionString, "localhost");
            var client = new MongoClient(connectionString);
        }

        public void ConnectWithAuthentication(string dbName = "ecommlight", string userName = "some_user", string password = "pwd")
        {
            var defaultPort = Properties.Settings.Default.DefaultPort;
            var defaultServer = Properties.Settings.Default.DefaultServer;
            var credentials = MongoCredential.CreateCredential(dbName, userName, password);
            var clientSettings = new MongoClientSettings()
            {
                Credentials = new[] { credentials },
                Server =
                new MongoServerAddress(defaultServer, defaultPort)
            };
            var client = new MongoClient(clientSettings);
            Console.WriteLine("Connected as {0}", userName);
        }

        public MongoClient GetMongoClient(string hostName)
        {
            var defaultConnectionString = Properties.Settings.Default.DefaultConnectionString;
            string connectionString = string.Format
                (defaultConnectionString, hostName);
            return new MongoClient(connectionString);
        }
        // comentario
        /// <summary>
        /// Crear la conexión con la base de datos hospedada en un servidor particular.
        /// </summary>
        /// <param name="hostName">Es el nombre del servidor que hospeda la BD.</param>
        /// <param name="dbName">Es el nombre de la BD hospedada en el servidor</param>
        /// <returns>La conexión con la BD Mongo</returns>
        public IMongoDatabase GetDatabaseReference(string hostName, string dbName)
        {
            MongoClient client = GetMongoClient(hostName);
            IMongoDatabase database = client.GetDatabase(dbName);
            return database;
        }

        public IMongoDatabase CreateDatabase(string hostName, string databaseName, string collectionName)
        {
            var database = GetDatabaseReference(hostName, databaseName);
            database.CreateCollection(collectionName);
            return database;
        }


    }
}
