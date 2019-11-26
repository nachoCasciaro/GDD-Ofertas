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

namespace FrbaOfertas.RegistroClientesYProveedoresConUsuario
{
    public partial class NuevoCliente : Form
    {
        Form parent;
        string username;

        public NuevoCliente(Form parent, string username)
        {
            this.parent = parent;
            this.username = username;
            InitializeComponent();
        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();

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

            if (string.IsNullOrWhiteSpace(txtbox_ciudad.Text))
            {
                mensajeError.Add("Debe completar la ciudad.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_cp.Text))
            {
                mensajeError.Add("Debe completar el código postal.");
            }


            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string error = this.validarDatos();

                if (error == "")
                {
                    var connection = DB.getInstance().getConnection();
                    SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_cliente", connection);
                    query.CommandType = CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@username", username));
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

                    MessageBox.Show("El cliente se registró con éxito, inicie sesión para empezar a disfrutar las ofertas!");

                    this.Hide();

                    this.parent.Show();

                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show("Ya existe un cliente con ese dni.", "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtbox_nombre.Text = "";
            txtbox_dni.Text = "";
            txtbox_cp.Text = "";
            txtbox_calle.Text = "";
            txtbox_apellido.Text = "";
            txtbox_ciudad.Text = "";
            txtbox_mail.Text = "";
            txtbox_nropiso.Text = "";
            txtbox_telefono.Text = "";
            txtbox_depto.Text = "";
            dtm_fecha.ResetText();
        }
    }
}
