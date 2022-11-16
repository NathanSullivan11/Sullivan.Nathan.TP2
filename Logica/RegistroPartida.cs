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
        private string fechaDeJuego;
        private string ganador;
        private string perdedor;
        private int manosJugadas;

        public RegistroPartida()
        {

        }

        public RegistroPartida(int codigoPartida, DateTime fechaDeJuego, string ganador, string perdedor, int manosJugadas) :this()
        {
            this.fechaDeJuego = fechaDeJuego.ToString();
            this.codigoPartida = codigoPartida;
            this.ganador = ganador;
            this.perdedor = perdedor;
            this.manosJugadas = manosJugadas;
        }

        public int CodigoPartida { get => codigoPartida; set => codigoPartida = value; }
        public string FechaDeJuego { get => fechaDeJuego; set => fechaDeJuego = value; }
        public string Ganador { get => ganador; set => ganador = value; }
        public string Perdedor { get => perdedor; set => perdedor = value; }
        public int ManosJugadas { get => manosJugadas; set => manosJugadas = value; }

        public override string ToString()
        {
            return $"Partida: {CodigoPartida} - Ganador: {ganador} - Perdedor: {perdedor}";
        }
    }
}
