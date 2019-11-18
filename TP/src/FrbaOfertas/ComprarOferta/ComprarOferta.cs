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

        private Int32 comprarOferta()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la fila completa utilizando la flecha de la izquierda");
                return -1;
            } else
            {
                String descripcion = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                Int32 id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                Double precioOriginal = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
                Double precioOferta = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value);
                Int32 resultado = 8; //lo inicializo en cualquier valor distinto de los que debe devolver el stored

                var connection = DB.getInstance().getConnection();
                SqlCommand query = new SqlCommand("POR_COLECTORA.sp_comprar_oferta", connection);
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add(new SqlParameter("@id_oferta", id));
                query.Parameters.Add(new SqlParameter("@id_cliente", idCliente));
                query.Parameters.Add(new SqlParameter("@fecha_compra", DateTime.Now));
                query.Parameters.Add(new SqlParameter("@cantidad_compra", 1));
                query.Parameters.Add(new SqlParameter("@resultado_compra", resultado));

                connection.Open();
                query.ExecuteNonQuery();

                resultado = Convert.ToInt32(query.Parameters["@resultado_compra"].Value);

                connection.Close();

                return resultado;
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 resultado = this.comprarOferta();

                if (resultado == 1)
                {
                    MessageBox.Show("El saldo es insuficiente para comprar esta oferta.");
                    this.Hide();
                    new Menu_Principal.MenuCliente(idCliente).Show();
                }

                else if (resultado == 2)
                {
                    MessageBox.Show("Ya compró el máximo permitido de esta oferta");
                    this.Hide();
                    new Menu_Principal.MenuCliente(idCliente).Show();
                }

                else if (resultado == 0)
                {
                    MessageBox.Show("Oferta comprada con éxito");
                    this.Hide();
                    new Menu_Principal.MenuCliente(idCliente).Show();
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu_Principal.MenuCliente(idCliente).Show();
        }
    }
}
