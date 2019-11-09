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
    public partial class BMRol : Form
    {
        public BMRol()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BMRol_Load(object sender, System.EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.mostrarRoles(), dataGridView1);
        }

        private SqlDataReader mostrarRoles()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POR_COLECTORA.sp_mostrar_roles", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        private void button1_Click(object sender, EventArgs e) //Boton baja
        {
            try
            {
                this.darBajaRol();
                this.Close();
            }
            catch (Exception excepcion) //Chequear sp, cuando entraria por el catch?
            {
                MessageBox.Show(excepcion.Message, "El rol ya se encuentra inhabilitado", MessageBoxButtons.OK);
            }
        }

        private SqlDataReader darBajaRol()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POR_COLECTORA.sp_baja_rol", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Obtener rol en el que me encuentro para el sp 

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    this.seleccionarRolModificar();
                    this.Close();
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void seleccionarRolModificar()
        {
            //Rol que se esta modificando

            new AbmRol.ModificacionRol().Show();

        }


    }
}
