using System;
using System.Drawing;
using System.Windows.Forms;

namespace Botones{
    public class Juego : Form{
        public static bool jugando=true;
        private Button ctr1;
        private Tablero tablero_juego;
        private readonly int dif,tamano;
        public Juego(int dif) {
            String Text=null;
            int disminuir=0;
            this.dif = dif;
            switch (dif) {
                case 5:
                    this.tamano = 50;
                    Text = "Dificultad: Fácil";
                    disminuir = 135;
                    break;
                case 10:
                    this.tamano = 70;
                    Text = "Dificultad: Medio";
                    disminuir = 65;
                    break;
                case 15:
                    this.tamano = 90;
                    Text = "Dificultad: Difícil";
                    break;
            }
            InitializeComponents();
            Funciones.Diseno(this, 440, 440-disminuir, Text, "logo.ico");
            LostFocus += new EventHandler(comprueba);
            this.ctr1.Click += new EventHandler(carga_tablero);
        }
        private void InitializeComponents() {
            this.ctr1 = new Button();
            this.ctr1.Image = Image.FromFile("../../img/vivo.jpg");
            this.ctr1.Size = new Size(50, 50);
            this.ctr1.Text = "";
            this.ctr1.Location = new Point((this.Size.Width / 2) + (this.ctr1.Size.Width / 2) + 10, 5);
            this.Controls.Add(this.ctr1);
            Load+= new EventHandler(carga_tablero);
        }
        private void carga_tablero(object sender, EventArgs e) {
            this.tablero_juego = new Tablero(this.tamano, this.dif);
            this.tablero_juego.dibujarTablero(this);
        }
        private void comprueba(object sender, EventArgs e) {
            if (!jugando)
                this.ctr1.Image = Image.FromFile("../../img/muerto.png");
        }
    }
}
