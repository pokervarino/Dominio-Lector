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
    public partial class Avatar : Form
    {
        public Avatar()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Alumno ventana3 = new Alumno();
            ventana3.Show();
            this.Hide();
        }
    }
}
