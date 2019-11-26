using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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

        private bool existeProveedor(int idProveedor)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_existe_proveedor", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@idProvee", idProveedor));
            query.Parameters.Add("@resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            bool resultado = Convert.ToBoolean(query.Parameters["@resultado"].Value);

            return resultado;
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

                if (this.existeProveedor(idProve))
                {
                    this.Hide();
                    new CrearOferta(idProve, parent).Show();
                }
                else
                {
                    MessageBox.Show("El id ingresado no corresponde a un proveedor existente, inténtelo de nuevo.");
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }
    }
}
