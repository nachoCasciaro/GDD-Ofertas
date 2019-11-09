using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class MenuAbmRol : Form
    {
        public MenuAbmRol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Alta rol
        {
            this.Hide();
            new AbmRol.AltaRol().Show();
        }

        private void button2_Click(object sender, EventArgs e) //Baja modificacion rol
        {
            this.Hide();
            new AbmRol.BMRol().Show();

        }

        private void button3_Click(object sender, EventArgs e) //Volver al menu principal
        {
            this.Hide();
            new Menu_Principal.MenuAdmin().Show();
        }

    }
}
