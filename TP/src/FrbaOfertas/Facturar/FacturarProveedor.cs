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
        public FacturarProveedor()
        {
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

        private void validarDatos()
        {
            if (this.dtm_fin.Value < this.dtm_inicio.Value)
            {

                throw new Exception("La fecha de inicio de facturación debe ser anterior a la de fin");

            }

        }

        private void combobox_prov_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarDatos();
                ConfiguradorDataGrid.llenarDataGridConConsulta(this.listadoOfertas(), dataGridView1);
                //ConfiguradorDataGrid.llenarDataGridConConsulta(this.importeFactura(), dataGridView2);
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private SqlDataReader listadoOfertas()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_facturar_a_proveedor_listado", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@fecha_inicio", this.dtm_inicio.Value));
            query.Parameters.Add(new SqlParameter("@fecha_fin", this.dtm_fin.Value));
            query.Parameters.Add(new SqlParameter("@proveedor", this.combobox_prov));

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            return reader;
        }
        /*
        private SqlDataReader importeFactura()
        {
            //este sp esta mal, es el de facturar
            
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_prov_mayor_facturacion", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@semestre", Convert.ToInt16(this.co)));
            query.Parameters.Add(new SqlParameter("@anio", this.dtm_año.Value));

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            return reader;
              
        }
    */
    }
}
