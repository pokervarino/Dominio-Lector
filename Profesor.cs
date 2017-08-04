using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Dominio_Lector
{
    
    public partial class Profesor : Form
    {
        //Creacion Elementos
        public TextBox txtBusqueda = new TextBox();
        public TextBox txtLetras = new TextBox();
        public string nombreArch;
        public string nombreDir;
        public RadioButton rButton3 = new RadioButton();
        public RadioButton rButton1 = new RadioButton();
        public ComboBox cbNivel = new ComboBox();
        public TextBox txtNomLectura = new TextBox();
        public TextBox txtDescripcion = new TextBox();
        public DataGridView dgrilla = new DataGridView();
        public ListBox lbLecturas1 = new ListBox();
        public ListBox lbLecturas2 = new ListBox();
        public Button btnMoverIzq = new Button();
        public string destinoArchivo;
        public Button btnMoverDer = new Button();
        public Button btnAgregaPrueba = new Button();
        // Creacion de los elementos de la primera pregunta y respuesta de la prueba.
        public TextBox txtPregunta1 = new TextBox();
        public TextBox txtRespA1 = new TextBox();
        public ComboBox cbRespCorrecta1 = new ComboBox();
        // Creacion de los elementos de la segunda pregunta y respuesta de la prueba.
        public TextBox txtPregunta2 = new TextBox();
        public Random r = new Random(DateTime.Now.Millisecond);
        public TextBox txtRespA2 = new TextBox();
        public ComboBox cbRespCorrecta2 = new ComboBox();
        // Creacion de los elementos de la tercera pregunta y respuesta de la prueba.
        public TextBox txtPregunta3 = new TextBox();
        public TextBox txtRespA3 = new TextBox();
        public ComboBox cbRespCorrecta3 = new ComboBox();
        // Creacion de los elementos de la cuarta pregunta y respuesta de la prueba
        public TextBox txtPregunta4 = new TextBox();
        public TextBox txtRespA4 = new TextBox();
        public ComboBox cbRespCorrecta4 = new ComboBox();
        //Creacion de los elementos con los datos de la prueba info general. 
        public TextBox txtNPrueba = new TextBox();
        public TextBox txtDesPrueba = new TextBox();
        public ComboBox cbLectura = new ComboBox();
        public Label label16 = new Label();
        public string s;
        public int count;
        public int i;
        public int aleat;
        public Label label33 = new Label();
        public Label label26 = new Label();
        public Label label22 = new Label();

        // Experimento 

        public Button btnLlenaCombo = new Button();
        public Button btnLlenaCombo1 = new Button();
        public Button btnLlenaCombo2 = new Button();
        public Button btnLlenaCombo3 = new Button();
        public Button btnEligePrueba = new Button();

        // Experimento 2 

        public Button btnPregunta1 = new Button();
        public Button btnPregunta2 = new Button();
        public Button btnPregunta3 = new Button();
        public Button btnPregunta4 = new Button();

        //  Contadores 

        public string rcorrecta1;
        public string rcorrecta2;
        public string rcorrecta3;
        public string rcorrecta4;

          
        public Profesor()
        {
            InitializeComponent();
        }


        protected void btnExaminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            OpenFileDialog oFD = new OpenFileDialog();
            oFD.FileName = txtBusqueda.Text;
            oFD.Filter = "RTF FILES (*.rtf)|*.rtf|txt files (*.TXT)|*.TXT|Todos los documentos Word (*.doc)|*.doc|All Files (*.*)|(*.*)";
            oFD.FilterIndex = 2;
            oFD.Title = "Selecciona el Archivo";

            if(oFD.ShowDialog() == DialogResult.OK)
            {
                txtBusqueda.Text = oFD.FileName;
                
                s = oFD.FileName;
                string sFic = s;
                nombreArch= Path.GetFileName(s);
                nombreDir = Path.GetDirectoryName(s);

                StreamReader sr = new StreamReader(sFic, System.Text.Encoding.Default);

                s = sr.ReadLine();
                while (sr.Peek() != -1) 
                {
                    s = sr.ReadLine().Trim();
                    if (s.Length > 0) 
                    {
                        string cadena = s;
                        s = sr.ReadLine();
                        contarPalabras(cadena);
                    }
                    else
                    {
                        sr.ReadLine();
                    }
                }
                sr.Close();

                MessageBox.Show("numero" + count);
                              
            }
        }

        // Funcion que me crea los Elementos, para el boton de cargar Elementos y selección de la Lectura. 
        public void creaElementos() 
        {
            //Creacion del GroupBox para contener info de examinar y cargar
            GroupBox gbCuadro = new GroupBox();
            gbCuadro.FlatStyle = FlatStyle.Flat;
            gbCuadro.Location = new Point(15, 22);
            gbCuadro.Size = new Size(275, 100);
            panel1.Controls.Add(gbCuadro);

            //Segunod groupbox que tendrá info de la lectura recien cargada. 
            GroupBox gbCuadro2 = new GroupBox();
            gbCuadro2.FlatStyle = FlatStyle.Flat;
            gbCuadro2.Location = new Point(15, 130);
            gbCuadro2.Size = new Size(275, 315);
            panel1.Controls.Add(gbCuadro2);

            Label label1 = new Label();
            label1.Text = "Nombre Lectura";
            label1.Location = new Point(15, 18);
            label1.Size = new Size(83, 13);
            gbCuadro2.Controls.Add(label1);

            //Textbox donde se ingresa el nombre de la lectura recién cargada. 
            txtNomLectura.Location = new Point(115, 15);
            txtNomLectura.Size = new Size(145, 50);
            gbCuadro2.Controls.Add(txtNomLectura);

            Label label6 = new Label();
            label6.Text = "Descripción";
            label6.Location = new Point(15, 48);
            label6.Size = new Size(63, 13);
            gbCuadro2.Controls.Add(label6);

            //Textbox donde se ingresa una descripción de la lectura
            txtDescripcion.Location = new Point(115, 45);
            txtDescripcion.Size = new Size(145, 70);
            txtDescripcion.Multiline = true;
            gbCuadro2.Controls.Add(txtDescripcion);

            Label label7 = new Label();
            label7.Text = "N° de Palabras";
            label7.Location = new Point(15, 123);
            label7.Size = new Size(78, 13);
            gbCuadro2.Controls.Add(label7);

            //Textbox que mostrará el número de palabras del texto cargado.
            txtLetras.Location = new Point(115, 120);
            txtLetras.Size = new Size(145, 50);
            gbCuadro2.Controls.Add(txtLetras);

            //ComboBox, que mostrar el nivel al cual estará relacionado la lectura
            cbNivel.Location = new Point(115, 150);
            cbNivel.Size = new Size(145, 70);
            cbNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNivel.Items.Add("Nivel I");
            cbNivel.Items.Add("Nivel II");
            cbNivel.Items.Add("Nivel III");
            gbCuadro2.Controls.Add(cbNivel);

            Label label8 = new Label();
            label8.Text = "Nivel de Lectura";
            label8.Location = new Point(15, 153);
            label8.Size = new Size(85, 13);
            gbCuadro2.Controls.Add(label8);

            //Creacion del Button Agregar y Limpiar

            Button btnGrabarLectura = new Button();
            btnGrabarLectura.Text = "Grabar";
            btnGrabarLectura.Location = new Point(15, 190);
            btnGrabarLectura.Click += new EventHandler(btnGrabarLectura_Click);
            gbCuadro2.Controls.Add(btnGrabarLectura);

            //Creacion del Button Examinar, y definicion de posicion
            Button btnExaminar = new Button();
            btnExaminar.Text = "Examinar";
            btnExaminar.Click += new EventHandler(btnExaminar_Click);
            btnExaminar.Location = new Point(195, 22);
            gbCuadro.Controls.Add(btnExaminar);

            //Creacion del Button Agregar y definicion de Posicion
            Button btnAgregar = new Button();
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += new EventHandler(btnAgregar_Click);
            btnAgregar.Location = new Point(10, 50);
            gbCuadro.Controls.Add(btnAgregar);

            //Creacion del TextBox Busqueda, posicion y tamaño
            txtBusqueda.Location = new Point(10, 22);
            txtBusqueda.Size = new Size(180, 50);
            //txtBusqueda.Click += new EventHandler(btnExaminar_Click);
            gbCuadro.Controls.Add(txtBusqueda);

            //Creacion del DataGridView
            
            BindingSource bsMain = new BindingSource();
            dgrilla.Dock = DockStyle.Fill;
            dgrilla.Location = new Point(385, 28);
            dgrilla.Size = new Size(550, 380);

            //Creación del Contenedor y mostrar DataGrid
            Panel pContenedor = new Panel();
            pContenedor.Size = new Size(550, 380);
            pContenedor.Controls.Add(dgrilla);
            pContenedor.Location = new Point(295, 24);
            panel1.Controls.Add(pContenedor);
        }
        
        protected void btnAgregar_Click(object sender, EventArgs e) 
        {
            aleat = r.Next(1060, 1490);
            copiarArchivo(nombreArch,nombreDir);
            txtLetras.Text = aleat.ToString();
            
        }

        public void quitaElementos() 
        {
            //panel1.CreateGraphics().Clear(Color.Blue);
            panel1.Controls.Clear();
        }

        public void diseñaPrueba() 
        {
            GroupBox gbCuadro4 = new GroupBox();
            gbCuadro4.Size = new Size(300, 430);
            gbCuadro4.Location = new Point(7, 3);
            panel1.Controls.Add(gbCuadro4);

            Label label1 = new Label();
            label1.Text = "Nombre Prueba";
            label1.Location = new Point(20, 20);
            gbCuadro4.Controls.Add(label1);

            txtNPrueba.Location = new Point(140, 20);
            txtNPrueba.Size = new Size(121, 20);
            gbCuadro4.Controls.Add(txtNPrueba);

            Label label2 = new Label();
            label2.Text = "Descripción";
            label2.Location = new Point(20, 45);
            gbCuadro4.Controls.Add(label2);
            
            txtDesPrueba.Location = new Point(140, 45);
            txtDesPrueba.Multiline = true;
            txtDesPrueba.Size = new Size(121, 60);
            gbCuadro4.Controls.Add(txtDesPrueba);

            Label label3 = new Label();
            label3.Text = "Elegir Lectura";
            label3.Location = new Point(20, 110);
            gbCuadro4.Controls.Add(label3);

            //Creacion del ComboBox en la sección de la creación de Pruebas
            //Mostrará las pruebas disponibles, con la cual se relacionará la prueba ha crear. 
            cbLectura.Location = new Point(140, 110);
            cbLectura.DropDownStyle = ComboBoxStyle.DropDownList;
            gbCuadro4.Controls.Add(cbLectura);

            Label label4 = new Label();
            label4.Text = "Tipo de Prueba";
            label4.Location = new Point(20, 150);
            gbCuadro4.Controls.Add(label4);

            GroupBox gbCuadro3 = new GroupBox();
            gbCuadro3.FlatStyle = FlatStyle.Flat;
            gbCuadro3.Location = new Point(140, 140);
            gbCuadro3.Size = new Size(130, 70);
            gbCuadro4.Controls.Add(gbCuadro3);

            rButton1.Text = "Selección Múltiple";
            rButton1.Location = new Point(5, 15);
            rButton1.Size = new Size(111, 17);
            rButton1.AutoCheck = true;
            //rButton1.CheckedChanged += new EventHandler(rButton1_CheckedChanged);
            gbCuadro3.Controls.Add(rButton1);

            rButton3.Text = "Verdadero o Falso";
            rButton3.Location = new Point(5, 45);
            rButton3.Size = new Size(111, 17);
            rButton3.AutoCheck = true;
            gbCuadro3.Controls.Add(rButton3);

            btnEligePrueba.Text = "Crear";
            btnEligePrueba.Location = new Point(103, 368);
            btnEligePrueba.Click += new EventHandler(btnEligePrueba_Click);
            gbCuadro4.Controls.Add(btnEligePrueba);
           


        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login win = new Login();
            win.Show();
            this.Close();
        }

        public void alumno() 
        {
            Label label6 = new Label();
            label6.Text = "Desde";
            label6.Location = new Point(14, 18);
            label6.Size = new Size(38, 13);
            panel1.Controls.Add(label6);

            DateTimePicker calendario = new DateTimePicker();
            calendario.Location = new Point(70, 14);
            panel1.Controls.Add(calendario);

            Label label7 = new Label();
            label7.Text = "Hasta";
            label7.Location = new Point(279, 18);
            label7.Size = new Size(38, 13);
            panel1.Controls.Add(label7);

            DateTimePicker calendario2 = new DateTimePicker();
            calendario2.Location = new Point(320, 14);
            panel1.Controls.Add(calendario2);

            TextBox txtBusqueda = new TextBox();
            txtBusqueda.Location = new Point(584, 17);
            txtBusqueda.Size = new Size(121,20);

            panel1.Controls.Add(txtBusqueda);

            Button btnBusqueda = new Button();
            btnBusqueda.Text = "Buscar";
            btnBusqueda.Location = new Point(720,15);
            panel1.Controls.Add(btnBusqueda);

            Label label8 = new Label();
            label8.Text = "Por Lectura";
            label8.Location = new Point(14,53);
            label8.Size = new Size(62,13);
            panel1.Controls.Add(label8);

            ComboBox cbPorLectura = new ComboBox();
            cbPorLectura.Location = new Point(82,50);
            cbPorLectura.DropDownStyle = ComboBoxStyle.DropDownList;
            panel1.Controls.Add(cbPorLectura);

            Label label9 = new Label();
            label9.Text = "Por Nivel";
            label9.Location = new Point(14, 53);
            label9.Size = new Size(62, 13);
            panel1.Controls.Add(label9);

            ComboBox cbPorNivel = new ComboBox();
            cbPorNivel.Location = new Point(320, 50);
            cbPorNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            panel1.Controls.Add(cbPorNivel);

            Label label10 = new Label();
            label10.Text = "Por Resultado";
            label10.Location = new Point(504, 58);
            label10.Size = new Size(74, 13);
            panel1.Controls.Add(label10);

            ComboBox cbPorResultado = new ComboBox();
            cbPorResultado.Location = new Point(584, 50);
            cbPorResultado.DropDownStyle = ComboBoxStyle.DropDownList;
            panel1.Controls.Add(cbPorResultado);
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            quitaElementos();
            alumno();
        }

        public void Lecturas() 
        {
            
            lbLecturas1.Size = new Size(284, 355);
            lbLecturas1.Location = new Point(68, 42);
            panel1.Controls.Add(lbLecturas1);

            
            lbLecturas2.Size = new Size(284, 355);
            lbLecturas2.Location = new Point(412, 42);
            panel1.Controls.Add(lbLecturas2);

            //Button que mueve el elemento seleccionado en el Listbox 
            //hacia la derecha
            btnMoverIzq.Text = " > ";
            btnMoverIzq.Location = new Point(358, 43);
            btnMoverIzq.Size = new Size(48,42);
            btnMoverIzq.Click += new EventHandler(btnMoverIzq_Click);
            panel1.Controls.Add(btnMoverIzq);

            
            //Button que mueve el elemento seleccionado del listbox
            //hacia la izquierda
            btnMoverDer.Text = " < ";
            btnMoverDer.Location = new Point(358,121);
            btnMoverDer.Size = new Size(48, 42);
            btnMoverDer.Click += new EventHandler(btnMoverDer_Click);
            panel1.Controls.Add(btnMoverDer);

            Button btnAgregaTodo = new Button();
            btnAgregaTodo.Text = " >> ";
            btnAgregaTodo.Location = new Point(358,168);
            btnAgregaTodo.Size = new Size(48,42);
            panel1.Controls.Add(btnAgregaTodo);

            Button btnQuitaTodo = new Button();
            btnQuitaTodo.Text = " << ";
            btnQuitaTodo.Location = new Point(358,215);
            btnQuitaTodo.Size = new Size(48,42);
            panel1.Controls.Add(btnQuitaTodo);

            Button btnActualiza = new Button();
            btnActualiza.Text = "Actualizar";
            btnActualiza.Location = new Point(736,73);
            btnActualiza.Size = new Size(75, 23);
            panel1.Controls.Add(btnActualiza);
        }

        private void btnLecturas_Click(object sender, EventArgs e)
        {
            quitaElementos();
            Lecturas();
            llenaListBoxIzq();
            llenaListBoxDer();
        }

        public void copiarArchivo(string nombre, string origen) 
        {
            string nombreArchivo = nombre;
            string dirOrigen = origen;
            string dirDestino = @"D:\Development\C#Programs\Dominio Lector\";

            
            try
            {
                string origenArchivo = System.IO.Path.Combine(dirOrigen, nombreArchivo);
                destinoArchivo = System.IO.Path.Combine(dirDestino, nombreArchivo);
                if (!Directory.Exists(dirDestino))
                {
                    Directory.CreateDirectory(dirDestino);
                }
                File.Copy(origenArchivo, destinoArchivo, true );

                MessageBox.Show("Se ha cargado el archivo con exito");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Se ha producido un error" + ex.Message);
            }
            
        }

        private void btnCrearPrueba_Click(object sender, EventArgs e)
        {
            quitaElementos();
            diseñaPrueba();
            llenaCbLectura();
        }

        private void btnCargar1_Click(object sender, EventArgs e)
        {
            quitaElementos();
            creaElementos();
            actulizaGrilla();
        }

        public void tipoPrueba() 
        {
            if (rButton1.Checked)
            {
                GroupBox gbCuadro4 = new GroupBox();
                gbCuadro4.FlatStyle = FlatStyle.Flat;
                gbCuadro4.Location = new Point(323, 3);
                gbCuadro4.Size = new Size(562, 430);
                panel1.Controls.Add(gbCuadro4);

                Label label11 = new Label();
                label11.Location = new Point(10,35);
                label11.Size = new Size(74,13);
                label11.Text = "Pregunta N° 1";
                gbCuadro4.Controls.Add(label11);

                txtPregunta1.Location = new Point(110, 32);
                txtPregunta1.Size = new Size(306, 20);
                gbCuadro4.Controls.Add(txtPregunta1);

                btnPregunta1.Location = new Point(444, 32);
                btnPregunta1.Text = "Guardar";
                btnPregunta1.Click += new EventHandler(btnPregunta1_Click);
                gbCuadro4.Controls.Add(btnPregunta1);

                Label label12 = new Label();
                label12.Location = new Point(10,61);
                label12.Size = new Size(101,13);
                label12.Text = "Ingrese Respuestas";
                gbCuadro4.Controls.Add(label12);
                //Textbox de respuesta para la pregunta N°1.
                txtRespA1.Location = new Point(110,58);
                txtRespA1.Size = new Size(142, 20);
                txtRespA1.Enabled = false;
                gbCuadro4.Controls.Add(txtRespA1);
                //Boton para llenar el primer combobox de respuestas.
                btnLlenaCombo.Location = new Point(283,58);
                btnLlenaCombo.Text = "Agrega Respuesta";
                btnLlenaCombo.Enabled = false;
                btnLlenaCombo.Click += new EventHandler(btnLlenaCombo_Click);
                gbCuadro4.Controls.Add(btnLlenaCombo);
      
                label16.Location = new Point(444, 32);
                label16.Size = new Size(101, 13);
                label16.Text = "Respuesta Correcta";
                label16.Visible = false;
                gbCuadro4.Controls.Add(label16);
                                
                cbRespCorrecta1.Location = new Point(435, 58);
                cbRespCorrecta1.Size = new Size(121, 21);
                cbRespCorrecta1.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRespCorrecta1.Visible = false;
                cbRespCorrecta1.SelectedIndexChanged += new EventHandler(cbRespCorrecta1_SelectedIndexChanged);
                gbCuadro4.Controls.Add(cbRespCorrecta1);

                Label label17 = new Label();
                label17.Location = new Point(10, 121);
                label17.Size = new Size(74, 13);
                label17.Text = "Pregunta N° 2";
                gbCuadro4.Controls.Add(label17);

                txtPregunta2.Location = new Point(110, 118);
                txtPregunta2.Size = new Size(306, 20);
                gbCuadro4.Controls.Add(txtPregunta2);

                btnPregunta2.Text = "Guardar";
                btnPregunta2.Location = new Point(444,118);
                btnPregunta2.Click += new EventHandler(btnPregunta2_Click);
                gbCuadro4.Controls.Add(btnPregunta2);

                Label label18 = new Label();
                label18.Location = new Point(10, 147);
                label18.Size = new Size(101, 13);
                label18.Text = "Ingrese Respuestas";
                gbCuadro4.Controls.Add(label18);

                txtRespA2.Location = new Point(110, 144);
                txtRespA2.Size = new Size(142, 20);
                txtRespA2.Enabled = false;
                gbCuadro4.Controls.Add(txtRespA2);

                btnLlenaCombo1.Location = new Point(283, 144);
                btnLlenaCombo1.Text = "Agregar";
                btnLlenaCombo1.Click += new EventHandler(btnLlenaCombo1_Click);
                btnLlenaCombo1.Enabled = false;
                gbCuadro4.Controls.Add(btnLlenaCombo1);

                label22.Location = new Point(444, 118);
                label22.Size = new Size(101, 13);
                label22.Visible = false;
                label22.Text = "Respuesta Correcta";
                gbCuadro4.Controls.Add(label22);

                cbRespCorrecta2.Location = new Point(435, 144);
                cbRespCorrecta2.Size = new Size(121, 21);
                cbRespCorrecta2.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRespCorrecta2.Visible = false;
                cbRespCorrecta2.SelectedIndexChanged += new EventHandler(cbRespCorrecta2_SelectedIndexChanged);
                gbCuadro4.Controls.Add(cbRespCorrecta2);

                Label label27 = new Label();
                label27.Location = new Point(15, 210);
                label27.Size = new Size(74, 13);
                label27.Text = "Pregunta N° 3";
                gbCuadro4.Controls.Add(label27);

                txtPregunta3.Location = new Point(110, 207);
                txtPregunta3.Size = new Size(306, 20);
                gbCuadro4.Controls.Add(txtPregunta3);

                Label label23 = new Label();
                label23.Location = new Point(10, 236);
                label23.Size = new Size(101, 13);
                label23.Text = "Ingrese Respuesta";
                gbCuadro4.Controls.Add(label23);

                txtRespA3.Location = new Point(110, 233);
                txtRespA3.Size = new Size(142, 20);
                txtRespA3.Enabled = false;
                gbCuadro4.Controls.Add(txtRespA3);

                btnPregunta3.Text = "Guardar";
                btnPregunta3.Location = new Point(444,207);
                btnPregunta3.Click += new EventHandler(btnPregunta3_Click);
                gbCuadro4.Controls.Add(btnPregunta3);

                label26.Location = new Point(444, 207);
                label26.Size = new Size(101, 13);
                label26.Visible = false;
                label26.Text = "Respuesta Correcta";
                gbCuadro4.Controls.Add(label26);

                btnLlenaCombo2.Location = new Point(283, 233);
                btnLlenaCombo2.Text = "Agrega Respuesta";
                btnLlenaCombo2.Click += new EventHandler(btnLlenaCombo2_Click);
                btnLlenaCombo2.Enabled = false;
                gbCuadro4.Controls.Add(btnLlenaCombo2);

                cbRespCorrecta3.Location = new Point(435, 233);
                cbRespCorrecta3.Size = new Size(121, 21);
                cbRespCorrecta3.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRespCorrecta3.Visible = false;
                cbRespCorrecta3.SelectedIndexChanged += new EventHandler(cbRespCorrecta3_SelectedIndexChanged);
                gbCuadro4.Controls.Add(cbRespCorrecta3);

                ////Comienzo Pregunta 4 con sus elementos

                txtPregunta4.Location = new Point(110, 293);
                txtPregunta4.Size = new Size(306, 20);
                gbCuadro4.Controls.Add(txtPregunta4);

                Label label28 = new Label();
                label28.Location = new Point(15, 296);
                label28.Size = new Size(74, 13);
                label28.Text = "Pregunta N° 4";
                gbCuadro4.Controls.Add(label28);

                Label label29 = new Label();
                label29.Location = new Point(10, 322);
                label29.Size = new Size(101, 13);
                label29.Text = "Ingrese Respuesta";
                gbCuadro4.Controls.Add(label29);

                txtRespA4.Location = new Point(110, 319);
                txtRespA4.Size = new Size(142, 20);
                txtRespA4.Enabled = false;
                gbCuadro4.Controls.Add(txtRespA4);

                btnLlenaCombo3.Location = new Point(283, 319);
                btnLlenaCombo3.Text = "Agrega Respuesta";
                btnLlenaCombo3.Click += new EventHandler(btnLlenaCombo3_Click);
                btnLlenaCombo3.Enabled = false;
                gbCuadro4.Controls.Add(btnLlenaCombo3);

                btnPregunta4.Text = "Guardar";
                btnPregunta4.Location = new Point(444, 293);
                btnPregunta4.Click += new EventHandler(btnPregunta4_Click);
                gbCuadro4.Controls.Add(btnPregunta4);

                label33.Location = new Point(444, 293);
                label33.Size = new Size(101, 13);
                label33.Text = "Respuesta Correcta";
                label33.Visible = false;
                gbCuadro4.Controls.Add(label33);

                cbRespCorrecta4.Location = new Point(435, 319);
                cbRespCorrecta4.Size = new Size(121, 21);
                cbRespCorrecta4.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRespCorrecta4.Visible = false;
                cbRespCorrecta4.SelectedIndexChanged += new EventHandler(cbRespCorrecta4_SelectedIndexChanged);
                gbCuadro4.Controls.Add(cbRespCorrecta4);

                //Creacion de Botones de Agregar y Limpiar 
                //Button Crear Prueba, envia la info ingresada a la base de datos, 
                //Para contener la información de la prueba. 
                btnAgregaPrueba.Size = new Size(106, 23);
                btnAgregaPrueba.Location = new Point(130, 396);
                btnAgregaPrueba.Text = "Guardar Prueba";
                btnAgregaPrueba.Click += new EventHandler(btnAgregaPrueba_Click);
                gbCuadro4.Controls.Add(btnAgregaPrueba);

                Button btnLimpiar = new Button();
                btnLimpiar.Size = new Size(106, 23);
                btnLimpiar.Location = new Point(302, 396);
                btnLimpiar.Text = "Limpiar";
                gbCuadro4.Controls.Add(btnLimpiar);              
            }
            else 
            { }
        }
        private void btnAgregaPrueba_Click(object sender, EventArgs e)
        {
            try {
                Consultas Query = new Consultas();
                string respuestaModificacion1 = Query.actualizaEstadoRspta(rcorrecta1);
                string respuestaModificacion2 = Query.actualizaEstadoRspta(rcorrecta2);
                string respuestaModificacion3 = Query.actualizaEstadoRspta(rcorrecta3);
                string respuestaModificacion4 = Query.actualizaEstadoRspta(rcorrecta4);

            }
            catch (Exception ex) {
                MessageBox.Show("Se ha producido un error" + ex);
            }
        }
        private void btnEligePrueba_Click(object sender, EventArgs e)
        {
            Consultas Query = new Consultas();
            string indice = cbLectura.SelectedIndex + 1.ToString();
            string respuestaInsert = Query.creaPrueba(txtNPrueba.Text, txtDesPrueba.Text, cbLectura.SelectedIndex + 1, cbLectura.SelectedIndex + 1);
            MessageBox.Show("Agregue las preguntas");
            tipoPrueba();
        }
        private void btnGrabarLectura_Click(object sender, EventArgs e) 
        {
            try
            {
                Consultas Query = new Consultas();
                string nivel = cbNivel.SelectedIndex + 1.ToString();
                int estado = 0;
                string respuestaInsert = Query.ingresaLectura(txtNomLectura.Text, txtDescripcion.Text, int.Parse(nivel), int.Parse(txtLetras.Text), destinoArchivo, estado);
                MessageBox.Show("Se ha agregado correctamente");
                actulizaGrilla();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Se ha producido un error" + ex);
            }
            
        }

        private void contarPalabras(string sText)
        {
            // Desglosar en palabras individuales el contenido del parámetro
            //
            // Estos signos se considerarán separadores de palabras
            string sSep = @".,;: ()<>[]{}¿?¡!/\'=+*-%&$|#@" + "\"\t\n\r";
            // crear un array con cada una de las palabras
            string[] palabras = sText.Split(sSep.ToCharArray());
            int i;
            //
            for (i = 0; i <= palabras.Length - 1; i++)
            {
                string s = palabras[i];
                // sólo si no es una cadena vacía
                if (s != "")
                {
                    count++;
                }
            }

        }

        public void actulizaGrilla() 
        {
            Consultas Query1 = new Consultas();
            DataTable listaLecturas = new DataTable();
            listaLecturas.Load(Query1.recuperaLecturas());
            listaLecturas.PrimaryKey = new DataColumn[] {
                    listaLecturas.Columns["Id_Lectura"]
                };
            dgrilla.DataSource = listaLecturas;
            dgrilla.Refresh();
        }

        public void llenaListBoxIzq() 
        {
            Consultas Query = new Consultas();
            DataTable listaLecturas = new DataTable();
            listaLecturas.Load(Query.recuperaLecturasNo());
            listaLecturas.PrimaryKey = new DataColumn[] { 
                listaLecturas.Columns["Id_Lectura"]
            };
            lbLecturas1.DataSource = listaLecturas;
            lbLecturas1.ValueMember = "Nom_Lectura";
            
        }
        public void llenaListBoxDer() 
        {
            Consultas Query = new Consultas();
            DataTable listaLecturas = new DataTable();
            listaLecturas.Load(Query.recuperaLecturasSi());
            listaLecturas.PrimaryKey = new DataColumn[] { 
                listaLecturas.Columns["Id_Lectura"]
            };
            lbLecturas2.DataSource = listaLecturas;
            lbLecturas2.ValueMember = "Nom_Lectura";
        }
        private void btnMoverIzq_Click(object sender, EventArgs e) 
        {
            Consultas Query2 = new Consultas();
            int indice;
            indice = lbLecturas1.SelectedIndex + 1;
            string respuestaInsert = Query2.actualizaEstado1(indice);
        }
        private void btnMoverDer_Click(object sender, EventArgs e) {
            Consultas Query2 = new Consultas();
            int indice;
            indice = lbLecturas2.SelectedIndex + 1;
            string respuestaInsert = Query2.actualizaEstado2(indice);
        }

        public void llenaCbLectura() 
        {
            Consultas Query = new Consultas();
            DataTable listaLecturas = new DataTable();
            listaLecturas.Load(Query.recuperaLecturas());
            listaLecturas.PrimaryKey = new DataColumn[] { listaLecturas.Columns["Id_Lectura"]
            };
            cbLectura.DataSource = listaLecturas;
            cbLectura.ValueMember = "Nom_Lectura";
        }
        private void btnLlenaCombo_Click(object sender, EventArgs e) 
        {
            Consultas Query = new Consultas();
            DataTable listaPreguntas = new DataTable();
            listaPreguntas.Load(Query.recuperaPreguntas());
            listaPreguntas.PrimaryKey = new DataColumn[] { listaPreguntas.Columns["Id_Pregunta"]};
            int codigo;
            codigo = listaPreguntas.Rows.Count;

            Consultas Query1 = new Consultas();
            int estado = 0;
            string respuestaInsert = Query1.agregaRespuesta(txtRespA1.Text, estado, codigo);
            cbRespCorrecta1.Items.Add(txtRespA1.Text);
            label16.Visible = true;
             cbRespCorrecta1.Visible = true;
             btnPregunta1.Visible = false;
           
        }
        private void btnLlenaCombo1_Click(object sender, EventArgs e) 
        {
            Consultas Query = new Consultas();
            DataTable listaPreguntas = new DataTable();
            listaPreguntas.Load(Query.recuperaPreguntas());
            listaPreguntas.PrimaryKey = new DataColumn[] { listaPreguntas.Columns["Id_Pregunta"] };
            int codigo;
            codigo = listaPreguntas.Rows.Count;

            Consultas Query1 = new Consultas();
            int estado = 0;
            string respuestaInsert = Query1.agregaRespuesta(txtRespA2.Text, estado, codigo);
            cbRespCorrecta2.Items.Add(txtRespA2.Text);
            label22.Visible = true;
            cbRespCorrecta2.Visible = true;
            btnPregunta2.Visible = false;
           
        }
        private void btnLlenaCombo2_Click(object sender, EventArgs e) {
            Consultas Query = new Consultas();
            DataTable listaPreguntas = new DataTable();
            listaPreguntas.Load(Query.recuperaPreguntas());
            listaPreguntas.PrimaryKey = new DataColumn[] { listaPreguntas.Columns["Id_Pregunta"] };
            int codigo;
            codigo = listaPreguntas.Rows.Count;

            Consultas Query1 = new Consultas();
            int estado = 0;
            string respuestaInsert = Query1.agregaRespuesta(txtRespA3.Text, estado, codigo);
            cbRespCorrecta3.Items.Add(txtRespA3.Text);
            label26.Visible = true;
            cbRespCorrecta3.Visible = true;
            btnPregunta3.Visible = false;
        }
        private void btnLlenaCombo3_Click(object sender, EventArgs e) {
            Consultas Query = new Consultas();
            DataTable listaPreguntas = new DataTable();
            listaPreguntas.Load(Query.recuperaPreguntas());
            listaPreguntas.PrimaryKey = new DataColumn[] { listaPreguntas.Columns["Id_Pregunta"] };
            int codigo;
            codigo = listaPreguntas.Rows.Count;

            Consultas Query1 = new Consultas();
            int estado = 0;
            string respuestaInsert = Query1.agregaRespuesta(txtRespA4.Text, estado, codigo);
            cbRespCorrecta4.Items.Add(txtRespA4.Text);
            label33.Visible = true;
            cbRespCorrecta4.Visible = true;
            btnPregunta4.Visible = false;
        }
        private void btnPregunta1_Click(object sender, EventArgs e) 
        {
            Consultas Query1 = new Consultas();
            DataTable listaExamenes = new DataTable();
            listaExamenes.Load(Query1.recuperaExamenes());
            listaExamenes.PrimaryKey = new DataColumn[] {
                listaExamenes.Columns["Id_Examen"]
            };
            int codigo;
            codigo = listaExamenes.Rows.Count;
            Consultas Query = new Consultas();
            string respuestaInsert = Query.agregaPreguntas(txtPregunta1.Text, codigo);
            txtRespA1.Enabled = true;
            btnLlenaCombo.Enabled = true;
 
        }
        private void btnPregunta2_Click(object sender, EventArgs e) 
        {
            Consultas Query1 = new Consultas();
            DataTable listaExamenes = new DataTable();
            listaExamenes.Load(Query1.recuperaExamenes());
            listaExamenes.PrimaryKey = new DataColumn[] {
                listaExamenes.Columns["Id_Examen"]
            };
            int codigo;
            codigo = listaExamenes.Rows.Count;
            Consultas Query = new Consultas();
            string respuestaInsert = Query.agregaPreguntas(txtPregunta2.Text, codigo);
            txtRespA2.Enabled = true;
            btnLlenaCombo1.Enabled = true;
            
 
        }
        private void btnPregunta3_Click(object sender, EventArgs e) {
            Consultas Query1 = new Consultas();
            DataTable listaExamenes = new DataTable();
            listaExamenes.Load(Query1.recuperaExamenes());
            listaExamenes.PrimaryKey = new DataColumn[] {
                listaExamenes.Columns["Id_Examen"]
            };
            int codigo;
            codigo = listaExamenes.Rows.Count;
            string respuestaInsert = Query1.agregaPreguntas(txtPregunta3.Text, codigo);
            txtRespA3.Enabled = true;
            btnLlenaCombo2.Enabled = true;
            
        }

        private void btnPregunta4_Click(object sender, EventArgs e) {
            Consultas Query1 = new Consultas();
            DataTable listaExamenes = new DataTable();
            listaExamenes.Load(Query1.recuperaExamenes());
            listaExamenes.PrimaryKey = new DataColumn[] {
                listaExamenes.Columns["Id_Examen"]
            };
            Consultas Query = new Consultas();
            int codigo;
            codigo = listaExamenes.Rows.Count;
            string respuestaInsert = Query.agregaPreguntas(txtPregunta4.Text, codigo);
            txtRespA3.Enabled = true;
            btnLlenaCombo3.Enabled = true; 
        }

        private void cbRespCorrecta1_SelectedIndexChanged(object sender, EventArgs e) {
            rcorrecta1 = cbRespCorrecta1.SelectedItem.ToString();
        }
        private void cbRespCorrecta2_SelectedIndexChanged(object sender, EventArgs e) {

            rcorrecta2 = cbRespCorrecta2.SelectedItem.ToString();

        }
        private void cbRespCorrecta3_SelectedIndexChanged(object sender, EventArgs e) {
            rcorrecta3 = cbRespCorrecta3.SelectedItem.ToString();
        }
        private void cbRespCorrecta4_SelectedIndexChanged(object sender, EventArgs e) {

            rcorrecta4 = cbRespCorrecta4.SelectedItem.ToString();
            
        }



    }
}