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
    public partial class BajaProveedor : Form
    {
        public BajaProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_baja_proveedor", connection);
            query.CommandType = CommandType.StoredProcedure;
            //Obtener proveedor loggeado (necesito el ID)

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }
}
