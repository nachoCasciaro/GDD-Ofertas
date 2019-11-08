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
            new AbmProveedor.RegistroProveedor(2).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hacer la funcion que le pases el username y te devuelve a que id de proveedor corresponda
            int idProveedor = 1;
            this.Hide();
            new Menu_Principal.MenuProveedor(idProveedor).Show();
        }
    }
}
