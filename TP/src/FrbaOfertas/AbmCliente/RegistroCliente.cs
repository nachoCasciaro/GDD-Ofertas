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

namespace FrbaOfertas.AbmCliente
{
    public partial class RegistroCliente : Form
    {
        int esAdminOCliente;

        public RegistroCliente(int esAdminOCliente)
        {
            this.esAdminOCliente = esAdminOCliente;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void RegistroCliente_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();

            if (string.IsNullOrWhiteSpace(txtbox_user.Text))
            {
                mensajeError.Add("Debe especificar un nombre de usuario.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_password.Text))
            {
                mensajeError.Add("Debe ingresar una contraseña.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_nombre.Text)) 
            {
                mensajeError.Add("Debe completar el nombre.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_apellido.Text))
            {
                mensajeError.Add("Debe completar el apellido.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_dni.Text))
            {
                mensajeError.Add("Debe completar el dni.");
            }
            else
            {
                if (!Validaciones.contieneSoloNumeros(txtbox_dni.Text))
                {

                    mensajeError.Add("El dni debe contener únicamente números.");
                }
            }

            if (string.IsNullOrWhiteSpace(txtbox_mail.Text))
            {
                mensajeError.Add("Debe completar el mail.");
            }
            else
            {
                if (!Validaciones.tieneFormatoMail(txtbox_mail.Text))
                {

                    mensajeError.Add("El formato del mail no es correcto.");
                }
            }

            if (string.IsNullOrWhiteSpace(txtbox_telefono.Text))
            {
                mensajeError.Add("Debe completar el teléfono.");
            }
            else
            {
                if (!Validaciones.contieneSoloNumeros(txtbox_telefono.Text))
                {

                    mensajeError.Add("El telefono debe contener únicamente números.");
                }
            }

            if (string.IsNullOrWhiteSpace(txtbox_calle.Text))
            {
                mensajeError.Add("Debe completar la calle.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_cp.Text))
            {
                mensajeError.Add("Debe completar el código postal.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_ciudad.Text))
            {
                mensajeError.Add("Debe completar la ciudad.");
            }

            
            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        void button1_Click(object sender, EventArgs e)
        {

            string error = this.validarDatos();

            if (error == "")
            {
                var connection = DB.getInstance().getConnection();
                SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_cliente", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@username", this.txtbox_user.Text));
                query.Parameters.Add(new SqlParameter("@password", this.txtbox_password.Text));
                query.Parameters.Add(new SqlParameter("@nombre", this.txtbox_nombre.Text));
                query.Parameters.Add(new SqlParameter("@apellido", this.txtbox_apellido.Text));
                query.Parameters.Add(new SqlParameter("@dni", Convert.ToInt32(this.txtbox_dni.Text)));
                query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text));
                query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(this.txtbox_telefono.Text)));
                query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
                query.Parameters.Add(new SqlParameter("@nroPiso", this.txtbox_nropiso.Text));
                query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
                query.Parameters.Add(new SqlParameter("@ciudad", this.txtbox_ciudad.Text));
                query.Parameters.Add(new SqlParameter("@CP", this.txtbox_cp.Text));
                query.Parameters.Add(new SqlParameter("@fechaNacimiento", this.dtm_fecha.Value));

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("El cliente se registró con éxito.");

                this.Close();

                if (esAdminOCliente == 1)
                {
                    new Menu_Principal.MenuAdmin().Show();
                }
                else
                {
                    new Login.LoginCliente().Show();
                }

            }
            else
            {
                MessageBox.Show(error);
            }


        }

      
        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
