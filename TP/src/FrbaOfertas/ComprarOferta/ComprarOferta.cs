using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace FrbaOfertas.ComprarOferta
{
    public partial class ComprarOferta : Form
    {
        public ComprarOferta()
        {
            InitializeComponent();

            Load += new EventHandler(ComprarOferta_Load);
        }

        private void ComprarOferta_Load(object sender, System.EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.ofertasVigentes(), dataGridView1);
        }

        private SqlDataReader ofertasVigentes()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POR_COLECTORA.sp_ofertas_vigentes", connection);
            command.CommandType = CommandType.StoredProcedure;

            string setting = ConfigurationManager.AppSettings["current_date"];

            command.Parameters.Add(new SqlParameter("@fecha", Convert.ToDateTime(setting)));

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
