
namespace Vista
{
    partial class FrmEstadisticasJugadores
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
            this.dgv_EstadisticasJugadores = new System.Windows.Forms.DataGridView();
            this.btn_AgregarJugador = new System.Windows.Forms.Button();
            this.btn_EliminarJugador = new System.Windows.Forms.Button();
            this.txt_NombreIngresado = new System.Windows.Forms.TextBox();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.chk_esUsuario = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EstadisticasJugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_EstadisticasJugadores
            // 
            this.dgv_EstadisticasJugadores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(1)))));
            this.dgv_EstadisticasJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EstadisticasJugadores.Location = new System.Drawing.Point(12, 12);
            this.dgv_EstadisticasJugadores.Name = "dgv_EstadisticasJugadores";
            this.dgv_EstadisticasJugadores.RowHeadersVisible = false;
            this.dgv_EstadisticasJugadores.RowTemplate.Height = 25;
            this.dgv_EstadisticasJugadores.Size = new System.Drawing.Size(415, 273);
            this.dgv_EstadisticasJugadores.TabIndex = 0;
            // 
            // btn_AgregarJugador
            // 
            this.btn_AgregarJugador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_AgregarJugador.FlatAppearance.BorderSize = 0;
            this.btn_AgregarJugador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AgregarJugador.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_AgregarJugador.Location = new System.Drawing.Point(433, 12);
            this.btn_AgregarJugador.Name = "btn_AgregarJugador";
            this.btn_AgregarJugador.Size = new System.Drawing.Size(123, 61);
            this.btn_AgregarJugador.TabIndex = 1;
            this.btn_AgregarJugador.Text = "Agregar jugador";
            this.btn_AgregarJugador.UseVisualStyleBackColor = false;
            this.btn_AgregarJugador.Click += new System.EventHandler(this.btn_AgregarJugador_Click);
            // 
            // btn_EliminarJugador
            // 
            this.btn_EliminarJugador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_EliminarJugador.FlatAppearance.BorderSize = 0;
            this.btn_EliminarJugador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EliminarJugador.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_EliminarJugador.Location = new System.Drawing.Point(433, 224);
            this.btn_EliminarJugador.Name = "btn_EliminarJugador";
            this.btn_EliminarJugador.Size = new System.Drawing.Size(123, 61);
            this.btn_EliminarJugador.TabIndex = 1;
            this.btn_EliminarJugador.Text = "Eliminar jugador";
            this.btn_EliminarJugador.UseVisualStyleBackColor = false;
            this.btn_EliminarJugador.Click += new System.EventHandler(this.btn_EliminarJugador_Click);
            // 
            // txt_NombreIngresado
            // 
            this.txt_NombreIngresado.Location = new System.Drawing.Point(433, 101);
            this.txt_NombreIngresado.Name = "txt_NombreIngresado";
            this.txt_NombreIngresado.PlaceholderText = "Ingrese Nombre";
            this.txt_NombreIngresado.Size = new System.Drawing.Size(123, 23);
            this.txt_NombreIngresado.TabIndex = 2;
            this.txt_NombreIngresado.Visible = false;
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(465, 150);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(59, 23);
            this.btn_Agregar.TabIndex = 3;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Visible = false;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // chk_esUsuario
            // 
            this.chk_esUsuario.AutoSize = true;
            this.chk_esUsuario.ForeColor = System.Drawing.Color.White;
            this.chk_esUsuario.Location = new System.Drawing.Point(450, 130);
            this.chk_esUsuario.Name = "chk_esUsuario";
            this.chk_esUsuario.Size = new System.Drawing.Size(79, 19);
            this.chk_esUsuario.TabIndex = 4;
            this.chk_esUsuario.Text = "Es usuario";
            this.chk_esUsuario.UseVisualStyleBackColor = true;
            this.chk_esUsuario.Visible = false;
            // 
            // FrmEstadisticasJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(565, 299);
            this.Controls.Add(this.chk_esUsuario);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.txt_NombreIngresado);
            this.Controls.Add(this.btn_EliminarJugador);
            this.Controls.Add(this.btn_AgregarJugador);
            this.Controls.Add(this.dgv_EstadisticasJugadores);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(581, 338);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(581, 338);
            this.Name = "FrmEstadisticasJugadores";
            this.Text = "Estadísticas de jugadores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEstadisticasJugadores_FormClosing);
            this.Load += new System.EventHandler(this.FrmEstadisticasJugadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EstadisticasJugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_EstadisticasJugadores;
        private System.Windows.Forms.Button btn_AgregarJugador;
        private System.Windows.Forms.Button btn_EliminarJugador;
        private System.Windows.Forms.TextBox txt_NombreIngresado;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.CheckBox chk_esUsuario;
    }
}