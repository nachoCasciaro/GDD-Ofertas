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
        public ModificacionProveedor()
        {
            InitializeComponent();
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
            //Obtener proveedor loggeado (necesito el ID)
            query.Parameters.Add(new SqlParameter("@razonSocial", this.txtbox_rs.Text));
            query.Parameters.Add(new SqlParameter("@mail", this.txtbox_mail.Text));
            query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(this.txtbox_telefono.Text)));
            query.Parameters.Add(new SqlParameter("@direCalle", this.txtbox_calle.Text));
            query.Parameters.Add(new SqlParameter("@nroPiso", this.txtbox_nropiso.Text));
            query.Parameters.Add(new SqlParameter("@depto", this.txtbox_depto.Text));
            query.Parameters.Add(new SqlParameter("@CP", this.txtbox_cp.Text));
            query.Parameters.Add(new SqlParameter("@cuit", this.txtbox_cuit.Text));
            query.Parameters.Add(new SqlParameter("@nombreContacto", this.txtbox_contacto.Text));
            bool habilitado = false;
            if (checkbox_habilitado.Checked)
            {
                habilitado = true;
            }
            query.Parameters.Add(new SqlParameter("@habilitado", habilitado));

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
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
