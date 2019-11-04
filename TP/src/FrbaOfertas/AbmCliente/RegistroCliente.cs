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
        public RegistroCliente()
        {
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

        private void validarDatos()
        {
            if (Validaciones.estaVacio(txtbox_user.Text) || Validaciones.estaVacio(txtbox_password.Text) || Validaciones.estaVacio(txtbox_nombre.Text) || Validaciones.estaVacio(txtbox_apellido.Text) || Validaciones.estaVacio(txtbox_dni.Text) || Validaciones.estaVacio(txtbox_mail.Text) || Validaciones.estaVacio(txtbox_telefono.Text) || Validaciones.estaVacio(txtbox_calle.Text) || Validaciones.estaVacio(txtbox_cp.Text) || Validaciones.estaVacio(txtbox_nropiso.Text) || Validaciones.estaVacio(txtbox_depto.Text) || Validaciones.estaVacio(txtbox_ciudad.Text) || Validaciones.estaVacio(txtbox_cp.Text))
            {

                throw new Exception("Debe completar todos los campos");

            }
            if (!Validaciones.contieneSoloNumeros(txtbox_cp.Text))
            {

                throw new Exception("El código postal debe contener únicamente números");
            }
            if (!Validaciones.contieneSoloNumeros(txtbox_telefono.Text))
            {

                throw new Exception("El telefono debe contener únicamente números");
            }
            if (!Validaciones.contieneSoloNumeros(txtbox_dni.Text))
            {

                throw new Exception("El dni debe contener únicamente números");
            }
            if (!Validaciones.tieneFormatoMail(txtbox_mail.Text))
            {

                throw new Exception("Ingrese el mail correctamente");
            }

        }

        private void registrarCliente()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_cliente", connection);
            query.CommandType = CommandType.StoredProcedure;
            //No se si le tengo que pasar el user y password aca o no !!!!!!!!!!!!!!!!!!!!!
            query.Parameters.Add(new SqlParameter("@nombre", this.txtbox_nombre.Text));
            query.Parameters.Add(new SqlParameter("@apellido", this.txtbox_apellido.Text));
            query.Parameters.Add(new SqlParameter("@dni", Convert.ToInt32(this.txtbox_dni.Text)));
            query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text));
            query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(txtbox_telefono.Text)));
            query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
            query.Parameters.Add(new SqlParameter("@nroPiso", this.txtbox_nropiso.Text));
            query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
            query.Parameters.Add(new SqlParameter("@ciudad", this.txtbox_ciudad.Text));
            query.Parameters.Add(new SqlParameter("@CP", Convert.ToInt32(txtbox_cp.Text)));
            query.Parameters.Add(new SqlParameter("@fechaNacimiento", dtm_fecha.Value));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Boton registrarme
        {
            try
            {
                this.validarDatos();
                this.registrarCliente();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.Login().Show();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
