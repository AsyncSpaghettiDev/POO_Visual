using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Suma_Domino{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){
            try
            {
            String[,] fichas = new String[,] { 
            { "0-0.png", "0-1.png", "0-2.png", "0-3.png", "0-4.png", "0-5.png", "0-6.png" },
            { "1-0.png", "1-1.png", "1-2.png", "1-3.png", "1-4.png", "1-5.png", "1-6.png" },
            { "2-0.png", "2-1.png", "2-2.png", "2-3.png", "2-4.png", "2-5.png", "2-6.png" },
            { "3-0.png", "3-1.png", "3-2.png", "3-3.png", "3-4.png", "3-5.png", "3-6.png" },
            { "4-0.png", "4-1.png", "4-2.png", "4-3.png", "4-4.png", "4-5.png", "4-6.png" },
            { "5-0.png", "5-1.png", "5-2.png", "5-3.png", "5-4.png", "5-5.png", "5-6.png" },
            { "6-0.png", "6-1.png", "6-2.png", "6-3.png", "6-4.png", "6-5.png", "6-6.png" },
            };
            Domino a = new Domino(Int32.Parse(textBox1.Text),Int32.Parse(textBox2.Text));
            for (int i=0;i<=6;i++){
                for(int j = 0; j <= 6; j++){
                    if ((a.getEspacio1() == i) & (a.getEspacio2() == j)) pictureBox1.Image = Image.FromFile(fichas[i,j]);break;
                }
            }
            Domino b = new Domino(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
            for (int i = 0; i <= 6; i++){
                for (int j = 0; j <= 6; j++){
                    if ((b.getEspacio1() == i) & (b.getEspacio2() == j)) pictureBox2.Image = Image.FromFile(fichas[i, j]);break;
                }
            }
            int suma = a + b;
            label2.Text = suma.ToString();
            }
            catch (Exception){
                MessageBox.Show("Debes ingresar valores en los campos.", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e){
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label2.Text = "";
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        private void button3_Click(object sender, EventArgs e){
            Application.Exit();
        }
    }
    class Domino{
        private int Espacio1;
        private int Espacio2;
        public Domino(int Espacio1, int Espacio2){
            if ((Espacio1 > 6) | (Espacio1 < 0)) this.Espacio1 = 0;
            else this.Espacio1 = Espacio1;

            if ((Espacio2 > 6) | (Espacio2 < 0)) this.Espacio2 = 0;
            else this.Espacio2 = Espacio2;
        }
        public int getEspacio1() => Espacio1;
        public int getEspacio2() => Espacio2;
        public static int operator +(Domino x, Domino y){
            return y.getEspacio1() + y.getEspacio2() + x.getEspacio1() + x.getEspacio2();
        }
    }
}
