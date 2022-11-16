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
    public partial class FrmMostrarPartidaBotVsBot : Form
    {
        public Partida partida;
        public event Action<Partida> cerrarPartidaSinGuardar;
        public Task tarea;
        public event Action cancelarPartida;

       
        public FrmMostrarPartidaBotVsBot(Partida partida, Task tarea) : this()
        {
            this.tarea = tarea;
            this.partida = partida;
        }

        public FrmMostrarPartidaBotVsBot()
        {
            InitializeComponent();
        }

        private void FrmMostrar_Load(object sender, EventArgs e)
        {
            this.Text = $"Mesa en juego | {this.partida.Jugador1.Nombre} vs {this.partida.Jugador2.Nombre}";
        }

        private void FrmMostrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btn_CerrarSala_Click(object sender, EventArgs e)
        {
            this.FormClosing -= this.FrmMostrar_FormClosing;
            EventHandler delegado = CerrarSalaSinGuardar;
            this.Invoke(delegado, sender, e);
        }

        private void CerrarSalaSinGuardar(object sender, EventArgs e)
        {
            this.cerrarPartidaSinGuardar.Invoke(this.partida);
            this.Close();
        }

        private void btn_GuardarEnTxt_Click(object sender, EventArgs e)
        {
            if (ManejadorArchivoTxt.Escribir(this.richTBox_InformacionSalasAbiertas.Text, $"partida_{partida.Jugador1.Nombre}vs{partida.Jugador2.Nombre}"))
            {
                MessageBox.Show("Se creo el archivo!");
                this.FormClosing -= this.FrmMostrar_FormClosing;
                this.cerrarPartidaSinGuardar.Invoke(this.partida);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo crear el archivo!");
            }
        }

        private void btn_CancelarPartida_Click(object sender, EventArgs e)
        {
            this.cancelarPartida.Invoke();
            MessageBox.Show("Se cancelara al terminar la mano en curso...");
        }

        public void Actualizar(string mensaje)
        {
            if (InvokeRequired)
            {
                Action<string> delegado = Actualizar;
                this.Invoke(delegado, mensaje);
            }
            else
            {
                this.richTBox_InformacionSalasAbiertas.Text = this.richTBox_InformacionSalasAbiertas.Text.Insert(0, mensaje);
            }
        }

        public void MostrarBotonesAlFinalizarPartida()
        {
            if (InvokeRequired)
            {
                Action delegado = MostrarBotonesAlFinalizarPartida;
                this.Invoke(delegado);
            }
            else
            {
                this.richTBox_InformacionSalasAbiertas.Size = new Size(303, 325);
                this.btn_CerrarSala.Visible = true;
                this.btn_GuardarEnTxt.Visible = true;
                this.btn_CancelarPartida.Visible = false;
                this.btn_GuardarEnJson.Visible = true;
                this.btn_GuardarEnXml.Visible = true;
            }
        }

        private void btn_GuardarEnJson_Click(object sender, EventArgs e)
        {
            this.btn_GuardarEnJson.Enabled = false;

            string mensaje = Juego.GuardarRegistroPartidaJSON(this.partida,true);

            MessageBox.Show(mensaje);
            if (mensaje == "Partida serializada en json EXITOSAMENTE")
            {
                this.Close();
            }
        }

        private void btn_GuardarEnXml_Click(object sender, EventArgs e)
        {
            this.btn_GuardarEnXml.Enabled = false;

            string mensaje = Juego.GuardarRegistroPartidaXML(this.partida, true);

            MessageBox.Show(mensaje);
            if (mensaje == "Partida serializada en xml EXITOSAMENTE")
            {
                this.Close();
            }
        }
    }
}
