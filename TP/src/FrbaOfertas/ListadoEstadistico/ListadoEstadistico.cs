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


namespace FrbaOfertas.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        Form parent;

        public ListadoEstadistico(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            dtm_año.Format = DateTimePickerFormat.Custom;
            dtm_año.CustomFormat = "yyyy";
            dtm_año.ShowUpDown = true; 
        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();

            if (combobox_tipolistado.SelectedIndex == -1)
            {
                mensajeError.Add("Debe seleccionar un tipo de listado");
            }

            if (combobox_semestre.SelectedIndex == -1)
            {
                mensajeError.Add("Debe seleccionar un semestre");
            }

            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }


        private void button1_Click(object sender, EventArgs e)
        {

            string error = this.validarDatos();

            if (error == "") 
            {
                if (combobox_tipolistado.SelectedIndex == 0) //Mayor porcentaje desc
                {
                    ConfiguradorDataGrid.llenarDataGridConConsulta(this.obtenerProveedoresMayorDescuento(), dataGridView1);
                    string fi = dataGridView1.RowCount.ToString();
                    if (dataGridView1.RowCount <= 1)
                    {
                        MessageBox.Show("En el año y semestre seleccionados ningún proveedor realizó ofertas.");
                    }
                }
                else if (combobox_tipolistado.SelectedIndex == 1) //Mayor facturacion
                {
                    ConfiguradorDataGrid.llenarDataGridConConsulta(this.obtenerProveedoresMayorFacturacion(), dataGridView1);
                    if (dataGridView1.RowCount <= 1)
                    {
                        MessageBox.Show("En el año y semestre seleccionados ningún proveedor facturó.");
                    }
                }
            }
            else
            {
                MessageBox.Show(error);
            }
         
        }

        private SqlDataReader obtenerProveedoresMayorDescuento()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_prov_mas_descuento", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@semestre", Convert.ToInt16(this.combobox_semestre.SelectedItem)));
            query.Parameters.Add(new SqlParameter("@anio", this.dtm_año.Value.Year));

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            return reader;
        }

        private SqlDataReader obtenerProveedoresMayorFacturacion()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_prov_mayor_facturacion", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@semestre", Convert.ToInt16(this.combobox_semestre.SelectedItem)));
            query.Parameters.Add(new SqlParameter("@anio", this.dtm_año.Value.Year));

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            return reader;
        }

        private void Año_Click(object sender, EventArgs e)
        {

        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {

        }

        private void combobox_tipolistado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();

        }
    }
}
