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
        public bool estado { get; set; } = false;
        /// <summary>
        /// Creacion de la celda
        /// </summary>
        /// <param name="cant">Cantidad deseada de botones por renglon</param>
        public Celda(int cant,int fila,int columna) {
            this.lado=355/cant;
            this.y = fila* lado+60;
            this.x = (columna+1)* lado;
            this.Size = new Size(lado,lado);
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
            if (sig.incluye(centro_x + lado, centro_y) && sig.estado)
                this.rodeada++;
            //Izquierda
            if (sig.incluye(centro_x - lado, centro_y) && sig.estado)
                this.rodeada++;
            //Abajo
            if (sig.incluye(centro_x, centro_y + lado) && sig.estado)
                this.rodeada++;
            //Arriba
            if (sig.incluye(centro_x, centro_y - lado) && sig.estado)
                this.rodeada++;

            //Derecha arriba
            if (sig.incluye(centro_x + lado, centro_y + lado) && sig.estado)
                this.rodeada++;
            //Derecha abajo
            if (sig.incluye(centro_x + lado, centro_y - lado) && sig.estado)
                this.rodeada++;
            //Izquierda arriba
            if (sig.incluye(centro_x - lado, centro_y + lado) && sig.estado)
                this.rodeada++;
            //Izquierda abajo
            if (sig.incluye(centro_x - lado, centro_y - lado) && sig.estado)
                this.rodeada++;
        }
        /// <summary>
        /// Determina si la celda contiene el punto dado
        /// </summary>
        /// <param name="x">Coordenada x del punto a evaluar</param>
        /// <param name="y">Coordenada y del punto a evaluar</param>
        /// <returns></returns>
        private bool incluye(int x,int y) {
            return x > this.x && x < this.x + lado && y > this.y && y < this.y + lado;
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
    }
}
