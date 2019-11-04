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
    public partial class ModificacionCliente : Form
    {
        public ModificacionCliente()
        {
            InitializeComponent();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_ofertas", connection);
            query.CommandType = CommandType.StoredProcedure;
            //Obtener cliente loggeado (necesito el ID)
            query.Parameters.Add(new SqlParameter("@nombre", this.txtbox_nombre.Text));
            query.Parameters.Add(new SqlParameter("@apellido", this.txtbox_apellido.Text));
            query.Parameters.Add(new SqlParameter("@dni", Convert.ToInt32(this.txtbox_dni.Text)));
            query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text));
            query.Parameters.Add(new SqlParameter("@telefono", this.txtbox_telefono.Text));
            query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
            query.Parameters.Add(new SqlParameter("@nroPiso", this.txtbox_nropiso.Text));
            query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
            query.Parameters.Add(new SqlParameter("@ciudad", this.txtbox_ciudad.Text));
            query.Parameters.Add(new SqlParameter("@CP", this.txtbox_cp.Text));
            query.Parameters.Add(new SqlParameter("@fechaNacimiento", this.txtbox_fechanac.Text));//No se de que tipo va la fecha jeje

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }
}
