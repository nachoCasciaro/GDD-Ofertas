namespace FrbaOfertas.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.dtm_año = new System.Windows.Forms.DateTimePicker();
            this.combobox_semestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Año = new System.Windows.Forms.Label();
            this.combobox_tipolistado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtm_año);
            this.groupBox1.Controls.Add(this.combobox_semestre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Año);
            this.groupBox1.Controls.Add(this.combobox_tipolistado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(94, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(541, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado a visualizar";
            // 
            // dtm_año
            // 
            this.dtm_año.Location = new System.Drawing.Point(71, 79);
            this.dtm_año.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtm_año.Name = "dtm_año";
            this.dtm_año.Size = new System.Drawing.Size(200, 22);
            this.dtm_año.TabIndex = 5;
            // 
            // combobox_semestre
            // 
            this.combobox_semestre.FormattingEnabled = true;
            this.combobox_semestre.Items.AddRange(new object[] {
            "1",
            "2"});
            this.combobox_semestre.Location = new System.Drawing.Point(364, 79);
            this.combobox_semestre.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_semestre.Name = "combobox_semestre";
            this.combobox_semestre.Size = new System.Drawing.Size(132, 24);
            this.combobox_semestre.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Semestre";
            // 
            // Año
            // 
            this.Año.AutoSize = true;
            this.Año.Location = new System.Drawing.Point(29, 82);
            this.Año.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Año.Name = "Año";
            this.Año.Size = new System.Drawing.Size(33, 17);
            this.Año.TabIndex = 2;
            this.Año.Text = "Año";
            this.Año.Click += new System.EventHandler(this.Año_Click);
            // 
            // combobox_tipolistado
            // 
            this.combobox_tipolistado.FormattingEnabled = true;
            this.combobox_tipolistado.Items.AddRange(new object[] {
            "Proveedores con mayor porcentaje de descuento",
            "Proveedores con mayor facturación"});
            this.combobox_tipolistado.Location = new System.Drawing.Point(167, 31);
            this.combobox_tipolistado.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_tipolistado.Name = "combobox_tipolistado";
            this.combobox_tipolistado.Size = new System.Drawing.Size(329, 24);
            this.combobox_tipolistado.TabIndex = 1;
            this.combobox_tipolistado.SelectedIndexChanged += new System.EventHandler(this.combobox_tipolistado_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de listado";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 164);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "VER LISTADO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 231);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(695, 223);
            this.dataGridView1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 496);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "VOLVER AL MENU PRINCIPAL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 573);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListadoEstadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox combobox_semestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Año;
        private System.Windows.Forms.ComboBox combobox_tipolistado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtm_año;
    }
}