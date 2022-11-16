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
            ruta += "\\ArchivosJSON";
        }
        
        public bool Serializar(T datos, string nombreArchivo)
        {
            bool retorno = false;
            string rutaCompleta = ruta + "\\" + nombreArchivo + ".json";
            if(!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            try
            {
                string json = JsonSerializer.Serialize(datos);
                File.WriteAllText(rutaCompleta, json);
                retorno = true;
            }
            catch (Exception)
            {
                throw new Exception($"No se ha podido serializar en json datos del tipo {typeof(T).ToString()}");
            }
            return retorno;
        }

        public bool Serializar(T datos, string carpeta, string nombreArchivo)
        {
            bool retorno = false;
            string rutaMasCarpeta = ruta + "\\" + carpeta;
            string rutaCompleta = rutaMasCarpeta + "\\" + nombreArchivo + ".json";
            
            try
            {
                if (!Directory.Exists(rutaMasCarpeta))
                {
                    Directory.CreateDirectory(rutaMasCarpeta);
                }

                string json = JsonSerializer.Serialize(datos);
                File.WriteAllText(rutaCompleta, json);
                retorno = true;
            }
            catch (Exception )
            {
                throw new Exception($"No se ha podido serializar en json datos del tipo {typeof(T).ToString()}");
            }
            return retorno;
        }

        public T Deserializar(string nombreArchivo)
        {
            T datos = default;
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            string rutaCompleta = ruta + "\\" + nombreArchivo + ".json";

            try
            {
                string json = File.ReadAllText(rutaCompleta);
                datos = (T)JsonSerializer.Deserialize(json, typeof(T));

            }
            catch(Exception)
            {
                throw new Exception($"No se ha podido deserializar en json los datos de tipo {typeof(T).ToString()}");
            }

            return datos;
        }
    }
}
