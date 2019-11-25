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
    public partial class MenuProveedor : Form
    {
        int idProveedor;
        int idUserLogueado;

        public MenuProveedor(int idProveedor, int idUserLogueado)
        {
            this.idProveedor = idProveedor;
            this.idUserLogueado = idUserLogueado;
            InitializeComponent();
            Load += new EventHandler(MenuProveedor_Load);

        }

        private bool chequearHabilitacion()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_proveedor_esta_habilitado", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@idProveedor", idProveedor));
            query.Parameters.Add("@resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            bool resultado = Convert.ToBoolean(query.Parameters["@resultado"].Value);

            return resultado;
        }

        private bool chequearTieneRol()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_user_posee_rol_proveedor", connection);
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

            bool poseeRolProveedor = this.chequearTieneRol();

            if (estaHabilitado && poseeRolProveedor)
            {
                this.Hide();
                new CrearOferta.CrearOferta(idProveedor, this).Show();
            }
            else if (!estaHabilitado)
            {
                MessageBox.Show("Estás inhabilitado por lo que no podes acceder a esta función.");
            }
            else if (!poseeRolProveedor)
            {
                MessageBox.Show("Ya no posees el rol proveedor, comunicarse con el administrador.");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EntregarOferta.EntregarOferta(idProveedor,this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.Login().Show();
        }

        private void MenuProveedor_Load(object sender, EventArgs e)
        {
            this.mostrarFuncionalidades();
        }

        private void mostrarFuncionalidades()
        {
            if (this.poseeFuncionalidad("ABM Rol"))
            {
                this.button6.Visible = true;
            }
            else
            {
                this.button6.Visible = false;
            }

            if (this.poseeFuncionalidad("Cargar Crédito"))
            {
                this.button7.Visible = true;
            }
            else
            {
                this.button7.Visible = false;
            }

            if (this.poseeFuncionalidad("ABM Cliente"))
            {
                this.button8.Visible = true;
            }
            else
            {
                this.button8.Visible = false;
            }

            if (this.poseeFuncionalidad("ABM Proveedor"))
            {
                this.button9.Visible = true;
            }
            else
            {
                this.button9.Visible = false;
            }

            if (this.poseeFuncionalidad("Comprar Oferta"))
            {
                this.button10.Visible = true;
            }
            else
            {
                this.button10.Visible = false;
            }

            if (this.poseeFuncionalidad("Confección y publicación de Ofertas"))
            {
                this.button2.Visible = true;
            }
            else
            {
                this.button2.Visible = false;
            }


            if (this.poseeFuncionalidad("Entrega/Consumo de Oferta"))
            {
                this.button1.Visible = true;
            }
            else
            {
                this.button1.Visible = false;
            }

            if (this.poseeFuncionalidad("Listado Estadistico"))
            {
                this.button5.Visible = true;
            }
            else
            {
                this.button5.Visible = false;
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
            query.Parameters.Add(new SqlParameter("@rol", 3));
            query.Parameters.Add(new SqlParameter("@func_descrip", nombreFuncionalidad));

            query.Parameters.Add("@resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            bool resultado = Convert.ToBoolean(query.Parameters["@resultado"].Value);

            return resultado;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoEstadistico.ListadoEstadistico(this).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debe acceder como cliente para poder utilizar esta función.");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debe acceder como cliente para poder utilizar esta función.");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmCliente.MenuAbmCliente(this).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmProveedor.MenuAbmProveedor(this).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmRol.MenuAbmRol(this).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Facturar.FacturarProveedor(this).Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CambiarContraseña(idUserLogueado, this).Show();
        }
    }
}
