using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CrearOferta
{
    public partial class IndicarProveedorReferenciaOferta : Form
    {
        Form parent;

        public IndicarProveedorReferenciaOferta(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Debe completar el id del proveedor.");
            }
            else
            {
                int idProve = Convert.ToInt32(textBox1.Text);
                this.Hide();
                new CrearOferta( idProve, parent).Show();
            }
        }
    }
}
