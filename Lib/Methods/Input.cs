using System;
using System.Globalization;
using Lib.Enums;

namespace Lib.Methods
{
   public class Input
   {
      static bool resultado = true;

      protected internal static string PedeString(string titulo, bool edit = false, string import = null)
      {
         Console.Write(titulo);
         string str = Console.ReadLine();

         if (edit && str == "" && import != null)
         {
            return import;
         }

         return str;
      }

      protected internal static string Cep()
      {
         int cep;
         do
         {
            Console.Write("CEP (apenas números): ");
            string cepInput = Console.ReadLine();
            cepInput = cepInput.Length > 8 ? cepInput[..8] : cepInput;

            resultado = Int32.TryParse(cepInput, out cep);

            if (cepInput.Length < 8) resultado = false;
            if (resultado == false) Console.WriteLine("**Digite apenas 8 dígitos**");
         } while (resultado == false);

         string cepN = cep.ToString();

         string novo = cepN[..2] + "."
                     + cepN.Substring(2, 3) + "-"
                     + cepN.Substring(6, 2);
         return novo;
      }

      protected internal static int Numero()
      {
         int numero;
         do
         {
            Console.Write("Número (digite 0 para S/N): ");
            string numeroInput = Console.ReadLine();

            resultado = Int32.TryParse(numeroInput, out numero);

            if (resultado == false) Console.WriteLine("**Digite apenas números**");
         } while (resultado == false);

         return numero;
      }

      protected internal static string EstadoUF()
      {
         Console.WriteLine("Estado (UF)");

         foreach (int i in Enum.GetValues(typeof(EstadosUF)))
         {
            Console.WriteLine(Enum.GetName(typeof(EstadosUF), i));
         }

         bool input = false;
         string uf;

         do
         {
            Console.Write("Digite apenas a sigla do Estado: ");
            uf = Console.ReadLine();
            uf = uf.Length > 2 ? uf[..2] : uf;

            foreach (int i in Enum.GetValues(typeof(EstadosUF)))
            {
               if (uf.ToUpper() == Enum.GetName(typeof(EstadosUF), i))
               {
                  input = true;
                  break;
               }
            }

         } while (!input);

         return uf.ToUpper();
      }

