using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ManejadorArchivoTxt
    {
        private static string ruta;

        static ManejadorArchivoTxt()
        {
            ruta = Environment.CurrentDirectory;
            ruta += @"/RegistroPartidas";
        }

        public static bool Escribir(string mensaje, string nombreArchivo)
        {
            bool retorno = false;
            string rutaCompleta = ruta + @$"/{nombreArchivo}" + ".txt";
            try
            {
                if(!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                using(StreamWriter sw = new StreamWriter(rutaCompleta))
                {
                    sw.WriteLine(mensaje);
                }
                retorno = true;
            }
            catch(Exception)
            {
                throw new Exception($"Error al abrir archivo {nombreArchivo}");
            }
            return retorno;
        }
    }
}
