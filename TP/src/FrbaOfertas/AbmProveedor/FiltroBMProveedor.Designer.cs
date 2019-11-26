namespace FrbaOfertas.AbmProveedor
{
    partial class FiltroBMProveedor
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
            this.txtbox_rs = new System.Windows.Forms.TextBox();
            this.txtbox_cuit = new System.Windows.Forms.TextBox();
            this.txtbox_mail = new System.Windows.Forms.TextBox();
            this.FILTRAR = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Razón Social";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(699, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "CUIT";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mail";
            // 
            // txtbox_rs
            // 
            this.txtbox_rs.Location = new System.Drawing.Point(355, 58);
            this.txtbox_rs.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_rs.Name = "txtbox_rs";
            this.txtbox_rs.Size = new System.Drawing.Size(313, 22);
            this.txtbox_rs.TabIndex = 4;
            // 
            // txtbox_cuit
            // 
            this.txtbox_cuit.Location = new System.Drawing.Point(785, 57);
            this.txtbox_cuit.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_cuit.Name = "txtbox_cuit";
            this.txtbox_cuit.Size = new System.Drawing.Size(313, 22);
            this.txtbox_cuit.TabIndex = 5;
            // 
            // txtbox_mail
            // 
            this.txtbox_mail.Location = new System.Drawing.Point(355, 102);
            this.txtbox_mail.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_mail.Name = "txtbox_mail";
            this.txtbox_mail.Size = new System.Drawing.Size(313, 22);
            this.txtbox_mail.TabIndex = 6;
            // 
            // FILTRAR
            // 
            this.FILTRAR.Location = new System.Drawing.Point(1149, 57);
            this.FILTRAR.Margin = new System.Windows.Forms.Padding(4);
            this.FILTRAR.Name = "FILTRAR";
            this.FILTRAR.Size = new System.Drawing.Size(100, 28);
            this.FILTRAR.TabIndex = 8;
            this.FILTRAR.Text = "BUSCAR";
            this.FILTRAR.UseVisualStyleBackColor = true;
            this.FILTRAR.Click += new System.EventHandler(this.FILTRAR_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(666, 469);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 48);
            this.button1.TabIndex = 9;
            this.button1.Text = "BAJA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(882, 469);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 49);
            this.button2.TabIndex = 10;
            this.button2.Text = "MODIFICACIÓN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(63, 156);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1269, 289);
            this.dataGridView2.TabIndex = 13;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1149, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 14;
            this.button3.Text = "LIMPIAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(442, 469);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 48);
            this.button4.TabIndex = 15;
            this.button4.Text = "ATRÁS";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FiltroBMProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 544);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FILTRAR);
            this.Controls.Add(this.txtbox_mail);
            this.Controls.Add(this.txtbox_cuit);
            this.Controls.Add(this.txtbox_rs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FiltroBMProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiltroBMProveedor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbox_rs;
        private System.Windows.Forms.TextBox txtbox_cuit;
        private System.Windows.Forms.TextBox txtbox_mail;
        private System.Windows.Forms.Button FILTRAR;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}