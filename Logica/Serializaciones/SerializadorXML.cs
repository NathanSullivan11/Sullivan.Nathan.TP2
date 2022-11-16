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
        XmlSerializer xmlSerializer;

        public SerializadorXML()
        {
            ruta = Environment.CurrentDirectory;
            ruta += "\\ArchivosXML";
        }
        
        public bool Serializar(T datos, string nombreArchivo)
        {
            bool retorno = false;
            string rutaCompleta = ruta + "\\" + nombreArchivo + ".xml";         
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                using (StreamWriter streamWriter = new StreamWriter(rutaCompleta))
                {
                    this.xmlSerializer = new XmlSerializer(typeof(T));

                    this.xmlSerializer.Serialize(streamWriter, datos);
                }
                retorno = true;
            }
            catch (Exception )
            {
                throw new Exception($"No se ha podido serializar en xml datos del tipo {typeof(T).ToString()}");
            }
            return retorno;
            
        }

        public T Deserializar(string nombreArchivo)
        {
            T datos = default;

            string rutaCompleta = ruta + @"\\" + nombreArchivo + ".xml";
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                using (StreamReader streamReader = new StreamReader(rutaCompleta))
                {
                    this.xmlSerializer = new XmlSerializer(typeof(T));
                    datos = (T)xmlSerializer.Deserialize(streamReader);
                }
            }
            catch (Exception)
            {
                throw new Exception($"No se ha podido deserializar en xml los datos de tipo {typeof(T).ToString()}");
            }

            return datos;
        }
    }
}
