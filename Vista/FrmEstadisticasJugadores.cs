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

namespace Vista
{
    public partial class FrmEstadisticasJugadores : Form
    {
        List<Jugador> jugadores;
        JugadoresADO accesoDatosJugadores;
        DataTable tablaDatos;

        public FrmEstadisticasJugadores()
        {
            InitializeComponent();
            this.jugadores = new List<Jugador>();
            this.accesoDatosJugadores = new JugadoresADO(Juego.nombreServer,Juego.nombreBaseDeDatos);
            this.tablaDatos = new DataTable();
            this.InicializarDataTable();
        }

        private void FrmEstadisticasJugadores_Load(object sender, EventArgs e)
        {
            this.dgv_EstadisticasJugadores.DataSource = this.tablaDatos;
        }

        private void InicializarDataTable()
        {
            this.tablaDatos.Columns.Add("Id", typeof(int));
            this.tablaDatos.Columns.Add("Nombre", typeof(string));
            this.tablaDatos.Columns.Add("Jugadas", typeof(int));
            this.tablaDatos.Columns.Add("Ganadas", typeof(int));
            this.tablaDatos.Columns.Add("Perdidas", typeof(int));
            this.tablaDatos.Columns.Add("Es Usuario", typeof(bool));
        }

        internal void ActualizarTablaDeDatos()
        {
            this.tablaDatos.Rows.Clear();
            foreach (Jugador item in accesoDatosJugadores.ObtenerJugadores())
            {
                int id = item.idBaseDeDatos;
                string nombre = item.Nombre;
                int jugadas = item.PartidasJugadas;
                int ganadas = item.PartidasGanadas;
                int perdidas = item.PartidasPerdidas;
                bool esUsuario = item.EsUsuario;

                this.tablaDatos.Rows.Add(id,nombre, jugadas, ganadas, perdidas, esUsuario);
            }
        }

        private void btn_AgregarJugador_Click(object sender, EventArgs e)
        {
            this.txt_NombreIngresado.Visible = true;
            this.btn_Agregar.Visible = true;
            this.chk_esUsuario.Visible = true;

        }

        private void FrmEstadisticasJugadores_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.txt_NombreIngresado.Text))
            {
                if(accesoDatosJugadores.Agregar(this.txt_NombreIngresado.Text,this.chk_esUsuario.Checked))
                {
                    MessageBox.Show("Se agrego correctamente");
                    this.ActualizarTablaDeDatos();
                }
                this.btn_Agregar.Visible = false;
                this.txt_NombreIngresado.Visible = false;
                this.chk_esUsuario.Visible = false;
            }
        }

        private void btn_EliminarJugador_Click(object sender, EventArgs e)
        {

            int row = this.dgv_EstadisticasJugadores.CurrentCell.RowIndex;
            DataGridViewRow filaSeleccionada = this.dgv_EstadisticasJugadores.Rows[row];
            int id = (int)filaSeleccionada.Cells[0].Value;

            if(this.accesoDatosJugadores.Eliminar(id))
            {
                this.ActualizarTablaDeDatos();
                MessageBox.Show($"Jugador con id: {id} ELIMINADO");            
            }
        }
    }
}
