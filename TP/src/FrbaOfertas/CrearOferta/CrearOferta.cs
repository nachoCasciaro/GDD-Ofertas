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
        int idProveedor;

        public CrearOferta(int idProveedor)
        {
            this.idProveedor = idProveedor;
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

            query.Parameters.Add(new SqlParameter("@id_prove", Convert.ToInt32(this.idProveedor)));
            query.Parameters.Add(new SqlParameter("@descripcion", this.txtbox_descripcion.Text));
            query.Parameters.Add(new SqlParameter("@fecha", this.date_publicacion.Value));
            query.Parameters.Add(new SqlParameter("@fecha_venc", this.date_vencimiento.Value));
            query.Parameters.Add(new SqlParameter("@precio_oferta", this.txtbox_preciooferta.Text));
            query.Parameters.Add(new SqlParameter("@precio_original", this.txtbox_preciooriginal.Text));
            query.Parameters.Add(new SqlParameter("@stock", this.txtbox_stock.Text));
            query.Parameters.Add(new SqlParameter("@max_compra", this.txtbox_maxunidades.Text));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Se creó la oferta con éxito");
            this.Close();
            new Menu_Principal.MenuProveedor(idProveedor).Show();
        }
    }
}
