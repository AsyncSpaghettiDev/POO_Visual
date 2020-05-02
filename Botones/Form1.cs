using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Botones{
    public class Form1 : Form{
        private Button ctr1;
        private List<Celda> cuadricula=new List<Celda>();
        private Label eti=new Label();
        public Form1(){
            this.ctr1 = new Button();
            this.ctr1.Text = "Iniciar";
            this.ctr1.Size = new Size(75,25);
            this.ctr1.Location = new Point(174,300);

            this.Text = "Muchos Botones";
            this.Controls.Add(this.ctr1);
            this.Controls.Add(this.eti);
            this.Size = new Size(440,400);
            this.Icon = new Icon("./logo.ico");

            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Load+= new EventHandler(ctr_Click);
            this.ctr1.Click += new EventHandler(iniciar);

            foreach(Celda boton in cuadricula) {
                boton.MouseClick += new MouseEventHandler(message);
            }
            
        }
        private void iniciar(object sender, EventArgs e) {
            (sender as Button).Text = "Corre";
            (sender as Button).BackColor = Color.White;
            (sender as Button).Enabled = false;
            cuadricula[2].estado = true;
            eti.Text = cuadricula[2].estado.ToString();
            eti.Location = new Point(75, 300);
        }
        private void message(object sender, MouseEventArgs e) {
            if ((sender as Celda).estado)
                MessageBox.Show("Explotas","Kaboom");
        }
        public void ctr_Click(object sender, EventArgs e){
            for (int i=0;i<50;i++) {
                cuadricula.Add(new Celda(10));
                if (i == 0)
                    cuadricula[i].setPos(35, 35);
                else if (i == 10 | i == 20 | i == 30 | i == 40 | i == 50)
                    cuadricula[i].setPos(35,cuadricula[i-10].y+35);
                else 
                    cuadricula[i].setPos(35, cuadricula[i-1]);
            }

            Random rdm = new Random();
            for (int i = 0; i < 5; i++) {
                cuadricula[rdm.Next(50)].estado = true;
            }

            foreach (Celda item in cuadricula)
                item.dibujar(this);
        }
    }
}
