using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Botones {
    /// <summary>
    /// Creacion de un boton tipo celda
    /// </summary>
    public class Celda:Button {
        private int x { get; set; }
        private int y { get; set; }
        public int lado { get; set; }
        public int rodeada { get; set; }
        private bool _estado=false;
        public bool estado {
            get => this._estado;
            set {
                this._estado = value;
                if(estado)
                    this.rodeada--;
            }
        }
        private bool _habilitado;
        public bool habilitado {
            get => _habilitado;
            set {
                this._habilitado = value;
                this.Enabled = value;
                if (this.rodeada != 0)
                    this.Enabled = true;
            }
        }
        private List<Celda> cardinal;
        private List<Celda> esquinas;
        private readonly List<Celda> vecinos;
        /// <summary>
        /// Creacion de la celda
        /// </summary>
        /// <param name="cant">Cantidad deseada de botones por renglon</param>
        public Celda(int fila,int columna) {
            this.habilitado = true;
            this.cardinal = new List<Celda>();
            this.esquinas = new List<Celda>();
            this.vecinos = new List<Celda>();
            this.lado=35;
            this.y = fila* lado+60;
            this.x = (columna+1)* lado;
            this.Size = new Size(lado,lado);
            MouseDown += new MouseEventHandler(descubre);
            TabStop = false;
            this.ForeColor = Color.White;
        }
        /// <summary>
        /// Determina si existe alguna celda contigua en un area 3x3
        /// </summary>
        /// <param name="sig">Celda dentro del area 3x3</param>
        /* Se establece un punto central y sumando o restando el tamaño del boton se
         * logra determinar si ese punto pertenece a alguna otra celda en un area 3x3
         */
        public void contar(Celda sig) {
            if (!this.estado) {
                int centro_x=this.x+(lado/2);
                int centro_y=this.y+(lado/2);
                //Arriba
                if (sig.lados(centro_x, centro_y - lado, this) && sig.estado)
                    this.rodeada++;
                //Derecha arriba
                if (sig.esquina(centro_x + lado, centro_y + lado, this) && sig.estado)
                    this.rodeada++;
                //Derecha
                if (sig.lados(centro_x + lado, centro_y, this) && sig.estado)
                    this.rodeada++;
                //Derecha abajo
                if (sig.esquina(centro_x + lado, centro_y - lado, this) && sig.estado)
                    this.rodeada++;
                //Abajo
                if (sig.lados(centro_x, centro_y + lado, this) && sig.estado)
                    this.rodeada++;
                //Izquierda abajo
                if (sig.esquina(centro_x - lado, centro_y - lado, this) && sig.estado)
                    this.rodeada++;
                //Izquierda
                if (sig.lados(centro_x - lado, centro_y, this) && sig.estado)
                    this.rodeada++;
                //Izquierda arriba
                if (sig.esquina(centro_x - lado, centro_y + lado, this) && sig.estado)
                    this.rodeada++;
            }
        }
        /// <summary>
        /// Determina si la celda contiene el punto dado
        /// </summary>
        /// <param name="x">Coordenada x del punto a evaluar</param>
        /// <param name="y">Coordenada y del punto a evaluar</param>
        /// <returns></returns>
        private bool esquina(int x,int y,Celda cell) {
            if (x > this.x && x < this.x + lado && y > this.y && y < this.y + lado) {
                cell.esquinas.Add(this);
                cell.vecinos.Add(this);
                return true;
            }
            else
                return false;
        }
        private bool lados(int x, int y, Celda cell) {
            if (x > this.x && x < this.x + lado && y > this.y && y < this.y + lado) {
                cell.cardinal.Add(this);
                cell.vecinos.Add(this);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Desplegar los botones en una ventana.
        /// </summary>
        /// <param name="pantalla">Ventana donde se desplegará, se recomienda usar this</param>
        public void dibujar(Form pantalla) {
            this.Location=new Point(this.x,this.y);
            pantalla.Controls.Add(this);
        }
        /// <summary>
        /// Busca en todas las celdas vecinas de una celda si estan vacias, de ser asi se deshabilita
        /// </summary>
        /// <param name="objetivo">Celda a evaluar</param>
        private void actualiza(Celda objetivo) {
            int i=0;
            foreach (Celda campo in objetivo.cardinal) {
                if (campo.rodeada > 0 && campo.habilitado) {
                    cerca(campo);
                    campo.habilitado = false;
                    //break;
                }
                else if (campo.rodeada == 0 && campo.habilitado) {
                    campo.habilitado = false;
                    actualiza(campo);
                }
            }
        }
        /// <summary>
        /// Efectua la accion de revelar el estado de una celda, vacia, cerca de mina o mina
        /// </summary>
        public void descubre(object sender, MouseEventArgs e) {
            ComponentResourceManager imgs = new ComponentResourceManager(typeof(recursos));
            if (e.Button==MouseButtons.Left) {
                if ((sender as Celda).rodeada == 0) {
                    (sender as Celda).habilitado = false;
                    foreach (Celda campo in (sender as Celda).vecinos)
                        actualiza(campo);
                }
                else if (!(sender as Celda).estado)
                    cerca((sender as Celda));
                else if ((sender as Celda).estado) {
                    Juego.jugando = false;
                    (sender as Celda).Image = new Bitmap(imgs.GetObject("mina") as Bitmap,(sender as Celda).lado-4, (sender as Celda).lado - 4);
                    MessageBox.Show("Kaboom");
                }
            }
            else if(e.Button==MouseButtons.Right) {
                (sender as Celda).Image = new Bitmap(imgs.GetObject("descarte") as Bitmap, (sender as Celda).lado - 4, (sender as Celda).lado - 4);
            }
        }
        /// <summary>
        /// Colorea la celda de un color acorde a la cantidad de minas alrededor
        /// </summary>
        /// <param name="cerca">Celda central a la que se evaluarán sus vecinos</param>
        private void cerca(Celda cerca) {
            switch (cerca.rodeada) {
                case 1:
                    cerca.BackColor = Color.Blue;
                    break;
                case 2:
                    cerca.BackColor = Color.DarkGreen;
                    break;
                case 3:
                    cerca.BackColor = Color.DarkRed;
                    break;
                case 4:
                    cerca.BackColor = Color.DarkMagenta;
                    break;
                default:
                    cerca.BackColor = Color.Black;
                    break;
            }
            cerca.Text = cerca.rodeada.ToString();
        }
    }
}
