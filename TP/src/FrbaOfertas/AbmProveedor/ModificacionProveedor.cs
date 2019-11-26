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

namespace FrbaOfertas.AbmProveedor
{
    public partial class ModificacionProveedor : Form
    {
        Int32 id;
        String rs;
        String mail;
        Int32 telefono;
        String cuit;
        String calle;
        String nroPiso;
        String depto;
        String ciudad;
        String cp;
        String rubro;
        String nombreContacto;
        bool habilitado;
        Form parent;

        public ModificacionProveedor(Int32 id, String rs, String mail, Int32 telefono, String cuit, String calle, String nroPiso, String depto, String ciudad, String cp, String rubro, String nombreContacto, bool habilitado, Form parent)
        {
            InitializeComponent();
            this.id = id;
            this.rs = rs;
            this.mail = mail;
            this.telefono = telefono;
            this.cuit = cuit;
            this.calle = calle;
            this.nroPiso = nroPiso;
            this.depto = depto;
            this.ciudad = ciudad;
            this.cp = cp;
            this.rubro = rubro;
            this.nombreContacto = nombreContacto;
            this.habilitado = habilitado;

            if (habilitado)
            {
                this.checkbox_habilitado.Visible = false;
            }

            this.parent = parent;

            Load += new EventHandler(ModificacionProveedor_Load);
        }

        private void ModificacionProveedor_Load(object sender, EventArgs e)
        {
            this.txtbox_rs.Text = rs;
            this.txtbox_mail.Text = mail;
            this.txtbox_telefono.Text = telefono.ToString();
            this.txtbox_cuit.Text = cuit;
            this.txtbox_calle.Text = calle;
            this.txtbox_nropiso.Text = nroPiso;
            this.txtbox_depto.Text = depto;
            this.txtbox_cp.Text = cp;
            this.txtbox_ciudad.Text = ciudad;
            this.txtbox_contacto.Text = nombreContacto;

            var connection = DB.getInstance().getConnection();
            SqlCommand sqlCmd = new SqlCommand("SELECT Rubro_Detalle FROM POR_COLECTORA.Rubros", connection);
            connection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {

                comboBox_rubro.Items.Add(sqlReader["Rubro_Detalle"].ToString());
            }

            comboBox_rubro.SelectedIndex = comboBox_rubro.FindString(rubro);

            sqlReader.Close();

        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();

            if (string.IsNullOrWhiteSpace(txtbox_rs.Text))
            {
                mensajeError.Add("Debe completar la razón social");
            }

            if (string.IsNullOrWhiteSpace(txtbox_mail.Text))
            {
                mensajeError.Add("Debe completar el mail");
            }
            else
            {
                if (!Validaciones.tieneFormatoMail(txtbox_mail.Text))
                {
                    mensajeError.Add("El formato del mail no es correcto");
                }
            }

            if (string.IsNullOrWhiteSpace(txtbox_telefono.Text))
            {
                mensajeError.Add("Debe completar el teléfono");
            }
            else
            {
                if (!Validaciones.contieneSoloNumeros(txtbox_telefono.Text))
                {
                    mensajeError.Add("El telefono debe contener únicamente números");
                }
            }

            if (string.IsNullOrWhiteSpace(txtbox_cuit.Text))
            {
                mensajeError.Add("Debe completar el CUIT");
            }
            else
            {
                if (!Validaciones.tieneFormatoDeCuit(txtbox_cuit.Text))
                {
                    mensajeError.Add("El formato del CUIT no es correcto");
                }
            }

            if (comboBox_rubro.SelectedIndex == -1)
            {

                mensajeError.Add("Debe seleccionar un rubro");
            }

            if (string.IsNullOrWhiteSpace(txtbox_contacto.Text))
            {
                mensajeError.Add("Debe completar el nombre de contacto");
            }

            if (string.IsNullOrWhiteSpace(txtbox_calle.Text))
            {
                mensajeError.Add("Debe completar la calle");
            }
           
            if (string.IsNullOrWhiteSpace(txtbox_ciudad.Text))
            {
                mensajeError.Add("Debe completar la ciudad");
            }

            if (string.IsNullOrWhiteSpace(txtbox_cp.Text))
            {
                mensajeError.Add("Debe completar el código postal");
            }
            


            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

        void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string error = this.validarDatos();

                if (error == "")
                {
                    var connection = DB.getInstance().getConnection();
                    SqlCommand query = new SqlCommand("POR_COLECTORA.sp_modificar_proveedor", connection);
                    query.CommandType = CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@id_prove", this.id));
                    query.Parameters.Add(new SqlParameter("@razonSocial", this.txtbox_rs.Text));
                    query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text));
                    query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(this.txtbox_telefono.Text)));
                    query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
                    query.Parameters.Add(new SqlParameter("@nroPiso", this.txtbox_nropiso.Text));
                    query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
                    query.Parameters.Add(new SqlParameter("@ciudad", this.txtbox_ciudad.Text));
                    query.Parameters.Add(new SqlParameter("@CP", this.txtbox_cp.Text));
                    query.Parameters.Add(new SqlParameter("@cuit", this.txtbox_cuit.Text));
                    query.Parameters.Add(new SqlParameter("@nombreContacto", this.txtbox_contacto.Text));
                    query.Parameters.Add(new SqlParameter("@rubro_detalle", this.comboBox_rubro.SelectedItem));

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

                    MessageBox.Show("Los datos del proveedor fueron modificados con éxito.");

                    this.Hide();

                    this.parent.Show();

                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show("Ya existe un proveedor con ese cuit o razón social.", "Error", MessageBoxButtons.OK);
            }

            


        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_rubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtbox_rs.Text = "";
            txtbox_cuit.Text = "";
            txtbox_cp.Text = "";
            txtbox_calle.Text = "";
            txtbox_ciudad.Text = "";
            txtbox_mail.Text = "";
            txtbox_nropiso.Text = "";
            txtbox_telefono.Text = "";
            txtbox_depto.Text = "";
            txtbox_contacto.Text = "";
            comboBox_rubro.ResetText();
        }
    }
}
