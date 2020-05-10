using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Botones {
    class Inicio :Form{
        private List<Button> cambios;
        private Button salir,custom;
        private readonly String[] dif=new String[]{
            "Fácil",
            "Medio",
            "Dificil"
        };
        public Inicio() {
            InitializeComponents();
        }
        public void InitializeComponents() {
            Funciones.Diseno(this, 400, 150,"Elige Dificultad", "menu");

            this.cambios = new List<Button>();

            for(int i = 0; i < 3; i++) {
                this.cambios.Add(new Button());
                this.cambios[i].Text = this.dif[i];
                if (i == 0)
                    this.cambios[0].Location = new Point(30, 20);
                else
                    this.cambios[i].Location = new Point(this.cambios[i-1].Location.X+120, 20);
                this.cambios[i].Enabled = true;
                this.Controls.Add(this.cambios[i]);
                this.cambios[i].Click+= new EventHandler(cambiar);
            }
            this.custom = new Button();
            this.custom.Location = new Point(this.cambios[1].Location.X - 60, this.cambios[1].Location.Y + 40);
            this.custom.Text = "Custom";
            this.custom.Click += new EventHandler(custom_J);
            this.Controls.Add(this.custom);

            this.salir = new Button();
            this.salir.Location = new Point(this.cambios[1].Location.X+60, this.cambios[1].Location.Y +40);
            this.salir.Text = "Salir";
            this.salir.Click += new EventHandler(Funciones.Cerrar);
            this.Controls.Add(this.salir);
        }
        private void custom_J(object sender, EventArgs e) {
        }
        private void cambiar(object sender, EventArgs e) {
            Dispose(false);
            switch ((sender as Button).Text) {
                case "Fácil": new Juego(10).Show();
                    break;
                case "Medio": new Juego(40).Show();
                    break;
                case "Dificil":new Juego(62).Show();
                    break;
            }
        }
    }
}
