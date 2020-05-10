using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Botones {
    class Tablero {
        public readonly List<Celda> cuadricula;
        private readonly int dif;
        private readonly int tamano,ancho,alto;
        public Tablero(int ancho,int alto,int dif) {
            this.cuadricula = new List<Celda>();
            this.ancho = ancho;
            this.alto = alto;
            this.tamano = ancho*alto;
            this.dif = dif;

            crea_cuadricula(this.ancho, this.alto);
            aleatorio(this.cuadricula);
            marcar();
        }
        private void crea_cuadricula(int filas,int columnas) {
            for(int i = 0; i < columnas; i++) 
                for (int j = 0; j < filas; j++)
                    this.cuadricula.Add(new Celda(i,j));
        }
        public void dibujarTablero(Form Lienzo) {
            foreach (var boton in this.cuadricula)
                    boton.dibujar(Lienzo);
        }
        private void marcar() {
            foreach(var boton in this.cuadricula)
                foreach(Celda estado in this.cuadricula) 
                    boton.contar(estado);
        }
        public void actualiza(Form Lienzo) {
            ComponentResourceManager imgs = new ComponentResourceManager(typeof(recursos));
            foreach (var item in cuadricula) {
                if (!item.estado)
                    item.Enabled = false;
                else
                    item.Image = new Bitmap(imgs.GetObject("mina") as Bitmap,cuadricula[0].lado-4, cuadricula[0].lado - 4);
            }
            dibujarTablero(Lienzo);
        }
        private void aleatorio(List<Celda> tablero) {
            Random rdm = new Random();
            for (int i=0;i<this.dif;i++)
                tablero[rdm.Next(this.tamano)].estado = true;
        }
    }
}
