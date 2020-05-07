using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Celdas {
    public partial class Juego : Form {
        Button pintar;
        Tablero juego;
        public Juego() {
            Funciones.Diseno(this, 500, 500, "Clon Triple Town","logo.ico");
            juego = new Tablero();
            this.pintar = new Button();
            this.pintar.Location = new Point(350,30);
            this.pintar.Click += new EventHandler(presionar);
            this.Controls.Add(pintar);
        }
        public void presionar(object sender,EventArgs e) {
            juego.pintar_tablero(this);
        }
    }
}
