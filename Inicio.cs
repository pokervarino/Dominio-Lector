using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dominio_Lector
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            Profesor Ventana = new Profesor();
            Ventana.Show();
            this.Hide();
        }

        private void bntAlumno_Click(object sender, EventArgs e)
        {
            Avatar Ventana1 = new Avatar();
            Ventana1.Show();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
