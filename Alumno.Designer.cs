namespace Dominio_Lector
{
    partial class Alumno
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLectura = new System.Windows.Forms.Button();
            this.btnPruebas = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLectura);
            this.flowLayoutPanel1.Controls.Add(this.btnPruebas);
            this.flowLayoutPanel1.Controls.Add(this.btnSalir);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(83, 311);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnLectura
            // 
            this.btnLectura.Location = new System.Drawing.Point(3, 3);
            this.btnLectura.Name = "btnLectura";
            this.btnLectura.Size = new System.Drawing.Size(75, 64);
            this.btnLectura.TabIndex = 0;
            this.btnLectura.Text = "Lecturas";
            this.btnLectura.UseVisualStyleBackColor = true;
            this.btnLectura.Click += new System.EventHandler(this.btnLectura_Click);
            // 
            // btnPruebas
            // 
            this.btnPruebas.Enabled = false;
            this.btnPruebas.Location = new System.Drawing.Point(3, 73);
            this.btnPruebas.Name = "btnPruebas";
            this.btnPruebas.Size = new System.Drawing.Size(75, 64);
            this.btnPruebas.TabIndex = 1;
            this.btnPruebas.Text = "Pruebas";
            this.btnPruebas.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(3, 143);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 64);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(91, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 507);
            this.panel1.TabIndex = 4;
            // 
            // Alumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 531);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Alumno";
            this.Text = "Alumno";
            this.Load += new System.EventHandler(this.Alumno_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Timers.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLectura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPruebas;
        private System.Windows.Forms.Button btnSalir;
    }
}