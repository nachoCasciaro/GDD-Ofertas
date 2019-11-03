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

namespace FrbaOfertas.CrearOferta
{
    public partial class CrearOferta : Form
    {
        public CrearOferta()
        {
            InitializeComponent();
        }

        private void CrearOferta_Load(object sender, EventArgs e)
        {

        }

        private void CREAR_Click(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_ofertas", connection);
            query.CommandType = CommandType.StoredProcedure;
            //Obtener proveedor loggeado (necesito el ID)
            query.Parameters.Add(new SqlParameter("@descripcion", this.txtbox_descripcion.Text));
            query.Parameters.Add(new SqlParameter("@fecha", this.txtbox_fecha.Text)); //No se de que tipo va la fecha jeje
            query.Parameters.Add(new SqlParameter("@fecha_venc", Convert.ToInt32(this.txtbox_fechavencimiento.Text)));
            query.Parameters.Add(new SqlParameter("@precio_oferta", this.txtbox_preciooferta.Text));
            query.Parameters.Add(new SqlParameter("@precio_original", this.txtbox_preciooriginal.Text));
            query.Parameters.Add(new SqlParameter("@stock", this.txtbox_stock.Text));
            query.Parameters.Add(new SqlParameter("@max_compra", this.txtbox_maxunidades.Text));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }
}
