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
    public partial class FrmPartidasBotVsBot : Form
    {
        List<Partida> partidasEnJuego;
        List<UC_Mesa> mesas;
        JugadoresADO jugadores;
 
        public FrmPartidasBotVsBot()
        {
            InitializeComponent();
            jugadores = new JugadoresADO(Juego.nombreServer, Juego.nombreBaseDeDatos);
            partidasEnJuego = new List<Partida>();
            mesas = new List<UC_Mesa>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*actualizarListaPartidasEnJuego = new Task(() => ActualizarPartidasEnJuego());
            actualizarListaPartidasEnJuego.Start();*/
        }

        private void ActualizarPartidasEnJuego()
        {
            while (true)
            {
                Thread.Sleep(1000);
                ActualizarPrevisualizacionesPartidas();
            }
        }

        private Partida CrearMesaDeJuego()
        {           
            Jugador j1 = Juego.ObtenerJugadorBotDisponible();
            Jugador j2 = Juego.ObtenerJugadorBotDisponible();
            
            Partida partida = null;
            if (j1 is not null && j2 is not null)
            {
                j1.IdJugador = 1;
                j2.IdJugador = 2;
                partida = new Partida(j1, j2);
            }
            else
            {
                if(j1 is null && j2 is not null)
                {
                    j2.EstaJugando = false;
                }
                else if(j1 is not null && j2 is null)
                {
                    j1.EstaJugando = false;
                }
            }

            return partida;                
        }

        private void btn_CrearSala_Click(object sender, EventArgs e)
        {
            Partida partida = CrearMesaDeJuego();
            if (partida is not null)
            {

                UC_Mesa mesaPrevisualizacion = new UC_Mesa(partida);
                mesaPrevisualizacion.actualizarPuntaje += ActualizarPuntajePartida;
                this.mesas.Add(mesaPrevisualizacion);
                this.partidasEnJuego.Add(mesaPrevisualizacion.Partida);
                mesaPrevisualizacion.FormMostrarSala.cerrarPartidaSinGuardar += EliminarPartida;
                this.flowLayoutPanel1.Controls.Add(mesaPrevisualizacion);
            }
            else
            {
                MessageBox.Show("No hay jugadores disponibles para jugar");
            }
        }

        private void EliminarPartida(Partida partida)
        { 
            if (InvokeRequired)
            {
                Action<Partida> delegado = EliminarPartida;
                Invoke(delegado, partida);
            }
            else
            {              
                foreach(Control control in this.flowLayoutPanel1.Controls)
                {
                    if(control is UC_Mesa mesa && mesa.Partida == partida)
                    {
                        this.flowLayoutPanel1.Controls.Remove(control);
                        partidasEnJuego.Remove(partida);
                    }
                }
            }           
        }

        private void ActualizarPuntajePartida(UC_Mesa mesa, int puntajeJ1, int puntajeJ2)
        {
            if(InvokeRequired)
            {
                Action<UC_Mesa,int,int> delegado = ActualizarPuntajePartida;
                this.Invoke(delegado, mesa,puntajeJ1,puntajeJ2);
            }
            else
            {
                mesa.lbl_Puntaje.Text = $"{puntajeJ1} : {puntajeJ2}";
            }
        }

        private void ActualizarPrevisualizacionesPartidas()
        {
           if (InvokeRequired)
           {
                Action delegado = ActualizarPrevisualizacionesPartidas;
                Invoke(delegado);
           }
            else
            {
                foreach (Control control in this.flowLayoutPanel1.Controls)
                {
                    if(control is UC_Mesa userControl && !userControl.Partida.PartidaFinalizada)
                    {
                        userControl.lbl_Puntaje.Text = $"{userControl.Partida.Jugador1.Puntaje} : {userControl.Partida.Jugador2.Puntaje}";
                    }                   
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gbox_Sala_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
