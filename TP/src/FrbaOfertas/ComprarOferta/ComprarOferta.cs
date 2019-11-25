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
        Form parent;

        public ComprarOferta(int idCliente, Form parent)
        {
            this.idCliente = idCliente;
            this.parent = parent;
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

        private string comprarOferta()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return "-1";
                
            } else
            {
                String descripcion = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                Int32 id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                Double precioOriginal = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
                Double precioOferta = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value);

                var connection = DB.getInstance().getConnection();
                SqlCommand query = new SqlCommand("POR_COLECTORA.sp_comprar_oferta", connection);
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add(new SqlParameter("@id_oferta", id));
                query.Parameters.Add(new SqlParameter("@id_cliente", idCliente));

                string setting = ConfigurationManager.AppSettings["current_date"];
                query.Parameters.Add(new SqlParameter("@fecha_compra", Convert.ToDateTime(setting) ));

                query.Parameters.Add(new SqlParameter("@cantidad_compra", numericCantidad.Value));
                query.Parameters.Add("@resultado_compra", SqlDbType.VarChar,250).Direction = ParameterDirection.Output;

                connection.Open();
                query.ExecuteNonQuery();

                string resultado = query.Parameters["@resultado_compra"].Value.ToString();


                connection.Close();

                return resultado;
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string resultado = this.comprarOferta();

                string[] resultadoDividido = resultado.Split(' ');

                string resultadoCompra = resultadoDividido[0];
                string nroCompra = resultadoDividido[1];

                if (resultadoCompra == "1")
                {
                    MessageBox.Show("El saldo es insuficiente para realizar la compra.");
                    this.Hide();
                    this.parent.Show();
                }

                else if (resultadoCompra == "2")
                {
                    MessageBox.Show("Ya compró el máximo permitido de esta oferta.");
                    this.Hide();
                    this.parent.Show();
                }

                else if (resultadoCompra == "3")
                {
                    MessageBox.Show("No hay stock suficiente para realizar la compra.");
                    this.Hide();
                    this.parent.Show();
                }

                else if (resultadoCompra == "0")
                {
                    MessageBox.Show("Oferta comprada con éxito, su número de compra es: " + nroCompra);
                    this.Hide();
                    this.parent.Show();
                }

            }
            catch (Exception excepcion)
            {
                MessageBox.Show("Debe seleccionar la fila completa utilizando la flecha de la izquierda", "Error", MessageBoxButtons.OK);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }
    }
}
