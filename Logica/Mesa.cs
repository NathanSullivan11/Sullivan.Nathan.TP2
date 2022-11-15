using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mesa
    {
        public List<Carta> cartasTiradasPorJ1;
        public List<Carta> cartasTiradasPorJ2;

        public Mesa()
        {
            cartasTiradasPorJ1 = new List<Carta>();
            cartasTiradasPorJ2 = new List<Carta>();
        }
    }
}
