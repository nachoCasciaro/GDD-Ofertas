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
    public partial class LoginCliente : Form
    {
        public LoginCliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmCliente.RegistroCliente(this).Show();
        }

        private int idClienteIngresado(string username)
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_obtener_id_cliente", connection);
            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add(new SqlParameter("@user", username));

            query.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

            connection.Open();
            query.ExecuteNonQuery();

            var resultado = (query.Parameters["@resultado"].Value);

            connection.Close();

            if (resultado != DBNull.Value)
            {
                return Convert.ToInt32(resultado);
            } else
            {
                return -1;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string error = this.validarDatos();


            if (error == "")
            {
                var connection = DB.getInstance().getConnection();
                SqlCommand query = new SqlCommand("POR_COLECTORA.sp_login", connection);
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add(new SqlParameter("@user", this.textBox_usuario.Text));
                query.Parameters.Add(new SqlParameter("@pass", this.textBox_pass.Text));
                query.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                query.ExecuteNonQuery();

                int resultado = Convert.ToInt32(query.Parameters["@resultado"].Value);

                connection.Close();

                if (resultado == 4)
                {
                    this.Hide();

                    int idCliente = this.idClienteIngresado(this.textBox_usuario.Text);

                    if (idCliente != -1)
                    {
                        new Menu_Principal.MenuCliente(idCliente).Show();
                    }
                    else
                    {
                        MessageBox.Show("El usuario ingresado no es un cliente");
                        new LoginCliente().Show();
                    }

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
            else
            {
                MessageBox.Show(error);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string validarDatos()
        {
            List<string> mensajeError = new List<string>();


            if (string.IsNullOrWhiteSpace(textBox_usuario.Text))
            {

                mensajeError.Add("Debe completar el username.");
            }
            if (string.IsNullOrWhiteSpace(textBox_pass.Text))
            {

                mensajeError.Add("Debe completar la password.");
            }


            string mensajeConcat;
            mensajeConcat = string.Join("\n", mensajeError);

            return mensajeConcat;

        }

    }
}
