using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Menu_Principal
{
    public partial class MenuCliente : Form
    {
        public MenuCliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CargaCredito.CargaCredito().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ComprarOferta.ComprarOferta().Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.Login().Show();

        }
    }
}
