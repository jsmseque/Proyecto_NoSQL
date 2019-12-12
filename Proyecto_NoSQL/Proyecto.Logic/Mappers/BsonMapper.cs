using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using Proyecto.Model.MisModelos;


namespace Proyecto.Logic.Mappers
{
    class BsonMapper
    {
        public void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Cliente)))
            {
                BsonClassMap.RegisterClassMap<Cliente>(
                    cliente =>
                {
                    cliente.MapIdProperty(p => p.ClienteId).SetIdGenerator(new StringObjectIdGenerator());
                    cliente.MapProperty(p => p.Cedula).SetElementName("cedula");
                    cliente.MapProperty(p => p.Nombre).SetElementName("nombre");
                    cliente.MapProperty(p => p.PrimerApellido).SetElementName("primerApellido");
                    cliente.MapProperty(p => p.SegundoApellido).SetElementName("segundoApellido");
                    cliente.MapProperty(p => p.Telefonos).SetElementName("telefonos");
                    cliente.MapProperty(p => p.Email).SetElementName("email");
                    cliente.MapProperty(p => p.Direccion).SetElementName("direccion");          
                    cliente.SetIgnoreExtraElements(true);
                });
            }
            if (!BsonClassMap.IsClassMapRegistered(typeof(Telefono)))
            {
                BsonClassMap.RegisterClassMap<Telefono>
                    (telefono =>
                    {
                        telefono.MapProperty(p => p.Tipo).SetElementName("tipo");
                        telefono.MapProperty(p => p.Numero).SetElementName("numero");
                    });
            }
            if (!BsonClassMap.IsClassMapRegistered(typeof(Direccion)))
            {
                BsonClassMap.RegisterClassMap<Direccion>
                    (direccion =>
                    {
                        direccion.MapProperty(p => p.Pais).SetElementName("pais");
                        direccion.MapProperty(p => p.Provincia).SetElementName("provincia");
                        direccion.MapProperty(p => p.Canton).SetElementName("canton");
                        direccion.MapProperty(p => p.Distrito).SetElementName("distrito");
                    });
            }
        } 
    }
}
