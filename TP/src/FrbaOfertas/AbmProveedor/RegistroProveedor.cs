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

namespace FrbaOfertas.AbmProveedor
{
    public partial class RegistroProveedor : Form
    {
        Form parent;

        public RegistroProveedor(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            Load += new EventHandler(RegistroProveedor_Load);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();

            if (string.IsNullOrWhiteSpace(txtbox_username.Text))
            {
                mensajeError.Add("Debe especificar un nombre de usuario.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_password.Text))
            {
                mensajeError.Add("Debe ingresar una contraseña.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_RS.Text))
            {
                mensajeError.Add("Debe completar la razón social.");
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

            if (string.IsNullOrWhiteSpace(txtbox_cuit.Text))
            {
                mensajeError.Add("Debe completar el CUIT.");
            }
            else
            {
                if (!Validaciones.tieneFormatoDeCuit(txtbox_cuit.Text))
                {

                    mensajeError.Add("El formato del CUIT no es correcto. Ejemplo: 20-30483921-1 ");
                }
            }

            if (combobox_rubro.SelectedIndex == -1)
            {

                mensajeError.Add("Debe seleccionar un rubro.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_contacto.Text))
            {
                mensajeError.Add("Debe completar el nombre de contacto.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_calle.Text))
            {
                mensajeError.Add("Debe completar la calle.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_ciudad.Text))
            {
                mensajeError.Add("Debe completar la ciudad.");
            }

            if (string.IsNullOrWhiteSpace(txtbox_CP.Text))
            {
                mensajeError.Add("Debe completar el código postal.");
            }
           
            if (!Validaciones.contieneSoloNumeros(txtbox_CP.Text))
            {

                mensajeError.Add("El código postal debe contener únicamente números.");
            }

            if (!Validaciones.contieneSoloNumeros(txtbox_telefono.Text))
            {

                mensajeError.Add("El telefono debe contener únicamente números.");
            }

            

            

            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        private bool sePudoCrearUsuario()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_usuario", connection);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add(new SqlParameter("@username", this.txtbox_username.Text));
            query.Parameters.Add(new SqlParameter("@password", this.txtbox_password.Text));

            query.Parameters.Add("@resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

            connection.Open();
            query.ExecuteNonQuery();

            bool resultado = Convert.ToBoolean(query.Parameters["@resultado"].Value);

            connection.Close();

            return resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string error = this.validarDatos();

                if (error == "")
                {
                    bool usuarioCreadoConExito = this.sePudoCrearUsuario();

                    if (usuarioCreadoConExito)
                    {
                        var connection = DB.getInstance().getConnection();
                        SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_proveedor", connection);
                        query.CommandType = CommandType.StoredProcedure;
                        query.Parameters.Add(new SqlParameter("@username", this.txtbox_username.Text));
                        query.Parameters.Add(new SqlParameter("@razonSocial", this.txtbox_RS.Text));
                        query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text));
                        query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(txtbox_telefono.Text)));
                        query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
                        query.Parameters.Add(new SqlParameter("@nroPiso", this.txtbox_nropiso.Text));
                        query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
                        query.Parameters.Add(new SqlParameter("@ciudad", this.txtbox_ciudad.Text));
                        query.Parameters.Add(new SqlParameter("@CP", this.txtbox_CP.Text));
                        query.Parameters.Add(new SqlParameter("@cuit", this.txtbox_cuit.Text));
                        query.Parameters.Add(new SqlParameter("@nombreContacto", this.txtbox_contacto.Text));
                        query.Parameters.Add(new SqlParameter("@rubro", this.combobox_rubro.SelectedItem));


                        connection.Open();
                        query.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("El proveedor se registró con éxito.");

                        this.Hide();

                        this.parent.Show();

                    }
                    else
                    {
                        MessageBox.Show("Ya existe un usuario con ese username, intente con otro.");
                    }


                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show("Ya existe un proveedor con ese cuit o razón social.", "Error", MessageBoxButtons.OK);
            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.Login().Show();
        }

        private void combobox_rubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegistroProveedor_Load(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand sqlCmd = new SqlCommand("SELECT Rubro_Detalle FROM POR_COLECTORA.Rubros", connection);
            connection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {

                combobox_rubro.Items.Add(sqlReader["Rubro_Detalle"].ToString());
            }

            sqlReader.Close();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtbox_username.Text = "";
            txtbox_password.Text = "";
            txtbox_RS.Text= "";
            txtbox_cuit.Text = "";
            txtbox_CP.Text = "";
            txtbox_calle.Text = "";
            txtbox_ciudad.Text = "";
            txtbox_mail.Text = "";
            txtbox_nropiso.Text = "";
            txtbox_telefono.Text = "";
            txtbox_depto.Text = "";
            txtbox_contacto.Text = "";
            combobox_rubro.ResetText();
        }
       
    }
}
