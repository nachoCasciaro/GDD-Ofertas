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
using System.Configuration;

namespace FrbaOfertas.CargaCredito
{
    public partial class CargaCredito : Form
    {
        int idCliente;

        public CargaCredito(int idCliente)
        {
            this.idCliente = idCliente;
            InitializeComponent();
        }

        private void combobox_pago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_carga_credito", connection);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add(new SqlParameter("@id_cliente", Convert.ToInt32(this.idCliente)));
            
             DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["current_date"]);
            query.Parameters.Add(new SqlParameter("@fecha_carga",fechaActual));

            query.Parameters.Add(new SqlParameter("@monto", this.txtbox_monto.Text));
            query.Parameters.Add(new SqlParameter("@tipo_tarjeta", this.combobox_tipotarjeta.Text));
            query.Parameters.Add(new SqlParameter("@numero_tarjeta", this.txtbox_numerotarjeta.Text));
            query.Parameters.Add(new SqlParameter("@fecha_venc", this.date_fechaVencimiento.Value));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void Carga_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu_Principal.MenuCliente(idCliente).Show();
        }
    }
}