      protected internal static string Situacao()
      {
         Console.WriteLine("O imóvel está destinado à: ");

         foreach (int i in Enum.GetValues(typeof(Situacao)))
         {
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Situacao), i));
         }

         bool input = false;
         int output = 0;

         do
         {
            Console.WriteLine();
            Console.Write("Digite o número da opção: ");
            input = int.TryParse(Console.ReadLine(), out output);
         } while (!input);

         return Enum.GetName(typeof(Situacao), output);
      }

      protected internal static string Email(bool edit = false, string import = null)
      {
         string email;
         resultado = false;

         do
         {
            Console.Write("Email (ex@exemp.lo): ");
            email = Console.ReadLine();

            if (edit && email == "" && import != null)
            {
               return import;
            }

            try
            {
               var test = email.Split('@');

               if (test.Length >= 2
                && test[0].Length != 0
                && test[1].Split('.')[1].Length >= 2)
               {
                  // Console.WriteLine("Email valido");
                  resultado = true;
               }
            }
            catch (Exception)
            {
               // Console.WriteLine("Email invalido");
               resultado = false;
            }

            if (!resultado)
               Console.WriteLine("**Digite corretamente o email**");

         } while (!resultado);

         return email;
      }

      protected internal static string Cpf(string titulo, bool edit = false, string import = null)
      {
         long cpf;
         do
         {
            Console.Write(titulo);
            string cpfInput = Console.ReadLine();
            if (edit && cpfInput == "" && import != null)
            {
               return Encriptografia.Encrypt(import);
            }
            else
            {
               cpfInput = cpfInput.Length > 11 ? cpfInput[..11] : cpfInput;
               resultado = Int64.TryParse(cpfInput, out cpf);
               if (!resultado) Console.WriteLine("**Digite apenas números**");
            }
         } while (!resultado);

         return Encriptografia.Encrypt(NormalizeCpf(cpf.ToString()));
      }

      protected internal static string Rg(bool edit = false, string import = null)
      {
         long rg;
         do
         {
            Console.Write("RG (apenas números): ");
            string rgInput = Console.ReadLine();
            if (edit && rgInput == "" && import != null)
            {
               return Encriptografia.Encrypt(import);
            }
            rgInput = rgInput.Length > 9 ? rgInput[..9] : rgInput;
            resultado = Int64.TryParse(rgInput, out rg);
            if (resultado == false) Console.WriteLine("**Digite apenas números**");
         } while (resultado == false);

         return Encriptografia.Encrypt(NormalizeRg(rg.ToString()));
      }

      protected internal static string OrgaoUF(bool edit = false, string import = null)
      {
         string orgao, uf;
         string[] imp = import.Split("/");

         do
         {
            Console.Write("Órgão Expedidor: ");
            orgao = Console.ReadLine();

            if (edit && orgao == "" && import != null)
            {
               orgao = imp[0];
            }
            else
            {
               Console.WriteLine("**Informe o Órgão Expedidor de seu documento**");
               Console.WriteLine();
            }

         } while (orgao != "");

         do
         {
            Console.Write("UF: ");
            uf = Console.ReadLine().ToUpper();

            if (edit && uf == "" && import != null)
            {
               uf = imp[1];
            }

            if (uf.Length != 2)
               Console.WriteLine("**UF Inválido**");

         } while (uf.Length != 2);

         return orgao + "/" + uf;
      }

      protected internal static string DataNasc(bool edit = false, string import = null)
      {
         DateTime data;
         string linha;

         do
         {
            Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
            linha = Console.ReadLine();

            if (edit && linha == "" && import != null)
            {
               return import;
            }

            resultado = DateTime.TryParse(linha, new CultureInfo("pt-BR"), DateTimeStyles.None, out data);

            if (!resultado)
               Console.WriteLine("**Use o formato correto (dd/mm/aaaa)**");

         } while (!resultado);

         return data.ToString("dd/MM/yyyy");
      }

      protected internal static string EstadoCivil(bool edit = false, string import = null)
      {
         int output;

         Console.WriteLine("Estado Civil:");

         foreach (int i in Enum.GetValues(typeof(EstadoCivil)))
         {
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(EstadoCivil), i));
         }

         Console.WriteLine();

         do
         {
            Console.Write("Digite o número da opção: ");
            string inp = Console.ReadLine();

            if (edit && inp == "" && import != null)
            {
               return import;
            }

            resultado = int.TryParse(inp, out output);

            if (!resultado)
            {
               Console.WriteLine("**Digite uma opção válida**");
               Console.WriteLine();
            }

         } while (!resultado);

         return Enum.GetName(typeof(EstadoCivil), output);
      }

      protected internal static string FichaRapida(bool edit = false, string import = null)
      {
         int output;

         Console.WriteLine("Ficha Rapida:");

         foreach (int i in Enum.GetValues(typeof(FichaRapida)))
         {
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(FichaRapida), i));
         }

         Console.WriteLine();

         do
         {
            Console.Write("Digite o número da opção: ");
            string inp = Console.ReadLine();

            if (edit && inp == "" && import != null)
            {
               return import;
            }

            resultado = int.TryParse(inp, out output);

            if (!resultado)
            {
               Console.WriteLine("**Digite uma opção válida**");
               Console.WriteLine();
            }
         } while (!resultado);

         return Enum.GetName(typeof(FichaRapida), output);
      }

      protected internal static string NormalizeCpf(string cpf)
      {
         string novo = cpf[..3] + "."
                     + cpf.Substring(3, 3) + "."
                     + cpf.Substring(6, 3) + "-"
                     + cpf.Substring(9, 2);
         return novo;
      }

      protected internal static string NormalizeRg(string rg)
      {
         string novo = rg[..2] + "."
                     + rg.Substring(2, 3) + "."
                     + rg.Substring(5, 3) + "-"
                     + rg.Substring(8, 1);
         return novo;
      }

      protected internal static string Senha(string titulo = "Senha")
      {
         Console.Write($"{titulo}: ");
         return Password();
      }

      private static string Password()
      {
         string senha = "";
         do
         {
            ConsoleKeyInfo key = Console.ReadKey(true);
            // Backspace Should Not Work
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
               senha += key.KeyChar;
               Console.Write("*");
            }
            else
            {
               if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
               {
                  senha = senha[0..^1];
                  Console.Write("\b \b");
               }
               else if (key.Key == ConsoleKey.Enter)
               {
                  Console.WriteLine();
                  break;
               }
            }
         } while (true);
         return Encriptografia.Encrypt(senha);
      }
   }
}