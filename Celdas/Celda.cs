using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Celdas {
    /// <summary>
    /// Indica el objeto que se esta mostrando actualmente
    /// </summary>
    public enum Type { 
        empty, 
        grass, 
        bush, 
        tree,
        house 
    }
    /// <summary>
    /// Celda donde se incluye que objeto tendrá
    /// </summary>
    class Celda {
        readonly Type estado;
        readonly int size=50;
        readonly int row,column;
        readonly int x,y;
        readonly List<Bitmap> _objeto = new List<Bitmap>();
        /// <summary>
        /// Creación de una celda donde se declara que objeto tendrá
        /// </summary>
        /// <param name="row">Establece en que fila se encontrará</param>
        /// <param name="column">Establece en que columna se encontrará</param>
        /// <param name="estado">Declara que objeto está dibujado en la celda</param>
        public Celda(int row,int column, Type estado) {
            
            this.estado = estado;
            this.row = row;
            this.column = column;
            /*Se determina la posicion donde se dibujará multiplicando la fila y columna
             por el tamaño de esta*/
            this.x = row * this.size;
            this.y = column * this.size;
            this._objeto.Add(new Bitmap("../../img/path.bmp"));
            this._objeto.Add(new Bitmap("../../img/Grass.png"));
            this._objeto.Add(new Bitmap("../../img/Bush.png"));
            this._objeto.Add(new Bitmap("../../img/Tree.png"));
            this._objeto.Add(new Bitmap("../../img/House.png"));
        }
        /// <summary>
        /// Dibuja la celda actual en la ventana deseada
        /// </summary>
        /// <param name="Lienzo">Pasa la form actual, se recomienda usar this</param>
        public void Dibuja(Form Lienzo) {
            Graphics imagen = Lienzo.CreateGraphics();
            try {
                /*Si la celda acual tiene un objeto se le dibuja un fondo*/
                if(this.estado!=Type.empty)
                    imagen.DrawImage(new Bitmap("../../img/bg.bmp"), this.size * this.row, this.size * this.column, this.size, this.size);
                imagen.DrawImage(this._objeto[(int)this.estado], this.size * this.row, this.size * this.column, this.size, this.size);
            }
            catch (Exception e) {
                MessageBox.Show(e.Message+e.TargetSite);
            }
        }
        /// <summary>
        /// Determina si la celda actual contiene el punto dado.
        /// </summary>
        /// <param name="x">Ingresa la coordenada x del punto a determinar</param>
        /// <param name="y">Ingresa la coordenada y del punto a determinar</param>
        /// <returns></returns>
        public bool Ìncluye(int x,int y) {
            return this.x < x && this.x + this.size > x && this.y < y && this.y + this.size > y;
        }
    }
}
