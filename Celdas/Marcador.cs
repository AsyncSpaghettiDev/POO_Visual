using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Celdas {
    class Marcador {
        Cambio prox;
        Label puntaje;
        public int puntos { get; set; }
        public Marcador(int x,int y) {
            this.prox = new Cambio(x, y, this.probab());
            this.puntaje = new Label();
            this.puntaje.Location = new Point(400, 0);
            this.puntaje.Text = String.Format("Puntos totales\n{0}",this.puntos);
        }
        private Type probab() {
            Random rdm= new Random();
            double prob=rdm.NextDouble();
            if (prob < 0.60)
                return Type.grass;
            else if (prob >= 0.60 && prob < 0.90)
                return Type.bush;
            else if (prob >= 0.90 && prob < 0.95)
                return Type.tree;
            else
                return Type.house;
        }
    }
}
