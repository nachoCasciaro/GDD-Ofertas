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

namespace FrbaOfertas.AbmProveedor
{
    public partial class FiltroBMProveedor : Form
    {
        public FiltroBMProveedor()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FILTRAR_Click(object sender, EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.filtrar(), dataGridView2);
        }

        private SqlDataReader filtrar()
        {
            var connection = DB.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POR_COLECTORA.sp_filtrar_proveedores", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add(new SqlParameter("@razonSocial", txtbox_rs.Text));

            if (txtbox_cuit.Text == "")
            {
                command.Parameters.Add(new SqlParameter("@cuit", Convert.ToInt32(0)));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("@cuit", Convert.ToInt32(txtbox_cuit.Text)));
            }
            command.Parameters.Add(new SqlParameter("@mail", txtbox_mail.Text));

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        private void seleccionarProveedorModificar()
        {
            Int32 id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            String rs = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            String mail = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            Int32 telefono = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[3].Value);
            String cuit = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            String calle = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
            String nroPiso = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
            String depto = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();
            String ciudad = dataGridView2.SelectedRows[0].Cells[8].Value.ToString();
            String cp = dataGridView2.SelectedRows[0].Cells[9].Value.ToString();
            String rubro = dataGridView2.SelectedRows[0].Cells[10].Value.ToString();
            String nombreContacto = dataGridView2.SelectedRows[0].Cells[11].Value.ToString();
            bool habilitado = (bool)dataGridView2.SelectedRows[0].Cells[12].Value;
            new AbmProveedor.ModificacionProveedor(id, rs, mail, telefono, cuit, calle, nroPiso, depto, ciudad, cp, rubro, nombreContacto, habilitado).Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    this.seleccionarProveedorModificar();
                    this.Close();
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un proveedor al cuál desea modificar");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    this.seleccionarProveedorBaja();

                    MessageBox.Show("Se dió de baja el proveedor con éxito");

                    this.Hide();
                    new Menu_Principal.MenuAdmin().Show();

                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un proveedor al cuál desea dar de baja");
            }
        }

        private void seleccionarProveedorBaja()
        {
            Int32 id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            var connection = DB.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POR_COLECTORA.sp_baja_proveedor", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id_prove", id));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();

        }

    }
}
