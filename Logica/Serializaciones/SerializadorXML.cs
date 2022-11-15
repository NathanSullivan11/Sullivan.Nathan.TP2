using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Entidades
{
    public class SerializadorXML<T> : ISerializarDeserializar<T> where T : class, new()
    {
        private string ruta;

        public SerializadorXML()
        {
            ruta = Environment.CurrentDirectory;
            ruta += @"/ArchivosXML";
        }
        
        public void Serializar(T datos, string nombreArchivo)
        {
          
        }

        public T Deserializar(string nombreArchivo)
        {
            T datos = default;

            return datos;
        }
    }
}
