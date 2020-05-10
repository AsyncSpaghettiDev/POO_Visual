using System;
using System.Drawing;
using System.Windows.Forms;

namespace Botones{
    public class Juego : Form{
        private Button ctr1;
        private Tablero tablero_juego;
        public Juego(int dif) {
            String Text=null;
            int disminuir=0;
            switch (dif) {
                case 5: tablero_juego = new Tablero(50, dif);
                    Text = "Dificultad: Fácil";
                    disminuir = 135;
                    break;
                case 10: tablero_juego = new Tablero(70, dif);
                    Text = "Dificultad: Medio";
                    disminuir = 65;
                    break;
                case 15: tablero_juego = new Tablero(90, dif);
                    Text = "Dificultad: Difícil";
                    break;
            }
            InitializeComponents();
            Funciones.Diseno(this, 440, 440-disminuir, Text, "logo.ico");
        }
        private void InitializeComponents() {
            this.ctr1 = new Button();
            this.ctr1.Image = Image.FromFile("./vivo.jpg");
            this.ctr1.Size = new Size(50, 50);
            this.ctr1.Text = "";
            this.ctr1.Location = new Point(186, 5);
            this.ctr1.ImageAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(this.ctr1);

            Load+= new EventHandler(carga_tablero);
            foreach(Celda loza in tablero_juego.cuadricula) {
                loza.MouseClick += new MouseEventHandler(descubre);
                loza.TabStop = false;
            }
        }
        private void carga_tablero(object sender, EventArgs e) {
            tablero_juego.dibujarTablero(this);
        }
        private void descubre(object sender, MouseEventArgs e) {
            var loza=sender as Celda;
            var bandera=new Bitmap("../../img/descarte.png");
            var bomba=new Bitmap("../../img/mina.png");
            if (e.Button == MouseButtons.Left) {
                if (loza.rodeada == 0 && !loza.estado)
                    loza.Enabled = false;
                else if (!loza.estado)
                    loza.Text = loza.rodeada.ToString();
                else if (loza.estado) {
                    loza.Image = new Bitmap(bomba, loza.lado-4, loza.lado-4);
                    MessageBox.Show("Kaboom");
                    this.tablero_juego.dibujarTablero(this);
                }
            }
            else {
                loza.Image = new Bitmap(bandera, 30, 30);
            }
                

        }
    }
}
