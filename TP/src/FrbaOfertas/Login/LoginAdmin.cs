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

namespace FrbaOfertas.Login
{
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_login", connection);
            query.CommandType = CommandType.StoredProcedure;
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
          */
            this.Hide();
            new Menu_Principal.MenuAdmin().Show();

        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {
            string someValue = "Get the value from wherever you want";
            textBox1.Text = someValue;
        }

    }
}
