using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface ISerializarDeserializar<T> where T : class, new()
    {
        bool Serializar(T datos, string nombreArchivo);

        T Deserializar(string nombreArchivo);
    }
}
