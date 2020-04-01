using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Peliculas
{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){
            try
            {
                Pelicula a = new Pelicula(textBox1.Text, Int16.Parse(textBox2.Text));
                label1.Text = a.ToString();

                Pelicula b = new Pelicula(textBox3.Text, Int16.Parse(textBox4.Text));
                label2.Text = b.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Todos los campos deben tener un dato valido","Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label1.Text = "";
            label2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e){
            Application.Exit();
        }
    }
    class Pelicula
    {
        private string titulo;
        private Int16 año;
        private string pais;
        private string director;
        public Pelicula(string titulo, Int16 año)
        {
            this.titulo = titulo;
            this.año = año;
        }
        public override String ToString() => String.Format("La película {0} se estrenó el año {1}.", this.titulo, año);
    }
}
