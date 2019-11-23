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
        public int idUser;

        public CambiarContraseña()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

            new Menu_Principal.MenuCliente(1).Show();
        }
    }
}
