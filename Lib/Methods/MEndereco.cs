namespace Lib.Methods
{
   public class MEndereco
   {
      static bool resultado = false;

      public static string Cep(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         input = input.Length > 8 ? input[..8] : input;

         resultado = int.TryParse(input, out int cep);

         if (input.Length < 8) return "";

         if (!resultado) return "";

         string cepN = cep.ToString();

         string novo = cepN[..2] + "."
                     + cepN.Substring(2, 3) + "-"
                     + cepN.Substring(6, 2);

         return novo;
      }

      public static string Numero(string input, bool edit = false, string import = null)
      {
         if (edit && input == "" && import != null) return import;

         resultado = int.TryParse(input, out int numero);

         if (!resultado) return "";

         if (numero == 0) return "S/N";

         return numero.ToString();
      }


   }
}