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
        Form parent;

        public CargaCredito(int idCliente, Form parent)
        {
            this.idCliente = idCliente;
            this.parent = parent;
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
            try
            {
                string error = this.validarDatos();

                if (error == "")
                {
                    if (combobox_pago.SelectedItem.ToString() != "Efectivo")
                    {
                        var connection = DB.getInstance().getConnection();
                        SqlCommand query = new SqlCommand("POR_COLECTORA.sp_carga_credito", connection);
                        query.CommandType = CommandType.StoredProcedure;

                        query.Parameters.Add(new SqlParameter("@id_cliente", Convert.ToInt32(this.idCliente)));

                        DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["current_date"]);
                        query.Parameters.Add(new SqlParameter("@fecha_carga", fechaActual));

                        query.Parameters.Add(new SqlParameter("@monto", this.txtbox_monto.Text));
                        query.Parameters.Add(new SqlParameter("@tipo_tarjeta", this.combobox_tipotarjeta.Text));
                        query.Parameters.Add(new SqlParameter("@numero_tarjeta", this.txtbox_numerotarjeta.Text));
                        query.Parameters.Add(new SqlParameter("@fecha_venc", this.date_fechaVencimiento.Value));

                        connection.Open();
                        query.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("La carga se realizó con éxito.");
                        this.Hide();

                        this.parent.Show();

                    }
                    else
                    {
                        var connection = DB.getInstance().getConnection();
                        SqlCommand query = new SqlCommand("POR_COLECTORA.sp_carga_credito_efectivo", connection);
                        query.CommandType = CommandType.StoredProcedure;

                        query.Parameters.Add(new SqlParameter("@id_cliente", Convert.ToInt32(this.idCliente)));

                        DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["current_date"]);
                        query.Parameters.Add(new SqlParameter("@fecha_carga", fechaActual));

                        query.Parameters.Add(new SqlParameter("@monto", this.txtbox_monto.Text));

                        connection.Open();
                        query.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("La carga se realizó con éxito.");
                        this.Hide();
                        this.parent.Show();

                    }
                }
                else
                {
                    MessageBox.Show(error);
                }

            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }

            
            
        }

        private void Carga_Load(object sender, EventArgs e)
        {

        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();
            
            if(string.IsNullOrWhiteSpace(txtbox_monto.Text)){
                mensajeError.Add("Debe completar el monto de la carga.");
            }
            if (combobox_pago.SelectedIndex == -1)
            {

                mensajeError.Add("Debe seleccionar una forma de pago.");
            }
            else 
            {
                if (combobox_pago.SelectedItem.ToString() == "Tarjeta")
                {
                    if (combobox_tipotarjeta.SelectedIndex == -1)
                    {
                        mensajeError.Add("Debe seleccionar un tipo de tarjeta.");
                    }
                    if (string.IsNullOrWhiteSpace(txtbox_numerotarjeta.Text))
                    {
                        mensajeError.Add("Debe completar el numero de la tarjeta.");
                    }

                    if (!Validaciones.contieneSoloNumeros(txtbox_numerotarjeta.Text))
                    {
                        mensajeError.Add("El numero de la tarjeta deben ser solo numeros");
                    }

                    string setting = ConfigurationManager.AppSettings["current_date"];
                    DateTime fechaSistema = Convert.ToDateTime(setting);
                    int value = DateTime.Compare(date_fechaVencimiento.Value, fechaSistema);
                    if (value < 0)
                    {
                        mensajeError.Add("La fecha de vencimiento de la tarjeta tiene que ser mayor o igual a la actual");
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtbox_numerotarjeta.Text))
                    {
                        mensajeError.Add("Debe dejar vacío el numero de tarjeta si desea realizar una carga en efectivo.");
                    }

                    if (combobox_tipotarjeta.SelectedIndex == -1)
                    {
                        mensajeError.Add("Debe seleccionar No aplica en el tipo de tarjeta.");
                    }

                }

            }
           

            if (!Validaciones.contieneSoloNumeros(txtbox_monto.Text))
            {

                mensajeError.Add("El monto de carga debe contener solo numeros.");
            }
            
           

            string mensajeConcat;
             mensajeConcat = string.Join("\n", mensajeError);

             return mensajeConcat;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }

        private void txtbox_monto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
