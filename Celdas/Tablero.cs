using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Celdas {
    /// <summary>
    /// Indica el estado del tablero
    /// </summary>
    public enum Condicion {
        agregando,
        actualizando,
        final
    }
    /// <summary>
    /// Representa una cuadricula donde se ubican celdas
    /// </summary>
    class Tablero {
        readonly List<List<Celda>> cuadricula;
        readonly Condicion condicion_actual;
        Celda seleccionada;
        public Tablero() {
            this.cuadricula = new List<List<Celda>>();
            Inicia_cuadricula(8,8);
            this.condicion_actual = Condicion.agregando;
        }
        /// <summary>
        /// Agrega celdas a la lista de filas que posteriomente esta lista "filas" se agrega a cuadricula en el tamaño especificado
        /// </summary>
        /// <param name="fila">Establece las cantidad de filas deseadas</param>
        /// <param name="columnas">Establece las cantidad de columnas deseadas</param>
        private void Inicia_cuadricula(int fila,int columnas) {
            try {
                for(int i = 0; i < fila; i++) {
                    List<Celda> filas= new List<Celda>();
                    for(int j = 0; j < columnas; j++) {
                        filas.Add(new Celda(i,j,Aleatorio()));
                    }
                    this.cuadricula.Add(filas);
                }
            }
            catch(Exception e) {
                MessageBox.Show(e.Message+e.TargetSite);
            }
        }
        /// <summary>
        /// Agrega celdas a la lista de filas que posteriomente esta lista "filas" se agrega a cuadricula en un tamaño 6x6
        /// </summary>
        private void Inicia_cuadricula() {
            Inicia_cuadricula(6, 6);
        }
        /// <summary>
        /// Dibuja todas las celdas que tiene el tablero
        /// </summary>
        /// <param name="lienzo">Pasa la form actual, se recomienda usar this</param>
        public void Pintar_tablero(Form lienzo) {
            foreach (var fila in this.cuadricula) {
                foreach(Celda espacio in fila){
                    espacio.Dibuja(lienzo);
                }
            }
        }
        public void getSeleccionada(int x,int y) {
            foreach(var fila in this.cuadricula)
                foreach(Celda posible in fila) {
                    if (posible.Ìncluye(x, y)) {
                        this.seleccionada = posible as Celda;
                    }
                }
        }
        public void getProxima(int x,int y) {

        }
        private Type Aleatorio() {
            Random rdm= new Random();
            double prob=rdm.NextDouble();
            if (prob < 0.50)
                return Type.empty;
            else if (prob >= 0.50 && prob < 0.70)
                return Type.grass;
            else if (prob >= 0.70 && prob < 0.85)
                return Type.bush;
            else if (prob >= 0.85 && prob < 0.95)
                return Type.tree;
            else
                return Type.house;
        }
    }
}
