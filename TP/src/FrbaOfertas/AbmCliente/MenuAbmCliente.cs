using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class MenuAbmCliente : Form
    {
        public MenuAbmCliente()
        {
            InitializeComponent();
        }

        private void MenuAbmCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmCliente.FiltroBMCliente().Show();

        }
    }
}
