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
        public RegistroProveedor()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_proveedor", connection);
            query.CommandType = CommandType.StoredProcedure;
            //query.Parameters.Add(new SqlParameter("@username", Convert.ToInt32(this.txtbox_username.Text)));
            //query.Parameters.Add(new SqlParameter("@password", this.txtbox_password.Text));
            query.Parameters.Add(new SqlParameter("@razonSocial", this.txtbox_RS.Text));
            query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text));
            query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(this.txtbox_telefono.Text)));
            query.Parameters.Add(new SqlParameter("@cuit", this.txtbox_cuit.Text));
            //query.Parameters.Add(new SqlParameter("@rubro", this.combobox_rubro.Text));
            query.Parameters.Add(new SqlParameter("@nombreContacto", this.txtbox_contacto.Text));
            query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
            query.Parameters.Add(new SqlParameter("@nroPiso", this.txtbox_nropiso.Text));
            query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
            query.Parameters.Add(new SqlParameter("@ciudad", this.txtbox_ciudad.Text));
            query.Parameters.Add(new SqlParameter("@CP", this.txtbox_codigopostal.Text));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }
}
