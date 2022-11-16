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
using Vista.Properties;


namespace Vista
{
    /// <summary>
    /// Control personalizado para mostrar cartas
    /// </summary>
    public partial class ImagenCarta : UserControl
    {
        private Carta carta;
        private bool esDeUsuario;

        public ImagenCarta()
        {
            InitializeComponent();
            this.carta = null;
            this.esDeUsuario = false;
            this.BackgroundImage = null;
        }

        public bool EsDeUsuario { get => esDeUsuario; set => esDeUsuario = value; }
        public Image Imagen { get => this.BackgroundImage; set => this.BackgroundImage = value; }
        public Carta Carta { get => carta; }

        public void MostrarCarta(Carta carta)
        {
            this.carta = carta;
            if(this.esDeUsuario)
            {
                this.Imagen = (Image)Resources.ResourceManager.GetObject($"_{this.carta.Numero}de{this.carta.Palo.ToString().ToLower()}");
            }
            else
            {
                this.Imagen = (Image)Resources.ResourceManager.GetObject("carta_trasera_azul");
            }
        }

    }
}
