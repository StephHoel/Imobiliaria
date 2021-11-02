using Imobiliaria.DataBase;

namespace Imobiliaria.Repositorio
{
   public class LogRepositorio
   {
      static readonly string path = "DataBase/log.db";

      public static void Log(string log)
      {
         DB.Escrever(log, path);
      }
   }
}