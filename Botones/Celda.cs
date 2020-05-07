using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Botones {
    /// <summary>
    /// Creacion de un boton tipo celda
    /// </summary>
    public class Celda:Button {
        public int x { get; set; }
        public int y { get; set; }
        private int lado;
        private bool _estado=false;
        public bool estado {
            get => _estado;
            set => _estado = value;
        }
        /// <summary>
        /// Creacion de la celda
        /// </summary>
        /// <param name="cant">Cantidad deseada de botones por renglon</param>
        public Celda(int cant) {
            this.lado=355/cant;
            this.Size = new Size(lado,lado);
        }
        private void setText() {
            if (!estado)
                this.Text = "";
            else
                this.Text = "X";
        }
        /// <summary>
        /// Establecer la posicion deseada del boton
        /// </summary>
        /// <param name="x">Ingresar el valor inicial de X</param>
        /// <param name="anterior">Dar la celda anterior</param>
        public void setPos(int x,Celda anterior) {
            this.x = anterior.x+lado;
            this.y = anterior.y;
        }
        /// <summary>
        /// Establecer la posicion deseada del boton, indicando X, Y
        /// </summary>
        /// <param name="x">Ingresar el valor inicial de X</param>
        /// <param name="y">Ingresar el valor inicial de Y</param>
        public void setPos(int x,int y) {
            this.x = x;
            this.y = y;
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
