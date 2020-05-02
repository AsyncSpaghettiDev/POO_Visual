using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Botones {
    public class Celda:Button {
        public int x { get; set; }
        public int y { get; set; }
        private int lado;
        private bool _estado=false;
        public bool estado {
            get => _estado;
            set => _estado = value;
        }
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
        public void setPos(int x,Celda anterior) {
            this.x = anterior.x+lado;
            this.y = anterior.y;
        }
        public void setPos(int x,int y) {
            this.x = x;
            this.y = y;
        }
        public void dibujar(Form pantalla) {
            setText();
            this.Location=new Point(this.x,this.y);
            pantalla.Controls.Add(this);
        }
    }
}
