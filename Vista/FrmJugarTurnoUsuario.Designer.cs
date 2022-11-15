
namespace Vista
{
    partial class FrmJugarTurnoUsuario
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
            this.btn_IrseAlMazo = new System.Windows.Forms.Button();
            this.btn_cantarEnvido = new System.Windows.Forms.Button();
            this.btn_cantarTruco = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cartaUnoEnMano = new Vista.ImagenCarta();
            this.cartaDosEnMano = new Vista.ImagenCarta();
            this.cartaTresEnMano = new Vista.ImagenCarta();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_IrseAlMazo
            // 
            this.btn_IrseAlMazo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_IrseAlMazo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_IrseAlMazo.FlatAppearance.BorderSize = 0;
            this.btn_IrseAlMazo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IrseAlMazo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_IrseAlMazo.ForeColor = System.Drawing.Color.White;
            this.btn_IrseAlMazo.Location = new System.Drawing.Point(63, 50);
            this.btn_IrseAlMazo.Name = "btn_IrseAlMazo";
            this.btn_IrseAlMazo.Size = new System.Drawing.Size(152, 27);
            this.btn_IrseAlMazo.TabIndex = 4;
            this.btn_IrseAlMazo.Text = "Irse al mazo";
            this.btn_IrseAlMazo.UseVisualStyleBackColor = false;
            this.btn_IrseAlMazo.Visible = false;
            this.btn_IrseAlMazo.Click += new System.EventHandler(this.btn_IrseAlMazo_Click);
            // 
            // btn_cantarEnvido
            // 
            this.btn_cantarEnvido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_cantarEnvido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cantarEnvido.FlatAppearance.BorderSize = 0;
            this.btn_cantarEnvido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cantarEnvido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_cantarEnvido.ForeColor = System.Drawing.Color.White;
            this.btn_cantarEnvido.Location = new System.Drawing.Point(145, 12);
            this.btn_cantarEnvido.Name = "btn_cantarEnvido";
            this.btn_cantarEnvido.Size = new System.Drawing.Size(121, 32);
            this.btn_cantarEnvido.TabIndex = 5;
            this.btn_cantarEnvido.Text = "Cantar envido";
            this.btn_cantarEnvido.UseVisualStyleBackColor = false;
            this.btn_cantarEnvido.Visible = false;
            this.btn_cantarEnvido.Click += new System.EventHandler(this.btn_cantarEnvido_Click);
            // 
            // btn_cantarTruco
            // 
            this.btn_cantarTruco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_cantarTruco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cantarTruco.FlatAppearance.BorderSize = 0;
            this.btn_cantarTruco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cantarTruco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_cantarTruco.ForeColor = System.Drawing.Color.White;
            this.btn_cantarTruco.Location = new System.Drawing.Point(15, 12);
            this.btn_cantarTruco.Name = "btn_cantarTruco";
            this.btn_cantarTruco.Size = new System.Drawing.Size(116, 32);
            this.btn_cantarTruco.TabIndex = 6;
            this.btn_cantarTruco.Text = "Cantar truco";
            this.btn_cantarTruco.UseVisualStyleBackColor = false;
            this.btn_cantarTruco.Visible = false;
            this.btn_cantarTruco.Click += new System.EventHandler(this.btn_cantarTruco_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.cartaUnoEnMano, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cartaDosEnMano, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cartaTresEnMano, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(257, 105);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // cartaUnoEnMano
            // 
            this.cartaUnoEnMano.BackColor = System.Drawing.Color.Transparent;
            this.cartaUnoEnMano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cartaUnoEnMano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartaUnoEnMano.EsDeUsuario = false;
            this.cartaUnoEnMano.Imagen = null;
            this.cartaUnoEnMano.Location = new System.Drawing.Point(3, 3);
            this.cartaUnoEnMano.Name = "cartaUnoEnMano";
            this.cartaUnoEnMano.Size = new System.Drawing.Size(79, 99);
            this.cartaUnoEnMano.TabIndex = 0;
            this.cartaUnoEnMano.Tag = "carta1";
            this.cartaUnoEnMano.Click += new System.EventHandler(this.cartaSeleccionada);
            // 
            // cartaDosEnMano
            // 
            this.cartaDosEnMano.BackColor = System.Drawing.Color.Transparent;
            this.cartaDosEnMano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cartaDosEnMano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartaDosEnMano.EsDeUsuario = false;
            this.cartaDosEnMano.Imagen = null;
            this.cartaDosEnMano.Location = new System.Drawing.Point(88, 3);
            this.cartaDosEnMano.Name = "cartaDosEnMano";
            this.cartaDosEnMano.Size = new System.Drawing.Size(79, 99);
            this.cartaDosEnMano.TabIndex = 1;
            this.cartaDosEnMano.Tag = "carta2";
            this.cartaDosEnMano.Click += new System.EventHandler(this.cartaSeleccionada);
            // 
            // cartaTresEnMano
            // 
            this.cartaTresEnMano.BackColor = System.Drawing.Color.Transparent;
            this.cartaTresEnMano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cartaTresEnMano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartaTresEnMano.EsDeUsuario = false;
            this.cartaTresEnMano.Imagen = null;
            this.cartaTresEnMano.Location = new System.Drawing.Point(173, 3);
            this.cartaTresEnMano.Name = "cartaTresEnMano";
            this.cartaTresEnMano.Size = new System.Drawing.Size(81, 99);
            this.cartaTresEnMano.TabIndex = 2;
            this.cartaTresEnMano.Tag = "carta3";
            this.cartaTresEnMano.Click += new System.EventHandler(this.cartaSeleccionada);
            // 
            // FrmJugarTurnoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 200);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_IrseAlMazo);
            this.Controls.Add(this.btn_cantarEnvido);
            this.Controls.Add(this.btn_cantarTruco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmJugarTurnoUsuario";
            this.Text = "FrmJugarTurnoUsuario";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_IrseAlMazo;
        private System.Windows.Forms.Button btn_cantarEnvido;
        private System.Windows.Forms.Button btn_cantarTruco;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ImagenCarta cartaUnoEnMano;
        private ImagenCarta cartaDosEnMano;
        private ImagenCarta cartaTresEnMano;
    }
}