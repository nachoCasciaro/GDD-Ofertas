namespace FrbaOfertas.AbmRol
{
    partial class ModificacionRol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbox_nuevonombre = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Funcionalidades = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.combobox_funcionalidad = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Funcionalidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbox_nuevonombre);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(33, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(511, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cambiar nombre";
            // 
            // txtbox_nuevonombre
            // 
            this.txtbox_nuevonombre.Location = new System.Drawing.Point(205, 44);
            this.txtbox_nuevonombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbox_nuevonombre.Name = "txtbox_nuevonombre";
            this.txtbox_nuevonombre.Size = new System.Drawing.Size(260, 22);
            this.txtbox_nuevonombre.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(49, 84);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(417, 28);
            this.button3.TabIndex = 4;
            this.button3.Text = "MODIFICAR NOMBRE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo nombre";
            // 
            // Funcionalidades
            // 
            this.Funcionalidades.Controls.Add(this.dataGridView1);
            this.Funcionalidades.Location = new System.Drawing.Point(33, 162);
            this.Funcionalidades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Funcionalidades.Name = "Funcionalidades";
            this.Funcionalidades.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Funcionalidades.Size = new System.Drawing.Size(511, 206);
            this.Funcionalidades.TabIndex = 0;
            this.Funcionalidades.TabStop = false;
            this.Funcionalidades.Text = "Funcionalidades";
            this.Funcionalidades.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 20);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(495, 178);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 438);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "AGREGAR FUNCIONALIDAD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 368);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(495, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "ELIMINAR FUNCIONALIDAD";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // combobox_funcionalidad
            // 
            this.combobox_funcionalidad.FormattingEnabled = true;
            this.combobox_funcionalidad.Location = new System.Drawing.Point(41, 438);
            this.combobox_funcionalidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combobox_funcionalidad.Name = "combobox_funcionalidad";
            this.combobox_funcionalidad.Size = new System.Drawing.Size(225, 24);
            this.combobox_funcionalidad.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(163, 534);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(264, 28);
            this.button4.TabIndex = 5;
            this.button4.Text = "VOLVER AL MENU PRINCIPAL";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(41, 483);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(146, 36);
            this.button5.TabIndex = 6;
            this.button5.Text = "HABILITAR ROL";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ModificacionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 577);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.combobox_funcionalidad);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Funcionalidades);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ModificacionRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModificacionRol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Funcionalidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Funcionalidades;
        private System.Windows.Forms.TextBox txtbox_nuevonombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox combobox_funcionalidad;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}