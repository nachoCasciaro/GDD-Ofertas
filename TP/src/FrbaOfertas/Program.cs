using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Login.Login());
            //Application.Run(new AbmRol.MenuAbmRol());
            //Application.Run(new CargaCredito.CargaCredito(1));
            //Application.Run(new Menu_Principal.MenuProveedor(25));
            //Application.Run(new Menu_Principal.MenuCliente(1));
        }
    }
}
