using System.Text.RegularExpressions;

namespace ChallengeBp4.Modelos
{
    public class ValidadorCliente
    {
        public static string validarCliente(Cliente cliente)
        {
            string formatoMail = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            string formatoCuit = @"^\d{2}-\d{8}-\d{1}$";

            Regex regexMail = new Regex(formatoMail);
            Regex regexCuit = new Regex(formatoCuit);

            if (!regexMail.IsMatch(cliente.Email))
            {
                return "El mail no tiene un formato valido";
            }
            if (!regexCuit.IsMatch(cliente.Cuit))
            {
                return "El cuit no tiene un formato valido";
            }

            return "";
        }
    }
}
