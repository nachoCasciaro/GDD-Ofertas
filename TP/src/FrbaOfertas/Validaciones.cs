using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


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

        public static Boolean estaVacio(String texto)
        {
            return texto.Length.Equals(0);
        }

        public static Boolean contieneSoloNumeros(String texto)
        {
            return (texto.All(caracter => Char.IsNumber(caracter)));
        }

        public static Boolean tieneFormatoMail(String texto) { 
            
            return Regex.IsMatch(texto, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");// false o True
        }


        public static Boolean tieneFormatoDeCuit(String texto)
        {
            int i = 0;

            for ( ; i < 2; i++)
            {
                if (!Char.IsNumber(texto[i]))
                    return false;
            }

            if (!texto[i].Equals('-'))
                return false;

            for (i++; i < 11; i++)
            {
                if(!Char.IsNumber(texto[i]))
                    return false;
            }

            if (!texto[i].Equals('-'))
                return false;

            for (i++; i < 13; i++)
            {
                if (!Char.IsNumber(texto[i]))
                    return false;
            }

            return true;
        }

    }
}
