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
        int idCliente; 

        public ComprarOferta(int idCliente)
        {
            this.idCliente = idCliente;
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

        private void seleccionarOferta()
        {
            String descripcion = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
            Int32 id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            Double precioOriginal = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
            Double precioOferta = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value);

            //sp comprar oferta? 

            new Menu_Principal.MenuCliente(idCliente).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.seleccionarOferta();
                MessageBox.Show("Oferta comprada con éxito");
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
