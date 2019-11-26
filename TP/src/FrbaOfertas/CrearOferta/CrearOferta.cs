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

namespace FrbaOfertas.CrearOferta
{
    public partial class CrearOferta : Form
    {
        Form parent;
        int idProveedor;

        public CrearOferta(int idProveedor, Form parent)
        {
            this.idProveedor = idProveedor;
            this.parent = parent;
            InitializeComponent();
        }

        private void CrearOferta_Load(object sender, EventArgs e)
        {

        }

        private void CREAR_Click(object sender, EventArgs e)
        {
            try
            {
                string error = this.validarDatos();

                if (error == "")
                {
                    var connection = DB.getInstance().getConnection();
                    SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_ofertas", connection);
                    query.CommandType = CommandType.StoredProcedure;

                    query.Parameters.Add(new SqlParameter("@id_prove", Convert.ToInt32(this.idProveedor)));
                    query.Parameters.Add(new SqlParameter("@descripcion", this.txtbox_descripcion.Text));
                    query.Parameters.Add(new SqlParameter("@fecha", this.date_publicacion.Value));
                    query.Parameters.Add(new SqlParameter("@fecha_venc", this.date_vencimiento.Value));
                    query.Parameters.Add(new SqlParameter("@precio_oferta", Convert.ToDecimal(this.txtbox_preciooferta.Text)));
                    query.Parameters.Add(new SqlParameter("@precio_original", Convert.ToDecimal(this.txtbox_preciooriginal.Text)));
                    query.Parameters.Add(new SqlParameter("@stock", Convert.ToInt32(this.txtbox_stock.Text)));
                    query.Parameters.Add(new SqlParameter("@max_compra", Convert.ToInt32(this.txtbox_maxunidades.Text)));

                    connection.Open();
                    query.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Se creó la oferta con éxito");
                    this.Close();
                    this.parent.Show();
                }
                else
                {
                    MessageBox.Show(error);
                }

            }
            catch (Exception excepcion)
            {
                MessageBox.Show("Debe seleccionar la fila completa utilizando la flecha de la izquierda", "Error", MessageBoxButtons.OK);
            }

          
        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();

            if (string.IsNullOrWhiteSpace(txtbox_descripcion.Text))
            {
                mensajeError.Add("Debe completar la descripción.");
            }

            if (date_vencimiento.Value < date_publicacion.Value)
            {
                mensajeError.Add("La fecha de vencimiento tiene que ser mayor o igual a la de publicación.");
            }


            DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["current_date"]);


            if (date_publicacion.Value < fechaActual )
            {
                mensajeError.Add("La fecha de publicación tiene que ser mayor o igual a la fecha de hoy."); //fecha de hoy se refiere a la fecha del archivo de configuracion
            }

            if (string.IsNullOrWhiteSpace(txtbox_preciooriginal.Text))
            {
                mensajeError.Add("Debe completar el precio original.");
            }
            else
            {
                if (!Validaciones.contieneSoloNumeros(txtbox_preciooriginal.Text))
                {

                    mensajeError.Add("El precio original debe contener únicamente números.");
                }
            }

            if (string.IsNullOrWhiteSpace(txtbox_preciooferta.Text))
            {
                mensajeError.Add("Debe completar el precio oferta.");
            }
            else
            {
                if (!Validaciones.contieneSoloNumeros(txtbox_preciooferta.Text))
                {

                    mensajeError.Add("El precio oferta debe contener únicamente números.");
                }
            }


            if (string.IsNullOrWhiteSpace(txtbox_stock.Text))
            {
                mensajeError.Add("Debe completar el stock disponible.");
            }
            else
            {
                if (!Validaciones.contieneSoloNumeros(txtbox_stock.Text))
                {

                    mensajeError.Add("El stock disponible debe contener únicamente números.");
                }
            }


            if (string.IsNullOrWhiteSpace(txtbox_maxunidades.Text))
            {
                mensajeError.Add("Debe completar el máximo unidades por compra por cliente.");
            }
            else
            {
                if (!Validaciones.contieneSoloNumeros(txtbox_maxunidades.Text))
                {

                    mensajeError.Add("El máximo unidades por compra por cliente debe contener únicamente números.");
                }
            }

            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }
    }
}
