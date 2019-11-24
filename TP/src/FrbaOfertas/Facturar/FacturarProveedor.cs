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

namespace FrbaOfertas.Facturar
{
    public partial class FacturarProveedor : Form
    {
        Form parent;

        public FacturarProveedor(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            Load += new EventHandler(FacturarProveedor_Load);
        }

        private void FacturarProveedor_Load(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand sqlCmd = new SqlCommand("SELECT Provee_RS FROM POR_COLECTORA.Proveedores", connection);
            connection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                combobox_prov.Items.Add(sqlReader["Provee_RS"].ToString());
            }

            sqlReader.Close();

        }


        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();


            if (this.dtm_fin.Value < this.dtm_inicio.Value)
            {

                mensajeError.Add("La fecha de inicio de facturación debe ser anterior a la de fin.");
            }

            if (combobox_prov.SelectedIndex <= -1)
            {
                mensajeError.Add("Debe seleccionar un proveedor al que desee facturar.");

            }

            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        private void combobox_prov_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string error = this.validarDatos();

                if (error == "")
                {

                    ConfiguradorDataGrid.llenarDataGridConConsulta(this.listadoOfertas(), dataGridView1);
                    this.importeFactura();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show("No existen facturas dentro del período seleccionado para ese proveedor.", "Error", MessageBoxButtons.OK);
            }
        }

        private SqlDataReader listadoOfertas()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_facturar_a_proveedor_listado", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@fecha_inicio", this.dtm_inicio.Value));
            query.Parameters.Add(new SqlParameter("@fecha_fin", this.dtm_fin.Value));
            query.Parameters.Add(new SqlParameter("@proveedor", this.combobox_prov.SelectedItem.ToString()));

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            return reader;
        }
        
        private void importeFactura()
        {
            
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_facturar_a_proveedor", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@fecha_inicio", this.dtm_inicio.Value));
            query.Parameters.Add(new SqlParameter("@fecha_fin", this.dtm_fin.Value));
            query.Parameters.Add(new SqlParameter("@proveedor", this.combobox_prov.SelectedItem.ToString()));

            query.Parameters.Add("@resultado", SqlDbType.VarChar,250).Direction = ParameterDirection.Output;

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            string resultado = query.Parameters["@resultado"].Value.ToString();

            string[] resultadoDividido = resultado.Split(' ');

            this.textBox1.Text = "$ " + resultadoDividido[0];
            this.textBox2.Text = resultadoDividido[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    
    }
}
