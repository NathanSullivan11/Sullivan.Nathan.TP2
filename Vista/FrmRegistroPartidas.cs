﻿using System;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = Environment.CurrentDirectory + @"/ArchivosJSON";
            this.folderBrowserDialog1.ShowDialog();
        }
    }
}
