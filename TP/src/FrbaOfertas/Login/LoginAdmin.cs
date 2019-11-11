﻿using System;
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
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_login", connection);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add(new SqlParameter("@user", this.textBox1.Text));
            query.Parameters.Add(new SqlParameter("@pass", this.textBox2.Text));
            query.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

            connection.Open();
            query.ExecuteNonQuery();

            int resultado = Convert.ToInt32(query.Parameters["@resultado"].Value);

            connection.Close();

            if (resultado == 4)
            {
                this.Hide();
                new Menu_Principal.MenuAdmin().Show();
            }
            else if (resultado == 2)
            {
                MessageBox.Show("Contraseña incorrecta, intentelo de nuevo");

            }
            else if (resultado == 1)
            {
                MessageBox.Show("El usuario ingresado no existe");
            }
            else if (resultado == 3)
            {
                MessageBox.Show("El usuario ingresado se encuentra inhabilitado, consultar con el administrador");
            }



        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {
            string someValue = "Get the value from wherever you want";
            textBox1.Text = someValue;
        }

    }
}
