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

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();


            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                //Obtener id funcionalidad asociado a string funcionalidad
                var connection2 = DB.getInstance().getConnection();
                SqlCommand query2 = new SqlCommand("POR_COLECTORA.sp_agregar_funcionalidad_a_rol", connection2);
                query2.CommandType = CommandType.StoredProcedure;
                
                query2.Parameters.Add(new SqlParameter("@id_rol", "asd")); //id del rol que acabo de crear //TODO revisar esto!
                query2.Parameters.Add(new SqlParameter("@id_funcionalidad", itemChecked));

                connection2.Open();
                query2.ExecuteNonQuery();
                connection2.Close();

            }


            MessageBox.Show("El rol fue creado con éxito.");

            new Menu_Principal.MenuAdmin().Show();
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
