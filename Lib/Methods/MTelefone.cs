namespace Lib.Methods
{
   public class MTelefone
   {
      static bool resultado = false;

      public static string Codigo(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         // Se o comprimento de input for maior que 2,
         // salva o segundo e terceiro dígito,
         // senão salva o valor original
         input = input.Length > 2 ? input.Substring(1, 3) : input;

         resultado = int.TryParse(input, out int codigo);

         if (input.Length < 2) resultado = false;

         if (!resultado) return "";

         return codigo.ToString();
      }

      public static string Numero(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         // Se o comprimento de input for maior que 9,
         // salva até o nono dígito,
         // senão salva o valor original
         input = input.Length > 9 ? input[..9] : input;

         resultado = int.TryParse(input, out int numero);

         if (input.Length < 8) resultado = false;

         if (!resultado) return "";

         return numero.ToString();
      }

   }
}