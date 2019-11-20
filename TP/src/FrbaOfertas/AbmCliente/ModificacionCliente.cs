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

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();

            if (string.IsNullOrWhiteSpace(txtbox_nombre.Text))
            {
                mensajeError.Add("Debe completar el nombre");
            }

            if (string.IsNullOrWhiteSpace(txtbox_apellido.Text))
            {
                mensajeError.Add("Debe completar el apellido");
            }

            if (string.IsNullOrWhiteSpace(txtbox_dni.Text))
            {
                mensajeError.Add("Debe completar el dni");
            }

            if (string.IsNullOrWhiteSpace(txtbox_mail.Text))
            {
                mensajeError.Add("Debe completar el mail");
            }

            if (string.IsNullOrWhiteSpace(txtbox_telefono.Text))
            {
                mensajeError.Add("Debe completar el teléfono");
            }

            if (string.IsNullOrWhiteSpace(txtbox_calle.Text))
            {
                mensajeError.Add("Debe completar la calle");
            }

            if (string.IsNullOrWhiteSpace(txtbox_cp.Text))
            {
                mensajeError.Add("Debe completar el código postal");
            }

            if (string.IsNullOrWhiteSpace(txtbox_ciudad.Text))
            {
                mensajeError.Add("Debe completar la ciudad");
            }

            /*if (string.IsNullOrWhiteSpace(txtbox_depto.Text))  
            {
                mensajeError.Add("Debe completar el departamento");
            }

            if (string.IsNullOrWhiteSpace(txtbox_nropiso.Text))
            {
                mensajeError.Add("Debe completar el número de piso");
            }*/

            if (!Validaciones.contieneSoloNumeros(txtbox_telefono.Text))
            {

                mensajeError.Add("El telefono debe contener únicamente números");
            }
            if (!Validaciones.contieneSoloNumeros(txtbox_dni.Text))
            {

                throw new Exception("El dni debe contener únicamente números");
            }
            if (!Validaciones.tieneFormatoMail(txtbox_mail.Text))
            {

                mensajeError.Add("El formato del mail no es correcto");
            }

            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        void button1_Click(object sender, EventArgs e)
        {

            string error = this.validarDatos();

            if (error == "")
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


                if (this.checkbox_habilitado.Checked)
                {
                    query.Parameters.Add(new SqlParameter("@habilitar", true));

                }
                else
                {
                    query.Parameters.Add(new SqlParameter("@habilitar", habilitado));
                }

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Los datos del cliente fueron modificados con éxito.");

                this.Hide();

                new Menu_Principal.MenuAdmin().Show();

            }
            else
            {
                MessageBox.Show(error);
            }


        }

    }
}
