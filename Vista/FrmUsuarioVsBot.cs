using Entidades;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmUsuarioVsBot : Form
    {
        public Partida partida;
        private CancellationToken tokenCancelacion;
        private CancellationTokenSource fuenteTokenCancelacion;
        private Task tareaPartida;
        private FrmJugarTurnoUsuario formJugarTurno;

        public FrmUsuarioVsBot()
        {
            InitializeComponent();

            this.OcultarMensajesJugadores();
            this.tokenCancelacion = new CancellationToken();
            this.fuenteTokenCancelacion = new CancellationTokenSource();
            this.tokenCancelacion = this.fuenteTokenCancelacion.Token;
        }

        public FrmUsuarioVsBot(Jugador usuario, Jugador maquina) :this()
        {
           
        }

        private void btn_Jugar_Click(object sender, EventArgs e)
        {
            this.btn_Jugar.Enabled = false;
            Jugador j1 = new Jugador("Nathan",0,0,0);
            Jugador j2 = new Jugador("BOT", 0, 0, 0);
            j1.IdJugador = 1;
            j1.EsUsuario = true;
            j1.obtenerRespuestaUsuario += this.respuestaUsuario;
            j2.IdJugador = 2;
            partida = new Partida(j1, j2);


            partida.repartirCarta += this.RepartirCarta;
            partida.actualizarPuntaje += this.ActualizarPuntaje;
            partida.pedirJugadaUsuario += TurnoUsuario;
            partida.enviarCarta += this.MostrarCarta;
            partida.manoTerminada += this.ReiniciarParaNuevaMano;
            partida.partidaTerminada += this.ReiniciarParaNuevaPartida;
            partida.partidaTerminada += this.ReiniciarParaNuevaMano;
            partida.enviarMensaje += this.ImprimirMensaje;

            tareaPartida = new Task( () => partida.ComenzarPartida(tokenCancelacion));
            tareaPartida.Start();

        }

        private void ReiniciarParaNuevaPartida()
        {
            if(InvokeRequired)
            {
                Action delegado = ReiniciarParaNuevaPartida;
                this.Invoke(delegado);
            }
            else
            {
                this.btn_Jugar.Enabled = true;
                this.lbl_tituloUsuariovsMaquina.Text = $"Ganador: {this.partida.HayGanador.Nombre}";
                this.fuenteTokenCancelacion.Cancel();
            }
        }

        private void ImprimirMensaje(string mensaje, bool esUsuario)
        {
            if (InvokeRequired)
            {
                Action<string,bool> delegado = this.ImprimirMensaje;
                this.Invoke(delegado, mensaje, esUsuario);
            }
            else
            {
                if(esUsuario)
                {
                    this.lbl_MensajeUsuario.Visible = true;
                    this.lbl_MensajeUsuario.Text = mensaje;
                }
                else
                { 
                    this.lbl_MensajeBot.Visible = true;
                    this.lbl_MensajeBot.Text = mensaje;
                }

            }      
        }

        private void ReiniciarParaNuevaMano()
        {
            if (InvokeRequired)
            {
                this.Invoke((Action)this.ReiniciarParaNuevaMano);
            }
            else
            {
                this.flp_cartasEnMesaJ1.Controls.Clear();
                this.flp_cartasEnMesaJ2.Controls.Clear();
                this.flp_cartasEnManoJ1.Controls.Clear();
                this.flp_cartasEnManoJ2.Controls.Clear();
            }
        }

        public void ActualizarPuntaje(int puntajeJ1, int puntajeJ2)
        {
            if (InvokeRequired)
            {
                Action<int,int> delegado = ActualizarPuntaje;
                this.Invoke(delegado, puntajeJ1, puntajeJ2);
            }
            else
            {
                this.lbl_puntajeUsuario.Text = puntajeJ1.ToString();
                this.lbl_PuntajeBot.Text = puntajeJ2.ToString();
            }
        }

        private void MostrarCarta(Carta carta, bool esJugador1)
        {
            if (InvokeRequired)
            {
                Action<Carta, bool> delegado = MostrarCarta;
                this.Invoke(delegado, carta, esJugador1);
            }
            else
            {
                this.OcultarMensajesJugadores();
                FlowLayoutPanel panel = this.flp_cartasEnMesaJ2;
                FlowLayoutPanel panel1 = this.flp_cartasEnManoJ2;
                FlowLayoutPanel panel2 = this.flp_cartasEnManoJ1;

                this.EliminarCartaDeMano(carta, esJugador1);
                ImagenCarta imagen = new ImagenCarta();
                if (esJugador1)
                {
                    panel = this.flp_cartasEnMesaJ1;
                }
                imagen.EsDeUsuario = true;
                imagen.MostrarCarta(carta);
                panel.Controls.Add(imagen);              
            }
        }

        private void OcultarMensajesJugadores()
        {
            this.lbl_MensajeUsuario.Visible = false;
            this.lbl_MensajeBot.Visible = false;
        }

        private void EliminarCartaDeMano(Carta carta, bool esDeUsuario)
        {
            FlowLayoutPanel cartasEnMano = this.flp_cartasEnManoJ2;

            if(esDeUsuario)
            {
                cartasEnMano = this.flp_cartasEnManoJ1;
            }
            foreach (Control control in cartasEnMano.Controls)
            {
                if(control is ImagenCarta imagen)
                {
                    if(imagen.Carta == carta)
                    {
                        cartasEnMano.Controls.Remove(imagen);
                    }
                }      
            }
        }

        private bool respuestaUsuario(string mensaje)
        {
            bool respuesta = false;
            if (InvokeRequired)
            {
                Func<string, bool> delegado = respuestaUsuario;
                respuesta = (bool)this.Invoke(delegado, mensaje);
            }
            else
            {
                if(MessageBox.Show(mensaje, "RESPONDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    respuesta = true;
                }    

               
            }
            return respuesta;
        }

        private string TurnoUsuario()
        {
            string jugada = null;
              
            formJugarTurno = new FrmJugarTurnoUsuario(this.partida);
            formJugarTurno.StartPosition = FormStartPosition.CenterScreen;         
                                                                               
            if (formJugarTurno.ShowDialog() == DialogResult.OK)
            {
                jugada = formJugarTurno.Jugada;              
            }

            return jugada;
           
        }
     
        private void RepartirCarta(Carta carta, bool esUsuario)
        {
            if (InvokeRequired)
            {
                Action<Carta,bool> delegado = RepartirCarta;
                Invoke(delegado, carta, esUsuario);
            }
            else
            {
                this.OcultarMensajesJugadores();
                // List<ImagenCarta> cartas = this.cartasEnManoJ2;
                FlowLayoutPanel panel = this.flp_cartasEnManoJ2;
                if(esUsuario)
                {
                    //cartas = this.cartasTiradasJ1;
                    panel = this.flp_cartasEnManoJ1;
                }

                ImagenCarta imagen = new ImagenCarta();
                imagen.EsDeUsuario = esUsuario;
                imagen.MostrarCarta(carta);
                panel.Controls.Add(imagen);
            }
        }

        private void FrmUsuarioVsBot_FormClosing(object sender, FormClosingEventArgs e)
        {                      
            if (InvokeRequired)
            {
                Action<object,FormClosingEventArgs> delegado = FrmUsuarioVsBot_FormClosing;
                this.Invoke(delegado, sender, e);
            }
            else
            {
                if(formJugarTurno is not null)
                {
                    formJugarTurno.Close();
                }
                this.fuenteTokenCancelacion.Cancel();
            }
        }
    }
}
