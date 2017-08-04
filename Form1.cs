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

        private void button2_Click(object sender, EventArgs e)
        {
            Avatar newMDIParent = new Avatar();
            newMDIParent.Show();
            
        }
    }
}
