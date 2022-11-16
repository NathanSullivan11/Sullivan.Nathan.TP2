
namespace Vista
{
    partial class FrmUsuarioVsBot
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_puntajeUsuario = new System.Windows.Forms.Label();
            this.lbl_PuntajeBot = new System.Windows.Forms.Label();
            this.lbl_TituloUsuario = new System.Windows.Forms.Label();
            this.lbl_TituloBot = new System.Windows.Forms.Label();
            this.panel_tablaPuntajes = new System.Windows.Forms.Panel();
            this.lbl_tituloPuntaje = new System.Windows.Forms.Label();
            this.lbl_mensajeAnunciarGanador = new System.Windows.Forms.Label();
            this.btn_Jugar = new System.Windows.Forms.Button();
            this.lbl_MensajeBot = new System.Windows.Forms.Label();
            this.flp_cartasEnManoJ1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_cartasEnMesaJ1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_cartasEnMesaJ2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_cartasEnManoJ2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_MensajeUsuario = new System.Windows.Forms.Label();
            this.btn_SerializarXml = new System.Windows.Forms.Button();
            this.btn_SerializarJson = new System.Windows.Forms.Button();
            this.btn_CerrarSinGuardar = new System.Windows.Forms.Button();
            this.pictureBox_bot = new System.Windows.Forms.PictureBox();
            this.pictureBox_Usuario = new System.Windows.Forms.PictureBox();
            this.btn_CancelarPartida = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_tablaPuntajes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Usuario)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_puntajeUsuario, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_PuntajeBot, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_TituloUsuario, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_TituloBot, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(174, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbl_puntajeUsuario
            // 
            this.lbl_puntajeUsuario.AutoSize = true;
            this.lbl_puntajeUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_puntajeUsuario.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_puntajeUsuario.Location = new System.Drawing.Point(3, 28);
            this.lbl_puntajeUsuario.Name = "lbl_puntajeUsuario";
            this.lbl_puntajeUsuario.Size = new System.Drawing.Size(81, 28);
            this.lbl_puntajeUsuario.TabIndex = 2;
            this.lbl_puntajeUsuario.Text = "0";
            this.lbl_puntajeUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PuntajeBot
            // 
            this.lbl_PuntajeBot.AutoSize = true;
            this.lbl_PuntajeBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_PuntajeBot.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_PuntajeBot.Location = new System.Drawing.Point(90, 28);
            this.lbl_PuntajeBot.Name = "lbl_PuntajeBot";
            this.lbl_PuntajeBot.Size = new System.Drawing.Size(81, 28);
            this.lbl_PuntajeBot.TabIndex = 2;
            this.lbl_PuntajeBot.Text = "0";
            this.lbl_PuntajeBot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TituloUsuario
            // 
            this.lbl_TituloUsuario.AutoSize = true;
            this.lbl_TituloUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TituloUsuario.Font = new System.Drawing.Font("Bodoni MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_TituloUsuario.Location = new System.Drawing.Point(3, 0);
            this.lbl_TituloUsuario.Name = "lbl_TituloUsuario";
            this.lbl_TituloUsuario.Size = new System.Drawing.Size(81, 28);
            this.lbl_TituloUsuario.TabIndex = 2;
            this.lbl_TituloUsuario.Text = "Usuario";
            this.lbl_TituloUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TituloBot
            // 
            this.lbl_TituloBot.AutoSize = true;
            this.lbl_TituloBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TituloBot.Font = new System.Drawing.Font("Bodoni MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_TituloBot.Location = new System.Drawing.Point(90, 0);
            this.lbl_TituloBot.Name = "lbl_TituloBot";
            this.lbl_TituloBot.Size = new System.Drawing.Size(81, 28);
            this.lbl_TituloBot.TabIndex = 2;
            this.lbl_TituloBot.Text = "Bot";
            this.lbl_TituloBot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_tablaPuntajes
            // 
            this.panel_tablaPuntajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.panel_tablaPuntajes.Controls.Add(this.lbl_tituloPuntaje);
            this.panel_tablaPuntajes.Controls.Add(this.tableLayoutPanel2);
            this.panel_tablaPuntajes.Location = new System.Drawing.Point(37, 109);
            this.panel_tablaPuntajes.MaximumSize = new System.Drawing.Size(174, 86);
            this.panel_tablaPuntajes.MinimumSize = new System.Drawing.Size(174, 86);
            this.panel_tablaPuntajes.Name = "panel_tablaPuntajes";
            this.panel_tablaPuntajes.Size = new System.Drawing.Size(174, 86);
            this.panel_tablaPuntajes.TabIndex = 1;
            // 
            // lbl_tituloPuntaje
            // 
            this.lbl_tituloPuntaje.Font = new System.Drawing.Font("Bodoni MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_tituloPuntaje.Location = new System.Drawing.Point(0, 2);
            this.lbl_tituloPuntaje.Name = "lbl_tituloPuntaje";
            this.lbl_tituloPuntaje.Size = new System.Drawing.Size(174, 25);
            this.lbl_tituloPuntaje.TabIndex = 2;
            this.lbl_tituloPuntaje.Text = "PUNTAJES";
            this.lbl_tituloPuntaje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_mensajeAnunciarGanador
            // 
            this.lbl_mensajeAnunciarGanador.AutoSize = true;
            this.lbl_mensajeAnunciarGanador.Font = new System.Drawing.Font("Stencil", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_mensajeAnunciarGanador.ForeColor = System.Drawing.Color.White;
            this.lbl_mensajeAnunciarGanador.Location = new System.Drawing.Point(12, 213);
            this.lbl_mensajeAnunciarGanador.Name = "lbl_mensajeAnunciarGanador";
            this.lbl_mensajeAnunciarGanador.Size = new System.Drawing.Size(228, 26);
            this.lbl_mensajeAnunciarGanador.TabIndex = 0;
            this.lbl_mensajeAnunciarGanador.Text = "Anunciar ganador";
            this.lbl_mensajeAnunciarGanador.Visible = false;
            // 
            // btn_Jugar
            // 
            this.btn_Jugar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_Jugar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Jugar.FlatAppearance.BorderSize = 0;
            this.btn_Jugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Jugar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Jugar.ForeColor = System.Drawing.Color.White;
            this.btn_Jugar.Location = new System.Drawing.Point(37, 58);
            this.btn_Jugar.Name = "btn_Jugar";
            this.btn_Jugar.Size = new System.Drawing.Size(174, 40);
            this.btn_Jugar.TabIndex = 3;
            this.btn_Jugar.Text = "Comenzar";
            this.btn_Jugar.UseVisualStyleBackColor = false;
            this.btn_Jugar.Click += new System.EventHandler(this.btn_Jugar_Click);
            // 
            // lbl_MensajeBot
            // 
            this.lbl_MensajeBot.AutoSize = true;
            this.lbl_MensajeBot.BackColor = System.Drawing.Color.White;
            this.lbl_MensajeBot.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_MensajeBot.ForeColor = System.Drawing.Color.Black;
            this.lbl_MensajeBot.Location = new System.Drawing.Point(696, 139);
            this.lbl_MensajeBot.Name = "lbl_MensajeBot";
            this.lbl_MensajeBot.Size = new System.Drawing.Size(123, 25);
            this.lbl_MensajeBot.TabIndex = 9;
            this.lbl_MensajeBot.Text = "Mensaje BOT";
            this.lbl_MensajeBot.Visible = false;
            // 
            // flp_cartasEnManoJ1
            // 
            this.flp_cartasEnManoJ1.Location = new System.Drawing.Point(259, 557);
            this.flp_cartasEnManoJ1.Name = "flp_cartasEnManoJ1";
            this.flp_cartasEnManoJ1.Size = new System.Drawing.Size(370, 164);
            this.flp_cartasEnManoJ1.TabIndex = 10;
            // 
            // flp_cartasEnMesaJ1
            // 
            this.flp_cartasEnMesaJ1.Location = new System.Drawing.Point(259, 370);
            this.flp_cartasEnMesaJ1.Name = "flp_cartasEnMesaJ1";
            this.flp_cartasEnMesaJ1.Size = new System.Drawing.Size(370, 164);
            this.flp_cartasEnMesaJ1.TabIndex = 11;
            // 
            // flp_cartasEnMesaJ2
            // 
            this.flp_cartasEnMesaJ2.Location = new System.Drawing.Point(259, 213);
            this.flp_cartasEnMesaJ2.Name = "flp_cartasEnMesaJ2";
            this.flp_cartasEnMesaJ2.Size = new System.Drawing.Size(370, 164);
            this.flp_cartasEnMesaJ2.TabIndex = 12;
            // 
            // flp_cartasEnManoJ2
            // 
            this.flp_cartasEnManoJ2.Location = new System.Drawing.Point(259, 31);
            this.flp_cartasEnManoJ2.Name = "flp_cartasEnManoJ2";
            this.flp_cartasEnManoJ2.Size = new System.Drawing.Size(370, 164);
            this.flp_cartasEnManoJ2.TabIndex = 13;
            // 
            // lbl_MensajeUsuario
            // 
            this.lbl_MensajeUsuario.AutoSize = true;
            this.lbl_MensajeUsuario.BackColor = System.Drawing.Color.White;
            this.lbl_MensajeUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_MensajeUsuario.ForeColor = System.Drawing.Color.Black;
            this.lbl_MensajeUsuario.Location = new System.Drawing.Point(680, 478);
            this.lbl_MensajeUsuario.Name = "lbl_MensajeUsuario";
            this.lbl_MensajeUsuario.Size = new System.Drawing.Size(154, 25);
            this.lbl_MensajeUsuario.TabIndex = 9;
            this.lbl_MensajeUsuario.Text = "Mensaje Usuario";
            this.lbl_MensajeUsuario.Visible = false;
            // 
            // btn_SerializarXml
            // 
            this.btn_SerializarXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_SerializarXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SerializarXml.FlatAppearance.BorderSize = 0;
            this.btn_SerializarXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SerializarXml.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_SerializarXml.ForeColor = System.Drawing.Color.White;
            this.btn_SerializarXml.Location = new System.Drawing.Point(55, 348);
            this.btn_SerializarXml.Name = "btn_SerializarXml";
            this.btn_SerializarXml.Size = new System.Drawing.Size(128, 46);
            this.btn_SerializarXml.TabIndex = 3;
            this.btn_SerializarXml.Text = "Guardar registro en XML";
            this.btn_SerializarXml.UseVisualStyleBackColor = false;
            this.btn_SerializarXml.Visible = false;
            this.btn_SerializarXml.Click += new System.EventHandler(this.btn_SerializarXml_Click);
            // 
            // btn_SerializarJson
            // 
            this.btn_SerializarJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_SerializarJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SerializarJson.FlatAppearance.BorderSize = 0;
            this.btn_SerializarJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SerializarJson.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_SerializarJson.ForeColor = System.Drawing.Color.White;
            this.btn_SerializarJson.Location = new System.Drawing.Point(55, 285);
            this.btn_SerializarJson.Name = "btn_SerializarJson";
            this.btn_SerializarJson.Size = new System.Drawing.Size(128, 46);
            this.btn_SerializarJson.TabIndex = 3;
            this.btn_SerializarJson.Text = "Guardar registro en JSON";
            this.btn_SerializarJson.UseVisualStyleBackColor = false;
            this.btn_SerializarJson.Visible = false;
            this.btn_SerializarJson.Click += new System.EventHandler(this.btn_SerializarJson_Click);
            // 
            // btn_CerrarSinGuardar
            // 
            this.btn_CerrarSinGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_CerrarSinGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CerrarSinGuardar.FlatAppearance.BorderSize = 0;
            this.btn_CerrarSinGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CerrarSinGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_CerrarSinGuardar.ForeColor = System.Drawing.Color.White;
            this.btn_CerrarSinGuardar.Location = new System.Drawing.Point(37, 417);
            this.btn_CerrarSinGuardar.Name = "btn_CerrarSinGuardar";
            this.btn_CerrarSinGuardar.Size = new System.Drawing.Size(170, 46);
            this.btn_CerrarSinGuardar.TabIndex = 3;
            this.btn_CerrarSinGuardar.Text = "Cerrar sin guardar";
            this.btn_CerrarSinGuardar.UseVisualStyleBackColor = false;
            this.btn_CerrarSinGuardar.Visible = false;
            this.btn_CerrarSinGuardar.Click += new System.EventHandler(this.btn_CerrarSinGuardar_Click);
            // 
            // pictureBox_bot
            // 
            this.pictureBox_bot.Image = global::Vista.Properties.Resources.dialogo;
            this.pictureBox_bot.Location = new System.Drawing.Point(635, 92);
            this.pictureBox_bot.Name = "pictureBox_bot";
            this.pictureBox_bot.Size = new System.Drawing.Size(240, 136);
            this.pictureBox_bot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_bot.TabIndex = 14;
            this.pictureBox_bot.TabStop = false;
            this.pictureBox_bot.Visible = false;
            // 
            // pictureBox_Usuario
            // 
            this.pictureBox_Usuario.Image = global::Vista.Properties.Resources.dialogo;
            this.pictureBox_Usuario.Location = new System.Drawing.Point(622, 432);
            this.pictureBox_Usuario.Name = "pictureBox_Usuario";
            this.pictureBox_Usuario.Size = new System.Drawing.Size(253, 147);
            this.pictureBox_Usuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Usuario.TabIndex = 14;
            this.pictureBox_Usuario.TabStop = false;
            this.pictureBox_Usuario.Visible = false;
            // 
            // btn_CancelarPartida
            // 
            this.btn_CancelarPartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_CancelarPartida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CancelarPartida.FlatAppearance.BorderSize = 0;
            this.btn_CancelarPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarPartida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_CancelarPartida.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarPartida.Location = new System.Drawing.Point(37, 58);
            this.btn_CancelarPartida.Name = "btn_CancelarPartida";
            this.btn_CancelarPartida.Size = new System.Drawing.Size(174, 40);
            this.btn_CancelarPartida.TabIndex = 3;
            this.btn_CancelarPartida.Text = "Cancelar partida";
            this.btn_CancelarPartida.UseVisualStyleBackColor = false;
            this.btn_CancelarPartida.Visible = false;
            this.btn_CancelarPartida.Click += new System.EventHandler(this.btn_CancelarPartida_Click);
            // 
            // FrmUsuarioVsBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(21)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(880, 729);
            this.Controls.Add(this.btn_CerrarSinGuardar);
            this.Controls.Add(this.lbl_MensajeUsuario);
            this.Controls.Add(this.btn_SerializarXml);
            this.Controls.Add(this.lbl_mensajeAnunciarGanador);
            this.Controls.Add(this.btn_SerializarJson);
            this.Controls.Add(this.lbl_MensajeBot);
            this.Controls.Add(this.flp_cartasEnManoJ2);
            this.Controls.Add(this.flp_cartasEnMesaJ2);
            this.Controls.Add(this.flp_cartasEnMesaJ1);
            this.Controls.Add(this.flp_cartasEnManoJ1);
            this.Controls.Add(this.btn_CancelarPartida);
            this.Controls.Add(this.btn_Jugar);
            this.Controls.Add(this.panel_tablaPuntajes);
            this.Controls.Add(this.pictureBox_Usuario);
            this.Controls.Add(this.pictureBox_bot);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(896, 768);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(896, 768);
            this.Name = "FrmUsuarioVsBot";
            this.Text = "Usuario vs BOT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUsuarioVsBot_FormClosing);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel_tablaPuntajes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Usuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel_tablaPuntajes;
        private System.Windows.Forms.Label lbl_tituloPuntaje;
        private System.Windows.Forms.Label lbl_TituloUsuario;
        private System.Windows.Forms.Label lbl_TituloBot;
        private System.Windows.Forms.Label lbl_puntajeUsuario;
        private System.Windows.Forms.Label lbl_PuntajeBot;
        private System.Windows.Forms.Button btn_Jugar;
        private System.Windows.Forms.Label lbl_mensajeAnunciarGanador;
        private System.Windows.Forms.Label lbl_MensajeBot;
        private System.Windows.Forms.FlowLayoutPanel flp_cartasEnManoJ1;
        private System.Windows.Forms.FlowLayoutPanel flp_cartasEnMesaJ1;
        private System.Windows.Forms.FlowLayoutPanel flp_cartasEnMesaJ2;
        private System.Windows.Forms.FlowLayoutPanel flp_cartasEnManoJ2;
        private System.Windows.Forms.Label lbl_MensajeUsuario;
        private System.Windows.Forms.Button btn_SerializarXml;
        private System.Windows.Forms.Button btn_SerializarJson;
        private System.Windows.Forms.Button btn_CerrarSinGuardar;
        private System.Windows.Forms.PictureBox pictureBox_bot;
        private System.Windows.Forms.PictureBox pictureBox_Usuario;
        private System.Windows.Forms.Button btn_CancelarPartida;
    }
}