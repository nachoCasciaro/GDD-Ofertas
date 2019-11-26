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

namespace FrbaOfertas.AbmCliente
{
    public partial class FiltroBMCliente : Form
    {
        Form parent;

        public FiltroBMCliente(Form parent)
        {
            this.parent = parent;
            InitializeComponent();

        }

        private void button_filtrar_Click(object sender, EventArgs e)
        {
            string error = this.validarDatos();

            if (error == "")
            {
                ConfiguradorDataGrid.llenarDataGridConConsulta(this.filtrar(), dataGridView1);

            }
            else
            {
                MessageBox.Show(error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private SqlDataReader filtrar()
        {

                var connection = DB.getInstance().getConnection();
                SqlCommand command = new SqlCommand("POR_COLECTORA.sp_filtrar_clientes", connection);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add(new SqlParameter("@nombre", txtbox_nombre.Text));
                command.Parameters.Add(new SqlParameter("@apellido", txtbox_apellido.Text));
                if (txtbox_dni.Text == "")
                {
                    command.Parameters.Add(new SqlParameter("@dni", Convert.ToInt32(0)));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@dni", Convert.ToInt32(txtbox_dni.Text)));
                }
                command.Parameters.Add(new SqlParameter("@mail", txtbox_mail.Text));

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                return reader;

            


        }

        private void seleccionarClienteModificar()
        {
            Int32 id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            String nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            String apellido = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Int32 dni = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            String mail = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            Int32 telefono = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
            String calle = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            String nroPiso = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            String depto = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            String ciudad = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            String cp = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            DateTime fecha = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[11].Value);
            bool habilitado = (bool)dataGridView1.SelectedRows[0].Cells[12].Value;
            new AbmCliente.ModificacionCliente(id,nombre,apellido,dni,mail,telefono,calle,nroPiso,depto,ciudad,cp,fecha,habilitado,parent).Show();

        }

        private void button_modificar_Click(object sender, EventArgs e)
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
                MessageBox.Show("Debe seleccionar un cliente al cuál desea modificar");
            }
        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();


            if (!Validaciones.contieneSoloNumeros(txtbox_dni.Text))
            {

                mensajeError.Add("El dni debe contener únicamente números");
            }


            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        private void button_baja_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    this.seleccionarClienteBaja();

                    MessageBox.Show("Se dió de baja el cliente con éxito");

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
                MessageBox.Show("Debe seleccionar un cliente al cuál desea dar de baja");
            }
        }

        private void seleccionarClienteBaja()
        {
            try
            {
                Int32 id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var connection = DB.getInstance().getConnection();
                SqlCommand query = new SqlCommand("POR_COLECTORA.sp_baja_cliente", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@id_clie", id));

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
           
        }

        private void FiltroBMCliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtbox_nombre.Text = "";
            txtbox_mail.Text = "";
            txtbox_apellido.Text = "";
            txtbox_dni.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }


    }
}
