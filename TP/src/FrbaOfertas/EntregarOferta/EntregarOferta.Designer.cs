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
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de Consumo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código de Cupón";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 206);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID Cliente";
            // 
            // dtm_fechaconsumo
            // 
            this.dtm_fechaconsumo.Location = new System.Drawing.Point(256, 98);
            this.dtm_fechaconsumo.Margin = new System.Windows.Forms.Padding(4);
            this.dtm_fechaconsumo.MaxDate = new System.DateTime(2019, 12, 31, 0, 0, 0, 0);
            this.dtm_fechaconsumo.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dtm_fechaconsumo.Name = "dtm_fechaconsumo";
            this.dtm_fechaconsumo.Size = new System.Drawing.Size(265, 22);
            this.dtm_fechaconsumo.TabIndex = 3;
            // 
            // txtbox_cupon
            // 
            this.txtbox_cupon.Location = new System.Drawing.Point(256, 153);
            this.txtbox_cupon.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_cupon.Name = "txtbox_cupon";
            this.txtbox_cupon.Size = new System.Drawing.Size(265, 22);
            this.txtbox_cupon.TabIndex = 4;
            // 
            // txtbox_cliente
            // 
            this.txtbox_cliente.Location = new System.Drawing.Point(256, 202);
            this.txtbox_cliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_cliente.Name = "txtbox_cliente";
            this.txtbox_cliente.Size = new System.Drawing.Size(265, 22);
            this.txtbox_cliente.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 279);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "DAR DE BAJA CUPÓN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 279);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 49);
            this.button2.TabIndex = 7;
            this.button2.Text = "VOLVER AL MENU PRINCIPAL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EntregarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 393);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbox_cliente);
            this.Controls.Add(this.txtbox_cupon);
            this.Controls.Add(this.dtm_fechaconsumo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EntregarOferta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button button2;
    }
}