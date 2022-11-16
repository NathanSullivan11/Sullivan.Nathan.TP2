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
    public partial class FrmRegistroPartidas : Form
    { 
        public FrmRegistroPartidas()
        {
            InitializeComponent();
            this.rbtn_json.Visible = true;
            this.rbtn_xml.Visible = true;
           
        }

        private void ActualizarDataGrid(string tipoArchivo, bool partidasBotVsBot)
        {
            try
            {
                List<RegistroPartida> registro = Juego.ObtenerRegistrosPartidas(tipoArchivo, partidasBotVsBot);
                this.dtg_RegistroPartidas.DataSource = registro;

            }
            catch(Exception e )
            {
                MessageBox.Show(e.Message);
            }
         }

        private void btn_EstadisticasPartidasBotBot_Click(object sender, EventArgs e)
        {
            string tipoArchivo = "xml";
            if (this.rbtn_json.Checked)
            {
                tipoArchivo = "json";
                if (Juego.RegistroPartidasBotVsBotJSON.Count > 0)
                {
                    this.ActualizarDataGrid(tipoArchivo, true);
                }
                else
                {
                    MessageBox.Show("No hay registro de partidas BOT vs BOT en JSON");
                }
            }
            else if (Juego.RegistroPartidasBotVsBotXML.Count > 0)
            {
                this.ActualizarDataGrid(tipoArchivo, true);
            }
            else
            {
                MessageBox.Show("No hay registro de partidas BOT vs BOT en XML");
            }

        }

        private void btn_EstadisticasPartidasUsuarioBot_Click(object sender, EventArgs e)
        {
            this.rbtn_json.Visible = true;
            this.rbtn_xml.Visible = true;
            this.btn_EstadisticasPartidasBotBot.Enabled = true;
            string tipoArchivo = "xml";
            if (this.rbtn_json.Checked)
            {
                tipoArchivo = "json";
                if (Juego.RegistroPartidasUserVsBotJSON.Count > 0)
                {
                    this.ActualizarDataGrid(tipoArchivo, false);
                }
                else
                {
                    MessageBox.Show("No hay registro de partidas USER vs BOT en JSON");
                }
            } 
            else if (Juego.RegistroPartidasUserVsBotXML.Count > 0)
            {                     
                this.ActualizarDataGrid(tipoArchivo, false);
            }
            else
            {
                MessageBox.Show("No hay registro de partidas USER vs BOT en XML");
            }
        }

        private void FrmRegistroPartidas_Load(object sender, EventArgs e)
        {
            //Juego.IncializarRegistros();
        }
    }
}
