using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Celdas {
    public enum Type { 
        empty, 
        grass, 
        bush, 
        tree,
        house 
    }
    class Celda {
        Type estado;
        int size=50;
        int row,column;
        int x,y;
        List<Bitmap> _objeto = new List<Bitmap>();
        public Celda(int row,int column, Type estado) {
            
            this.estado = estado;
            this.row = row;
            this.column = column;
            this.x = row * size;
            this.y = column * size;
            _objeto.Add(new Bitmap("../../img/path.bmp"));
            _objeto.Add(new Bitmap("../../img/Grass.png"));
            _objeto.Add(new Bitmap("../../img/Bush.png"));
            _objeto.Add(new Bitmap("../../img/Tree.png"));
            _objeto.Add(new Bitmap("../../img/House.png"));
        }
        public void Dibuja(Form Lienzo) {
            Graphics imagen = Lienzo.CreateGraphics();
            try {
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
