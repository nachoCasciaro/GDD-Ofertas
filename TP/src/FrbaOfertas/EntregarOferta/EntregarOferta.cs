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
        public EntregarOferta()
        {
            InitializeComponent();
        }

        private void validarDatos()
        {
            if (Validaciones.estaVacio(txtbox_cupon.Text) || Validaciones.estaVacio(txtbox_cliente.Text))
            {

                throw new Exception("Debe completar todos los campos");

            }
            
            //Validacion codigo cupon? (Que exista alguno con ese codigo o algo asi?)

        }

        private void entregarOferta()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_consumir_oferta", connection);
            query.CommandType = CommandType.StoredProcedure;
            //Obtener proveedor loggeado (necesito el ID)
            query.Parameters.Add(new SqlParameter("@id_cupon", this.txtbox_cupon.Text));
            query.Parameters.Add(new SqlParameter("@fecha_actual", dtm_fechaconsumo.Value)); 
            
            //No se le manda el cliente ??? Es requisito en la interfaz, pero no esta en el stored
            //query.Parameters.Add(new SqlParameter("@", Convert.ToInt32(this.txtbox_fechavencimiento.Text)));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarDatos();
                this.entregarOferta();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
