using System;
using System.Windows.Forms;
using System.Drawing;

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
        /// <param name="Titulo">Ingresa el nombre deseado de la ventana</param>
        /// <param name="nombre">Ingresa el nombre del icono de la ventana, nota: poner en bin/Debug/</param>
    public static void Diseno(Form Lienzo,int x,int y,String Titulo,String nombre) {
        Lienzo.Size = new Size(x, y);
        Lienzo.Icon = new Icon("./"+nombre);
        Lienzo.Text = Titulo;

        Lienzo.FormBorderStyle = FormBorderStyle.Fixed3D;
        Lienzo.MaximizeBox = false;
        Lienzo.MinimizeBox = false;

        Lienzo.StartPosition = FormStartPosition.CenterScreen;
        Lienzo.FormClosed += new FormClosedEventHandler(Cerrar);
    }
    private static void Cerrar(object sender, EventArgs e) => Application.Exit();
}