
namespace Vista
{
    partial class FrmLobbyPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLobbyPrincipal));
            this.panel_Header = new System.Windows.Forms.Panel();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.pbox_Banner = new System.Windows.Forms.PictureBox();
            this.panel_MesasIA = new System.Windows.Forms.Panel();
            this.panel_UsuarioVsMaquina = new System.Windows.Forms.Panel();
            this.btn_RegistroPartidas = new System.Windows.Forms.Button();
            this.btn_EstadisticasJugadores = new System.Windows.Forms.Button();
            this.btn_JugarContraBot = new System.Windows.Forms.Button();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Banner)).BeginInit();
            this.panel_UsuarioVsMaquina.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(1)))));
            this.panel_Header.Controls.Add(this.lbl_Titulo);
            this.panel_Header.Controls.Add(this.pbox_Banner);
            this.panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Header.Location = new System.Drawing.Point(0, 0);
            this.panel_Header.Name = "panel_Header";
            this.panel_Header.Size = new System.Drawing.Size(1101, 160);
            this.panel_Header.TabIndex = 0;
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Titulo.ForeColor = System.Drawing.Color.White;
            this.lbl_Titulo.Location = new System.Drawing.Point(534, 48);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(454, 57);
            this.lbl_Titulo.TabIndex = 1;
            this.lbl_Titulo.Text = "Truco Argentino";
            // 
            // pbox_Banner
            // 
            this.pbox_Banner.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbox_Banner.Image = global::Vista.Properties.Resources.banner_truco;
            this.pbox_Banner.Location = new System.Drawing.Point(0, 0);
            this.pbox_Banner.Name = "pbox_Banner";
            this.pbox_Banner.Size = new System.Drawing.Size(450, 160);
            this.pbox_Banner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_Banner.TabIndex = 0;
            this.pbox_Banner.TabStop = false;
            // 
            // panel_MesasIA
            // 
            this.panel_MesasIA.Location = new System.Drawing.Point(19, 190);
            this.panel_MesasIA.Margin = new System.Windows.Forms.Padding(20);
            this.panel_MesasIA.Name = "panel_MesasIA";
            this.panel_MesasIA.Size = new System.Drawing.Size(773, 390);
            this.panel_MesasIA.TabIndex = 1;
            // 
            // panel_UsuarioVsMaquina
            // 
            this.panel_UsuarioVsMaquina.Controls.Add(this.btn_RegistroPartidas);
            this.panel_UsuarioVsMaquina.Controls.Add(this.btn_EstadisticasJugadores);
            this.panel_UsuarioVsMaquina.Controls.Add(this.btn_JugarContraBot);
            this.panel_UsuarioVsMaquina.Location = new System.Drawing.Point(825, 190);
            this.panel_UsuarioVsMaquina.Name = "panel_UsuarioVsMaquina";
            this.panel_UsuarioVsMaquina.Size = new System.Drawing.Size(252, 390);
            this.panel_UsuarioVsMaquina.TabIndex = 2;
            // 
            // btn_RegistroPartidas
            // 
            this.btn_RegistroPartidas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_RegistroPartidas.FlatAppearance.BorderSize = 0;
            this.btn_RegistroPartidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RegistroPartidas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_RegistroPartidas.Location = new System.Drawing.Point(27, 287);
            this.btn_RegistroPartidas.Name = "btn_RegistroPartidas";
            this.btn_RegistroPartidas.Size = new System.Drawing.Size(202, 65);
            this.btn_RegistroPartidas.TabIndex = 3;
            this.btn_RegistroPartidas.Text = "Registro de las partidas";
            this.btn_RegistroPartidas.UseVisualStyleBackColor = false;
            this.btn_RegistroPartidas.Click += new System.EventHandler(this.btn_RegistroPartidas_Click);
            // 
            // btn_EstadisticasJugadores
            // 
            this.btn_EstadisticasJugadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_EstadisticasJugadores.FlatAppearance.BorderSize = 0;
            this.btn_EstadisticasJugadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EstadisticasJugadores.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_EstadisticasJugadores.Location = new System.Drawing.Point(27, 153);
            this.btn_EstadisticasJugadores.Name = "btn_EstadisticasJugadores";
            this.btn_EstadisticasJugadores.Size = new System.Drawing.Size(202, 65);
            this.btn_EstadisticasJugadores.TabIndex = 3;
            this.btn_EstadisticasJugadores.Text = "Estadísticas jugadores";
            this.btn_EstadisticasJugadores.UseVisualStyleBackColor = false;
            this.btn_EstadisticasJugadores.Click += new System.EventHandler(this.btn_EstadisticasJugadores_Click);
            // 
            // btn_JugarContraBot
            // 
            this.btn_JugarContraBot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_JugarContraBot.FlatAppearance.BorderSize = 0;
            this.btn_JugarContraBot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_JugarContraBot.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_JugarContraBot.Location = new System.Drawing.Point(27, 25);
            this.btn_JugarContraBot.Name = "btn_JugarContraBot";
            this.btn_JugarContraBot.Size = new System.Drawing.Size(202, 65);
            this.btn_JugarContraBot.TabIndex = 3;
            this.btn_JugarContraBot.Text = "Jugar contra un BOT";
            this.btn_JugarContraBot.UseVisualStyleBackColor = false;
            this.btn_JugarContraBot.Click += new System.EventHandler(this.btn_JugarContraBot_Click);
            // 
            // FrmLobbyPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(1101, 602);
            this.Controls.Add(this.panel_UsuarioVsMaquina);
            this.Controls.Add(this.panel_MesasIA);
            this.Controls.Add(this.panel_Header);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLobbyPrincipal";
            this.Text = "Lobby";
            this.Load += new System.EventHandler(this.FrmLobbyPrincipal_Load);
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Banner)).EndInit();
            this.panel_UsuarioVsMaquina.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Header;
        private System.Windows.Forms.PictureBox pbox_Banner;
        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.Panel panel_MesasIA;
        private System.Windows.Forms.Panel panel_UsuarioVsMaquina;
        private System.Windows.Forms.Button btn_JugarContraBot;
        private System.Windows.Forms.Button btn_EstadisticasJugadores;
        private System.Windows.Forms.Button btn_RegistroPartidas;
    }
}