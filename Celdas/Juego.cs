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
        readonly Button pintar;
        readonly Tablero juego;
        public Juego() {
            Funciones.Diseno(this, 420, 475, "Clon Triple Town","logo.ico");
            this.juego = new Tablero();
            this.pintar = new Button();
            this.pintar.Size = new Size(50,30);
            this.pintar.Location = new Point(185,401);
            this.pintar.Click += new EventHandler(Presionar);
            this.Controls.Add(this.pintar);
            this.ShowDialog();
        }
        public void Presionar(object sender,EventArgs e) {
            this.juego.Pintar_tablero(this);
        }
    }
}
