namespace FrbaOfertas.AbmCliente
{
    partial class FiltroBMCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbox_nombre = new System.Windows.Forms.TextBox();
            this.txtbox_apellido = new System.Windows.Forms.TextBox();
            this.txtbox_dni = new System.Windows.Forms.TextBox();
            this.txtbox_mail = new System.Windows.Forms.TextBox();
            this.button_filtrar = new System.Windows.Forms.Button();
            this.button_baja = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(677, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "DNI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(676, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mail";
            // 
            // txtbox_nombre
            // 
            this.txtbox_nombre.Location = new System.Drawing.Point(373, 69);
            this.txtbox_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_nombre.Name = "txtbox_nombre";
            this.txtbox_nombre.Size = new System.Drawing.Size(231, 22);
            this.txtbox_nombre.TabIndex = 5;
            // 
            // txtbox_apellido
            // 
            this.txtbox_apellido.Location = new System.Drawing.Point(373, 119);
            this.txtbox_apellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_apellido.Name = "txtbox_apellido";
            this.txtbox_apellido.Size = new System.Drawing.Size(231, 22);
            this.txtbox_apellido.TabIndex = 6;
            // 
            // txtbox_dni
            // 
            this.txtbox_dni.Location = new System.Drawing.Point(753, 71);
            this.txtbox_dni.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_dni.Name = "txtbox_dni";
            this.txtbox_dni.Size = new System.Drawing.Size(231, 22);
            this.txtbox_dni.TabIndex = 7;
            // 
            // txtbox_mail
            // 
            this.txtbox_mail.Location = new System.Drawing.Point(753, 119);
            this.txtbox_mail.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_mail.Name = "txtbox_mail";
            this.txtbox_mail.Size = new System.Drawing.Size(231, 22);
            this.txtbox_mail.TabIndex = 8;
            // 
            // button_filtrar
            // 
            this.button_filtrar.Location = new System.Drawing.Point(1101, 65);
            this.button_filtrar.Margin = new System.Windows.Forms.Padding(4);
            this.button_filtrar.Name = "button_filtrar";
            this.button_filtrar.Size = new System.Drawing.Size(135, 28);
            this.button_filtrar.TabIndex = 9;
            this.button_filtrar.Text = "BUSCAR";
            this.button_filtrar.UseVisualStyleBackColor = true;
            this.button_filtrar.Click += new System.EventHandler(this.button_filtrar_Click);
            // 
            // button_baja
            // 
            this.button_baja.Location = new System.Drawing.Point(664, 468);
            this.button_baja.Margin = new System.Windows.Forms.Padding(4);
            this.button_baja.Name = "button_baja";
            this.button_baja.Size = new System.Drawing.Size(141, 48);
            this.button_baja.TabIndex = 10;
            this.button_baja.Text = "BAJA";
            this.button_baja.UseVisualStyleBackColor = true;
            this.button_baja.Click += new System.EventHandler(this.button_baja_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.Location = new System.Drawing.Point(857, 468);
            this.button_modificar.Margin = new System.Windows.Forms.Padding(4);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(141, 48);
            this.button_modificar.TabIndex = 11;
            this.button_modificar.Text = "MODIFICACIÓN";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(65, 167);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1269, 289);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1101, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "LIMPIAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(463, 468);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 48);
            this.button2.TabIndex = 14;
            this.button2.Text = "ATRÁS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FiltroBMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 529);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_baja);
            this.Controls.Add(this.button_filtrar);
            this.Controls.Add(this.txtbox_mail);
            this.Controls.Add(this.txtbox_dni);
            this.Controls.Add(this.txtbox_apellido);
            this.Controls.Add(this.txtbox_nombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FiltroBMCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiltroBMCliente";
            this.Load += new System.EventHandler(this.FiltroBMCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbox_nombre;
        private System.Windows.Forms.TextBox txtbox_apellido;
        private System.Windows.Forms.TextBox txtbox_dni;
        private System.Windows.Forms.TextBox txtbox_mail;
        private System.Windows.Forms.Button button_filtrar;
        private System.Windows.Forms.Button button_baja;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}