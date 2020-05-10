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
    /// Clase generica con datos básicos como el objeto que estará dibujado y el tamaño del mismo.
    /// </summary>
    abstract class Espacio {
        public Espacio(Type estado) {
            this.estado = estado;
        }
        protected Type estado;
        protected readonly int size=50;
        protected int x,y;
        protected List<Bitmap> _objeto;
        protected void actualiza(List<Bitmap> bitmaps) {
            bitmaps.Add(new Bitmap("../../img/path.bmp"));
            bitmaps.Add(new Bitmap("../../img/Grass.png"));
            bitmaps.Add(new Bitmap("../../img/Bush.png"));
            bitmaps.Add(new Bitmap("../../img/Tree.png"));
            bitmaps.Add(new Bitmap("../../img/House.png"));
        }
        public abstract void Dibuja(Form Lienzo);
    }
    /// <summary>
    /// Celda donde se incluye que objeto tendrá
    /// </summary>
    class Celda:Espacio {
        readonly int row,column;
        /// <summary>
        /// Creación de una celda donde se declara que objeto tendrá
        /// </summary>
        /// <param name="row">Establece en que fila se encontrará</param>
        /// <param name="column">Establece en que columna se encontrará</param>
        /// <param name="estado">Declara que objeto está dibujado en la celda</param>
        public Celda(int row,int column, Type estado):base(estado) {
            this._objeto = new List<Bitmap>();
            this.row = row;
            this.column = column;
            /*Se determina la posicion donde se dibujará multiplicando la fila y columna
             por el tamaño de esta*/
            this.x = row * this.size;
            this.y = column * this.size;
            actualiza(this._objeto);
        }
        /// <summary>
        /// Dibuja la celda actual en la ventana deseada
        /// </summary>
        /// <param name="Lienzo">Pasa la form actual, se recomienda usar this</param>
        public override void Dibuja(Form Lienzo) {
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
    class Cambio:Espacio {
        Label obj_cambio;
        public Cambio(int x,int y,Type estado) : base(estado) {
            this.obj_cambio = new Label();
            this.obj_cambio.Location = new Point(this.x-50,this.y);
            this.obj_cambio.Text = "Objeto a colocar";
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Dibuja la celda actual en la ventana deseada
        /// </summary>
        /// <param name="Lienzo">Pasa la form actual, se recomienda usar this</param>
        public override void Dibuja(Form Lienzo) {
            Graphics imagen = Lienzo.CreateGraphics();
            try {
                imagen.DrawImage(new Bitmap("../../img/bg.bmp"), this.x, this.y,this.size, this.size);
                imagen.DrawImage(this._objeto[(int)this.estado], this.x, this.y,this.size, this.size);
            }
            catch (Exception e) {
                MessageBox.Show(e.Message + e.TargetSite);
            }
        }
    }
}
