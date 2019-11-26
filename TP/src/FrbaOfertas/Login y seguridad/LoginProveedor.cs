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

        private bool chequearRolProveedorEstaHabilitado()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand sqlCmd = new SqlCommand("select Rol_Habilitado from POR_COLECTORA.Roles where Rol_Id = 3", connection);
            connection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            bool estaHabilitado = true;

            while (sqlReader.Read())
            {
                estaHabilitado = Convert.ToBoolean(sqlReader["Rol_Habilitado"].ToString());
            }

            sqlReader.Close();

            return estaHabilitado;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            bool estaHabilitado = this.chequearRolProveedorEstaHabilitado();

            if (estaHabilitado)
            {
                this.Hide();
                new AbmProveedor.RegistroProveedor(this).Show();
            }
            else
            {
                MessageBox.Show("El rol se encuentra inhabilitado por lo que no se te puede asignar a tu usuario.");
                this.Close();
                new Login().Show();
            }
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

            var resultado = (query.Parameters["@resultado"].Value);

            connection.Close();

            if (resultado != DBNull.Value)
            {
                return Convert.ToInt32(resultado);
            }
            else
            {
                return -1;
            }
        }

        private int idUserIngresado(string username)
        {
            var connection2 = DB.getInstance().getConnection();
            SqlCommand query2 = new SqlCommand("POR_COLECTORA.sp_obtener_id_user", connection2);
            query2.CommandType = CommandType.StoredProcedure;

            query2.Parameters.Add(new SqlParameter("@user", username));
            query2.Parameters.Add("@idUser", SqlDbType.Int).Direction = ParameterDirection.Output;

            connection2.Open();
            query2.ExecuteNonQuery();

            int id = Convert.ToInt32(query2.Parameters["@idUser"].Value);

            connection2.Close();

            return Convert.ToInt32(id);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = this.validarDatos();


            if (error == "")
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

                    int idUser = this.idUserIngresado(this.textBox1.Text);

                    if (idProveedor != -1)
                    {
                        new Menu_Principal.MenuProveedor(idProveedor,idUser).Show();
                    }
                    else
                    {
                        if (MessageBox.Show("El usuario ingresado no es un proveedor, desea registrarse y poder serlo?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.Hide();
                            new RegistroClientesYProveedoresConUsuario.NuevoProveedor(this, this.textBox1.Text).Show(); ;
                        }
                        else
                        {
                            new LoginProveedor().Show();
                        }
                    }
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
            else
            {
                MessageBox.Show(error);
            }


        }


        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();


            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {

                mensajeError.Add("Debe completar el username.");
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {

                mensajeError.Add("Debe completar la password.");
            }


            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }
    }
}
