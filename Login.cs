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
    public partial class Login : Form
    {
        
        

         //Delegado Prueba
        public delegate void delegadoUsuario(string mensaje);
        //Evento 
        public event delegadoUsuario miEvento;
        public int idAlumno;
        public string numero;
      
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            
            string username = txtUsuario.Text;
            string password = txtPass.Text;
            Consultas Query = new Consultas();
            DataTable Admin = new DataTable();
            try {
                Admin.Load(Query.loginAdmin(username, password));
                Admin.PrimaryKey = new DataColumn[]{
                    Admin.Columns["Id_Profesor"]
                };
                if (username == Admin.Rows[0][1].ToString() && password == Admin.Rows[0][2].ToString())
                {
                    Profesor ventana1 = new Profesor();
                    ventana1.Show();
                    this.Hide();
                    
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Datos de Login Incorrectos");
            }

            



        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Consultas Query = new Consultas();
                string respuestaInsert = Query.ingresaAlumno(txtUsuario2.Text, txtNombre.Text, txtApellido.Text, cbNivel.SelectedIndex + 1, txtContraseña.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error" + ex);
            }
            //Avatar ventana2 = new Avatar();
            //ventana2.Show();
            //this.Hide();
        }

        public void btnIngresar1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass2.Text;
            Consultas Query = new Consultas();
            DataTable Admin = new DataTable();
            try
            {
                Admin.Load(Query.loginAlumno(username, password));
                Admin.PrimaryKey = new DataColumn[]{
                    Admin.Columns["Id_Alumno"]
                };
                if (username == Admin.Rows[0][1].ToString() && password == Admin.Rows[0][2].ToString())
                {
                    Modulo digito = new Modulo();
                    idAlumno = Convert.ToInt32(Admin.Rows[0][0]);
                    numero = idAlumno.ToString();
                    digito.idAlumno1 = idAlumno;
                    //this.miEvento(numero);
                    Alumno ventana3 = new Alumno();
                    ventana3.Show();
                    //this.Hide();  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos de Ingreso Incorrectos");
            }  
        }

    }
}
