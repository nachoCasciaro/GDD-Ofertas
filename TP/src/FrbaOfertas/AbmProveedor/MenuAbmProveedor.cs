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
        Form parent;

        public MenuAbmProveedor(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmProveedor.FiltroBMProveedor(this).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmProveedor.RegistroProveedor(this).Show();
        }
    }
}
