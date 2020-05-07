using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras {
    enum EstadoActual { seleccionando, rectangulo, elipse }
    public partial class Form1 : Form {
        private Label etiqueta = new Label();
        private List<Figura> figs;
        EstadoActual estado= EstadoActual.seleccionando;
        private bool dibujando=false;
        private int temp_x;
        private int temp_y;
        private Button Elipse;
        private Button Rectangulo;
        private Button Seleccion;
        
        public Form1() {
            figs = new List<Figura>();
            this.Elipse = new Button();
            this.Rectangulo = new Button();
            this.Seleccion = new Button();

            this.Elipse.Location = new Point(400,50);
            this.Rectangulo.Location = new Point(300,50);
            this.Seleccion.Location = new Point(200,50);
            this.etiqueta.Location = new Point(50, 50);

            this.Elipse.Text = "Elipse";
            this.Rectangulo.Text = "Rectángulo";
            this.Seleccion.Text = "Selecciona";

            this.Elipse.TabIndex = 2;
            this.Rectangulo.TabIndex = 1;
            this.Seleccion.TabIndex = 0;

            this.Elipse.Click += new EventHandler(Elipse_Click);
            this.Rectangulo.Click+=new EventHandler(Rectangulo_Click);
            this.Seleccion.Click+=new EventHandler(Seleccion_Click);

            this.ClientSize = new Size(600,400);
            this.Controls.Add(etiqueta);
            this.Controls.Add(this.Elipse);
            this.Controls.Add(this.Rectangulo);
            this.Controls.Add(this.Seleccion);

            this.MouseClick += new MouseEventHandler(Mouse_Click);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.Paint += new PaintEventHandler(repintar);

        }
        public void Mouse_Click(object sender, MouseEventArgs e) {
            this.etiqueta.Text = String.Format("{0},{1}", e.X, e.Y);
            if(e.Button.Equals(MouseButtons.Left)&& this.estado.Equals(EstadoActual.seleccionando)) {
                Figura seleccionada=null;
                seleccionada = GetFigura(e.X, e.Y);
                if (seleccionada != null) {
                    seleccionada.brocha = new SolidBrush(Color.Blue);
                }
                    
            }
        }
        private Figura GetFigura(int x,int y) {
            foreach(Figura f in figs) {
                if (f.Incluye(x, y))
                    return f;
            }
            return null;
        }
        private void Seleccion_Click(object sender,EventArgs e) {
            estado = EstadoActual.seleccionando;
        }
        private void Elipse_Click(object sender, EventArgs e) {
            estado = EstadoActual.elipse;
        }
        private void Rectangulo_Click(object sender, EventArgs e) {
            estado = EstadoActual.rectangulo;
        }
        private void Form1_MouseDown(object sender,MouseEventArgs e) {
            this.temp_x = e.X;
            this.temp_y = e.Y;
            if (!dibujando & estado!=EstadoActual.seleccionando)
                dibujando = true;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if (dibujando) {
                Graphics pintar = this.CreateGraphics();
                switch (estado) {
                    case EstadoActual.rectangulo:
                        pintar.DrawRectangle(new Pen(Color.Black), this.temp_x, this.temp_y, e.X - this.temp_x, e.Y - this.temp_y);
                    break;
                    case EstadoActual.elipse:
                        pintar.DrawEllipse(new Pen(Color.Black), this.temp_x, this.temp_y, e.X - this.temp_x, e.Y - this.temp_y);
                    break;
            }
                
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            if (dibujando) {
                Figura f=null;
                switch (estado) {
                    case EstadoActual.rectangulo:
                        f= new Rectangulo(this.temp_x,this.temp_y, Math.Abs(e.X-this.temp_x),Math.Abs(e.Y-this.temp_y));
                    break;
                    case EstadoActual.elipse:
                        f=new Elipse(this.temp_x,this.temp_y,e.X-this.temp_x,e.Y-this.temp_y);
                    break;
                }
                f.dibuja(this);
                figs.Add(f);
                this.dibujando = false;
            }
        }
        private void repintar(object sender, PaintEventArgs e) {
            foreach (Figura f in figs)
                f.dibuja(this);

        }
    }
}
