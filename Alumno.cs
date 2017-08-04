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
    public partial class Alumno : Form
    {
        public Button btnInicia = new Button();
        int cont = 0;
        int numLectura;
        int numExamen;
        public Timer tiempo = new Timer();
        public Label lbCrono = new Label();

        //Creacion de los Botones usados
        public Button btnSeleccionar = new Button();
        public Button btnComenzar = new Button();
        public Button btnCancelar = new Button();
        public Button btnDetener = new Button();
        public Button btnTerminar = new Button();
        //Creacion de los ListBox usados.
        public ListBox lbLecturas = new ListBox();
        public ListBox lbExamenes = new ListBox();
        public string lectura;
        public RichTextBox rtbLectura = new RichTextBox();

        Login variable = new Login();
        // Labels para la prueba. 

        public Label lPregunta1 = new Label();
        public Label lPregunta2 = new Label();
        public Label lPregunta3 = new Label();
        public Label lPregunta4 = new Label();

        public Label lRespuesta1 = new Label();
        public Label lRespuesta2 = new Label();
        public Label lRespuesta3 = new Label();
        public Label lRespuesta4 = new Label();

        //Comboboxes para las respuestas. 

        public ComboBox cbRespuesta1 = new ComboBox();
        public ComboBox cbRespuesta2 = new ComboBox();
        public ComboBox cbRespuesta3 = new ComboBox();
        public ComboBox cbRespuesta4 = new ComboBox();

        public Alumno()
        {
            InitializeComponent();
        }

        public void muestraInicio() 
        {
            Label label1 = new Label();
            label1.Text = "Listado de Lecturas";
            label1.Location = new Point(120,29);
            label1.Size = new Size(100,13);
            panel1.Controls.Add(label1);

            
            lbLecturas.Location = new Point(32,55);
            lbLecturas.Size = new Size(323, 433);
            lbLecturas.SelectedIndexChanged += new EventHandler(lbLecturas_SelectedIndexChanged);
            panel1.Controls.Add(lbLecturas);

            btnSeleccionar.Location = new Point(733, 73);
            btnSeleccionar.Size = new Size(75, 23);
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.Click += new EventHandler(btnSeleccionar_Click);
            panel1.Controls.Add(btnSeleccionar);
        }

        public void llenarListBox() 
        {
            Consultas Query = new Consultas();
            DataTable listaLecturas = new DataTable();
            listaLecturas.Load(Query.recuperaLecturas());
            listaLecturas.PrimaryKey = new DataColumn[] { 
                listaLecturas.Columns["Id_Lectura"]
            };
            lbLecturas.DataSource = listaLecturas;
            lbLecturas.ValueMember = "Id_lectura";
            lbLecturas.DisplayMember = "Nom_Lectura";
        }
        public void llenaListBox2(int num) 
        {
            lbExamenes.Location = new Point(380, 55);
            lbExamenes.Size = new Size(341, 180);
            panel1.Controls.Add(lbExamenes);


            Consultas Query = new Consultas();
            DataTable listaExamenes = new DataTable();
            listaExamenes.Load(Query.recuperaExamen(numLectura));
            listaExamenes.PrimaryKey = new DataColumn[]{
                listaExamenes.Columns["Id_Examen"]
            };
            lbExamenes.DataSource = listaExamenes;
            lbExamenes.ValueMember = "Id_Examen";
            lbExamenes.DisplayMember = "Nom_Examen";

            Label label8 = new Label();
            label8.Location = new Point(405, 29);
            label8.Size = new Size(70, 13);
            label8.Text = "Elegir Prueba";
            panel1.Controls.Add(label8);
        }

        public void mensaje() {
            Label label2 = new Label();
            label2.Location = new Point(404, 273);
            label2.Size = new Size(205, 13);
            label2.Text = "1.- Estar comodo  y tranquilo en tu asiento";
            panel1.Controls.Add(label2);

            Label label3 = new Label();
            label3.Location = new Point(404, 302);
            label3.Size = new Size(247, 13);
            label3.Text = "2.- La lectura se inicia y detiene cuando tu decidas";
            panel1.Controls.Add(label3);

            Label label4 = new Label();
            label4.Location = new Point(404, 326);
            label4.Size = new Size(391, 13);
            label4.Text = "3.- Una vez detenida la lectura no puedes volver atrás y comienzan las preguntas";
            panel1.Controls.Add(label4);

            Label label5 = new Label();
            label5.Location = new Point(404, 351);
            label5.Size = new Size(188, 13);
            label5.Text = "4.- Concentrate en enteder lo que lees";
            panel1.Controls.Add(label5);

            Label label6 = new Label();
            label6.Location = new Point(404, 376);
            label6.Size = new Size(230, 13);
            label6.Text = "5.- Presionar el botón Comenzar y buena suerte";
            panel1.Controls.Add(label6);

            Label label7 = new Label();
            label7.Location = new Point(472,250);
            label7.Size = new Size(132, 31);
            label7.Text = "Recuerda";
            panel1.Controls.Add(label7);

            btnComenzar.Text = "Comenzar";
            btnComenzar.Location = new Point(422, 429);
            btnComenzar.Size = new Size(163, 41);
            btnComenzar.Click += new EventHandler(btnComenzar_Click);
            panel1.Controls.Add(btnComenzar);

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(628, 429);
            btnCancelar.Size = new Size(163, 41);
            panel1.Controls.Add(btnCancelar);
            
        }
   
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login win = new Login();
            win.Show();
            this.Close();
        }

        
        private void tiempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            lbCrono.Text = String.Format("{0}", cont);
            cont++;
        }

        private void btnLectura_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            muestraInicio();
            llenarListBox();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e) 
        {
            mensaje();
            numExamen = lbExamenes.SelectedIndex + 1;
            lbLecturas.Enabled = false;
            btnSeleccionar.Enabled = false;
            btnPruebas.Enabled = false;
            btnLectura.Enabled = false;
 
        }
        private void btnComenzar_Click(object sender, EventArgs e) 
        {
            panel1.Controls.Clear();
            numLectura = lbLecturas.SelectedIndex + 1;
            muestraLectura(numLectura);
            tiempo.Enabled = true;
            tiempo.Start();

        }
        private void btnDetener_Click(object sender, EventArgs e) 
        {
            panel1.Controls.Clear();
            tiempo.Enabled = false;
            tiempo.Stop();
            muestraPrueba();
            Consultas Query = new Consultas();
            DataTable listaPregunta = new DataTable();
            listaPregunta.Load(Query.recupera1Pregunta(numExamen));
            listaPregunta.PrimaryKey = new DataColumn[]{
                listaPregunta.Columns["Id_Pregunta"]
            };
            lPregunta1.Text = listaPregunta.Rows[1][1].ToString();
            lPregunta2.Text = listaPregunta.Rows[2][1].ToString();
            lPregunta3.Text = listaPregunta.Rows[3][1].ToString();
            lPregunta4.Text = listaPregunta.Rows[4][1].ToString();
        }
        private void lbLecturas_SelectedIndexChanged(object sender, EventArgs e)
        {

            numLectura = lbLecturas.SelectedIndex+1;
            llenaListBox2(numLectura);
        }
        private void lbExamenes_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            lectura = lbLecturas.SelectedItem.ToString();
        }

        public void muestraLectura(int num)
        {
            Consultas Query = new Consultas();
            DataTable listaLecturas = new DataTable();
            listaLecturas.Load(Query.recupera1Lectura(numLectura));
            listaLecturas.PrimaryKey = new DataColumn[] { 
                listaLecturas.Columns["Id_Lectura"]
            };
            string url;
            url = listaLecturas.Rows[0][3].ToString();
            

            btnDetener.Location = new Point(731, 43);
            btnDetener.Size = new Size(88, 79);
            btnDetener.Text = "Detener";
            btnDetener.Click += new EventHandler(btnDetener_Click);
            panel1.Controls.Add(btnDetener);

            rtbLectura.Location = new Point(17, 15);
            rtbLectura.Size = new Size(694, 489);
            rtbLectura.ReadOnly = true;
            rtbLectura.LoadFile(url);
            panel1.Controls.Add(rtbLectura);
        }

        public void muestraPrueba() 
        {
                   
            lPregunta1.Location = new Point(53, 29);
            lPregunta1.Size = new Size(235, 13);
            panel1.Controls.Add(lPregunta1);

            cbRespuesta1.Location = new Point(56, 59);
            cbRespuesta1.DropDownStyle = ComboBoxStyle.DropDownList;
            panel1.Controls.Add(cbRespuesta1);

            lRespuesta1.Location = new Point(62, 109);
            lRespuesta1.Size = new Size(115, 13);
            panel1.Controls.Add(lRespuesta1);

            lPregunta2.Location = new Point(472, 29);
            lPregunta2.Size = new Size(235,13);
            panel1.Controls.Add(lPregunta2);

            cbRespuesta2.Location = new Point(475, 59);
            cbRespuesta2.DropDownStyle = ComboBoxStyle.DropDownList;
            panel1.Controls.Add(cbRespuesta2);

            lRespuesta2.Location = new Point(80, 286);
            lRespuesta2.Size = new Size(115,13);
            panel1.Controls.Add(lRespuesta2);

            lPregunta3.Location = new Point(53, 178);
            lPregunta3.Size = new Size(235, 13);
            panel1.Controls.Add(lPregunta3);

            cbRespuesta3.Location = new Point(56, 227);
            cbRespuesta3.DropDownStyle = ComboBoxStyle.DropDownList;
            panel1.Controls.Add(cbRespuesta3);

            lRespuesta3.Location = new Point(80, 286);
            lRespuesta3.Size = new Size(115,13);
            panel1.Controls.Add(lRespuesta3);

            lPregunta4.Location = new Point(472, 178);
            lPregunta4.Size = new Size(235,13);
            panel1.Controls.Add(lPregunta4);

            cbRespuesta4.Location = new Point(475, 227);
            cbRespuesta4.DropDownStyle = ComboBoxStyle.DropDownList;
            panel1.Controls.Add(cbRespuesta4);

            btnTerminar.Location = new Point(263, 386);
            btnTerminar.Size = new Size(221, 72);
            btnTerminar.Text = "Terminar";
            panel1.Controls.Add(btnTerminar);

            


 
        }

        private void Alumno_Load(object sender, EventArgs e)
        {
            Modulo digito = new Modulo();
            variable.miEvento += new Login.delegadoUsuario(ObtieneID);
            //label8.Text = variable.idAlumno.ToString();

        }
        void ObtieneID(string mensaje)
        {
            //label8.Text = mensaje;

        }


     }
}
