using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ConsoleApp1.Utiles
{
    public class ClienteManager
    {
        public BsonDocument[] GetBsonClientes()
        {
            BsonDocument clienteUno = new BsonDocument()
        {
            { "cedula", 114090575 },
            { "nombre", "Johan" },
            { "primerApellido", "Sequeira" },
            { "segundoApellido", "Monge" },

            { "telefonos",
                new BsonArray {
                    new BsonDocument("tipo", "Personal"),
                    new BsonDocument("numero", "8942-2354") } },
              { "direccion",
                new BsonArray {
                    new BsonDocument("pais", "Costa Rica"),
                    new BsonDocument("provincia", "San José"),
                    new BsonDocument("canton", "Mora"),
                    new BsonDocument("distrito", "Tabarcia")
                } } };


            BsonDocument clienteDos = new BsonDocument()
        {
            { "cedula", 111222333 },
            { "nombre", "alguien" },
            { "primerApellido", "jimenez" },
            { "segundoApellido", "Mora" },

            { "telefonos",
                new BsonArray {
                    new BsonDocument("tipo", "Casa"),
                    new BsonDocument("numero", "2416-9654") } },
              { "direccion",
                new BsonArray {
                    new BsonDocument("pais", "Costa Rica"),
                    new BsonDocument("provincia", "San José"),
                    new BsonDocument("canton", "Santa Ana"),
                    new BsonDocument("distrito", "Río oro")
                } } };

            return new BsonDocument[] { clienteUno,clienteDos };
        }
    }
}
