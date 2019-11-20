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
        int idProveedor;

        public EntregarOferta(int idProveedor)
        {
            this.idProveedor = idProveedor;
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

            query.Parameters.Add(new SqlParameter("@id_proveedor", Convert.ToInt32(this.idProveedor)));
            query.Parameters.Add(new SqlParameter("@codigo_cupon", this.txtbox_cupon.Text));
            query.Parameters.Add(new SqlParameter("@fecha_consumo", dtm_fechaconsumo.Value)); 
            query.Parameters.Add(new SqlParameter("@id_cliente", Convert.ToInt32(this.txtbox_cliente.Text)));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();

            this.Hide();
            new Menu_Principal.MenuProveedor(idProveedor).Show();
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
