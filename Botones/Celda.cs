using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
                this.rodeada++;
                this._estado = value;
            }
        }
        private readonly List<Celda> vecinos;
        /// <summary>
        /// Creacion de la celda
        /// </summary>
        /// <param name="cant">Cantidad deseada de botones por renglon</param>
        public Celda(int cant,int fila,int columna) {
            this.Enabled = true;
            this.vecinos = new List<Celda>();
            this.lado=355/cant;
            this.y = fila* lado+60;
            this.x = (columna+1)* lado;
            this.Size = new Size(lado,lado);
            MouseClick += new MouseEventHandler(descubre);
            TabStop = false;
        }
        private void setText() {
            if (estado)
                this.Text = ".";
        }
        /// <summary>
        /// Determina si existe alguna celda contigua en un area 3x3
        /// </summary>
        /// <param name="sig">Celda dentro del area 3x3</param>
        /* Se establece un punto central y sumando o restando el tamaño del boton se
         * logra determinar si ese punto pertenece a alguna otra celda en un area 3x3
         */
        public void contar(Celda sig) {
            int centro_x=this.x+(lado/2);
            int centro_y=this.y+(lado/2);
            //Derecha
            if (sig.incluye(centro_x + lado, centro_y,this.vecinos) && sig.estado)
                this.rodeada++;
            //Izquierda
            if (sig.incluye(centro_x - lado, centro_y,this.vecinos) && sig.estado)
                this.rodeada++;
            //Abajo
            if (sig.incluye(centro_x, centro_y + lado,this.vecinos) && sig.estado)
                this.rodeada++;
            //Arriba
            if (sig.incluye(centro_x, centro_y - lado,this.vecinos) && sig.estado)
                this.rodeada++;
            //Derecha arriba
            if (sig.incluye(centro_x + lado, centro_y + lado,this.vecinos) && sig.estado)
                this.rodeada++;
            //Derecha abajo
            if (sig.incluye(centro_x + lado, centro_y - lado,this.vecinos) && sig.estado)
                this.rodeada++;
            //Izquierda arriba
            if (sig.incluye(centro_x - lado, centro_y + lado,this.vecinos) && sig.estado)
                this.rodeada++;
            //Izquierda abajo
            if (sig.incluye(centro_x - lado, centro_y - lado,this.vecinos) && sig.estado)
                this.rodeada++;
        }
        /// <summary>
        /// Determina si la celda contiene el punto dado
        /// </summary>
        /// <param name="x">Coordenada x del punto a evaluar</param>
        /// <param name="y">Coordenada y del punto a evaluar</param>
        /// <returns></returns>
        private bool incluye(int x,int y,List<Celda> vec) {
            if (x > this.x && x < this.x + lado && y > this.y && y < this.y + lado) {
                vec.Add(this);
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
            setText();
            this.Location=new Point(this.x,this.y);
            pantalla.Controls.Add(this);
        }
        /// <summary>
        /// Busca en todas las celdas vecinas de una celda si estan vacias, de ser asi se deshabilita
        /// </summary>
        /// <param name="objetivo">Celda a evaluar</param>
        private void actualiza(Celda objetivo) {
            foreach (Celda campo in objetivo.vecinos)
                if (campo.rodeada == 0)
                    campo.Enabled = false;
        }
        /// <summary>
        /// Efectua la accion de revelar el estado de una celda, vacia, cerca de mina o mina
        /// </summary>
        public void descubre(object sender, MouseEventArgs e) {
            var bandera=new Bitmap("../../img/descarte.png");
            var bomba=new Bitmap("../../img/mina.png");
            if (e.Button==MouseButtons.Left) {
                if (this.rodeada == 0) {
                    this.Enabled = false;
                    foreach (Celda campo in this.vecinos)
                        actualiza(campo);
                }
                else if (!this.estado)
                    cerca(this);
                else if (this.estado) {
                    Juego.jugando = false;
                    this.Image = new Bitmap(bomba, this.lado - 4, this.lado - 4);
                    MessageBox.Show("Kaboom");
                }
            }
            else {
                MessageBox.Show("MSG Der");
                this.Image = new Bitmap(bandera, 30, 30);
            }
        }
        private void cerca(Celda cerca) {
            cerca.ForeColor = Color.White;
            switch (cerca.rodeada) {
                case 1:
                    cerca.BackColor = Color.Yellow;
                    cerca.ForeColor = Color.Black;
                    break;
                case 2:
                    cerca.BackColor = Color.Orange;
                    break;
                case 3:
                    cerca.BackColor = Color.OrangeRed;
                    break;
                case 4:
                    cerca.BackColor = Color.DarkRed;
                    break;
                default:
                    cerca.BackColor = Color.Black;
                    break;
            }
            cerca.Text = cerca.rodeada.ToString();
        }
    }
}
