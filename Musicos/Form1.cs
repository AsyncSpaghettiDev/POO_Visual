using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Musicos{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
            listBox1.Items.Add("Musico");
            listBox1.Items.Add("Baterista");
            listBox1.Items.Add("Bajista");
            listBox1.Items.Add("Guitarrista");
            listBox1.SelectedIndex = 0;
            label1.Text="Ingresa nombre";
            label6.Text = "";
        }
        private Musico instanciar(){
            switch (listBox1.Text){
                case "Musico":
                    return new Musico(textBox1.Text);
                case "Baterista":
                    return new Baterista(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                case "Bajista":
                    return new Bajista(textBox1.Text, textBox2.Text, textBox3.Text);
                case "Guitarrista":
                    return new Guitarrista(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,double.Parse(textBox5.Text));
            }
            return new Musico();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){
            switch (listBox1.Text){
                case "Musico":
                    textBox2.Hide();
                    label2.Hide();

                    textBox3.Hide();
                    label3.Hide();

                    textBox4.Hide();
                    label4.Hide();

                    textBox5.Hide();
                    label5.Hide();

                    break;

                case "Baterista":
                    textBox2.Show();
                    label2.Show();
                    label2.Text = "Ingresa marca bateria";

                    textBox3.Show();
                    label3.Show();
                    label3.Text = "Ingresa marca platillos";

                    textBox4.Show();
                    label4.Show();
                    label4.Text="Ingresa marca baquetas";

                    textBox5.Hide();
                    label5.Hide();

                    break;

                case "Bajista":
                    textBox2.Show();
                    label2.Show();
                    label2.Text = "Ingresa marca bajo";

                    textBox3.Show();
                    label3.Show();
                    label3.Text = "Ingresa marca strap";

                    textBox4.Hide();
                    label4.Hide();

                    textBox5.Hide();
                    label5.Hide();
                    break;

                case "Guitarrista":
                    textBox2.Show();
                    label2.Show();
                    label2.Text = "Ingresa marca guitarra";

                    textBox3.Show();
                    label3.Show();
                    label3.Text = "Ingresa marca strap";

                    textBox4.Show();
                    label4.Show();
                    label4.Text = "Ingresa marca plumillas";

                    textBox5.Show();
                    label5.Show();
                    label5.Text = "Ingresa tamaño plumilla en mm";

                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e){
            try{
                Musico a = instanciar();
                label6.Text = a.saluda();
                pictureBox1.Image = Image.FromFile(a.saludar());
            }
            catch (Exception){
                MessageBox.Show("Todos los campos deben tener un valor","Error");
            }
        }

        private void button2_Click(object sender, EventArgs e){
            try{ 
            Musico a = instanciar();
            label6.Text = a.afina();
            pictureBox1.Image = Image.FromFile(a.afinar());
            }
            catch (Exception){
                MessageBox.Show("Todos los campos deben tener un valor", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e){
            try{
                Musico a = instanciar();
                label6.Text = a.toca();
                pictureBox1.Image = Image.FromFile(a.tocar());
            }
            catch (Exception){
                MessageBox.Show("Todos los campos deben tener un valor", "Error");
            }
        }

        private void button4_Click(object sender, EventArgs e){
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            pictureBox1.Image = null;
            label6.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    /*Creacion de la clase base musico con el atributo nombre, se declara protecte para que
        pueda ser heredado a las otras clases. Se usa la libreria Collectios.Generic para poder
        usar las listas más adelante.*/
    class Musico
    {
        protected string nombre;
        public Musico() { }
        public Musico(string nombre)
        {
            this.nombre = nombre;
        }
        public virtual string afinar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/m-afina.png";
        public virtual string saludar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/m-saluda.png";
        public virtual string tocar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/m-toca.png";
        /*Creación de métodos virtuales para poder ser redefinidos más adelante*/
        public virtual string afina(){
            return("Estoy afinando my instrumento.");
        }
        public virtual string saluda(){
            return("Que tal! Soy ."+ nombre);
        }
        public virtual string toca(){
            return("¡Hora de tocar!");
        }
    }
    /*Creacion de clase baterista que hereda de la clase musico, declaración de atributos
    tales como bateria, platillos y baquetas, estos son privados porque ya no se van a 
    heredar a otra clase*/
    class Baterista : Musico
    {
        private string marca_bateria;
        private string marca_platillos;
        private string marca_baquetas;
        public Baterista() { }
        /*Creacion del constructor y referencia al constructor de la clase base. Sobrecarga de parametros*/
        public Baterista(string nombre, string marca_bateria, string marca_platillos, string marca_baquetas) : base(nombre)
        {
            this.marca_bateria = marca_bateria;
            this.marca_platillos = marca_platillos;
            this.marca_baquetas = marca_baquetas;
        }
        public override string afinar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/b-afina.png";
        public override string saludar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/b-saluda.png";
        public override string tocar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/b-toca.png";
        /*Refedinicion de los métodos usando la palabra reservada override.*/
        public override string afina(){
            return("Estoy afinando los tambores de mi bateria "+ this.marca_bateria);
        }
        public override string saluda(){
            return("Hola amigos, soy " + this.nombre + " el baterista,\nUso mi bateria "+ this.marca_bateria + "\nCon los platillos "+ this.marca_platillos + "\nY mis baquetas "+ this.marca_baquetas + "." );
        }
        public override string toca(){
            return("Hora de Rockear!!");
        }
    }
    /*Creacion de clase bajista que hereda de la clase musico, declaración de atributos
    tales como bajo y marca del strap, estos son privados porque ya no se van a 
    heredar a otra clase*/
    class Bajista : Musico
    {
        private string marca_bajo;
        private string marca_strap;
        public Bajista() { }
        /*Creacion del constructor y referencia al constructor de la clase base. Sobrecarga de parametros*/
        public Bajista(string nombre, string marca_bajo, string marca_strap) : base(nombre)
        {
            this.marca_bajo = marca_bajo;
            this.marca_strap = marca_strap;
        }
        public override string afinar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/ba-afina.png";
        public override string saludar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/ba-saluda.png";
        public override string tocar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/ba-toca.png";
        /*Refedinicion de los métodos usando la palabra reservada override.*/
        public override string afina(){
            return("Estoy afinando mi bajo marca"+ this.marca_bajo);
        }
        public override string saluda(){
            return("Hola que tal soy "+ this.nombre + "\nToco el bajo "+ this.marca_bajo + " para la banda \nCon mi strap marca "+ this.marca_strap + ".");
        }
        public override string toca(){
            return("Demosle!!");
        }
    }
    /*Creacion de clase guitarrista que hereda de la clase musico, declaración de atributos
    tales como guitarra,marca del strap, marca de la plumilla que usa y la medida que esta tiene
    , estos son privados porque ya no se van a heredar a otra clase*/
    class Guitarrista : Musico
    {
        private string marca_guitarra;
        private string marca_strap;
        private string marca_plumilla;
        private double tamaño_plumilla;
        public Guitarrista() { }
        /*Creacion del constructor y referencia al constructor de la clase base. Sobrecarga de parametros*/
        public Guitarrista(string nombre, string marca_guitarra, string marca_strap, string marca_plumilla, double tamaño_plumilla) : base(nombre)
        {
            this.marca_guitarra = marca_guitarra;
            this.marca_strap = marca_strap;
            this.marca_plumilla = marca_plumilla;
            this.tamaño_plumilla = tamaño_plumilla;
        }
        public override string afinar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/g-afina.png";
        public override string saludar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/g-saluda.png";
        public override string tocar() => "C:/Users/Jonathan Mojica/Desktop/POO_Visual/Musicos/img/g-toca.png";
        /*Refedinicion de los métodos usando la palabra reservada override.*/
        public override string afina(){
            return ("Estoy afinando mi guitarra marca "+this.marca_guitarra);
        }
        public override string saluda(){
            return ("Muy buena gente soy "+ this.nombre + "\nMe gusta usar mi guitarra "+ this.marca_guitarra + "\nCon el strap marca "+ this.marca_strap + ".\nSiempre toco usando mis plumillas "+ this.marca_plumilla+ " " + this.tamaño_plumilla + "mm.");
        }
        public override string toca(){
            return ("Hora de tocar!!");
        }
    }
}
