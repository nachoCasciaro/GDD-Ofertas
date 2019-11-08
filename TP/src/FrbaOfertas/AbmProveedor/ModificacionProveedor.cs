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
        Int32 nroPiso;
        String depto;
        String ciudad;
        Int32 cp;
        String rubro;
        String nombreContacto;
        bool habilitado;

        public ModificacionProveedor(Int32 id, String rs, String mail, Int32 telefono, String cuit, String calle, Int32 nroPiso, String depto, String ciudad, Int32 cp, String rubro, String nombreContacto, bool habilitado)
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
            if (habilitado)
            {
                checkbox_habilitado.Checked = true;
            }
            Load += new EventHandler(ModificacionProveedor_Load);
        }

        private void ModificacionProveedor_Load(object sender, EventArgs e)
        {
            this.txtbox_rs.Text = rs;
            this.txtbox_mail.Text = mail;
            this.txtbox_telefono.Text = telefono.ToString();
            this.txtbox_cuit.Text = cuit;
            this.txtbox_calle.Text = calle;
            this.txtbox_nropiso.Text = nroPiso.ToString();
            this.txtbox_depto.Text = depto;
            this.txtbox_cp.Text = cp.ToString();
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

        private void validarDatos()
        {
            if (Validaciones.estaVacio(txtbox_rs.Text) || Validaciones.estaVacio(txtbox_cuit.Text) || Validaciones.estaVacio(txtbox_mail.Text) || Validaciones.estaVacio(txtbox_telefono.Text) || Validaciones.estaVacio(txtbox_calle.Text) || Validaciones.estaVacio(txtbox_contacto.Text) || Validaciones.estaVacio(txtbox_nropiso.Text) || Validaciones.estaVacio(txtbox_depto.Text) || Validaciones.estaVacio(txtbox_ciudad.Text) || Validaciones.estaVacio(txtbox_cp.Text))
            {
                throw new Exception("Debe completar todos los campos");
            }
            if (!Validaciones.tieneFormatoDeCuit(txtbox_cuit.Text))
            {
                throw new Exception("El CUIT ingresado no tiene el formato esperado");
            }
        }

        private void modificarProveedor()
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
            /*
            bool habilitado = false;
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
                this.modificarProveedor();
                this.Close();
                new Menu_Principal.MenuAdmin().Show();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
