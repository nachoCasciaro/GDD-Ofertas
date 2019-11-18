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
            Load += new EventHandler(BMRol_Load);
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    //this.seleccionarRolBaja();
                    this.Close();

                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el rol que desea dar de baja");
            }
        }

        private void darBajaRol()
        {
            Int32 id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            var connection = DB.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POR_COLECTORA.sp_baja_rol", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@rol", id));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            this.Close();
            new Menu_Principal.MenuAdmin().Show();
        } 

        private void button2_Click(object sender, EventArgs e) //Modificacion rol
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
            else
            {
                MessageBox.Show("Debe seleccionar el rol que desea modificar");
            }
        }

        private void seleccionarRolModificar()
        {
            Int32 id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            new AbmRol.ModificacionRol(id).Show();

        }

        private void BMRol_Load_1(object sender, EventArgs e)
        {

        }


    }
}
