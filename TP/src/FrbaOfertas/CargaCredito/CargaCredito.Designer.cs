namespace FrbaOfertas.CragaCredito
{
    partial class Form1
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
            this.txtbox_vencimientotarjeta = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto Carga";
            // 
            // txtbox_monto
            // 
            this.txtbox_monto.Location = new System.Drawing.Point(153, 43);
            this.txtbox_monto.Name = "txtbox_monto";
            this.txtbox_monto.Size = new System.Drawing.Size(153, 20);
            this.txtbox_monto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Forma de Pago";
            // 
            // combobox_pago
            // 
            this.combobox_pago.FormattingEnabled = true;
            this.combobox_pago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.combobox_pago.Location = new System.Drawing.Point(153, 85);
            this.combobox_pago.Name = "combobox_pago";
            this.combobox_pago.Size = new System.Drawing.Size(153, 21);
            this.combobox_pago.TabIndex = 3;
            this.combobox_pago.SelectedIndexChanged += new System.EventHandler(this.combobox_pago_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Tarjeta";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Número de Tarjeta";
            // 
            // txtbox_numerotarjeta
            // 
            this.txtbox_numerotarjeta.Location = new System.Drawing.Point(153, 165);
            this.txtbox_numerotarjeta.Name = "txtbox_numerotarjeta";
            this.txtbox_numerotarjeta.Size = new System.Drawing.Size(153, 20);
            this.txtbox_numerotarjeta.TabIndex = 7;
            // 
            // combobox_tipotarjeta
            // 
            this.combobox_tipotarjeta.FormattingEnabled = true;
            this.combobox_tipotarjeta.Items.AddRange(new object[] {
            "Crédito",
            "Débito"});
            this.combobox_tipotarjeta.Location = new System.Drawing.Point(153, 127);
            this.combobox_tipotarjeta.Name = "combobox_tipotarjeta";
            this.combobox_tipotarjeta.Size = new System.Drawing.Size(153, 21);
            this.combobox_tipotarjeta.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha de Vencimiento Tarjeta";
            // 
            // txtbox_vencimientotarjeta
            // 
            this.txtbox_vencimientotarjeta.Location = new System.Drawing.Point(206, 202);
            this.txtbox_vencimientotarjeta.Name = "txtbox_vencimientotarjeta";
            this.txtbox_vencimientotarjeta.Size = new System.Drawing.Size(100, 20);
            this.txtbox_vencimientotarjeta.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "CARGAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 330);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbox_vencimientotarjeta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.combobox_tipotarjeta);
            this.Controls.Add(this.txtbox_numerotarjeta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combobox_pago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbox_monto);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "CargaCredito";
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
        private System.Windows.Forms.TextBox txtbox_vencimientotarjeta;
        private System.Windows.Forms.Button button1;
    }
}