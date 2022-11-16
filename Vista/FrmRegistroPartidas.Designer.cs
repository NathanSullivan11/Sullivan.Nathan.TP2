
namespace Vista
{
    partial class FrmRegistroPartidas
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
            this.dtg_RegistroPartidas = new System.Windows.Forms.DataGridView();
            this.btn_EstadisticasPartidasBotBot = new System.Windows.Forms.Button();
            this.btn_EstadisticasPartidasUsuarioBot = new System.Windows.Forms.Button();
            this.rbtn_xml = new System.Windows.Forms.RadioButton();
            this.rbtn_json = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_RegistroPartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_RegistroPartidas
            // 
            this.dtg_RegistroPartidas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(1)))));
            this.dtg_RegistroPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_RegistroPartidas.Location = new System.Drawing.Point(12, 64);
            this.dtg_RegistroPartidas.Name = "dtg_RegistroPartidas";
            this.dtg_RegistroPartidas.RowHeadersVisible = false;
            this.dtg_RegistroPartidas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtg_RegistroPartidas.RowTemplate.Height = 25;
            this.dtg_RegistroPartidas.Size = new System.Drawing.Size(721, 212);
            this.dtg_RegistroPartidas.TabIndex = 0;
            // 
            // btn_EstadisticasPartidasBotBot
            // 
            this.btn_EstadisticasPartidasBotBot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_EstadisticasPartidasBotBot.FlatAppearance.BorderSize = 0;
            this.btn_EstadisticasPartidasBotBot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EstadisticasPartidasBotBot.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_EstadisticasPartidasBotBot.ForeColor = System.Drawing.Color.White;
            this.btn_EstadisticasPartidasBotBot.Location = new System.Drawing.Point(225, 12);
            this.btn_EstadisticasPartidasBotBot.Name = "btn_EstadisticasPartidasBotBot";
            this.btn_EstadisticasPartidasBotBot.Size = new System.Drawing.Size(239, 40);
            this.btn_EstadisticasPartidasBotBot.TabIndex = 1;
            this.btn_EstadisticasPartidasBotBot.Text = "Mostrar partidas: Bot vs Bot";
            this.btn_EstadisticasPartidasBotBot.UseVisualStyleBackColor = false;
            this.btn_EstadisticasPartidasBotBot.Click += new System.EventHandler(this.btn_EstadisticasPartidasBotBot_Click);
            // 
            // btn_EstadisticasPartidasUsuarioBot
            // 
            this.btn_EstadisticasPartidasUsuarioBot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(149)))), ((int)(((byte)(68)))));
            this.btn_EstadisticasPartidasUsuarioBot.FlatAppearance.BorderSize = 0;
            this.btn_EstadisticasPartidasUsuarioBot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EstadisticasPartidasUsuarioBot.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_EstadisticasPartidasUsuarioBot.ForeColor = System.Drawing.Color.White;
            this.btn_EstadisticasPartidasUsuarioBot.Location = new System.Drawing.Point(494, 12);
            this.btn_EstadisticasPartidasUsuarioBot.Name = "btn_EstadisticasPartidasUsuarioBot";
            this.btn_EstadisticasPartidasUsuarioBot.Size = new System.Drawing.Size(239, 40);
            this.btn_EstadisticasPartidasUsuarioBot.TabIndex = 1;
            this.btn_EstadisticasPartidasUsuarioBot.Text = "Mostrar partidas: User vs Bot";
            this.btn_EstadisticasPartidasUsuarioBot.UseVisualStyleBackColor = false;
            this.btn_EstadisticasPartidasUsuarioBot.Click += new System.EventHandler(this.btn_EstadisticasPartidasUsuarioBot_Click);
            // 
            // rbtn_xml
            // 
            this.rbtn_xml.AutoSize = true;
            this.rbtn_xml.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbtn_xml.ForeColor = System.Drawing.Color.White;
            this.rbtn_xml.Location = new System.Drawing.Point(27, 29);
            this.rbtn_xml.Name = "rbtn_xml";
            this.rbtn_xml.Size = new System.Drawing.Size(161, 23);
            this.rbtn_xml.TabIndex = 2;
            this.rbtn_xml.TabStop = true;
            this.rbtn_xml.Text = "Deserializacion XML";
            this.rbtn_xml.UseVisualStyleBackColor = true;
            // 
            // rbtn_json
            // 
            this.rbtn_json.AutoSize = true;
            this.rbtn_json.Checked = true;
            this.rbtn_json.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbtn_json.ForeColor = System.Drawing.Color.White;
            this.rbtn_json.Location = new System.Drawing.Point(27, 8);
            this.rbtn_json.Name = "rbtn_json";
            this.rbtn_json.Size = new System.Drawing.Size(168, 23);
            this.rbtn_json.TabIndex = 2;
            this.rbtn_json.TabStop = true;
            this.rbtn_json.Text = "Deserializacion JSON";
            this.rbtn_json.UseVisualStyleBackColor = true;
            // 
            // FrmRegistroPartidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(745, 291);
            this.Controls.Add(this.rbtn_json);
            this.Controls.Add(this.rbtn_xml);
            this.Controls.Add(this.btn_EstadisticasPartidasUsuarioBot);
            this.Controls.Add(this.btn_EstadisticasPartidasBotBot);
            this.Controls.Add(this.dtg_RegistroPartidas);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(761, 330);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(761, 330);
            this.Name = "FrmRegistroPartidas";
            this.Text = "Registro partidas";
            this.Load += new System.EventHandler(this.FrmRegistroPartidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_RegistroPartidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_RegistroPartidas;
        private System.Windows.Forms.Button btn_EstadisticasPartidasBotBot;
        private System.Windows.Forms.Button btn_EstadisticasPartidasUsuarioBot;
        private System.Windows.Forms.RadioButton rbtn_xml;
        private System.Windows.Forms.RadioButton rbtn_json;
    }
}