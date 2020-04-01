using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Duracion_Visual{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e){
            try{
               Duracion a = new Duracion(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text));
               Duracion b = new Duracion(Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text));
               Duracion c = a + b;
               label1.Text = c.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Debes rellenar todos los campos.","Error");
            }
            
        }

        private void button2_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            label1.Text = "";
        }
    }
    class Duracion{
        private int horas;
        private int minutos;
        private int segundos;
        public Duracion(int horas,int minutos,int segundos){
            convertir(ref segundos, ref minutos);
            this.segundos = segundos;

            convertir(ref minutos, ref horas);
            this.minutos = minutos;
            this.horas = horas;
        }
        public Duracion(int segundos){
            int minutos = 0;
            int horas = 0;

            convertir(ref segundos, ref minutos);
            this.segundos = segundos;

            convertir(ref minutos, ref horas);
            this.minutos = minutos;
            this.horas = horas;
        }
        public int getHoras() => this.horas;
        public int getMinutos() => this.minutos;
        public int getSegundos() => this.segundos;
        private void convertir(ref int x, ref int y){
            for (int i = 0; i <= 3600; i++){
                if (x / 60 >= 1){
                    y++;
                    x -= 60;
                }
                else{
                    break;
                }
            }
        }
        public override string ToString() => string.Format("{0:D2}:{1}:{2}", this.horas, this.minutos.ToString("D2"), this.segundos.ToString("D2"));
        public static Duracion operator +(Duracion x, Duracion y){
            return new Duracion(x.getHoras() + y.getHoras(), x.getMinutos() + y.getMinutos(), x.getSegundos() + y.getSegundos());
        }
    }
}
