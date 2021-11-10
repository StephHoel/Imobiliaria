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

         else return Encriptografia.Encrypt(NormalizeCpf(cpf.ToString()));

      }

      public static string Rg(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return Encriptografia.Encrypt(import);

         input = input.Length > 9 ? input[..9] : input;
         resultado = long.TryParse(input, out long rg);

         if (!resultado) return "";

         else return Encriptografia.Encrypt(NormalizeRg(rg.ToString()));

      }

      public static string DataNasc(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         resultado = System.DateTime.TryParse(input, new CultureInfo("pt-BR"), DateTimeStyles.None, out System.DateTime data);

         if (!resultado) return "";

         return data.ToString("dd/MM/yyyy");
      }

      public static string NormalizeCpf(string input)
      {
         string novo = Normalize(input);

         novo = input[..3] + "."
              + input.Substring(3, 3) + "."
              + input.Substring(6, 3) + "-"
              + input.Substring(9, 2);

         return novo;
      }

      public static string NormalizeRg(string input)
      {

         string novo = Normalize(input);

         novo = input[..2] + "."
              + input.Substring(2, 3) + "."
              + input.Substring(5, 3) + "-"
              + input.Substring(8, 1);

         return novo;
      }

      public static string Normalize(string input)
      {
         string novo = input;

         if (input.Split('.').Length > 0)
         {
            var verf = input.Split('.');
            novo = "";
            foreach (var v in verf)
               novo += v;
         }

         if (input.Split('-').Length > 0)
         {
            var verf = novo.Split('-');
            novo = "";
            foreach (var v in verf)
               novo += v;
         }

         return novo;
      }

      
   }
}