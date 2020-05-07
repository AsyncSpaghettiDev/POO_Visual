using System.Drawing;
using System.Windows.Forms;

namespace Figuras {
    abstract class Figura {
        protected Pen pluma;
        public Color tinta { get; set; }
        public SolidBrush brocha { get; set; }
        protected int x, y;
        protected int width,height;
        public Figura(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            tinta = Color.Black;
            pluma = new Pen(tinta);
            brocha = new SolidBrush(Color.Red);
        }
        public virtual void dibuja(Form Lienzo) { }
        /// <summary>
        /// Determina si el punto dado se encuentra en la figura
        /// </summary>
        /// <param name="p_x">Ingresar la coordenada X del punto a conocer</param>
        /// <param name="p_y">Ingresar la coordenada Y del punto a conocer</param>
        /// <returns>Si el punto dado se encuentra en la figura</returns>
        public bool Incluye(int p_x, int p_y) {
            return (p_x >= this.x && p_x <= this.x + this.width) && (p_y >= this.y & p_y <= this.y + this.height);
        }
    }
    class Rectangulo:Figura {
        public Rectangulo(int x, int y, int width, int height):base(x,y,width,height) {
        }
        public override void dibuja(Form lienzo) {
            Graphics pintar = lienzo.CreateGraphics();
            pintar.FillRectangle(this.brocha, this.x, this.y, this.width, this.height);
            pintar.DrawRectangle(this.pluma, this.x, this.y, this.width, this.height);
            pintar.Dispose();
        }
    }
    class Elipse : Figura {
        public Elipse(int x, int y, int width, int height) : base(x, y, width, height) {
        }
        public override void dibuja(Form lienzo) {
            Graphics pintar = lienzo.CreateGraphics();
            pintar.FillEllipse(this.brocha, this.x, this.y, this.width, this.height);
            pintar.DrawEllipse(this.pluma, this.x, this.y, this.width, this.height);
        }
    }
}
