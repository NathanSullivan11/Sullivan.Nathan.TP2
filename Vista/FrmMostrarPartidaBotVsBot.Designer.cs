
namespace Vista
{
    partial class FrmMostrarPartidaBotVsBot
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
            this.richTBox_InformacionSalasAbiertas = new System.Windows.Forms.RichTextBox();
            this.btn_GuardarEnTxt = new System.Windows.Forms.Button();
            this.btn_CerrarSala = new System.Windows.Forms.Button();
            this.btn_CancelarPartida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTBox_InformacionSalasAbiertas
            // 
            this.richTBox_InformacionSalasAbiertas.BackColor = System.Drawing.Color.Linen;
            this.richTBox_InformacionSalasAbiertas.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTBox_InformacionSalasAbiertas.Location = new System.Drawing.Point(44, 44);
            this.richTBox_InformacionSalasAbiertas.Name = "richTBox_InformacionSalasAbiertas";
            this.richTBox_InformacionSalasAbiertas.ReadOnly = true;
            this.richTBox_InformacionSalasAbiertas.Size = new System.Drawing.Size(296, 318);
            this.richTBox_InformacionSalasAbiertas.TabIndex = 0;
            this.richTBox_InformacionSalasAbiertas.Text = "";
            // 
            // btn_GuardarEnTxt
            // 
            this.btn_GuardarEnTxt.BackColor = System.Drawing.Color.Linen;
            this.btn_GuardarEnTxt.FlatAppearance.BorderSize = 0;
            this.btn_GuardarEnTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarEnTxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_GuardarEnTxt.Location = new System.Drawing.Point(44, 377);
            this.btn_GuardarEnTxt.Name = "btn_GuardarEnTxt";
            this.btn_GuardarEnTxt.Size = new System.Drawing.Size(138, 48);
            this.btn_GuardarEnTxt.TabIndex = 1;
            this.btn_GuardarEnTxt.Text = "Guardar registro en un archivo de texto";
            this.btn_GuardarEnTxt.UseVisualStyleBackColor = false;
            this.btn_GuardarEnTxt.Visible = false;
            this.btn_GuardarEnTxt.Click += new System.EventHandler(this.btn_GuardarEnTxt_Click);
            // 
            // btn_CerrarSala
            // 
            this.btn_CerrarSala.BackColor = System.Drawing.Color.Linen;
            this.btn_CerrarSala.FlatAppearance.BorderSize = 0;
            this.btn_CerrarSala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CerrarSala.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_CerrarSala.Location = new System.Drawing.Point(202, 377);
            this.btn_CerrarSala.Name = "btn_CerrarSala";
            this.btn_CerrarSala.Size = new System.Drawing.Size(138, 48);
            this.btn_CerrarSala.TabIndex = 1;
            this.btn_CerrarSala.Text = "Cerrar sin guardar";
            this.btn_CerrarSala.UseVisualStyleBackColor = false;
            this.btn_CerrarSala.Visible = false;
            this.btn_CerrarSala.Click += new System.EventHandler(this.btn_CerrarSala_Click);
            // 
            // btn_CancelarPartida
            // 
            this.btn_CancelarPartida.BackColor = System.Drawing.Color.Linen;
            this.btn_CancelarPartida.FlatAppearance.BorderSize = 0;
            this.btn_CancelarPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarPartida.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_CancelarPartida.Location = new System.Drawing.Point(127, 12);
            this.btn_CancelarPartida.Name = "btn_CancelarPartida";
            this.btn_CancelarPartida.Size = new System.Drawing.Size(138, 26);
            this.btn_CancelarPartida.TabIndex = 1;
            this.btn_CancelarPartida.Text = "CANCELAR PARTIDA";
            this.btn_CancelarPartida.UseVisualStyleBackColor = false;
            this.btn_CancelarPartida.Click += new System.EventHandler(this.btn_CancelarPartida_Click);
            // 
            // FrmMostrarPartidaBotVsBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(395, 440);
            this.Controls.Add(this.btn_CancelarPartida);
            this.Controls.Add(this.btn_CerrarSala);
            this.Controls.Add(this.btn_GuardarEnTxt);
            this.Controls.Add(this.richTBox_InformacionSalasAbiertas);
            this.Name = "FrmMostrarPartidaBotVsBot";
            this.Text = "FrmMostrar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMostrar_FormClosing);
            this.Load += new System.EventHandler(this.FrmMostrar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTBox_InformacionSalasAbiertas;
        private System.Windows.Forms.Button btn_GuardarEnTxt;
        private System.Windows.Forms.Button btn_CerrarSala;
        private System.Windows.Forms.Button btn_CancelarPartida;
    }
}