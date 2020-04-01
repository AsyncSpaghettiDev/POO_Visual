using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Alumnos{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
            textBox3.Hide();
            label3.Hide();
            textBox4.Hide();
            label4.Hide();
            textBox5.Hide();
            label5.Hide();
            label6.Text = "";
            label1.Text = "Ingresa el nombre";
            label2.Text = "Ingresa la matricula";
            listBox1.Items.Add("Alumno");
            listBox1.Items.Add("Licenciado");
            listBox1.Items.Add("Estudiante Posgrado");
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e){
            try{
                if (listBox1.Text == "Alumno"){
                    Alumno a = new Alumno(textBox1.Text,Int32.Parse(textBox2.Text));
                    pictureBox1.Image = Image.FromFile(a.foto());
                    label6.Text = a.imprime();
                }
                else if (listBox1.Text == "Licenciado"){
                    Licenciatura a = new Licenciatura(textBox1.Text, Int32.Parse(textBox2.Text), textBox3.Text, Int32.Parse(textBox4.Text));
                    pictureBox1.Image = Image.FromFile(a.foto());
                    label6.Text = a.imprime();
                }
                else if (listBox1.Text== "Estudiante Posgrado"){
                    Posgrado a = new Posgrado(textBox1.Text, Int32.Parse(textBox2.Text), textBox3.Text, Int32.Parse(textBox4.Text), textBox5.Text);
                    pictureBox1.Image = Image.FromFile(a.foto());
                    label6.Text = a.imprime();
                }
            }
            catch (Exception){
                MessageBox.Show("Todos los campos deben tener datos","Error");
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){
            if (listBox1.Text == "Alumno"){
                textBox3.Hide();
                label3.Hide();
                textBox4.Hide();
                label4.Hide();
                textBox5.Hide();
                label5.Hide();
            }
            else if (listBox1.Text == "Licenciado"){
                textBox3.Show();
                label3.Show();
                label3.Text = "Ingresa la carrera";
                textBox4.Show();
                label4.Show();
                label4.Text = "Ingresa el semestre";
                textBox5.Hide();
                label5.Hide();
            }
            else if (listBox1.Text == "Estudiante Posgrado"){
                textBox3.Show();
                label3.Show();
                label3.Text = "Ingresa la especialidad";
                textBox4.Show();
                label4.Show();
                label4.Text = "Ingresa el cuatrimestre";
                textBox5.Show();
                textBox5.Size=new Size(156,20);
                label5.Show();
                label5.Text = "Ingresa el tema de \ninvestigación";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            pictureBox1.Image = null;
            label6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e){
            Application.Exit();
        }
    }
    class Alumno{
        protected string nombre;
        protected int matricula;
        /*Creacion del constructor, usando la sobrecarga de parametros*/
        public Alumno(string nombre, int matricula){
            this.nombre = nombre;
            this.matricula = matricula;
        }
        /*Creacion del método imprime, se usa la palabra reservada virtual para declarar que en otras clases
        se puede redefinir.*/
        public virtual string foto() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Alumnos/bin/Debug/alumno.png";
        public virtual string imprime(){
            return "Mi nombre es " + this.nombre + "\nY mi matricula es "+ this.matricula+"\n";
        }
    }
    class Licenciatura : Alumno{
        /*Asignacion de atributos de clase como privados, debido a que no se van a heredar*/
        private string carrera;
        private int semestre;
        private string act_esp;
        /*Creacion del constructor de la clase, se usa la palabra reservada "base" para referenciar al
        constructor de la clase base. Si actualmente cursa un semestre mayor al octavo estará haciendo
        residencia y en caso de que estar en un semestre menor hará servicio social.*/
        public Licenciatura(string nombre, int matricula, string carrera, int semestre) : base(nombre, matricula)
        {
            this.carrera = carrera;
            this.semestre = semestre;
            if (semestre > 8) act_esp = "Residencia";
            else act_esp = "Servicio Social";
        }
        public override string foto()=> "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Alumnos/bin/Debug/universitario.png";
        /*Redefinición del método imprime usando los atributos de la clase*/
        public override string imprime(){
            return ("Mi nombre es "+ this.nombre + "\nEstoy en el semestre "+ this.semestre + "\nDe la carrera de"+ this.carrera + ".\nMi matricula es "+ this.matricula + "\nY actualmente estoy haciendo mi "+ this.act_esp);
        }
    }
    class Posgrado : Alumno{
        /*Asignacion de atributos de clase como privados, debido a que no se van a heredar*/
        private string especialidad;
        private int cuatrimestre;
        private string tema;
        /*Creacion del constructor de la clase, se usa la palabra reservada "base" para referenciar al
        constructor de la clase base.*/
        public Posgrado(string nombre, int matricula, string especialidad, int cuatrimestre, string tema) : base(nombre, matricula){
            this.especialidad = especialidad;
            this.cuatrimestre = cuatrimestre;
            this.tema = tema;
        }
        public override string foto() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Alumnos/bin/Debug/posgrado.png";
        /*Redefinición del método imprime usando los atributos de la clase*/
        public override string imprime(){
            return ("Mi nombre es "+ this.nombre + "\nEstoy en el cuatrimestre #"+ this.cuatrimestre + "\nDe la especialidad "+ this.especialidad + ".\nMi matricula es "+ this.matricula + "\nY mi tema de investigación"+ this.tema);
        }
    }
}
