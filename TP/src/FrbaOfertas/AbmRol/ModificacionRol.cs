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
    public partial class ModificacionRol : Form
    {
        Int32 id_rol;

        public ModificacionRol(Int32 rol)
        {
            InitializeComponent();

            this.id_rol = rol;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void seleccionarFuncionalidad()
        {
            String descripcion = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ModificarRol_Load(object sender, System.EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.mostrarFuncionalidadesRol(), dataGridView1);
        }

        private SqlDataReader mostrarFuncionalidadesRol()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POR_COLECTORA.sp_mostrar_funcionalidades_rol", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@rol", id_rol)); //Le mando el rol que me llega de la pantalla anterior

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        private void button2_Click(object sender, EventArgs e) //Eliminar funcionalidad
        {

        }

        private void button1_Click(object sender, EventArgs e) //Agregar funcionalidad
        {
            Int32 id_func = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_agregar_funcionalidad_a_rol", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@rol", id_rol));
            query.Parameters.Add(new SqlParameter("@funcionalidad", id_func));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();

            this.Close();
            new Menu_Principal.MenuAdmin().Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //Habilitar rol
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_habilitar_rol", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@rol", id_rol));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();

            this.Close();
            new Menu_Principal.MenuAdmin().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

    }
}
