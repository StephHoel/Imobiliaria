using System.Globalization;
using Lib.Enums;

namespace Lib.Methods
{
   public class MCliente
   {
      static bool resultado = false;

      public static string Cpf(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return Encriptografia.Encrypt(import);

         input = input.Length > 11 ? input[..11] : input;

         resultado = long.TryParse(input, out long cpf);

         if (!resultado) return "";

         else return Encriptografia.Encrypt(Input.NormalizeCpf(cpf.ToString()));

      }

      public static string Rg(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return Encriptografia.Encrypt(import);

         input = input.Length > 9 ? input[..9] : input;
         resultado = long.TryParse(input, out long rg);

         if (!resultado) return "";

         else return Encriptografia.Encrypt(Input.NormalizeRg(rg.ToString()));

      }

      public static string DataNasc(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         resultado = System.DateTime.TryParse(input, new CultureInfo("pt-BR"), DateTimeStyles.None, out System.DateTime data);

         if (!resultado) return "";

         return data.ToString("dd/MM/yyyy");
      }

   }
}