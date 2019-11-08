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
        int esAdminOProvee;

        public RegistroProveedor(int esAdminOProvee)
        {
            this.esAdminOProvee = esAdminOProvee;
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

        private void validarDatos()
        {
            if (Validaciones.estaVacio(txtbox_RS.Text) || Validaciones.estaVacio(txtbox_CP.Text) || Validaciones.estaVacio(txtbox_contacto.Text) || Validaciones.estaVacio(txtbox_mail.Text) || Validaciones.estaVacio(txtbox_telefono.Text) || Validaciones.estaVacio(txtbox_cuit.Text) || Validaciones.estaVacio(txtbox_calle.Text) || Validaciones.estaVacio(txtbox_nropiso.Text) || Validaciones.estaVacio(txtbox_depto.Text) || Validaciones.estaVacio(txtbox_ciudad.Text))
            {

                throw new Exception("Debe completar todos los campos");

            }
            if (!Validaciones.contieneSoloNumeros(txtbox_CP.Text))
            {

                throw new Exception("El código postal debe contener únicamente números");
            }
            if (!Validaciones.contieneSoloNumeros(txtbox_telefono.Text))
            {

                throw new Exception("El telefono debe contener únicamente números");
            }
            if (!Validaciones.tieneFormatoMail(txtbox_mail.Text))
            {

                throw new Exception("Ingrese el mail correctamente");
            }

        }

        private void registrarProveedor()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_proveedor", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@username", this.txtbox_username.Text));
            query.Parameters.Add(new SqlParameter("@password", this.txtbox_password.Text));
            query.Parameters.Add(new SqlParameter("@razonSocial", this.txtbox_RS.Text));
            query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text));
            query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(txtbox_telefono.Text)));
            query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
            query.Parameters.Add(new SqlParameter("@nroPiso", Convert.ToInt32(this.txtbox_nropiso.Text)));
            query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
            query.Parameters.Add(new SqlParameter("@ciudad", this.txtbox_ciudad.Text));
            query.Parameters.Add(new SqlParameter("@CP", Convert.ToInt32(this.txtbox_CP.Text)));
            query.Parameters.Add(new SqlParameter("@cuit", this.txtbox_cuit.Text));
            query.Parameters.Add(new SqlParameter("@nombreContacto", this.txtbox_contacto.Text));
            query.Parameters.Add(new SqlParameter("@rubro", this.combobox_rubro.SelectedItem));


            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Boton registrarme
        {
            try
            {
                this.validarDatos();
                this.registrarProveedor();
                this.Close();
                if (esAdminOProvee == 1)
                {
                    new Menu_Principal.MenuAdmin().Show();
                }
                else
                {
                    new Login.LoginProveedor().Show();
                }
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
       
    }
}
