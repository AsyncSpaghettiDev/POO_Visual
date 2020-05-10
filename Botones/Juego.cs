using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Botones{
    public class Juego : Form{
    ComponentResourceManager imgs = new ComponentResourceManager(typeof(recursos));

        public static bool jugando=true;
        private Button ctr1,volver;
        private Label minas;
        private Tablero tablero_juego;
        private readonly int dif,ancho,alto;
        
        public Juego(int dif) {
            String Text=null;
            this.dif = dif;
            switch (dif) {
                case 10:
                    this.ancho = 8;
                    this.alto=8;
                    Text = "Dificultad: Fácil";
                    break;
                case 40:
                    this.ancho = 16;
                    this.alto = 16;
                    Text = "Dificultad: Medio";
                    break;
                case 62:
                    this.ancho = 20;
                    this.alto = 20;
                    Text = "Dificultad: Difícil";
                    break;
            }
            Funciones.Diseno(this, this.ancho*35+90, this.alto*35+115, Text, "logo");
            InitializeComponents();
            LostFocus += new EventHandler(comprueba);
            this.ctr1.Click += new EventHandler(reinicia);
        }
        private void InitializeComponents() {
            this.minas = new Label();
            this.minas.Text = String.Format("Minas restantes: {0}",this.dif);
            this.minas.Location= new Point((this.Size.Width / 4) - (this.minas.Size.Width / 2), 25);

            this.volver = new Button();
            this.volver.Size = new Size(this.volver.Size.Width, 2 * this.volver.Size.Height);
            this.volver.Text = "Volver al menú";
            this.volver.Location = new Point((this.Size.Width * 3/4) - (this.volver.Size.Width / 2), 10);
            this.volver.Click += new EventHandler(volver_M);

            this.ctr1 = new Button();
            this.ctr1.Image = imgs.GetObject("vivo") as Bitmap;
            this.ctr1.Size = new Size(50, 50);
            this.ctr1.Text = "";
            this.ctr1.Location = new Point((this.Size.Width / 2)- (this.ctr1.Size.Width / 2), 5);

            this.Controls.Add(this.minas);
            this.Controls.Add(this.ctr1);
            this.Controls.Add(this.volver);
            Load += new EventHandler(carga_tablero);
        }
        private void carga_tablero(object sender, EventArgs e) {
            this.tablero_juego = new Tablero(this.ancho,this.alto, this.dif);
            this.tablero_juego.dibujarTablero(this);
        }
        private void reinicia(object sender, EventArgs e) {
            Dispose(true);
            new Juego(this.dif).Show();
        }
        private void comprueba(object sender, EventArgs e) {
            if (!jugando) {
                tablero_juego.actualiza(this);
                this.ctr1.Image = imgs.GetObject("muerto") as Bitmap;
            }  
        }
        private void volver_M(object sender, EventArgs e) {
            new Inicio().Show();
            Dispose(true);
        }
    }
}
