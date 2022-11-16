using System;
using System.Collections.Generic;
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
        private int puntajeParaGanar;
        private int puntosDelTruco;
        private bool partidaFinalizada;
        private bool partidaCancelada;
        private CancellationToken tokenCancelacion;

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
        
       
        #region Propiedades
        public bool SeJugoTruco { get => seJugoTruco; set => seJugoTruco = value; }
        public bool SeJugoEnvido { get => seJugoEnvido; set => seJugoEnvido = value; }
        public Jugador HayGanador { get => hayGanador; set => hayGanador = value; }
        public Jugador Jugador1 { get => jugador1; set => jugador1 = value; }
        public Jugador Jugador2 { get => jugador2; set => jugador2 = value; }
        public bool PartidaFinalizada { get => partidaFinalizada; set => partidaFinalizada = value; }
        public int ManosJugadas { get => manosJugadas; set => manosJugadas = value; }
        #endregion

        public Partida(Jugador jugador1, Jugador jugador2)
        {
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;
            this.hayGanador = null;
            this.puntajeParaGanar = 8;
            this.mesa = new Mesa();

        }

        public void ComenzarPartida(CancellationToken token)
        {
            this.tokenCancelacion = token;
            this.InicializarPartida();
            
            do
            {
                this.JugarMano(JugadorMano, JugadorPie);

            } while (this.hayGanador is null && !token.IsCancellationRequested);

            if(partidaCancelada)
            {
                return;
            }
            this.partidaTerminada.Invoke();

            this.TerminarPartida();
        }
        /// <summary>
        /// Invoca los métodos/Eventos para informar que se terminó la partida
        /// </summary>
        private void TerminarPartida()
        {
            this.ActualizarEstadisticasJugadores();
 
            this.actualizarLog?.Invoke($"\nGANÓ EL J{this.hayGanador.IdJugador}, {this.hayGanador.Nombre} ");

            this.partidaFinalizada = true;                     
            this.partidaTerminada.Invoke();
        }

        private void ActualizarEstadisticasJugadores()
        {
            this.jugador1.EstaJugando = false;
            this.jugador2.EstaJugando = false;
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
            Juego.ActualizarJugadorEnBaseDeDatos(jugador1);
            Juego.ActualizarJugadorEnBaseDeDatos(jugador2);

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

        public void CambiarMano()
        {
            this.jugador1.EsMano = !this.jugador1.EsMano;
            this.jugador2.EsMano = !this.jugador2.EsMano;
        }

        private void JugarMano(Jugador mano, Jugador pie)
        {
            this.ReiniciarParaNuevaMano();
            this.jugadorActual = mano;
           
           this.actualizarLog?.Invoke($"\n======= Mano {this.manosJugadas + 1} =======");
            
            this.RepartirCartas(mano, pie);
            
            do
            {
                this.JugarUnaBaza();
                
            } while (!this.partidaCancelada && !this.trucoNoQuerido && this.AlguienGanoLaMano() is null && this.bazasJugadas < 3);
           
            if(this.partidaCancelada)
            {
                return;
            }

            this.FinalizarMano();
            if(this.manoTerminada is not null)
            {
                this.manoTerminada.Invoke();
            }
            

        }
        /// <summary>
        /// Suma los puntos de la mano, y cambia el jugador mano y el jugador pie
        /// </summary>
        private void FinalizarMano()
        {
            this.SumarPuntos(this.ganadorMano, puntosDelTruco);
            this.actualizarLog?.Invoke($"\nJ1: {this.jugador1.Puntaje}\nJ2:{this.jugador2.Puntaje}");                    
            this.manosJugadas++;
            this.CambiarMano();
        }
        /// <summary>
        /// Reinicia los atributos necesarios para poder jugar una nueva mano
        /// </summary>
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

        /// <summary>
        /// Verifica si alguien gano la mano, evaluando todas las combinaciones. por ej; si pardo 1ra y gano 2da, si se pardaron las 3, etc.
        /// </summary>
        /// <returns></returns>
        public Jugador AlguienGanoLaMano()
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

        /// <summary>
        /// Juega una buza, un turno cada jugador y luego compara
        /// </summary>
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
        /// <summary>
        /// Compara a ver quien gano, perdio o si se pardo la baza
        /// </summary>
        private void CompararBaza()
        {
            if(this.partidaCancelada)
            { 
                return;
            }
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
        /// <summary>
        /// Juega un turno, si es usuario va a ejecutar otro código 
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Le suma los puntos al jugador, y luego verifica si llegó al puntaje necesario para ganar la partida
        /// </summary>
        /// <param name="jugador"></param>
        /// <param name="puntos"></param>
        /// <returns></returns>
        private bool SumarPuntos(Jugador jugador, int puntos)
        {
            jugador.Puntaje += puntos;
            if(jugador.Puntaje >= this.puntajeParaGanar)
            {
                this.hayGanador = jugador;

                this.actualizarPuntaje?.Invoke(this.jugador1.Puntaje, this.jugador2.Puntaje);
                
                return true;
            }

            this.actualizarPuntaje?.Invoke(this.jugador1.Puntaje, this.jugador2.Puntaje);
            
            return false;
        }

        /// <summary>
        /// La maquina juega un turno, si no se canto envido va evaluar si le conviene cantarlo, y lo mismo con truco
        /// </summary>
        /// <param name="jugador"></param>
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
            Thread.Sleep(200);
            this.actualizarLog?.Invoke($"\nJ{jugador.IdJugador}: {cartaTirada.ToString()}");
            this.AgregarCartaTiradaAMesaDeJuego(jugador, cartaTirada);
        }

        private void AgregarCartaTiradaAMesaDeJuego(Jugador jugador, Carta cartaTirada)
        {
            if (jugador.IdJugador == jugador1.IdJugador)
            {
                this.mesa.cartasTiradasPorJ1.Add(cartaTirada);
            }
            else if (jugador.IdJugador == jugador2.IdJugador)
            {
                this.mesa.cartasTiradasPorJ2.Add(cartaTirada);
            }
            if (this.enviarCarta is not null)
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
        /// <summary>
        /// La maquina evalua que carta le conviene tirar, dependiendo de las manos ganadas, jugadas o pardadas
        /// </summary>
        /// <param name="jugador"></param>
        private void EvaluarCartaATirar(Jugador jugador)
        {
            if (this.bazasJugadas == 1 && jugador.BazasGanadas == 0 || this.bazasPardadas == 1 && jugador.BazasGanadas == 1)
            {
                jugador.DelegadoTiradoCarta = jugador.TirarCartaMasAlta;
            }
            else if(jugador.BazasGanadas == 1 && this.bazasJugadas == 1)
            {
                jugador.DelegadoTiradoCarta = jugador.TirarCartaMasBaja;
            }
            else
            {
                jugador.DelegadoTiradoCarta = jugador.TirarCartaMasBaja;
            }
        }

        /// <summary>
        /// Juega turno el usuario, y le pide a la vista la jugada que haya hecho el usuario
        /// </summary>
        /// <param name="jugador"></param>
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

                                Thread.Sleep(200);
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
        /// <summary>
        /// EL jugador canta truco y espera la respuesta del oponente 
        /// </summary>
        /// <param name="jugadorQueCanta"></param>
        /// <returns></returns>
        private bool JugarTruco(Jugador jugadorQueCanta)
        {
            this.seJugoTruco = true;

            this.enviarMensaje?.Invoke("TRUCO", jugadorQueCanta.EsUsuario);               
            Thread.Sleep(200);
            this.actualizarLog?.Invoke($"\nJ{jugadorQueCanta.IdJugador}: TRUCO");

            if (!ObtenerOponente(jugadorQueCanta).ResponderTruco())
            {
                Thread.Sleep(500);
                this.enviarMensaje?.Invoke("No quiero", false);
                this.actualizarLog?.Invoke($"\nJ{ObtenerOponente(jugadorQueCanta).IdJugador}: No quiero");
                this.ganadorMano = jugadorQueCanta;
                this.trucoNoQuerido = true;
                return false;
            }
            else
            {
                Thread.Sleep(500);
                this.enviarMensaje?.Invoke("Quiero", false);
                this.actualizarLog?.Invoke($"\nJ{ObtenerOponente(jugadorQueCanta).IdJugador}: Quiero");               
                this.puntosDelTruco = 2;
                return true;
            }
        }
        /// <summary>
        /// EL jugador canta envido y espera la respuesta del oponente 
        /// </summary>
        /// <param name="jugadorQueCanta"></param>
        /// <returns></returns>
        private bool JugarEnvido(Jugador jugadorQueCanta)
        {
            this.seJugoEnvido = true;
            this.enviarMensaje?.Invoke("ENVIDO", jugadorQueCanta.EsUsuario); 
            Thread.Sleep(200);
            this.actualizarLog?.Invoke($"\nJ{jugadorQueCanta.IdJugador}: ENVIDO");
            
            if (this.ObtenerOponente(jugadorQueCanta).ResponderEnvido())
            {      
                Thread.Sleep(500);
                this.enviarMensaje?.Invoke("Quiero", !jugadorQueCanta.EsUsuario);                         
                this.actualizarLog?.Invoke($"\nJ{this.ObtenerOponente(jugadorQueCanta).IdJugador}: Quiero");              
                this.CompararEnvido(jugadorQueCanta);
                return true;                
            }
            else
            {
                Thread.Sleep(500);
                this.enviarMensaje?.Invoke("No quiero", !jugadorQueCanta.EsUsuario);
                this.actualizarLog?.Invoke($"\nJ{this.ObtenerOponente(jugadorQueCanta).IdJugador}: No quiero");
                this.SumarPuntos(jugadorQueCanta, 1);
                return false;                
            }
        }
        /// <summary>
        /// Compara los envidos 
        /// </summary>
        /// <param name="jugadorQueCanto"></param>
        private void CompararEnvido(Jugador jugadorQueCanto)
        {
            Jugador jugadorQueResponde = this.ObtenerOponente(jugadorQueCanto);
            int envidoDelQueCanto = jugadorQueCanto.CalcularEnvido();
            int envidoDelQueRespondio = jugadorQueResponde.CalcularEnvido();
            
            Thread.Sleep(500);
            this.enviarMensaje?.Invoke($"Tengo {envidoDelQueCanto}", jugadorQueCanto.EsUsuario);
            this.actualizarLog?.Invoke($"\nJ{jugadorQueCanto.IdJugador}: {envidoDelQueCanto}");
            

            switch (Juego.CompararEnvido(envidoDelQueCanto, envidoDelQueRespondio))
            {
                case 1:
                    Thread.Sleep(500);
                    this.enviarMensaje?.Invoke($"Son buenas", jugadorQueResponde.EsUsuario);
                    this.actualizarLog?.Invoke($"\nJ{jugadorQueCanto.IdJugador}: Son buenas");
                    this.SumarPuntos(jugadorQueCanto, 2);
                    break;
                case -1:
                    Thread.Sleep(500);
                    this.enviarMensaje?.Invoke($"{envidoDelQueRespondio} son mejores", jugadorQueResponde.EsUsuario);
                    this.actualizarLog?.Invoke($"\nJ{jugadorQueResponde.IdJugador}: {envidoDelQueRespondio} son mejores");                  
                    this.SumarPuntos(this.ObtenerOponente(jugadorQueCanto), 2);
                    break;
                case 0:
                    Thread.Sleep(500);
                    this.actualizarLog?.Invoke($"J{jugadorQueResponde.IdJugador}: {envidoDelQueRespondio}");
                    this.enviarMensaje?.Invoke($"{envidoDelQueRespondio}", jugadorQueResponde.EsUsuario);
                    Thread.Sleep(500);
                    this.actualizarLog?.Invoke($"\nGana {this.JugadorMano.IdJugador} porque es mano");
                    this.enviarMensaje?.Invoke($"Ganó yo porque soy mano", this.JugadorMano.EsUsuario);
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
            this.actualizarLog?.Invoke($"\nJ{pie.IdJugador}: {pie.CartasEnMano[0].ToString()} { pie.CartasEnMano[1].ToString()} { pie.CartasEnMano[2].ToString()}");
            this.actualizarLog?.Invoke($"\nJ{mano.IdJugador}: {mano.CartasEnMano[0].ToString()} { mano.CartasEnMano[1].ToString()} { mano.CartasEnMano[2].ToString()}");         
        }

        public Jugador ObtenerQuienGanoPrimera()
        {
            int resultado = Juego.CompararCartas(this.mesa.cartasTiradasPorJ1[0], this.mesa.cartasTiradasPorJ2[0]);
            if (resultado == 1)
            {
                return this.jugador1;
            }
            else if (resultado == -1)
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
            if (this.jugador1.EsUsuario)
            {
                return this.jugador1;
            }
            else
            {
                return this.jugador2;
            }
        }

        public void CancelarPartida(CancellationTokenSource tokenSource)
        {
            tokenSource.Cancel();
            this.partidaCancelada = true;
            this.TerminarPartida();
        }

        private void ActualizarMazo()
        {
            this.mazo = Juego.ObtenerMazoMezclado();
        }
    }
}
