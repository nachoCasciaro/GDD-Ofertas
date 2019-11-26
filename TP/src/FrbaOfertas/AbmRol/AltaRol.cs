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
        Form parent;

        public AltaRol(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {

        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();


            if (Validaciones.estaVacio(txtbox_nombrerol.Text))
            {

                mensajeError.Add("Debe completar el nombre del rol.");

            }

            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

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
                //Obtengo el id de la funcionalidad
                var connection2 = DB.getInstance().getConnection();
                SqlCommand sqlCmd2 = new SqlCommand("SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion = " + "'" + itemChecked + "'", connection2);
                connection2.Open();
                SqlDataReader sqlReader2 = sqlCmd2.ExecuteReader();
                Int32 id_funcionalidad = 0;

                while (sqlReader2.Read())
                {
                    id_funcionalidad = Convert.ToInt32(sqlReader2["Func_Id"]);
                }

                sqlReader2.Close();

                //Obtengo el id del rol que acabo de crear y en el que tengo que agregar las funcionalidades
                var connection4 = DB.getInstance().getConnection();
                SqlCommand sqlCmd4 = new SqlCommand("SELECT Rol_Id FROM POR_COLECTORA.Roles WHERE Rol_Nombre = " + "'" + this.txtbox_nombrerol.Text + "'", connection4);
                connection4.Open();
                SqlDataReader sqlReader4 = sqlCmd4.ExecuteReader();
                Int32 id_nuevo_rol = 0;

                while (sqlReader4.Read())
                {
                    id_nuevo_rol = Convert.ToInt32(sqlReader4["Rol_Id"]);
                }

                sqlReader4.Close();
                
                //Agrego la funcionalidad al nuevo rol
                var connection3 = DB.getInstance().getConnection();
                SqlCommand query3 = new SqlCommand("POR_COLECTORA.sp_agregar_funcionalidad_a_rol", connection3);
                query3.CommandType = CommandType.StoredProcedure;
                
                query3.Parameters.Add(new SqlParameter("@id_rol", id_nuevo_rol));
                query3.Parameters.Add(new SqlParameter("@id_funcionalidad", id_funcionalidad));

                connection3.Open();
                query3.ExecuteNonQuery();
                connection3.Close();

            }

            MessageBox.Show("El rol fue creado con éxito.");

            this.parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string error = this.validarDatos();
                if (error == "")
                {
                    this.crearRol();
                    this.Close();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }
    }
}
