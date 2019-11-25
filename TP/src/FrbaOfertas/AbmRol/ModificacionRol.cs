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
        Form parent;


        public ModificacionRol(Int32 rol, Form parent)
        {
            InitializeComponent();

            this.id_rol = rol;

            this.parent = parent;

            Load += new EventHandler(ModificarRol_Load);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ModificarRol_Load(object sender, System.EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand sqlCmd = new SqlCommand("SELECT Rol_Nombre FROM POR_COLECTORA.Roles WHERE Rol_Id = "+ id_rol , connection);
            connection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                txtbox_nuevonombre.Text = sqlReader["Rol_Nombre"].ToString();
            }
     
            sqlReader.Close();

            ConfiguradorDataGrid.llenarDataGridConConsulta(this.mostrarFuncionalidadesRol(), dataGridView1);
            dataGridView1.Columns[0].Visible = false;

            //COMBOBOX FUNCIONALIDADES
            var connection2 = DB.getInstance().getConnection();
            SqlCommand sqlCmd2 = new SqlCommand("SELECT DISTINCT Func_Descripcion FROM POR_COLECTORA.Funcionalidades JOIN POR_COLECTORA.FuncionalidadxRol ON Func_Id = Id_Func WHERE Id_Func NOT IN (SELECT Id_Func FROM POR_COLECTORA.FuncionalidadxRol WHERE Id_Rol = " + "'" + id_rol + "'" + ")", connection);
            connection2.Open();
            SqlDataReader sqlReader2 = sqlCmd2.ExecuteReader();

            while (sqlReader2.Read())
            {
                combobox_funcionalidad.Items.Add(sqlReader2["Func_Descripcion"].ToString());
            }

            sqlReader2.Close();

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
            if (dataGridView1.SelectedRows.Count > 0) 
            {
                Int32 id_func = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var connection = DB.getInstance().getConnection();
                SqlCommand query = new SqlCommand("POR_COLECTORA.sp_eliminar_funcionalidad_rol", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@rol", id_rol));
                query.Parameters.Add(new SqlParameter("@funcionalidad", id_func));

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("La funcionalidad se eliminó con éxito.");

                this.Close();
                this.parent.Show();

            }
            else
            {
                MessageBox.Show("Debe seleccionar la funcionalidad que desea eliminar.");
            }
        }

        /*private Int32 obtenerIdFuncionalidad()
        {
            var connection2 = DB.getInstance().getConnection();
            String funcionalidad = Convert.ToString(combobox_funcionalidad.SelectedItem);
            SqlCommand sqlCmd2 = new SqlCommand("SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion =" + funcionalidad, connection2);
            connection2.Open();
            SqlDataReader sqlReader2 = sqlCmd2.ExecuteReader();
            Int32 id;

            id = Convert.ToInt32(sqlReader2["Func_Id"]);

            sqlReader2.Close();
            return id;

        }*/

        private void button1_Click(object sender, EventArgs e) //Agregar funcionalidad
        {
            var connection2 = DB.getInstance().getConnection();
            String funcionalidad = Convert.ToString(combobox_funcionalidad.SelectedItem);
            SqlCommand sqlCmd2 = new SqlCommand("SELECT Func_Id FROM POR_COLECTORA.Funcionalidades WHERE Func_Descripcion =" +"'" + funcionalidad + "'", connection2);
            connection2.Open();
            SqlDataReader sqlReader2 = sqlCmd2.ExecuteReader();
            Int32 id_func = 0;

            while (sqlReader2.Read())
            {
                id_func = Convert.ToInt32(sqlReader2["Func_Id"].ToString());
            }

            sqlReader2.Close();

            if (combobox_funcionalidad.SelectedIndex > -1)
            {
                var connection = DB.getInstance().getConnection();
                SqlCommand query = new SqlCommand("POR_COLECTORA.sp_agregar_funcionalidad_a_rol", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@id_rol", id_rol));
                query.Parameters.Add(new SqlParameter("@id_funcionalidad", id_func));

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("La funcionalidad se agregó con éxito.");

                this.Close();

                this.parent.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar la funcionalidad que desea agregar al rol.");
            }

           
        }

        private void button3_Click(object sender, EventArgs e) //Modificar nombre
        {

            if (txtbox_nuevonombre.Text != "")
            {

                var connection = DB.getInstance().getConnection();
                SqlCommand query = new SqlCommand("POR_COLECTORA.sp_modificar_nombre_rol", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@rol", id_rol));
                query.Parameters.Add(new SqlParameter("@nuevo_nombre", txtbox_nuevonombre.Text));


                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("El nombre del rol se modificó con éxito.");

                this.Close();

                this.parent.Show();

            }
            else 
            {
                MessageBox.Show("Debe completar el nombre del rol con algún alias.");
            }



        }

        private void button4_Click(object sender, EventArgs e) //Boton volver al menu principal
        {
            this.Hide();
            this.parent.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_habilitar_rol", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@rol", id_rol));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Se habilitó el rol con éxito.");

            this.Close();
            this.parent.Show();
        }

    }
}
