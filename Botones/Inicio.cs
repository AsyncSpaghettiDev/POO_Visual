using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Botones {
    class Inicio :Form{
        private List<Button> cambios;
        private String[] dif=new String[]{
            "Fácil",
            "Medio",
            "Dificil"
        };
        public Inicio() {
            InitializeComponents();
        }
        public void InitializeComponents() {
            Funciones.Diseno(this, 400, 150,"Elige Dificultad", "menu.ico");

            this.cambios = new List<Button>();

            for(int i = 0; i < 3; i++) {
                cambios.Add(new Button());
                cambios[i].Text = dif[i];
                if (i == 0)
                    cambios[0].Location = new Point(30, 50);
                else
                    cambios[i].Location = new Point(cambios[i-1].Location.X+120, 50);

                this.Controls.Add(cambios[i]);
                this.cambios[i].Click+= new EventHandler(cambiar);
            }
        }
        private void cambiar(object sender, EventArgs e) {
            switch ((sender as Button).Text) {
                case "Fácil": new Juego(5).Show();
                    break;
                case "Medio": new Juego(10).Show();
                    break;
                case "Dificil":new Juego(15).Show();
                    break;
            }
            Hide();
        }
        
    }
}
