﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class MenuAbmCliente : Form
    {
        Form parent;

        public MenuAbmCliente(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void MenuAbmCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new AbmCliente.FiltroBMCliente().Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new AbmCliente.RegistroCliente(1).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
