using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Proyecto.Model.MisModelos
{
    //[MetadataType(typeof(ClienteMetadata))]
    //[BsonIgnoreExtraElements]
   public class Cliente
    {
        public Cliente()
        {
        }

        /* public Cliente(string clienteId, int cedula, string nombre, string primerApellido, string segundoApellido, Telefono[] telefonos, string email, Direccion direccion)
         {
             ClienteId = clienteId;
             Cedula = cedula;
             Nombre = nombre;
             PrimerApellido = primerApellido;
             SegundoApellido = segundoApellido;
             Telefonos = telefonos;
             Email = email;
             Direccion = direccion;
         }*/

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]     
        public ObjectId ClienteId { get; set; }

        [BsonElement("cedula")]
        public int Cedula { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("primerApellido")]
        public string PrimerApellido { get; set; }

        [BsonElement("segundoApellido")]
        public string SegundoApellido { get; set; }

        [BsonElement("telefonos")]
        public Telefono[] Telefonos { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("direccion")]
        public Direccion Direccion { get; set; }

        //[BsonExtraElements]
        // public BsonDocument Metadata { get; set; }
    }

    public class Telefono
    {
        public Telefono()
        {
        }

        public string Tipo { get; set; }
        public string Numero { get; set; }
    }

    public class Direccion
    {
        public Direccion()
        {
        }

        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

    }

}
