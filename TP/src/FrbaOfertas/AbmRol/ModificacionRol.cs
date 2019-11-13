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
        public ModificacionRol()
        {
            InitializeComponent();
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

            //Obtener rol en el que me encuentro

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        private void button2_Click(object sender, EventArgs e) //Eliminar funcionalidad
        {

        }

        private void button1_Click(object sender, EventArgs e) //Agregar funcionalidad
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Llamar al sp habilitar rol con el rol en el que se esta
        }

    }
}
