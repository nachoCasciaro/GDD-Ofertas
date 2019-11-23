using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Pantallas_Login_y_Menu_Nuevas
{
    public partial class MenuAdmin2 : Form
    {
        int idUser;

        public MenuAdmin2(int idUser)
        {
            this.idUser = idUser;

            InitializeComponent();
            Load += new EventHandler(MenuAdmin2_Load);

        }

        private void MenuAdmin2_Load(object sender, EventArgs e)
        {
            this.fill_list(1);
        }

        private void fill_list(int role_code)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand sqlCmd = new SqlCommand("SELECT Func_Descripcion FROM POR_COLECTORA.RolxUsuario r JOIN POR_COLECTORA.FuncionalidadxRol f ON (r.Id_Rol = f.Id_Rol) JOIN POR_COLECTORA.Funcionalidades ON (f.Id_Func = Func_Id) WHERE Id_Usuario = " + idUser + "ORDER BY Func_Descripcion ASC", connection);
            connection.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                listBox1.Items.Add(sqlReader["func_descripcion"].ToString());
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.Login().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }



    }
}
