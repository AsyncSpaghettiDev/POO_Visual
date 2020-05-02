using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras {
    public partial class Form1 : Form {
        private Label etiqueta = new Label();
        private List<Rectangulo> figs;
        public Form1() {
            //InitializeComponent();
            figs = new List<Rectangulo>();

            this.etiqueta.Location = new Point(50, 50);

            this.ClientSize = new Size(400,400);
            this.Controls.Add(etiqueta);
            this.MouseClick += new MouseEventHandler(Mouse_Click);
            this.Paint += new PaintEventHandler(repintar);

        }
        public void Mouse_Click(object sender, MouseEventArgs e) {
            this.etiqueta.Text = String.Format("{0},{1}", e.X, e.Y);           
            Rectangulo pintar = new Rectangulo(e.X,e.Y,20,20);
            pintar.dibuja(this);
            figs.Add(pintar);
        }
        public void repintar(object sender, PaintEventArgs e) {
            foreach (var cuadros in figs)
                cuadros.dibuja(this);
        }
    }
}
