using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Vista
{
    public partial class FrmJugarTurnoUsuario : Form
    {
        Partida partida;
        string jugada;
        Jugador usuario;

        public string Jugada { get => jugada; set => jugada = value; }

        public FrmJugarTurnoUsuario(Partida partida)
        {
            InitializeComponent();
            this.partida = partida;
            this.MostrarBotones();
            this.usuario = partida.ObtenerUsuario();
            this.MostrarCartasEnMano();
          
        }

        private void MostrarCartasEnMano()
        {
            List<Carta> cartas = new List<Carta>(this.usuario.CartasEnMano);
            cartas.Remove(this.usuario.CartaTirada);
            for (int i = 0; i < cartas.Count; i++)
            {
                ImagenCarta imagen = (ImagenCarta)this.tableLayoutPanel1.Controls[i];
                imagen.EsDeUsuario = true;
                imagen.MostrarCarta(cartas[i]);
            }
        }

        private void MostrarBotones()
        {
            this.btn_IrseAlMazo.Visible = true;
            if(!this.partida.SeJugoTruco)
            {
                this.btn_cantarTruco.Visible = true;
            }
            if (!this.partida.SeJugoEnvido)
            {
                this.btn_cantarEnvido.Visible = true;
            }
        }

        private void cartaSeleccionada(object sender, EventArgs e)
        {
            ImagenCarta cartaSeleccionada = (ImagenCarta)sender;
            if(cartaSeleccionada.Carta is not null)
            {
                jugada = cartaSeleccionada.Carta.ToString();
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private void btn_cantarTruco_Click(object sender, EventArgs e)
        {
            jugada = "TRUCO";
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cantarEnvido_Click(object sender, EventArgs e)
        {
            jugada = "ENVIDO";
            this.DialogResult = DialogResult.OK;
        }

        private void btn_IrseAlMazo_Click(object sender, EventArgs e)
        {
            jugada = "MAZO";
            this.DialogResult = DialogResult.OK;
        }

    }
}
