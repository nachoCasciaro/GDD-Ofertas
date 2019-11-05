namespace FrbaOfertas.EntregarOferta
{
    partial class EntregarOferta
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
            this.dtm_fechaconsumo = new System.Windows.Forms.DateTimePicker();
            this.txtbox_cupon = new System.Windows.Forms.TextBox();
            this.txtbox_cliente = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de Consumo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código de Cupón";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente";
            // 
            // dtm_fechaconsumo
            // 
            this.dtm_fechaconsumo.Location = new System.Drawing.Point(192, 80);
            this.dtm_fechaconsumo.MaxDate = new System.DateTime(2019, 12, 31, 0, 0, 0, 0);
            this.dtm_fechaconsumo.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dtm_fechaconsumo.Name = "dtm_fechaconsumo";
            this.dtm_fechaconsumo.Size = new System.Drawing.Size(200, 20);
            this.dtm_fechaconsumo.TabIndex = 3;
            // 
            // txtbox_cupon
            // 
            this.txtbox_cupon.Location = new System.Drawing.Point(192, 124);
            this.txtbox_cupon.Name = "txtbox_cupon";
            this.txtbox_cupon.Size = new System.Drawing.Size(200, 20);
            this.txtbox_cupon.TabIndex = 4;
            // 
            // txtbox_cliente
            // 
            this.txtbox_cliente.Location = new System.Drawing.Point(192, 164);
            this.txtbox_cliente.Name = "txtbox_cliente";
            this.txtbox_cliente.Size = new System.Drawing.Size(200, 20);
            this.txtbox_cliente.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "DAR DE BAJA CUPÓN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EntregarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 319);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbox_cliente);
            this.Controls.Add(this.txtbox_cupon);
            this.Controls.Add(this.dtm_fechaconsumo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EntregarOferta";
            this.Text = "EntregarOferta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtm_fechaconsumo;
        private System.Windows.Forms.TextBox txtbox_cupon;
        private System.Windows.Forms.TextBox txtbox_cliente;
        private System.Windows.Forms.Button button1;
    }
}