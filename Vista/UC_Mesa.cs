using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    /// <summary>
    /// Control personalizado para mostrar partidas
    /// </summary>
    public partial class UC_Mesa : UserControl
    {
        private Partida partida;
        private FrmMostrarPartidaBotVsBot formMostrarSala;
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        public event Action<UC_Mesa,int,int> actualizarPuntaje;

        public UC_Mesa()
        {
            InitializeComponent();      
        }

        public UC_Mesa(Partida partida) : this()
        {
            this.partida = partida;
            this.SetearDatosDePartida();
            this.GenerarTokenDeCancelacion();
            this.IniciarPartida();
        }

        private void SetearDatosDePartida()
        {
            this.lbl_Puntaje.Location = new Point(72, 16);
            this.lbl_Jugador1.Text = this.partida.Jugador1.Nombre;
            this.lbl_Jugador2.Text = this.partida.Jugador2.Nombre;
        }

        private void IniciarPartida()
        {
            Task tarea = new Task(() => partida.ComenzarPartida(token));

            this.formMostrarSala = new FrmMostrarPartidaBotVsBot(this.partida, tarea);
            this.formMostrarSala.cancelarPartida += this.CancelarPartida;
            this.partida.actualizarPuntaje += this.ActualizarPuntaje;
            this.partida.partidaTerminada += this.ActualizarMensaje;
            this.partida.actualizarLog += this.formMostrarSala.Actualizar;
            this.partida.partidaTerminada += this.formMostrarSala.MostrarBotonesAlFinalizarPartida;
            
            tarea.Start();
        }

        private void ActualizarPuntaje(int puntajeJ1, int puntajeJ2)
        {
            if(InvokeRequired)
            {
                Action<int, int> delegado = ActualizarPuntaje;
                this.Invoke(delegado, puntajeJ1, puntajeJ2);
            }
            else
            {
                this.actualizarPuntaje.Invoke(this, puntajeJ1, puntajeJ2);
            }
        }

        private void btn_VerSala_Click(object sender, EventArgs e)
        {
            this.formMostrarSala.Show();
        }

        private void CancelarPartida()
        {
            this.tokenSource.Cancel();
        }

        private void ActualizarMensaje()
        {
            if (InvokeRequired)
            {
                this.Invoke((Action)ActualizarMensaje);
            }
            else
            {
                this.lbl_Puntaje.Text = "Partida terminada";
                this.lbl_Puntaje.Location = new Point(20, 16);
            }
        }
         
        private void GenerarTokenDeCancelacion()
        {
            this.tokenSource = new CancellationTokenSource();
            this.token = this.tokenSource.Token;
        }

        public FrmMostrarPartidaBotVsBot FormMostrarSala
        {
            get { return this.formMostrarSala; }
        }

        public Partida Partida
        {
            get { return this.partida; }
        }
    }
}
