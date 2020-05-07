using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Celdas {
    /// <summary>
    /// Declara el objeto que se esta mostrando actualmente
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
        Type estado;
        int size=50;
        int row,column;
        int x,y;
        List<Bitmap> _objeto = new List<Bitmap>();
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
            this.x = row * size;
            this.y = column * size;
            _objeto.Add(new Bitmap("../../img/path.bmp"));
            _objeto.Add(new Bitmap("../../img/Grass.png"));
            _objeto.Add(new Bitmap("../../img/Bush.png"));
            _objeto.Add(new Bitmap("../../img/Tree.png"));
            _objeto.Add(new Bitmap("../../img/House.png"));
        }
        /// <summary>
        /// Dibuja la celda actual en la ventana deseada
        /// </summary>
        /// <param name="Lienzo">Pasa la form actual, se recomienda usar this</param>
        public void Dibuja(Form Lienzo) {
            Graphics imagen = Lienzo.CreateGraphics();
            try {
                /*Si la celda acual tiene un objeto se le dibuja un fondo*/
                if(estado!=Type.empty)
                    imagen.DrawImage(new Bitmap("../../img/bg.bmp"), size * row, size * column, size, size);
                imagen.DrawImage(_objeto[(int)this.estado], size * row, size * column, size, size);
            }
            catch (Exception e) {
                MessageBox.Show(e.Message+e.TargetSite);
            }
        }
    }
}
