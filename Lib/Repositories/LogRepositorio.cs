using Lib.Classes;

namespace Lib.Repositorio
{
   public class LogRepositorio
   {
      static readonly string path = "Databases/log.db";

      public static void Log(string log)
      {
         DB.Escrever(log, path);
      }
   }
}