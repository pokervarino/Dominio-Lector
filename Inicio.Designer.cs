namespace Dominio_Lector
{
    partial class Inicio
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
            this.btnProfesor = new System.Windows.Forms.Button();
            this.bntAlumno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProfesor
            // 
            this.btnProfesor.Location = new System.Drawing.Point(165, 136);
            this.btnProfesor.Name = "btnProfesor";
            this.btnProfesor.Size = new System.Drawing.Size(75, 23);
            this.btnProfesor.TabIndex = 0;
            this.btnProfesor.Text = "Profesor";
            this.btnProfesor.UseVisualStyleBackColor = true;
            this.btnProfesor.Click += new System.EventHandler(this.btnProfesor_Click);
            // 
            // bntAlumno
            // 
            this.bntAlumno.Location = new System.Drawing.Point(412, 136);
            this.bntAlumno.Name = "bntAlumno";
            this.bntAlumno.Size = new System.Drawing.Size(75, 23);
            this.bntAlumno.TabIndex = 1;
            this.bntAlumno.Text = "Alumno";
            this.bntAlumno.UseVisualStyleBackColor = true;
            this.bntAlumno.Click += new System.EventHandler(this.bntAlumno_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 424);
            this.Controls.Add(this.bntAlumno);
            this.Controls.Add(this.btnProfesor);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProfesor;
        private System.Windows.Forms.Button bntAlumno;
    }
}