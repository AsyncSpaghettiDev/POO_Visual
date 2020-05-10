using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Botones {
    class Tablero {
        public readonly List<Celda> cuadricula;
        private readonly int dif;
        private readonly int tamano;
        public Tablero(int tamano,int dif) {
            cuadricula = new List<Celda>();

            this.tamano = tamano;
            this.dif = dif;

            crea_cuadricula(tamano);
            aleatorio(this.cuadricula);
            marcar();
        }
        private void crea_cuadricula(int altura) {
            for(int i = 0; i < altura / 10; i++) 
                for (int j = 0; j < 10; j++)
                    cuadricula.Add(new Celda(10,i,j));
        }
        public void dibujarTablero(Form Lienzo) {
            foreach (var boton in cuadricula)
                    boton.dibujar(Lienzo);
        }
        private void marcar() {
            foreach(var boton in cuadricula)
                foreach(Celda estado in cuadricula) 
                    boton.contar(estado);
        }
        private void aleatorio(List<Celda> tablero) {
            Random rdm = new Random();
            for (int i=0;i<this.dif;i++)
                tablero[rdm.Next(this.tamano)].estado = true;
        }
    }
}
