using System.Drawing;
using System.Windows.Forms;

namespace Figuras {
    class Figura {

    }
    class Rectangulo {
        Pen pluma;
        Color tinta;
        SolidBrush brocha;
        int x, y;
        int width,height;
        public Rectangulo(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            tinta = Color.Black;
            pluma = new Pen(tinta);
            brocha = new SolidBrush(Color.Red);
        }
        public void dibuja(Form lienzo) {
            Graphics pintar = lienzo.CreateGraphics();
            pintar.FillRectangle(this.brocha, this.x, this.y, this.width, this.height);
            pintar.DrawRectangle(this.pluma, this.x, this.y, this.width, this.height);
        }
    }
}
