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
    public partial class MenuProveedor : Form
    {
        public MenuProveedor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CrearOferta.CrearOferta().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //new consumoOferta
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.Login().Show();
        }
    }
}
