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


namespace FrbaOfertas.EntregarOferta
{
    public partial class EntregarOferta : Form
    {
        Form parent;
        int idProveedor;

        public EntregarOferta(int idProveedor, Form parent)
        {
            this.idProveedor = idProveedor;
            this.parent = parent;
            InitializeComponent();
        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();

            if (Validaciones.estaVacio(txtbox_cupon.Text))
            {
                mensajeError.Add("Debe completar el código del cupón.");
            }

            if (Validaciones.estaVacio(txtbox_cliente.Text))
            {
                mensajeError.Add("Debe completar el código del cliente.");
            }

            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        private int entregarOferta()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_consumir_oferta", connection);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add(new SqlParameter("@id_proveedor", Convert.ToInt32(this.idProveedor)));
            query.Parameters.Add(new SqlParameter("@codigo_cupon", this.txtbox_cupon.Text));
            query.Parameters.Add(new SqlParameter("@fecha_consumo", dtm_fechaconsumo.Value)); 
            query.Parameters.Add(new SqlParameter("@id_cliente", Convert.ToInt32(this.txtbox_cliente.Text)));

            query.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

            connection.Open();
            query.ExecuteNonQuery();

            Int32 resultado = Convert.ToInt32(query.Parameters["@resultado"].Value);


            connection.Close();

            return resultado;

            this.Hide();
            this.parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            try
            {
                string error = this.validarDatos();
                if (error == "")
                {
                    int resultado = this.entregarOferta();

                    if (resultado == -1)
                    {
                        MessageBox.Show("El cupon que desea dar de baja se encuentra vencido.");
                        this.Hide();
                        this.parent.Show();

                    }

                    if (resultado == -2)
                    {
                        MessageBox.Show("El cupon ya fue dado de baja anteriormente.");
                        this.Hide();
                        this.parent.Show();

                    }

                    if (resultado == -3)
                    {
                        MessageBox.Show("No podes dar de baja un cupon que corresponde a una oferta de otro proveedor.");
                        this.Hide();
                        this.parent.Show();

                    }

                    if (resultado == 0)
                    {
                        MessageBox.Show("El cupón fué dado de baja con éxito.");
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
                MessageBox.Show("El código de cupón ingresado no existe", "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }
    }
}
