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
        Form parent;

        public MenuAbmRol(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Alta rol
        {
            this.Hide();
            new AbmRol.AltaRol(this).Show();
        }

        private void button2_Click(object sender, EventArgs e) //Baja modificacion rol
        {
            this.Hide();
            new AbmRol.BMRol(this).Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }

    }
}
