namespace FrbaOfertas.Facturar
{
    partial class FacturarProveedor
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
            this.dtm_inicio = new System.Windows.Forms.DateTimePicker();
            this.dtm_fin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_proveedor = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Fin";
            // 
            // dtm_inicio
            // 
            this.dtm_inicio.Location = new System.Drawing.Point(227, 34);
            this.dtm_inicio.Name = "dtm_inicio";
            this.dtm_inicio.Size = new System.Drawing.Size(200, 20);
            this.dtm_inicio.TabIndex = 2;
            // 
            // dtm_fin
            // 
            this.dtm_fin.Location = new System.Drawing.Point(227, 66);
            this.dtm_fin.Name = "dtm_fin";
            this.dtm_fin.Size = new System.Drawing.Size(200, 20);
            this.dtm_fin.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Proveedor";
            // 
            // txtbox_proveedor
            // 
            this.txtbox_proveedor.Location = new System.Drawing.Point(227, 104);
            this.txtbox_proveedor.Name = "txtbox_proveedor";
            this.txtbox_proveedor.Size = new System.Drawing.Size(200, 20);
            this.txtbox_proveedor.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 186);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(568, 174);
            this.dataGridView1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "FACTURAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FacturarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 427);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtbox_proveedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtm_fin);
            this.Controls.Add(this.dtm_inicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FacturarProveedor";
            this.Text = "FacturarProveedor";
            this.Load += new System.EventHandler(this.FacturarProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtm_inicio;
        private System.Windows.Forms.DateTimePicker dtm_fin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbox_proveedor;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}