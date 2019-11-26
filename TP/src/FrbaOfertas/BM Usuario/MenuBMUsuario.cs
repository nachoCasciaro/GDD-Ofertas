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

namespace FrbaOfertas.BM_Usuario
{
    public partial class MenuBMUsuario : Form
    {
        Form parent;

        public MenuBMUsuario(Form parent)
        {
            this.parent = parent;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    this.seleccionarUsuarioBaja();

                    MessageBox.Show("Se dió de baja el usuario con éxito");

                    this.Hide();

                    this.parent.Show();


                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario al cuál desea dar de baja");
            }
        }

        private void seleccionarUsuarioBaja()
        {
            String user = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_baja_usuario", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@username", user));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private SqlDataReader filtrar()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POR_COLECTORA.sp_mostrar_usuarios", connection);
            command.CommandType = CommandType.StoredProcedure;


            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        private void MenuBMUsuario_Load(object sender, EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.filtrar(), dataGridView1);
        }

        private void seleccionarClienteModificar()
        {
            Int32 id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            new CambiarContraseña(id, parent).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    this.seleccionarClienteModificar();
                    this.Hide();

                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario al cuál le desea modificar la contraseña");
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }


    }
}
