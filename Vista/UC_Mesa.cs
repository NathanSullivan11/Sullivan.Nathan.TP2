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
    public partial class UC_Mesa : UserControl
    {
        private Partida partida;
        private FrmMostrarPartidaBotVsBot formMostrarSala;
        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        public UC_Mesa()
        {
            InitializeComponent();      
        }

        public UC_Mesa(Partida partida) : this()
        {
            InitializeComponent();

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
            this.partida.partidaTerminada += this.ActualizarMensaje;
            this.partida.actualizarLog += this.formMostrarSala.Actualizar;
            this.partida.partidaTerminada += this.formMostrarSala.MostrarBotonesAlFinalizarPartida;
            
            tarea.Start();
        }

        private void btn_VerSala_Click(object sender, EventArgs e)
        {
            this.formMostrarSala.Show();
        }

        public Partida Partida
        {
            get { return this.partida; }
        }

        public FrmMostrarPartidaBotVsBot FormMostrarSala
        {
            get { return this.formMostrarSala; }
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

        /*
        public UC_Mesa(Sala sala) :this()
        {
            InitializeComponent();

            this.sala = sala;
            this.SetearDatosDeSala();
            this.GenerarTokenDeCancelacion();
            this.IniciarPartida();
        }

        private void SetearDatosDeSala()
        {
            this.lbl_Puntaje.Location = new Point(72, 16);
            this.lbl_Jugador1.Text = this.sala.Jugador1.Nombre;
            this.lbl_Jugador2.Text = this.sala.Jugador2.Nombre;
        }
     
        private void IniciarSalaDeJuego()
        {
            Task tarea = new Task(() => sala.ComenzarSalaMaquinaVSMaquina(token));

            this.formMostrarSala = new FrmMostrarPartidaBotVsBot(this.sala, tarea);
            this.formMostrarSala.cancelarPartida += this.CancelarPartida;
            this.sala.actualizarSeguimientoDePartida += this.formMostrarSala.Actualizar;
            this.sala.salaFinalizada += this.ActualizarPuntaje;
            this.sala.salaFinalizada += this.formMostrarSala.MostrarBotonesAlFinalizarSala;
            tarea.Start();
        }

        private void ActualizarPuntaje(object sender, EventArgs e)
        {
            if(InvokeRequired)
            {
                this.Invoke((EventHandler)ActualizarPuntaje, sender, e);
            }
            else
            {
                this.lbl_Puntaje.Text = "Partida terminada";
                this.lbl_Puntaje.Location = new Point(20, 16);
            }
        }

        private void btn_VerSala_Click(object sender, EventArgs e)
        {
            this.formMostrarSala.Show();
        }

        public Sala Sala
        {
            get { return this.sala; }
        }

        public FrmMostrarPartidaBotVsBot FormMostrarSala 
        {
            get { return this.formMostrarSala; }
        }
        */
    }
}
