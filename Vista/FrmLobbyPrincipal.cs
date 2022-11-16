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
    public partial class FrmLobbyPrincipal : Form
    {
        FrmPartidasBotVsBot formMesasIAvsIA;
        FrmUsuarioVsBot formUserVSMaquina;
        FrmEstadisticasJugadores formEstadisticasJugadores;
        FrmRegistroPartidas formRegistro;

        public FrmLobbyPrincipal()
        {
            InitializeComponent();
            this.formMesasIAvsIA = new FrmPartidasBotVsBot();
            formEstadisticasJugadores = new FrmEstadisticasJugadores();
            formRegistro = new FrmRegistroPartidas();
        }

        private void FrmLobbyPrincipal_Load(object sender, EventArgs e)
        {
            this.ConfigurarFormMesasIA();
        }

        private void ConfigurarFormMesasIA()
        {
            this.panel_MesasIA.Controls.Clear();
            this.formMesasIAvsIA.TopLevel = false;
            this.panel_MesasIA.Tag = this.formMesasIAvsIA;
            this.panel_MesasIA.Controls.Add(formMesasIAvsIA);
            this.formMesasIAvsIA.Dock = DockStyle.Fill;
            this.formMesasIAvsIA.Show();
        }

        private void btn_JugarContraBot_Click(object sender, EventArgs e)
        {
            this.formUserVSMaquina = new FrmUsuarioVsBot();
            this.formUserVSMaquina.Show();
        }

        private void btn_EstadisticasJugadores_Click(object sender, EventArgs e)
        {
            this.formEstadisticasJugadores.ActualizarTablaDeDatos();
            this.formEstadisticasJugadores.ShowDialog();                                
        }

        private void btn_RegistroPartidas_Click(object sender, EventArgs e)
        {
            
            formRegistro.ShowDialog();
        }
    }
}
