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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginAdmin().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginCliente().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginProveedor().Show();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}
