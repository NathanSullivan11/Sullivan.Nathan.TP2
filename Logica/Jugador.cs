using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Jugador
    {
        public delegate Carta DelegadoTirarCarta();
        private DelegadoTirarCarta delegadoTirarCarta;
        private List<Carta> cartasIniciales;
        private List<Carta> cartasEnMano;
        private Carta cartaTirada;
        private int puntaje;
        private bool esMano;
        private int bazasGanadas;
        private string nombre;
        private int numeroDeJugador;
        private int partidasJugadas;
        private int partidasGanadas;
        private int partidasPerdidas;
        private bool estaJugando;
        public int idBaseDeDatos;
        private bool esUsuario;
        public event Func<string, bool> obtenerRespuestaUsuario;

        public Jugador()
        {
            this.cartasIniciales = new List<Carta>(3);
            this.cartasEnMano = new List<Carta>(3);
            this.estaJugando = false;
            this.bazasGanadas = 0;
            this.puntaje = 0;
        }

        public Jugador(string nombre, int partidasJugadas, int partidasGanadas, int partidasPerdidas, bool esUsuario) : this()
        {
            this.nombre = nombre;
            this.partidasJugadas = partidasJugadas;
            this.partidasGanadas = partidasGanadas;
            this.partidasPerdidas = partidasPerdidas;
            this.esUsuario = esUsuario;
        }

        public Jugador(int id, string nombre, int partidasJugadas, int partidasGanadas, int partidasPerdidas, bool esUsuario) : this(nombre, partidasJugadas, partidasGanadas, partidasPerdidas, esUsuario)
        {
            this.idBaseDeDatos = id;
        }


        public void RecibirCarta(Carta carta)
        {
            if (this.cartasIniciales.Count < 3)
            {
                this.cartasIniciales.Add(carta);
                this.cartasEnMano.Add(carta);
            }
        }

        public Carta TirarCartaRandom()
        {
            int indiceCartaRandom = new Random().Next(0, this.cartasEnMano.Count);
            this.cartaTirada = this.cartasEnMano[indiceCartaRandom];
            return this.cartaTirada;
            //return this.cartasEnMano[new Random().Next(0, CantidadCartasEnMano)];
        }
        /// <summary>
        /// Se fija si tiene una carta mejor a la del oponenta, sino tira la mas baja
        /// </summary>
        /// <param name="cartaDelOponente"></param>
        /// <returns></returns>
        public Carta TirarCartaEvaluando(Carta cartaDelOponente)
        {
            Carta cartaATirar;
            bool tengo = TengoCartaGanadora(cartaDelOponente, out cartaATirar);
            if (tengo == true && cartaATirar is not null)
            {
                this.cartaTirada = cartaATirar;
                this.EliminarCartaTiradaDeMano();
                return cartaATirar;
            }
            else
            {
                return TirarCartaMasBaja();
            }
        }

        public void EliminarCartaTiradaDeMano()
        {
            this.cartasEnMano.Remove(this.cartaTirada);
        }


        public bool TengoBuenaManoParaTruco()
        {
            bool cartaMejorQueUnTres = false;
            foreach (Carta carta in this.cartasEnMano)
            {
                if (carta.ValorJerarquico < 6)
                {
                    cartaMejorQueUnTres = true;
                }
            }
            return cartaMejorQueUnTres;
        }

        private bool TengoCartaGanadora(Carta cartaDelOponente, out Carta cartaGanadora)
        {
            bool tengoCartaGanadora = false;
            cartaGanadora = null;
            for (int i = 0; i < this.cartasEnMano.Count; i++)
            {
                if (this.cartasEnMano[i].ValorJerarquico < cartaDelOponente.ValorJerarquico)
                {
                    if (cartaGanadora is not null && this.cartasEnMano[i].ValorJerarquico > cartaGanadora.ValorJerarquico)
                    {
                        cartaGanadora = this.cartasEnMano[i];
                    }
                    cartaGanadora = this.cartasEnMano[i];
                    tengoCartaGanadora = true;
                }
            }
            return tengoCartaGanadora;
        }

        public Carta TirarCartaMasAlta()
        {
            Carta masAlta = null;
            for (int i = 0; i < this.cartasEnMano.Count; i++)
            {
                if (i == 0 || this.cartasEnMano[i].ValorJerarquico < masAlta.ValorJerarquico)
                {
                    masAlta = this.cartasEnMano[i];
                }
            }
            this.cartaTirada = masAlta;
            this.EliminarCartaTiradaDeMano();
            return masAlta;
        }

        public Carta TirarCartaMasBaja()
        {
            Carta masBaja = null;
            for (int i = 0; i < this.cartasEnMano.Count; i++)
            {
                if (i == 0 || this.cartasEnMano[i].ValorJerarquico > masBaja.ValorJerarquico)
                {
                    masBaja = this.cartasEnMano[i];
                }
            }
            this.cartaTirada = masBaja;
            this.EliminarCartaTiradaDeMano();
            return masBaja;
        }

        public void VaciarCartasEnMano()
        {
            this.cartasEnMano.Clear();
            this.cartasIniciales.Clear();
        }

        public string MostrarCartasEnMano()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Carta item in this.cartasEnMano)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }


        public List<Carta> CartasEnMano { get => this.cartasEnMano; }
        public int CantidadCartasEnMano { get => this.cartasEnMano.Count; }
        public string Nombre { get => this.nombre; }
        public int BazasGanadas { get => this.bazasGanadas; set => this.bazasGanadas = value; }
        public Carta CartaTirada { get => this.cartaTirada; set => this.cartaTirada = value; }


        public bool CantarEnvido()
        {
            return this.CalcularEnvido() > 24;
        }

        public bool ResponderEnvido()
        {
            if (this.esUsuario)
            {
                System.Threading.Thread.Sleep(500);
                return this.obtenerRespuestaUsuario.Invoke("ENVIDO");
            }
            int envido = this.CalcularEnvido();
            return envido > 24;
        }

        internal int DecirEnvido()
        {
            return this.CalcularEnvido();
        }

        public int CalcularEnvido()
        {
            int envidoCalculado = 0;
            EPalo paloRepetido;

            if (this.TengoDosCartasDelMismoPalo(out paloRepetido))
            {
                int cantidadCartasConPalosIguales = 0;
                int banderaFigura = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (cantidadCartasConPalosIguales == 2)
                    {
                        break;
                    }
                    else if (this.cartasIniciales[i].Palo == paloRepetido && banderaFigura != 1)
                    {
                        cantidadCartasConPalosIguales++;
                        if (!this.cartasIniciales[i].EsFigura())
                        {
                            envidoCalculado += this.cartasIniciales[i].Numero;
                        }
                        else
                        {
                            banderaFigura = 1;
                            envidoCalculado += 20;
                        }
                    }
                }
                if (banderaFigura == 0)
                {
                    envidoCalculado += 20;
                }
            }
            else
            {
                envidoCalculado = this.CartaConEnvidoMasAlto();
            }

            return envidoCalculado;

        }

        internal void TirarCarta(Carta carta)
        {
            this.cartaTirada = carta;
            this.EliminarCartaTiradaDeMano();
        }

        internal bool CantarTruco()
        {
            return this.TengoBuenaManoParaTruco();
        }

        internal bool ResponderTruco()
        {
            if (this.esUsuario)
            {
                return this.obtenerRespuestaUsuario.Invoke("TRUCO");
            }
            int random = new Random().Next(0, 2);
            bool respuesta = true;
            if (random == 0)
            {
                respuesta = false;
            }

            return respuesta;
        }

        internal int CartaConEnvidoMasAlto()
        {
            int mejorEnvido = 0;

            for (int i = 0; i < this.cartasIniciales.Count; i++)
            {
                if (!this.cartasIniciales[i].EsFigura())
                {
                    if (i == 0 || this.cartasIniciales[i].Numero > mejorEnvido)
                    {
                        mejorEnvido = this.cartasIniciales[i].Numero;
                    }
                }
            }

            return mejorEnvido;
        }

        public bool CartasSonDelMismoPalo(Carta carta1, Carta carta2)
        {
            return carta1.Palo == carta2.Palo;
        }

        internal bool TengoDosCartasDelMismoPalo(out EPalo palo)
        {
            bool tengoDosDelMismoPalo = false;
            palo = EPalo.Basto; // Inicializo para que no tire error
            List<Carta> cartas = this.cartasIniciales;
            if (this.CartasSonDelMismoPalo(this.cartasIniciales[0], this.cartasIniciales[1]) || this.CartasSonDelMismoPalo(this.cartasIniciales[0], this.cartasIniciales[2]))
            {
                palo = this.cartasIniciales[0].Palo;
                tengoDosDelMismoPalo = true;
            }
            else if (this.CartasSonDelMismoPalo(this.cartasIniciales[1], this.cartasIniciales[2]))
            {
                palo = this.cartasIniciales[1].Palo;
                tengoDosDelMismoPalo = true;
            }

            return tengoDosDelMismoPalo;
        }

        public override bool Equals(object obj)
        {
            if(obj is Jugador auxJugador)
            {
                return auxJugador.idBaseDeDatos == this.idBaseDeDatos;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{this.nombre} - Jugadas: {this.partidasJugadas} - Ganadas: {this.partidasGanadas} - Perdidas: {this.partidasPerdidas}";
        }

        public int Puntaje { get => this.puntaje; set => this.puntaje = value; }
        public DelegadoTirarCarta DelegadoTiradoCarta { get => delegadoTirarCarta; set => delegadoTirarCarta = value; }
        public int IdJugador { get => numeroDeJugador; set => numeroDeJugador = value; }
        public bool EsMano { get => esMano; set => esMano = value; }
        public int PartidasJugadas { get => partidasJugadas; set => partidasJugadas = value; }
        public int PartidasGanadas { get => partidasGanadas; set => partidasGanadas = value; }
        public int PartidasPerdidas { get => partidasPerdidas; set => partidasPerdidas = value; }
        public bool EstaJugando { get => estaJugando; set => estaJugando = value; }
        public bool EsUsuario { get => esUsuario; set => esUsuario = value; }

    }
}