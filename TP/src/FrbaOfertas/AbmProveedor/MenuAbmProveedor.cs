using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class MenuAbmProveedor : Form
    {
        public MenuAbmProveedor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu_Principal.MenuAdmin().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmProveedor.FiltroBMProveedor().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmProveedor.RegistroProveedor(1).Show();
        }
    }
}
