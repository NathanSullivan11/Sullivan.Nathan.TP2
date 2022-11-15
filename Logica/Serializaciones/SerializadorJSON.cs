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
    public class SerializadorJSON<T> : ISerializarDeserializar<T> where T : class, new()
    {
        private string ruta;

        public SerializadorJSON()
        {
            ruta = Environment.CurrentDirectory;
            //ruta = @"C:\Users\Usuario\source\repos\Sullivan.Nathan.TP2\Vista\bin\Debug\net5.0-windows";
            ruta += @"/ArchivosJSON";
        }
        
        public void Serializar(T datos, string nombreArchivo)
        {
            string rutaCompleta = ruta + @"/" + nombreArchivo + ".json";
            if(!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            JsonSerializerOptions opciones = new JsonSerializerOptions()
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)},
            };
            string json = JsonSerializer.Serialize(datos);
            File.WriteAllText(rutaCompleta, json);
        }

        public T Deserializar(string nombreArchivo)
        {
            T datos = default;
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            string rutaCompleta = ruta + @"/" + nombreArchivo + ".json";

            try
            {
                string json = File.ReadAllText(rutaCompleta);
                datos = (T)JsonSerializer.Deserialize(json, typeof(T));

            }
            catch(Exception e)
            {

            }

            return datos;
        }
    }
}
