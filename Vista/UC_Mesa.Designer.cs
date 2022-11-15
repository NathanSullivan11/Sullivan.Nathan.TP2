
namespace Vista
{
    partial class UC_Mesa
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        public void InitializeComponent()
        {
            this.btn_VerSala = new System.Windows.Forms.Button();
            this.pbox_J1vsJ2 = new System.Windows.Forms.PictureBox();
            this.lbl_Jugador1 = new System.Windows.Forms.Label();
            this.lbl_Jugador2 = new System.Windows.Forms.Label();
            this.lbl_Puntaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_J1vsJ2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_VerSala
            // 
            this.btn_VerSala.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(1)))));
            this.btn_VerSala.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_VerSala.FlatAppearance.BorderSize = 0;
            this.btn_VerSala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_VerSala.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_VerSala.ForeColor = System.Drawing.Color.White;
            this.btn_VerSala.Location = new System.Drawing.Point(0, 108);
            this.btn_VerSala.Margin = new System.Windows.Forms.Padding(5);
            this.btn_VerSala.Name = "btn_VerSala";
            this.btn_VerSala.Size = new System.Drawing.Size(187, 30);
            this.btn_VerSala.TabIndex = 0;
            this.btn_VerSala.Text = "Ver";
            this.btn_VerSala.UseVisualStyleBackColor = false;
            this.btn_VerSala.Click += new System.EventHandler(this.btn_VerSala_Click);
            // 
            // pbox_J1vsJ2
            // 
            this.pbox_J1vsJ2.Image = global::Vista.Properties.Resources.versus__1_;
            this.pbox_J1vsJ2.Location = new System.Drawing.Point(72, 66);
            this.pbox_J1vsJ2.Name = "pbox_J1vsJ2";
            this.pbox_J1vsJ2.Size = new System.Drawing.Size(40, 34);
            this.pbox_J1vsJ2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_J1vsJ2.TabIndex = 12;
            this.pbox_J1vsJ2.TabStop = false;
            // 
            // lbl_Jugador1
            // 
            this.lbl_Jugador1.AutoSize = true;
            this.lbl_Jugador1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Jugador1.Location = new System.Drawing.Point(13, 50);
            this.lbl_Jugador1.Name = "lbl_Jugador1";
            this.lbl_Jugador1.Size = new System.Drawing.Size(19, 15);
            this.lbl_Jugador1.TabIndex = 10;
            this.lbl_Jugador1.Text = "J1";
            // 
            // lbl_Jugador2
            // 
            this.lbl_Jugador2.AutoSize = true;
            this.lbl_Jugador2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Jugador2.Location = new System.Drawing.Point(124, 50);
            this.lbl_Jugador2.Name = "lbl_Jugador2";
            this.lbl_Jugador2.Size = new System.Drawing.Size(19, 15);
            this.lbl_Jugador2.TabIndex = 11;
            this.lbl_Jugador2.Text = "J2";
            // 
            // lbl_Puntaje
            // 
            this.lbl_Puntaje.AutoSize = true;
            this.lbl_Puntaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Puntaje.Location = new System.Drawing.Point(72, 16);
            this.lbl_Puntaje.Name = "lbl_Puntaje";
            this.lbl_Puntaje.Size = new System.Drawing.Size(40, 21);
            this.lbl_Puntaje.TabIndex = 9;
            this.lbl_Puntaje.Text = "0 : 0";
            // 
            // UC_Mesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.Controls.Add(this.pbox_J1vsJ2);
            this.Controls.Add(this.lbl_Jugador1);
            this.Controls.Add(this.lbl_Jugador2);
            this.Controls.Add(this.lbl_Puntaje);
            this.Controls.Add(this.btn_VerSala);
            this.MaximumSize = new System.Drawing.Size(187, 138);
            this.MinimumSize = new System.Drawing.Size(187, 138);
            this.Name = "UC_Mesa";
            this.Size = new System.Drawing.Size(187, 138);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_J1vsJ2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_VerSala;
        public System.Windows.Forms.PictureBox pbox_J1vsJ2;
        public System.Windows.Forms.Label lbl_Jugador1;
        public System.Windows.Forms.Label lbl_Jugador2;
        public System.Windows.Forms.Label lbl_Puntaje;
    }
}
