using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Login
{
    public partial class LoginProveedor : Form
    {
        public LoginProveedor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmProveedor.RegistroProveedor().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu_Principal.MenuProveedor().Show();
        }
    }
}
