using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegistroPartida
    {
        private int codigoPartida;
        private Jugador ganador;
        private Jugador perdedor;
        private int manosJugadas;

        public RegistroPartida(int codigoPartida, Jugador ganador, Jugador perdedor, int manosJugadas)
        {
            this.codigoPartida = codigoPartida;
            this.ganador = ganador;
            this.perdedor = perdedor;
            this.manosJugadas = manosJugadas;
        }
    }
}
