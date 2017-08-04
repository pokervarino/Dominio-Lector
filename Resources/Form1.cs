using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;


namespace Dominio_Lector.Resources
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var word = new Word.Application();
            word.Visible = true;
            var missing = Type.Missing;
            object archivo = @"D:\Development\Desarrollo Proyectos\Dominio Lector\Dominio Lector\Nuevo.docx";
            word.Documents.Open(ref archivo, ref missing, ref missing,
                               ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing, ref missing);

        }
    }
}
