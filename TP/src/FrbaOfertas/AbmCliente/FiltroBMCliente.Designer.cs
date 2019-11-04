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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "DNI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mail";
            // 
            // txtbox_nombre
            // 
            this.txtbox_nombre.Location = new System.Drawing.Point(190, 87);
            this.txtbox_nombre.Name = "txtbox_nombre";
            this.txtbox_nombre.Size = new System.Drawing.Size(174, 20);
            this.txtbox_nombre.TabIndex = 5;
            // 
            // txtbox_apellido
            // 
            this.txtbox_apellido.Location = new System.Drawing.Point(190, 119);
            this.txtbox_apellido.Name = "txtbox_apellido";
            this.txtbox_apellido.Size = new System.Drawing.Size(174, 20);
            this.txtbox_apellido.TabIndex = 6;
            // 
            // txtbox_dni
            // 
            this.txtbox_dni.Location = new System.Drawing.Point(190, 151);
            this.txtbox_dni.Name = "txtbox_dni";
            this.txtbox_dni.Size = new System.Drawing.Size(174, 20);
            this.txtbox_dni.TabIndex = 7;
            // 
            // txtbox_mail
            // 
            this.txtbox_mail.Location = new System.Drawing.Point(190, 183);
            this.txtbox_mail.Name = "txtbox_mail";
            this.txtbox_mail.Size = new System.Drawing.Size(174, 20);
            this.txtbox_mail.TabIndex = 8;
            // 
            // button_filtrar
            // 
            this.button_filtrar.Location = new System.Drawing.Point(49, 243);
            this.button_filtrar.Name = "button_filtrar";
            this.button_filtrar.Size = new System.Drawing.Size(101, 23);
            this.button_filtrar.TabIndex = 9;
            this.button_filtrar.Text = "FILTRAR";
            this.button_filtrar.UseVisualStyleBackColor = true;
            // 
            // button_baja
            // 
            this.button_baja.Location = new System.Drawing.Point(156, 243);
            this.button_baja.Name = "button_baja";
            this.button_baja.Size = new System.Drawing.Size(101, 23);
            this.button_baja.TabIndex = 10;
            this.button_baja.Text = "BAJA";
            this.button_baja.UseVisualStyleBackColor = true;
            // 
            // button_modificar
            // 
            this.button_modificar.Location = new System.Drawing.Point(263, 243);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(101, 23);
            this.button_modificar.TabIndex = 11;
            this.button_modificar.Text = "MODIFICAR";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button3_Click);
            // 
            // FiltroBMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 353);
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
            this.Name = "FiltroBMCliente";
            this.Text = "FiltroBMCliente";
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
    }
}