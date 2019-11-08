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
    public partial class LoginCliente : Form
    {
        public LoginCliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmCliente.RegistroCliente(2).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sp login
            //hacer funcion que de acuerdo al username te pase el id del cliente
            int idCliente = 1;
            this.Hide();
            new Menu_Principal.MenuCliente(idCliente).Show();
        }
    }
}
