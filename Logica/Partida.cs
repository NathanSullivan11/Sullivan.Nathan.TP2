using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Partida
    {
        private Stack<Carta> mazo;
        private Mesa mesa;
        private Jugador jugador1;
        private Jugador jugador2;      
        private Jugador jugadorActual;
        private Jugador hayGanador;
        private Jugador ganadorMano;
        private int bazasJugadas;
        private int manosJugadas;
        private int bazasPardadas;
        private bool trucoNoQuerido;
        private bool seJugoTruco;
        private bool seJugoEnvido;
        private bool trucoCantado;
        private int puntajeParaGanar;
        private int puntosDelTruco;
        private bool partidaFinalizada;

        public event Action<string> actualizarLog;
        public event Action<string,bool> enviarMensaje;
        public event Action<int, int> actualizarPuntaje;
        public event Action<Carta,bool> repartirCarta;
        public event Action<Carta, bool> enviarCarta;
        public event Func<string> pedirJugadaUsuario;
        public event Action manoTerminada;
        public event Action partidaTerminada;

        public Jugador JugadorMano
        {
            get
            { 
                if(this.jugador1.EsMano)
                {
                    return jugador1;
                }
                else
                {
                    return jugador2;
                }
            }
        }

        public Jugador JugadorPie
        {
            get
            {
                if (this.jugador1.EsMano)
                {
                    return jugador2;
                }
                else
                {
                    return jugador1;
                }
            }
        }

        public Jugador ObtenerQuienGanoPrimera()
        {
            int resultado = Juego.CompararCartas(this.mesa.cartasTiradasPorJ1[0], this.mesa.cartasTiradasPorJ2[0]);
            if (resultado == 1)
            {
                return this.jugador1;
            } 
            else if(resultado == -1)
            {
                return this.jugador2;
            }
            else
            {
                return null;
            }
        }

        public Jugador ObtenerOponente(Jugador jugador)
        {           
            if (this.jugador1.Equals(jugador))
            {
                return this.jugador2;
            }
            else
            {
                return this.jugador1;
            }           
        }

        public Jugador ObtenerUsuario()
        {
            if(this.jugador1.EsUsuario)
            {
                return this.jugador1;
            }
            else
            {
                return this.jugador2;
            }
        }

        public bool SeJugoTruco { get => seJugoTruco; set => seJugoTruco = value; }
        public bool SeJugoEnvido { get => seJugoEnvido; set => seJugoEnvido = value; }
        public Jugador HayGanador { get => hayGanador; set => hayGanador = value; }
        public Jugador Jugador1 { get => jugador1; set => jugador1 = value; }
        public Jugador Jugador2 { get => jugador2; set => jugador2 = value; }
        public bool PartidaFinalizada { get => partidaFinalizada; set => partidaFinalizada = value; }
        public int ManosJugadas { get => manosJugadas; set => manosJugadas = value; }

        public Partida(Jugador jugador1, Jugador jugador2)
        {
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;
            this.hayGanador = null;
            this.puntajeParaGanar = 4;
            this.mesa = new Mesa();

        }

        public void ComenzarPartida(CancellationToken token)
        {
            this.InicializarPartida();
            
            do
            {
                this.JugarMano(JugadorMano, JugadorPie);

            } while (this.hayGanador is null && !token.IsCancellationRequested);

      
            this.partidaTerminada.Invoke();

            this.TerminarPartida();
        }

        private void TerminarPartida()
        {
            this.ActualizarEstadisticasJugadores();
            if(this.actualizarLog is not null)
            {
                this.actualizarLog.Invoke($"\nGANADOR J{this.hayGanador.Puntaje} - {this.hayGanador.Nombre} ");

            }
            this.partidaFinalizada = true;
            this.jugador1.EstaJugando = false;
            this.jugador2.EstaJugando = false;
            Juego.ActualizarJugadorEnBaseDeDatos(jugador1);
            Juego.ActualizarJugadorEnBaseDeDatos(jugador2);


        }

        private void ActualizarEstadisticasJugadores()
        {
            this.jugador1.PartidasJugadas++;
            this.jugador2.PartidasJugadas++;

            if (this.hayGanador is null)
            {
                if (this.jugador1.Puntaje > this.jugador2.Puntaje)
                {
                    this.hayGanador = this.jugador1;
                }
                else if (this.jugador1.Puntaje < this.jugador2.Puntaje)
                {
                    this.hayGanador = this.jugador2;
                }
                else
                {
                    this.hayGanador = this.jugador1;
                }
            }
            this.hayGanador.PartidasGanadas++;
            this.ObtenerOponente(this.hayGanador).PartidasPerdidas++;
        }

        private void LimpiarMesa()
        {
            this.mesa.cartasTiradasPorJ1.Clear();
            this.mesa.cartasTiradasPorJ2.Clear();
        }

        private void InicializarPartida()
        {
            this.jugador1.EstaJugando = true;
            this.jugador2.EstaJugando = true;

            this.jugador2.Puntaje = 0;
            this.jugador1.Puntaje = 0;

            this.jugador1.EsMano = true;
            this.jugador2.EsMano = false;

            this.LimpiarMesa();
        }

        private void CambiarMano()
        {
            this.jugador1.EsMano = !this.jugador1.EsMano;
            this.jugador2.EsMano = !this.jugador2.EsMano;
        }

        private void JugarMano(Jugador mano, Jugador pie)
        {
            this.ReiniciarParaNuevaMano();
            this.jugadorActual = mano;
            if (this.actualizarLog is not null)
            {
                this.actualizarLog.Invoke($"\n======= Mano {this.manosJugadas + 1} =======");
            }
            this.RepartirCartas(mano, pie);
            
            do
            {
                this.JugarUnaBaza();
                
            } while (!this.trucoNoQuerido && this.AlguienGanoLaMano() is null && this.bazasJugadas < 3);

            this.FinalizarMano();
            if(this.manoTerminada is not null)
            {
                this.manoTerminada.Invoke();
            }
            

        }

        private void FinalizarMano()
        {
            this.SumarPuntos(this.ganadorMano, puntosDelTruco);

            if (this.actualizarLog is not null)
            {
                this.actualizarLog.Invoke($"\nJ1: {this.jugador1.Puntaje}\nJ2:{this.jugador2.Puntaje}");         
            }
            this.manosJugadas++;
            this.CambiarMano();
        }

        private void ReiniciarParaNuevaMano()
        {
            this.bazasJugadas = 0;
            this.bazasPardadas = 0;
            this.seJugoEnvido = false;
            this.seJugoTruco = false;
            this.ganadorMano = null;
            this.jugador1.BazasGanadas = 0;
            this.jugador2.BazasGanadas = 0;
            this.puntosDelTruco = 1;
            this.trucoNoQuerido = false;
            this.LimpiarMesa();
        }


        private Jugador AlguienGanoLaMano()
        {          
            if (this.jugador1.BazasGanadas == 2 || this.bazasPardadas == 2 && this.jugador1.BazasGanadas == 1 || this.bazasPardadas == 1 && this.bazasJugadas == 2 && this.jugador1.BazasGanadas == 1)
            {
                this.ganadorMano = jugador1;
                return jugador1;
            }
            else if(this.jugador2.BazasGanadas == 2 || this.bazasPardadas == 2 && this.jugador2.BazasGanadas == 1 || this.bazasPardadas == 1 && this.bazasJugadas == 2 && this.jugador2.BazasGanadas == 1)
            {
                this.ganadorMano = jugador2;
                return jugador2;
            }
            else if (this.bazasPardadas == 3)
            {
                this.ganadorMano = this.JugadorMano; 
                return this.JugadorMano;  
            }
            else if (this.bazasJugadas == 3 && this.bazasPardadas == 1)
            {
                this.ganadorMano = this.ObtenerQuienGanoPrimera();
                return this.ganadorMano;
            }

            return null;
        }


        private void JugarUnaBaza()
        {
            if(!this.JugarTurno(this.jugadorActual))
            {
                return;
            }
            if (!this.JugarTurno(this.jugadorActual))
            {
                return;
            }
            Thread.Sleep(1000);
            this.CompararBaza();
            this.bazasJugadas++;

        }

        private void CompararBaza()
        {

            switch (Juego.CompararCartas(this.mesa.cartasTiradasPorJ1[this.bazasJugadas], this.mesa.cartasTiradasPorJ2[this.bazasJugadas]))
            {
                case 1:
                    if (this.actualizarLog is not null)
                    {
                        Thread.Sleep(200);
                        this.actualizarLog.Invoke($"\nJ1: Gana con {this.mesa.cartasTiradasPorJ1[this.bazasJugadas].ToString()}");
                        
                    }
                    this.jugadorActual = this.jugador1;
                    this.jugador1.BazasGanadas++;
                    break;
                case -1:
                    if (this.actualizarLog is not null)
                    {
                        Thread.Sleep(200);
                        this.actualizarLog.Invoke($"\nJ2: Gana con {this.mesa.cartasTiradasPorJ2[this.bazasJugadas].ToString()}");
                    }
                    this.jugadorActual = this.jugador2;
                    this.jugador2.BazasGanadas++;               
                    break;
                case 0:
                    if (this.actualizarLog is not null)
                    {
                        Thread.Sleep(200);
                        this.actualizarLog.Invoke($"\nParda: {this.mesa.cartasTiradasPorJ1[this.bazasJugadas].ToString()} = {this.mesa.cartasTiradasPorJ2[this.bazasJugadas].ToString()}");
                    }
                    if (this.bazasPardadas == 2)              
                    {
                        this.ganadorMano = this.JugadorMano;
                    }
                    this.bazasPardadas++; 
                    break;
            }
        }

        private bool JugarTurno(Jugador jugador)
        {
            if (jugador.EsUsuario)
            {
                this.JugarTurnoUsuario(jugador);
            }
            else
            {
                this.JugarTurnoMaquina(jugador);             
            }
       
            if(this.trucoNoQuerido)
            {
                return false;
            }

            this.jugadorActual = this.ObtenerOponente(jugadorActual);
            return true;
        }

        private bool SumarPuntos(Jugador jugador, int puntos)
        {
            jugador.Puntaje += puntos;
            if(jugador.Puntaje >= this.puntajeParaGanar)
            {
                this.hayGanador = jugador;
                if (this.actualizarPuntaje is not null)
                {
                    this.actualizarPuntaje.Invoke(this.jugador1.Puntaje, this.jugador2.Puntaje);
                }
                return true;
            }
            if(this.actualizarPuntaje is not null)
            {
                this.actualizarPuntaje.Invoke(this.jugador1.Puntaje, this.jugador2.Puntaje);
            }
            return false;
        }


        private void JugarTurnoMaquina(Jugador jugador)
        {
            Thread.Sleep(500);
            if (bazasJugadas == 0 && !this.seJugoEnvido)
            {
                Thread.Sleep(500);
                this.MaquinaCantarEnvido(jugador);
            }
            else if (!this.seJugoTruco)
            {
                Thread.Sleep(500);
                this.MaquinaCantarTruco(jugador); // Puede cantar
                if (trucoNoQuerido)
                {
                    return;
                }
            }

            this.EvaluarCartaATirar(jugador);

            Carta cartaTirada = jugador.DelegadoTiradoCarta.Invoke();

            if (this.actualizarLog is not null)
            {
                Thread.Sleep(200);
                this.actualizarLog.Invoke($"\nJ{jugador.IdJugador}: {cartaTirada.ToString()}");
            }
            if(jugador.IdJugador == jugador1.IdJugador )
            {
                this.mesa.cartasTiradasPorJ1.Add(cartaTirada);
            }
            else if (jugador.IdJugador == jugador2.IdJugador)
            {
                this.mesa.cartasTiradasPorJ2.Add(cartaTirada);
            }
            if(this.enviarCarta is not null)
            {
                this.enviarCarta(cartaTirada, false);
            }
        }

        private void MaquinaCantarTruco(Jugador maquina)
        {
            if (maquina.CantarTruco())
            {
                this.JugarTruco(maquina);
               
            }
        }

        private void MaquinaCantarEnvido(Jugador maquina)
        {            
            if (maquina.CantarEnvido())
            {
                 this.JugarEnvido(maquina);                   
            }
        }

        private void EvaluarCartaATirar(Jugador jugador)
        {
            if (bazasJugadas == 1 && jugador.BazasGanadas == 0 || bazasJugadas == 2 && jugador.BazasGanadas == 1)
            {
                jugador.DelegadoTiradoCarta = jugador.TirarCartaMasAlta;
            }
            else
            {
                jugador.DelegadoTiradoCarta = jugador.TirarCartaMasBaja;
            }
        }

        private void JugarTurnoUsuario(Jugador jugador)
        {
            if(this.pedirJugadaUsuario is not null)
            {
                string jugada = this.pedirJugadaUsuario.Invoke();
                switch(jugada)
                {
                    case "TRUCO":
                        if(!seJugoTruco)
                        {
                            if(this.JugarTruco(jugador))
                            {
                                this.JugarTurnoUsuario(jugador);
                            }
                        }                       
                        break;
                    case "ENVIDO":
                        if (!seJugoEnvido)
                        {
                            this.JugarEnvido(jugador);
                            this.JugarTurnoUsuario(jugador);
                        }                       
                        break;
                    case "MAZO":
                        this.ganadorMano = this.ObtenerOponente(jugador);
                        this.trucoNoQuerido = true;
                        break;
                    default:
                        foreach(Carta item in jugador.CartasEnMano)
                        {
                            if(item.ToString() == jugada)
                            {
                                if (this.actualizarLog is not null)
                                {
                                Thread.Sleep(200);
                                this.actualizarLog.Invoke($"\nJ{jugador.IdJugador}: {item.ToString()}");

                                }
                                jugador.TirarCarta(item);
                                this.mesa.cartasTiradasPorJ1.Add(item);
                                if (this.enviarCarta is not null)
                                {
                                    this.enviarCarta(item, true);
                                }
                                break;
                            }
                        }
                        break;
                }
            }           
        }

        private bool JugarTruco(Jugador jugadorQueCanta)
        {
            this.seJugoTruco = true;
            this.trucoCantado = true;
            if (this.enviarMensaje is not null)
            {
                this.enviarMensaje.Invoke("TRUCO", jugadorQueCanta.EsUsuario);               
            }
            if (this.actualizarLog is not null)
            {
            Thread.Sleep(200);
            this.actualizarLog.Invoke($"\nJ{jugadorQueCanta.IdJugador}: TRUCO");


            }
            if (!ObtenerOponente(jugadorQueCanta).ResponderTruco())
            {
                if (this.enviarMensaje is not null)
                {
                    Thread.Sleep(500);
                    this.enviarMensaje.Invoke("No quiero", false);
                    Thread.Sleep(500);
                }
                if (this.actualizarLog is not null)
                {
                Thread.Sleep(200);
                this.actualizarLog.Invoke($"\nJ{ObtenerOponente(jugadorQueCanta).IdJugador}: No quiero");


                }
                this.ganadorMano = jugadorQueCanta;
                this.trucoNoQuerido = true;
                return false;
            }
            else
            {
                if (this.enviarMensaje is not null)
                {
                    Thread.Sleep(500);
                    this.enviarMensaje.Invoke("Quiero", false);
                }
                if (this.actualizarLog is not null)
                {

                Thread.Sleep(200);
                this.actualizarLog.Invoke($"\nJ{ObtenerOponente(jugadorQueCanta).IdJugador}: Quiero");
                }
                this.puntosDelTruco = 2;
                return true;
            }
        }

        private bool JugarEnvido(Jugador jugador)
        {
            this.seJugoEnvido = true;
            if (this.enviarMensaje is not null)
            {
                this.enviarMensaje.Invoke("ENVIDO", jugador.EsUsuario);
            }
            if (this.actualizarLog is not null)
            {
                Thread.Sleep(200);
                this.actualizarLog.Invoke($"\nJ{jugador.IdJugador}: ENVIDO");
            }
            if (this.ObtenerOponente(jugador).ResponderEnvido())
            {
                if (this.enviarMensaje is not null)
                {
                    Thread.Sleep(500);
                    this.enviarMensaje.Invoke("Quiero", !jugador.EsUsuario);                
                    Thread.Sleep(500);
                }
                if (this.actualizarLog is not null)
                {
                    Thread.Sleep(200);
                    this.actualizarLog.Invoke($"\nJ{this.ObtenerOponente(jugador).IdJugador}: Quiero");
                }
                this.CompararEnvido(jugador);
                return true;                
            }
            else
            {
                if(this.enviarMensaje is not null)
                {
                    Thread.Sleep(500);
                    this.enviarMensaje.Invoke("No quiero", !jugador.EsUsuario);
                    Thread.Sleep(1000);
                }
                if (this.actualizarLog is not null)
                {
                    Thread.Sleep(200);
                    this.actualizarLog.Invoke($"\nJ{this.ObtenerOponente(jugador).IdJugador}: No quiero");
                }
                this.SumarPuntos(jugador, 1);
                return false;                
            }
        }

        private void CompararEnvido(Jugador jugadorQueCanto)
        {
            Jugador jugadorQueResponde = this.ObtenerOponente(jugadorQueCanto);
            int envidoDelQueCanto = jugadorQueCanto.CalcularEnvido();
            int envidoDelQueRespondio = jugadorQueResponde.CalcularEnvido();
            
            if (this.enviarMensaje is not null)
            {
                Thread.Sleep(500);
                this.enviarMensaje.Invoke($"Tengo {envidoDelQueCanto}", jugadorQueCanto.EsUsuario);
            }
            if (this.actualizarLog is not null)
            {

            Thread.Sleep(200);
            this.actualizarLog.Invoke($"\nJ{jugadorQueCanto.IdJugador}: {envidoDelQueCanto}");
            }

            switch (Juego.CompararEnvido(envidoDelQueCanto, envidoDelQueRespondio))
            {
                case 1:
                    if (this.enviarMensaje is not null)
                    {
                        Thread.Sleep(500);
                        this.enviarMensaje.Invoke($"Son buenas", jugadorQueResponde.EsUsuario);
                        Thread.Sleep(500);
                    }
                    if (this.actualizarLog is not null)
                    {

                    Thread.Sleep(200);
                    this.actualizarLog.Invoke($"\nJ{jugadorQueCanto.IdJugador}: Son buenas");
                    }

                    this.SumarPuntos(jugadorQueCanto, 2);
                    break;
                case -1:
                    if (this.enviarMensaje is not null)
                    {
                        Thread.Sleep(500);
                        this.enviarMensaje.Invoke($"{envidoDelQueRespondio} son mejores", jugadorQueResponde.EsUsuario);
                        Thread.Sleep(500);
                    }
                    if (this.actualizarLog is not null)
                    {

                    Thread.Sleep(200);
                    this.actualizarLog.Invoke($"\nJ{jugadorQueResponde.IdJugador}: {envidoDelQueRespondio} son mejores");
                    }
                    this.SumarPuntos(this.ObtenerOponente(jugadorQueCanto), 2);
                    break;
                case 0:
                    if (this.enviarMensaje is not null)
                    {
                        this.enviarMensaje.Invoke($"{envidoDelQueRespondio}", jugadorQueResponde.EsUsuario);
                        Thread.Sleep(500);
                        this.enviarMensaje.Invoke($"Ganó yo porque soy mano", this.JugadorMano.EsUsuario);
                        Thread.Sleep(500);
                    }
                    if (this.actualizarLog is not null)
                    {

                    Thread.Sleep(200);
                    this.actualizarLog.Invoke($"J{jugadorQueResponde.IdJugador}: {envidoDelQueRespondio}");
                    Thread.Sleep(200);
                    this.actualizarLog.Invoke($"\nGana {this.JugadorMano.IdJugador} porque es mano");
                    }
                    this.SumarPuntos(JugadorMano, 2);
                    break;
            }
        }



        public void RepartirCartas(Jugador mano, Jugador pie)
        {
            mano.VaciarCartasEnMano();
            pie.VaciarCartasEnMano();
            this.ActualizarMazo();

            for (int i = 0; i < 3; i++)
            {
                Carta cartaRecibidaPorMano = this.mazo.Pop();
                mano.RecibirCarta(cartaRecibidaPorMano);       
                Thread.Sleep(200);
                if(this.repartirCarta is not null)
                {
                    this.repartirCarta.Invoke(cartaRecibidaPorMano, mano.EsUsuario);
                }       
                Carta cartaRecibidaPorpie = this.mazo.Pop();
                pie.RecibirCarta(cartaRecibidaPorpie);
                Thread.Sleep(200);
                if (this.repartirCarta is not null)
                {
                    this.repartirCarta.Invoke(cartaRecibidaPorpie, pie.EsUsuario);
                }
            }
            if(this.actualizarLog is not null)
            {
                this.actualizarLog.Invoke($"\nJ{pie.IdJugador}: {pie.CartasEnMano[0].ToString()} { pie.CartasEnMano[1].ToString()} { pie.CartasEnMano[2].ToString()}");
                this.actualizarLog.Invoke($"\nJ{mano.IdJugador}: {mano.CartasEnMano[0].ToString()} { mano.CartasEnMano[1].ToString()} { mano.CartasEnMano[2].ToString()}");
            }

        }

        private void ActualizarMazo()
        {
            this.mazo = Juego.ObtenerMazoMezclado();
        }
    }
}
