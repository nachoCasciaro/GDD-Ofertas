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


namespace FrbaOfertas.Menu_Principal
{
    public partial class MenuCliente : Form
    {
        int idCliente;
        int idUserLogueado;

        public MenuCliente(int idCliente, int idUserLogueado)
        {
            this.idCliente = idCliente;
            this.idUserLogueado = idUserLogueado;
            InitializeComponent();
            Load += new EventHandler(MenuCliente_Load);

        }

        private bool chequearHabilitacion()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_cliente_esta_habilitado", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@idCliente", idCliente));
            query.Parameters.Add("@resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            bool resultado = Convert.ToBoolean(query.Parameters["@resultado"].Value);

            return resultado;
        }

        private bool chequearTieneRol()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_user_posee_rol_cliente", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@idUsuario", idUserLogueado));
            query.Parameters.Add("@resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            bool resultado = Convert.ToBoolean(query.Parameters["@resultado"].Value);

            return resultado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool estaHabilitado = this.chequearHabilitacion();

            bool poseeRolCliente = this.chequearTieneRol();

            if (estaHabilitado && poseeRolCliente)
            {
                this.Hide();
                new CargaCredito.CargaCredito(idCliente, this).Show();
            }
            else if (!estaHabilitado)
            {
                MessageBox.Show("Estás inhabilitado por lo que no podes acceder a esta función.");
            }
            else if (!poseeRolCliente)
            {
                MessageBox.Show("Ya no posees el rol cliente, comunicarse con el administrador.");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool estaHabilitado = this.chequearHabilitacion();

            bool poseeRolCliente = this.chequearTieneRol();

            if (estaHabilitado && poseeRolCliente)
            {
                this.Hide();
                new ComprarOferta.ComprarOferta(idCliente, this).Show();
            }
            else if(!estaHabilitado)
            {
                MessageBox.Show("Estás inhabilitado por lo que no podes acceder a esta función.");
            }
            else if (!poseeRolCliente)
            {
                MessageBox.Show("Ya no posees el rol cliente, comunicarse con el administrador.");
            }
            
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.Login().Show();

        }

        private void mostrarFuncionalidades()
        {
            if (this.poseeFuncionalidad("ABM Rol"))
            {
                this.button5.Visible = true;
            }
            else
            {
                this.button5.Visible = false;
            }

            if (this.poseeFuncionalidad("Cargar Crédito"))
            {
                this.button2.Visible = true;
            }
            else
            {
                this.button2.Visible = false;
            }

            if (this.poseeFuncionalidad("ABM Cliente"))
            {
                this.button6.Visible = true;
            }
            else
            {
                this.button6.Visible = false;
            }

            if (this.poseeFuncionalidad("ABM Proveedor"))
            {
                this.button7.Visible = true;
            }
            else
            {
                this.button7.Visible = false;
            }

            if (this.poseeFuncionalidad("Comprar Oferta"))
            {
                this.button1.Visible = true;
            }
            else
            {
                this.button1.Visible = false;
            }

            if (this.poseeFuncionalidad("Confección y publicación de Ofertas"))
            {
                this.button9.Visible = true;
            }
            else
            {
                this.button9.Visible = false;
            }


            if (this.poseeFuncionalidad("Entrega/Consumo de Oferta"))
            {
                this.button10.Visible = true;
            }
            else
            {
                this.button10.Visible = false;
            }

            if (this.poseeFuncionalidad("Listado Estadistico"))
            {
                this.button8.Visible = true;
            }
            else
            {
                this.button8.Visible = false;
            }


            if (this.poseeFuncionalidad("Facturación a Proveedor"))
            {
                this.button4.Visible = true;
            }
            else
            {
                this.button4.Visible = false;
            }

        }

        private bool poseeFuncionalidad(string nombreFuncionalidad)
        {

            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_rol_posee_funcionalidad", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@rol", 2));
            query.Parameters.Add(new SqlParameter("@func_descrip", nombreFuncionalidad));

            query.Parameters.Add("@resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            bool resultado = Convert.ToBoolean(query.Parameters["@resultado"].Value);

            return resultado;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debe acceder como proveedor para poder utilizar esta función.");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debe acceder como proveedor para poder utilizar esta función.");
        }

        private void MenuCliente_Load(object sender, EventArgs e)
        {
            this.mostrarFuncionalidades();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoEstadistico.ListadoEstadistico(this).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmCliente.MenuAbmCliente(this).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmProveedor.MenuAbmProveedor(this).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Facturar.FacturarProveedor(this).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmRol.MenuAbmRol(this).Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CambiarContraseña(idUserLogueado, this).Show();
        }
    }
}
