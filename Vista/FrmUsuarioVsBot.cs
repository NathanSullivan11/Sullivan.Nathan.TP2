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
        private RegistroPartida registroPartida;
        private CancellationToken tokenCancelacion;
        private CancellationTokenSource fuenteTokenCancelacion;
        private Task tareaPartida;
        private FrmJugarTurnoUsuario formJugarTurno;
        public event Action<CancellationTokenSource> cancelarPartida;

        public FrmUsuarioVsBot()
        {
            InitializeComponent();
            
            this.tokenCancelacion = new CancellationToken();
            this.fuenteTokenCancelacion = new CancellationTokenSource();
            this.tokenCancelacion = this.fuenteTokenCancelacion.Token;
        }

        private Partida InstanciarPartida()
        {

            this.Size = new System.Drawing.Size(896, 768);
            this.btn_Jugar.Enabled = false;
            Jugador j1;
            j1 = Juego.ObtenerJugadorUsuarioDisponible();
            if (j1 is null)
            {
                j1 = new Jugador("Nathan", 0, 0, 0, true);
            }
            Jugador j2 = Juego.ObtenerJugadorBotDisponible();
            if (j2 is null)
            {
                MessageBox.Show("No hay bots disponibles para jugar, debe agregar uno para poder jugar");
                this.btn_Jugar.Enabled = true;
                this.Close();
            }
            j1.IdJugador = 1;
            j1.obtenerRespuestaUsuario += this.ObtenerRespuestaUsuario;
            j2.IdJugador = 2;

            return new Partida(j1, j2);
        }

        private void btn_Jugar_Click(object sender, EventArgs e)
        {
            this.btn_CancelarPartida.Visible = true;
            this.btn_Jugar.Visible = false;
            partida = this.InstanciarPartida();
            if (partida is null)
            {
                return;
            }

            this.AsignarEventosDePartida();

            
            tareaPartida = new Task(() => partida.ComenzarPartida(tokenCancelacion));
            tareaPartida.Start();
        }

        /// <summary>
        /// Suscribe los delegado necesarios a sus respectivos eventos
        /// </summary>
        private void AsignarEventosDePartida()
        {
            this.cancelarPartida += partida.CancelarPartida;
            partida.repartirCarta += this.RepartirCarta;
            partida.actualizarPuntaje += this.ActualizarPuntaje;
            partida.pedirJugadaUsuario += TurnoUsuario;
            partida.enviarCarta += this.MostrarCarta;
            partida.manoTerminada += this.ReiniciarParaNuevaMano;
            partida.partidaTerminada += this.ReiniciarParaNuevaPartida;
            partida.partidaTerminada += this.ReiniciarParaNuevaMano;
            partida.enviarMensaje += this.ImprimirMensaje;
        }

        /// <summary>
        /// Prepara el entorno visual para una nueva partida
        /// </summary>
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
                this.lbl_mensajeAnunciarGanador.Visible = true;
                this.lbl_mensajeAnunciarGanador.Text = $"Ganador: {this.partida.HayGanador.Nombre}";
                this.fuenteTokenCancelacion.Cancel();
                this.OcultarMensajesJugadores();
                this.MostrarBotonesGuardarRegistro();
                this.Size = new System.Drawing.Size(290, 537);
                this.MaximumSize = new System.Drawing.Size(290, 537);
                this.MinimumSize = new System.Drawing.Size(290, 537);
            }
        }

        private void MostrarBotonesGuardarRegistro()
        {
            this.btn_SerializarJson.Visible = true;
            this.btn_SerializarXml.Visible = true;
            this.btn_CerrarSinGuardar.Visible = true;
        }
        /// <summary>
        /// Muestra el mensaje enviado por la el jugador de la partida
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="esUsuario"></param>
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
                    this.pictureBox_Usuario.Visible = true;
                    this.lbl_MensajeUsuario.Visible = true;
                    this.lbl_MensajeUsuario.Text = mensaje;
                }
                else
                {
                    this.pictureBox_bot.Visible = true;
                    this.lbl_MensajeBot.Visible = true;
                    this.lbl_MensajeBot.Text = mensaje;
                }

            }      
        }
        /// <summary>
        /// Limpia las cartas en mesa para jugar una nueva mano
        /// </summary>
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
                this.OcultarMensajesJugadores();
            }
        }
        /// <summary>
        /// Actualiza el puntaje de los jugadores
        /// </summary>
        /// <param name="puntajeJ1"></param>
        /// <param name="puntajeJ2"></param>
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
        /// <summary>
        /// Muestra la carta tirada por el jugador
        /// </summary>
        /// <param name="carta"></param>
        /// <param name="esJugador1"></param>
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
            this.pictureBox_Usuario.Visible = false;
            this.pictureBox_bot.Visible = false;
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

        private bool ObtenerRespuestaUsuario(string mensaje)
        {
            bool respuesta = false;
            if (InvokeRequired)
            {
                Func<string, bool> delegado = ObtenerRespuestaUsuario;
                respuesta = (bool)this.Invoke(delegado, mensaje);
            }
            else
            {
                if(MessageBox.Show($"Jugador 2: {mensaje}", mensaje, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    respuesta = true;
                }                  
            }
            return respuesta;
        }
        /// <summary>
        /// Despliega el formulario que le permite jugar el turno al usuario
        /// </summary>
        /// <returns></returns>
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
                if(!this.tokenCancelacion.IsCancellationRequested)
                {
                    MessageBox.Show("Debe cancelar la partida para poder cerrarlo");
                    e.Cancel = true;
                    return;
                }
                if(formJugarTurno.DialogResult != DialogResult.OK)
                {
                    formJugarTurno.DialogResult = DialogResult.OK;
                }
                this.fuenteTokenCancelacion.Cancel();               
            }
        }
        /// <summary>
        /// Serializa el registro de la partida en un archivo JSON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SerializarJson_Click(object sender, EventArgs e)
        {
            this.btn_SerializarJson.Enabled = false;

            string mensaje = Juego.GuardarRegistroPartidaJSON(this.partida, false);

            MessageBox.Show(mensaje);
            if (mensaje == "Partida serializada en json EXITOSAMENTE")
            {
                this.Close();
            }                                 
        }
        /// <summary>
        /// Serializa el registro de la partida en un archivo XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SerializarXml_Click(object sender, EventArgs e)
        {
            this.btn_SerializarXml.Enabled = false;

            string mensaje = Juego.GuardarRegistroPartidaXML(this.partida, false);
  
            MessageBox.Show(mensaje);
            if (mensaje == "Partida serializada en xml EXITOSAMENTE")
            {
                this.Close();
            }            
        }

        private void btn_CerrarSinGuardar_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("¿Estas seguro que desea cerrar sin guardar el registro?", "Salir sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
           {
                this.Close();
           }          
        }

        private void btn_CancelarPartida_Click(object sender, EventArgs e)
        {
            this.fuenteTokenCancelacion.Cancel();
            this.cancelarPartida.Invoke(this.fuenteTokenCancelacion);
            bool o = this.tareaPartida.IsCanceled;
        }
    }
}
