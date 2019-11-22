namespace FrbaOfertas.CargaCredito
{
    partial class CargaCredito
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
            this.txtbox_monto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combobox_pago = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbox_numerotarjeta = new System.Windows.Forms.TextBox();
            this.combobox_tipotarjeta = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.date_fechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto Carga";
            // 
            // txtbox_monto
            // 
            this.txtbox_monto.Location = new System.Drawing.Point(204, 53);
            this.txtbox_monto.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_monto.Name = "txtbox_monto";
            this.txtbox_monto.Size = new System.Drawing.Size(203, 22);
            this.txtbox_monto.TabIndex = 1;
            this.txtbox_monto.TextChanged += new System.EventHandler(this.txtbox_monto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Forma de Pago";
            // 
            // combobox_pago
            // 
            this.combobox_pago.FormattingEnabled = true;
            this.combobox_pago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.combobox_pago.Location = new System.Drawing.Point(204, 105);
            this.combobox_pago.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_pago.Name = "combobox_pago";
            this.combobox_pago.Size = new System.Drawing.Size(203, 24);
            this.combobox_pago.TabIndex = 3;
            this.combobox_pago.SelectedIndexChanged += new System.EventHandler(this.combobox_pago_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Tarjeta";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 207);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Número de Tarjeta";
            // 
            // txtbox_numerotarjeta
            // 
            this.txtbox_numerotarjeta.Location = new System.Drawing.Point(204, 203);
            this.txtbox_numerotarjeta.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_numerotarjeta.Name = "txtbox_numerotarjeta";
            this.txtbox_numerotarjeta.Size = new System.Drawing.Size(203, 22);
            this.txtbox_numerotarjeta.TabIndex = 7;
            // 
            // combobox_tipotarjeta
            // 
            this.combobox_tipotarjeta.FormattingEnabled = true;
            this.combobox_tipotarjeta.Items.AddRange(new object[] {
            "Crédito",
            "Débito",
            "No aplica"});
            this.combobox_tipotarjeta.Location = new System.Drawing.Point(204, 156);
            this.combobox_tipotarjeta.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_tipotarjeta.Name = "combobox_tipotarjeta";
            this.combobox_tipotarjeta.Size = new System.Drawing.Size(203, 24);
            this.combobox_tipotarjeta.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 252);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha de Vencimiento Tarjeta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 295);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "CARGAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 63);
            this.button2.TabIndex = 12;
            this.button2.Text = "VOLVER AL MENU PRINCIPAL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // date_fechaVencimiento
            // 
            this.date_fechaVencimiento.Location = new System.Drawing.Point(274, 252);
            this.date_fechaVencimiento.Name = "date_fechaVencimiento";
            this.date_fechaVencimiento.Size = new System.Drawing.Size(200, 22);
            this.date_fechaVencimiento.TabIndex = 13;
            // 
            // CargaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 444);
            this.Controls.Add(this.date_fechaVencimiento);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.combobox_tipotarjeta);
            this.Controls.Add(this.txtbox_numerotarjeta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combobox_pago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbox_monto);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CargaCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CargaCredito";
            this.Load += new System.EventHandler(this.Carga_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_monto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combobox_pago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbox_numerotarjeta;
        private System.Windows.Forms.ComboBox combobox_tipotarjeta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker date_fechaVencimiento;
    }
}