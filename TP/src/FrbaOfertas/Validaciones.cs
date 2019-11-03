using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LINQ;

namespace FrbaOfertas
{
    class Validaciones
    {
        public bool TelefonoValido(String unTelefono)
        {
            return unTelefono.All(char.IsDigit);
        }

        public bool CUITValido(String unCUIT)
        {
            return unCUIT.All(char.IsDigit) && unCUIT.Count() == 11;
        }

        public bool MailValido(String unMail)
        {
            return unMail.Contains("@");
        }

        public bool CargaCreditoValida(int unMonto)
        {
            return unMonto > 0; 
        }

    }
}
