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
    public partial class ModificacionProveedor : Form
    {
        public ModificacionProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_modificar_proveedor", connection);
            query.CommandType = CommandType.StoredProcedure;
            //Obtener proveedor loggeado (necesito el ID)
            query.Parameters.Add(new SqlParameter("@razonSocial", this.txtbox_rs.Text));
            query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text)); 
            query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(this.txtbox_telefono.Text)));
            query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
            query.Parameters.Add(new SqlParameter("@nroPiso", this.txtbox_nropiso.Text));
            query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
            query.Parameters.Add(new SqlParameter("@CP", this.txtbox_cp.Text));
            query.Parameters.Add(new SqlParameter("@cuit", this.txtbox_cuit.Text));
            query.Parameters.Add(new SqlParameter("@nombreContacto", this.txtbox_contacto.Text));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }
}
