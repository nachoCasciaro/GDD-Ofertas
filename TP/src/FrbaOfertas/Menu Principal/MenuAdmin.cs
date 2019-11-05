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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmCliente.MenuAbmCliente().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmProveedor.MenuAbmProveedor().Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.Login().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Facturar.Form1().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoEstadistico.ListadoEstadistico().Show();
        }
    }
}
