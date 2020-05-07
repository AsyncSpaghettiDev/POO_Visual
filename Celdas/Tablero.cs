using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Celdas {
    public enum Condicion {
        agregando,
        actualizando,
        final
    }
    class Tablero {
        List<List<Celda>> cuadricula;
        Condicion condicion_actual;
        Celda seleccionada;
        public Tablero() {
            cuadricula = new List<List<Celda>>();
            inicia_cuadricula();
            this.condicion_actual = Condicion.agregando;
        }
        private void inicia_cuadricula() {
            Random rdm= new Random();
            try {
                for(int i = 0; i < 6; i++) {
                    List<Celda> filas= new List<Celda>();
                    for(int j = 0; j < 6; j++) {
                        filas.Add(new Celda(i,j,(Type)rdm.Next(3)));
                    }
                    cuadricula.Add(filas);
                }
            }
            catch(Exception e) {
                MessageBox.Show(e.Message+e.TargetSite);
            }
        }
        public void pintar_tablero(Form lienzo) {
            foreach(var fila in cuadricula) {
                foreach(Celda espacio in fila){
                    espacio.Dibuja(lienzo);
                }
            }
        }
    }
}
