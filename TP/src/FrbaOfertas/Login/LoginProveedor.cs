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

        private int idProveedorIngresado(string username)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_obtener_id_proveedor", connection);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add(new SqlParameter("@user", username));
            query.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

            connection.Open();
            query.ExecuteNonQuery();

            int resultado = Convert.ToInt32(query.Parameters["@resultado"].Value);

            connection.Close();

            return resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_login", connection);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add(new SqlParameter("@user", this.textBox1.Text));
            query.Parameters.Add(new SqlParameter("@pass", this.textBox2.Text));
            query.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

            connection.Open();
            query.ExecuteNonQuery();

            int resultado = Convert.ToInt32(query.Parameters["@resultado"].Value);

            connection.Close();

            if (resultado == 4)
            {
                this.Hide();

                int idProveedor = this.idProveedorIngresado(this.textBox1.Text);

                new Menu_Principal.MenuProveedor(idProveedor).Show();
            }
            else if (resultado == 2)
            {
                MessageBox.Show("Contraseña incorrecta, intentelo de nuevo");

            }
            else if (resultado == 1)
            {
                MessageBox.Show("El usuario ingresado no existe");
            }
            else if (resultado == 3)
            {
                MessageBox.Show("El usuario ingresado se encuentra inhabilitado, consultar con el administrador");
            }

        }
    }
}
