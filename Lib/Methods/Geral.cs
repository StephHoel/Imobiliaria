using Lib.Enums;

namespace Lib.Methods
{
   public class Geral
   {
      static bool resultado = false;

      public static string RetornaString(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         return input;
      }

      public static string Email(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         var test = input.Split('@');

         if (test.Length >= 2
          && test[0].Length != 0
          && test[1].Split('.')[1].Length >= 2)
            return input;

         else return "";
      }

      public static string SimOuNao(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         // Se o comprimento de input for maior que 1,
         // salva o primeiro dígito,
         // senão salva o valor original
         input = input.Length > 1 ? input[..1] : input;

         if (input.ToUpper() == "S") return "True";

         else if (input.ToUpper() == "N") return "False";

         else return "";
      }

      public static string Uf(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         if (input.Length != 2) return "";

         return input.ToUpper();
      }

      public static string Enums(string input, string enums, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         resultado = int.TryParse(input, out int output);

         if (!resultado) return "";

         if (enums == "Situação")
            return System.Enum.GetName(typeof(Situacao), output);

         else if (enums == "Estado Civil")
            return System.Enum.GetName(typeof(EstadoCivil), output);

         else if (enums == "Ficha Rápida")
            return System.Enum.GetName(typeof(FichaRapida), output);

         return "";
      }

      

   }
}