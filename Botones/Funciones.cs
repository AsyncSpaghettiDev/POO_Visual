using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Botones {
    /// <summary>
    /// Configuraciones genericas.
    /// </summary>
    public class Funciones {
        /// <summary>
        /// <para> Establece el tamaño de la ventana, y su icono
        /// Ademas de dejar la ventana estática para evitar su redimension. </para>
        /// </summary>
        /// <param name="Lienzo"> Pasa la form actual, se recomienda usar this </param>
        /// <param name="x">Ingresa la dimension X deseada de la ventana </param>
        /// <param name="y">Ingresa la dimension Y deseada de la ventana </param>
        /// <param name="nombre">Ingresa el nombre del icono de la figura, nota: poner en bin/Debug/</param>
        public static void Diseno(Form Lienzo,int x,int y,String nombre) {
            Lienzo.Size = new Size(x, y);
            Lienzo.Icon = new Icon("./"+nombre);

            Lienzo.FormBorderStyle = FormBorderStyle.Fixed3D;
            Lienzo.MaximizeBox = false;
            Lienzo.MinimizeBox = false;

            Lienzo.FormClosed += new FormClosedEventHandler(cerrar);
        }
        private static void cerrar(object sender, EventArgs e) => Application.Exit();
    }
}
