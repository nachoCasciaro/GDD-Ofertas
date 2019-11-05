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

namespace FrbaOfertas.AbmRol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {

        }

        private void validarDatos()
        {
            if (Validaciones.estaVacio(txtbox_nombrerol.Text))
            {

                throw new Exception("Debe completar todos los campos");

            }

        }

        private void crearRol()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_alta_rol", connection);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add(new SqlParameter("@nombre", this.txtbox_nombrerol.Text));
            
            //Funcionalidades agregado


            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarDatos();
                this.crearRol();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
