using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Botones{
    public class Juego : Form{
        private Button ctr1;
        private List<Celda> cuadricula=new List<Celda>();
        private int dif;
        private int tamano;
        public Juego(int dif) {
            this.dif = dif;
            switch (dif) {
                case 5: tamano = 50;
                    this.Text = "Dificultad: Fácil";
                    break;
                case 10: tamano = 70;
                    this.Text = "Dificultad: Medio";
                    break;
                case 15: tamano = 90;
                    this.Text = "Dificultad: Difícil";
                    break;
            }
            InitializeComponents();
        }
        private void InitializeComponents(){
            this.ctr1 = new Button();
            this.ctr1.Text = "Iniciar";
            this.ctr1.Size = new Size(75,25);
            this.ctr1.Location = new Point(174,5);
            this.ctr1.Enabled = true;
            this.Controls.Add(this.ctr1);
            Funciones.Diseno(this,440, 420, "logo.ico");

            CenterToScreen();
            Load+= new EventHandler(crear_Botones);
            this.ctr1.Click += new EventHandler(iniciar);

            for (int i = 0; i < this.tamano; i++) {
                cuadricula.Add(new Celda(10));
                cuadricula[i].Click += new EventHandler(message);
                cuadricula[i].Enabled = false;
            }
        }
        public void iniciar(object sender, EventArgs e) {
            (sender as Button).Image = Image.FromFile("./vivo.jpg");
            (sender as Button).Size = new Size(50,50);
            (sender as Button).Text = "";
            (sender as Button).Location = new Point(186, 5);
            (sender as Button).ImageAlign = ContentAlignment.MiddleCenter;
            foreach (Button celda in cuadricula)
                celda.Enabled = true;
        }
        private void message(object sender, EventArgs e) {
            if ((sender as Celda).estado) {
                this.ctr1.Image = Image.FromFile("./muerto.png");
                MessageBox.Show("Explotas", "Kaboom");
                new Inicio().Show();
                this.Hide();
            }
            else
                (sender as Button).Enabled = false;
        }
        public void crear_Botones(object sender, EventArgs e){
            Random rdm = new Random();
            for (int i = 0; i < this.dif; i++)
                cuadricula[rdm.Next(this.tamano)].estado = true;

            for (int i=0;i<this.tamano;i++) {
                if (i == 0)
                    cuadricula[i].setPos(35, 55);
                else if (i%10==0)
                    cuadricula[i].setPos(35,cuadricula[i-10].y+35);
                else
                    cuadricula[i].setPos(35, cuadricula[i-1]);
                cuadricula[i].dibujar(this);
            }
        }
    }
}
