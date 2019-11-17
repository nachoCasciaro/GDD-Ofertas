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
    public partial class ModificacionCliente : Form
    {
        Int32 id;
        String nombre;
        String apellido;
        Int32 dni;        
        String mail;
        Int32 telefono;
        String calle;
        String nroPiso;
        String depto;
        String ciudad;
        String cp;
        DateTime fecha;
        bool habilitado;

        public ModificacionCliente(Int32 id, String nombre, String apellido, Int32 dni, String mail, Int32 telefono, String calle, String nroPiso, String depto, String ciudad, String cp, DateTime fecha, bool habilitado)
        {
            InitializeComponent();
            this.id = id;
            this.dni = dni;
            this.apellido = apellido;
            this.nombre = nombre;
            this.fecha = fecha;
            this.mail = mail;
            this.telefono = telefono;
            this.calle = calle;
            this.nroPiso = nroPiso;
            this.depto = depto;
            this.cp = cp;
            this.ciudad = ciudad;
            this.habilitado = habilitado;
            if (habilitado)
                checkbox_habilitado.Checked = true;
            Load += new EventHandler(ModificacionCliente_Load);

        }
         public ModificacionCliente()
        {
            InitializeComponent();
        }


        private void ModificacionCliente_Load(object sender, EventArgs e)
        {
            txtbox_dni.Text = dni.ToString();
            txtbox_nombre.Text = nombre;
            txtbox_apellido.Text = apellido;
            dtm_fecha.Value = fecha;
            txtbox_mail.Text = mail;
            txtbox_telefono.Text = telefono.ToString();
            txtbox_calle.Text = calle;
            txtbox_nropiso.Text = nroPiso;
            txtbox_depto.Text = depto;
            txtbox_cp.Text = cp;
            txtbox_ciudad.Text = ciudad;
            
        }


        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void validarDatos()
        {
            if (Validaciones.estaVacio(txtbox_nombre.Text) || Validaciones.estaVacio(txtbox_apellido.Text) || Validaciones.estaVacio(txtbox_dni.Text) || Validaciones.estaVacio(txtbox_mail.Text) || Validaciones.estaVacio(txtbox_telefono.Text) || Validaciones.estaVacio(txtbox_calle.Text) || Validaciones.estaVacio(txtbox_cp.Text) || Validaciones.estaVacio(txtbox_ciudad.Text))

            {

                throw new Exception("Debe completar todos los campos");

            }
            if (!Validaciones.contieneSoloNumeros(txtbox_telefono.Text))
            {

                throw new Exception("El telefono debe contener únicamente números");
            }
            if (!Validaciones.contieneSoloNumeros(txtbox_dni.Text))
            {

                throw new Exception("El dni debe contener únicamente números");
            }
            if (!Validaciones.tieneFormatoMail(txtbox_mail.Text))
            {

                throw new Exception("Ingrese el mail correctamente");
            }

        }

        private void modificarCliente()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_modificar_cliente", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id_clie", this.id));
            query.Parameters.Add(new SqlParameter("@nombre", this.txtbox_nombre.Text));
            query.Parameters.Add(new SqlParameter("@apellido", this.txtbox_apellido.Text));
            query.Parameters.Add(new SqlParameter("@dni", Convert.ToInt32(this.txtbox_dni.Text)));
            query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text));
            query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(txtbox_telefono.Text)));
            query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
            query.Parameters.Add(new SqlParameter("@nroPiso", this.txtbox_nropiso.Text));
            query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
            query.Parameters.Add(new SqlParameter("@ciudad", this.txtbox_ciudad.Text));
            query.Parameters.Add(new SqlParameter("@CP", this.txtbox_cp.Text));
            query.Parameters.Add(new SqlParameter("@fechaNacimiento", dtm_fecha.Value));
            /*bool habilitado = false;
            if (checkbox_habilitado.Checked)
            {
                habilitado = true;
            }
            query.Parameters.Add(new SqlParameter("@habilitado", habilitado));
            */
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarDatos();
                this.modificarCliente();
                MessageBox.Show("Se modificó el cliente con éxito");

                this.Hide();

                new Menu_Principal.MenuAdmin().Show();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

    }
}
