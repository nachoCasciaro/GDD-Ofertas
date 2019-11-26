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

namespace FrbaOfertas
{
    public partial class CambiarContraseña : Form
    {
        int idUser;
        Form parent;

        public CambiarContraseña(int idUser, Form parent)
        {
            this.idUser = idUser;
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string error = this.validarDatos();

                if (error == "")
                {
                    var connection = DB.getInstance().getConnection();
                    SqlCommand query = new SqlCommand("POR_COLECTORA.sp_cambiar_contraseña_user", connection);
                    query.CommandType = CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@id_user", this.idUser));
                    query.Parameters.Add(new SqlParameter("@new_pass", textBox1.Text));

                    connection.Open();
                    query.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Contraseña modificada con éxito.");

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
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
                    
        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                mensajeError.Add("Debe completar el campo New Password.");
            }

            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        private void CambiarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }
    }
}
