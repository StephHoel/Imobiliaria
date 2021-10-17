using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using Imobiliaria.Classes;
using Imobiliaria.Methods;

namespace Imobiliaria
{
   public class Cliente
   {
      // Variáveis
      private static bool resultado = true;
      static readonly PessoaRepositorio repositorio = new();

      // Funções Disponíveis
      protected internal static void NovoCliente()
      {
         int id = repositorio.ProximoId();

         if (id < 0)
         {
            Console.WriteLine("Erro no sistema, reinicie a aplicação");
            Console.ReadLine();
         }
         else
         {
            Output.Titulo("Adicionando Novo Cliente");

            /* O que precisa para o cliente?
               -> CPF (encriptografado) [int] [primary key]
               -> Nome Completo [string]
               -> RG (encriptografado) [int]
               -> Órgão/UF (RG) [string]
               -> Data de Nascimento [string]
               -> Nacionalidade [string]
               -> Naturalidade [string]
               -> Filiação Pai [string]
               -> Filiação Mãe [string]
               -> EstadoCivil [Enum] [Solteiro, Casado, Viuvo, Divorciado, Separado, UniaoEstavel] (criado)
               -> FichaRapida [Enum] [NaoEnviada, EmAnálise, Aprovada, Reprovada] (criado)
               -> Email
               ->
               -> Endereço (outra table)
               -> Telefone (outra table)
               ->
            */

            //Informação Básica do Cliente
            string cpf = Encriptografia.Encrypt(Cpf("CPF (apenas números): "));
            string nome = Input.PedeString("Nome Completo (sem abreviação): ");
            string rg = Encriptografia.Encrypt(Rg());
            string orgaouf = OrgaoUF();
            string dataNasc = DataNasc();
            string estadoCivil = EstadoCivil();
            string naturalidade = Input.PedeString("Naturalidade: ");
            string nacionalidade = Input.PedeString("Nacionalidade: ");
            string pai = Input.PedeString("Nome do Pai: ");
            string mae = Input.PedeString("Nome da Mãe: ");
            string email = Email();
            string fichaRapida = FichaRapida();

            //Telefone(s) do Cliente
            Telefones.NovoTelefone(cpf);

            //Endereço
            Enderecos.NovoEndereco(cpf);

            Pessoa cliente = new(id, cpf, nome, rg, orgaouf, dataNasc, naturalidade, nacionalidade, pai, mae, estadoCivil, fichaRapida, email);

            string cliente2 = $"{id}|{cpf}|{nome}|{rg}|{orgaouf}|{dataNasc}|{naturalidade}|{nacionalidade}|{pai}|{mae}|{estadoCivil}|{fichaRapida}|{email}|{false}";

            repositorio.Insere(cliente, cliente2);
         }

      }

      protected internal static void ListarCliente(List<Pessoa> objeto, List<Telefone> telefone)
      {
         Console.WriteLine("=====================");
         Console.WriteLine("**Listando Clientes**");
         Console.WriteLine("=====================");
         foreach (var person in objeto)
         {
            if (!person.RetornaExcluido())
            {
               Console.WriteLine();
               Console.Write($"CPF: {person.RetornaCpf()} | RG: {person.RetornaRg()} | Nome: {person.RetornaNome()}");
               foreach (var tel in telefone)
               {
                  if (tel.RetornaCpf() == person.RetornaCpf() && !tel.RetornaExcluido())
                  {
                     Console.Write($" | Telefone: ({tel.RetornaCod()}) {tel.RetornaNumero()}");
                     Console.Write(tel.RetornaRecado() ? " / Recado" : "");
                     Console.Write(tel.RetornaWhatsapp() ? " / Whatsapp" : "");
                  }
               }
            }
         }
         Console.WriteLine();
         Console.WriteLine();
         Console.WriteLine("=====================");
      }

      protected internal static void AtualizarCliente(List<Pessoa> pessoa)
      {
         Output.Titulo("Atualizando Cliente");

         //Pergunta qual cliente será editado
         string inputCpf = Cpf("Insira o CPF do cliente (apenas números): ");
         int id = -1;
         string cpf = "", nome = "", rg = "", orgaouf = "", dataNasc = "", estadoCivil = "", naturalidade = "", nacionalidade = "", pai = "", mae = "", email = "", fichaRapida = "";

         //Pegar Posição do Cliente escolhido
         foreach (var person in pessoa)
         {
            if (person.RetornaCpf() == inputCpf && !person.RetornaExcluido())
            {
               id = person.RetornaId();
               cpf = person.RetornaCpf();
               nome = person.RetornaNome();
               rg = person.RetornaRg();
               orgaouf = person.RetornaOrgaoUF();
               dataNasc = person.RetornaDataNasc();
               estadoCivil = person.RetornaEstadoCivil();
               naturalidade = person.RetornaNaturalidade();
               nacionalidade = person.RetornaNacionalidade();
               pai = person.RetornaPai();
               mae = person.RetornaMae();
               email = person.RetornaEmail();
               fichaRapida = person.RetornaFichaRapida();
               break;
            }
         }

         Console.WriteLine(id);

         if (id < 0)
         {
            Console.WriteLine("Erro no sistema, reinicie a aplicação");
            Console.ReadLine();
         }
         else
         {
            string temp;

            //Atualizar CPF
            Console.WriteLine($"O CPF anterior era {cpf} e para mantê-lo, basta digitar novamente");
            temp = Encriptografia.Encrypt(Cpf("CPF (apenas números): "));
            cpf = temp == "" ? cpf : temp;

            //Atualizar Nome
            Console.WriteLine($"O nome anterior era {nome} e para mantê-lo, basta digitar novamente");
            temp = Input.PedeString("Nome Completo (sem abreviação): ");
            nome = temp == "" ? nome : temp;

            //Atualizar RG
            Console.WriteLine($"O RG anterior era {rg} e para mantê-lo, basta digitar novamente");
            temp = Encriptografia.Encrypt(Rg());
            rg = temp == "" ? rg : temp;

            //Atualizar Órgão e UF
            Console.WriteLine($"O Órgão e UF anterior eram {orgaouf} e para mantê-lo, basta digitar novamente");
            temp = OrgaoUF();
            orgaouf = temp == "" ? orgaouf : temp;

            //Atualizar Data de Nascimento
            Console.WriteLine($"A data de nascimento anterior era {dataNasc} e para mantê-lo, basta digitar novamente");
            temp = DataNasc();
            dataNasc = temp == "" ? dataNasc : temp;

            //Atualizar Estado Civil
            Console.WriteLine($"O estado civil anterior era {estadoCivil} e para mantê-lo, basta digitar novamente");
            temp = EstadoCivil();
            estadoCivil = temp == "" ? estadoCivil : temp;

            //Atualizar Naturalidade
            Console.WriteLine($"A naturalidade anterior era {naturalidade} e para mantê-lo, basta digitar novamente");
            temp = Input.PedeString("Naturalidade: ");
            naturalidade = temp == "" ? naturalidade : temp;

            //Atualizar Nacionalidade
            Console.WriteLine($"A nacionalidade anterior era {nacionalidade} e para mantê-lo, basta digitar novamente");
            temp = Input.PedeString("Nacionalidade: ");
            nacionalidade = temp == "" ? nacionalidade : temp;

            //Atualizar Pai
            Console.WriteLine($"O nome do pai anterior era {pai} e para mantê-lo, basta digitar novamente");
            temp = Input.PedeString("Nome do Pai: ");
            pai = temp == "" ? pai : temp;

            //Atualizar Mãe
            Console.WriteLine($"O nome da mãe anterior era {mae} e para mantê-lo, basta digitar novamente");
            temp = Input.PedeString("Nome da Mãe: ");
            mae = temp == "" ? mae : temp;

            //Atualizar E-mail
            Console.WriteLine($"O e-mail anterior era {email} e para mantê-lo, basta digitar novamente");
            temp = Email();
            email = temp == "" ? email : temp;

            //Atualizar Ficha Rápida
            Console.WriteLine($"A situação da ficha rápida anterior era {fichaRapida} e para mantê-lo, basta digitar novamente");
            temp = FichaRapida();
            fichaRapida = temp == "" ? fichaRapida : temp;

            //Telefone(s) do Cliente
            // Telefones.AtualizaTelefone(cpf, id);

            //Endereço
            // Enderecos.AtualizaEndereco(cpf);

            Pessoa cliente = new(id, cpf, nome, rg, orgaouf, dataNasc, naturalidade, nacionalidade, pai, mae, estadoCivil, fichaRapida, email);

            repositorio.Atualiza(id, cliente, pessoa);
         }


      }


      // Funções Internas
      private static string Cpf(string titulo)
      {
         long cpf;
         do
         {
            Console.Write(titulo);
            string cpfInput = Console.ReadLine();
            cpfInput = cpfInput.Length > 11 ? cpfInput[..11] : cpfInput;
            resultado = Int64.TryParse(cpfInput, out cpf);
            if (!resultado) Console.WriteLine("**Digite apenas números**");
         } while (!resultado);

         return NormalizeCpf(cpf.ToString());
      }

      private static string Rg()
      {
         long rg;
         do
         {
            Console.Write("RG (apenas números): ");
            string rgInput = Console.ReadLine();
            rgInput = rgInput.Length > 9 ? rgInput[..9] : rgInput;
            resultado = Int64.TryParse(rgInput, out rg);
            if (resultado == false) Console.WriteLine("**Digite apenas números**");
         } while (resultado == false);

         return rg.ToString();
      }

      private static string OrgaoUF()
      {
         string[] output;
         string orgaouf;

         do
         {
            Console.Write("Órgão Expedidor/UF: ");
            orgaouf = Console.ReadLine();

            output = orgaouf.Split('/');

            if (output.Length != 2)
               Console.WriteLine("**Use uma barra (/) entre o Órgão Expedidor e o UF**");

         } while (output.Length != 2);

         return orgaouf;
      }

      private static string DataNasc()
      {
         DateTime data;
         string linha;

         do
         {
            Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
            linha = Console.ReadLine();

            resultado = DateTime.TryParse(linha, new CultureInfo("pt-BR"), DateTimeStyles.None, out data);

            if (!resultado)
            {
               Console.WriteLine("**Use o formato correto (dd/mm/aaaa)**");
            }

         } while (!resultado);

         return data.ToString("dd/MM/yyyy");
      }

      private static string Email()
      {
         string email;

         do
         {
            Console.Write("Email (exemplo@exemplo.com): ");
            email = Console.ReadLine();

            var addr = new MailAddress(email);
            resultado = addr.Address.Equals(email);

            if (!resultado)
               Console.WriteLine("**Digite corretamente o email**");

         } while (!resultado);

         return email;
      }

      private static string EstadoCivil()
      {
         Console.WriteLine("Estado Civil:");

         foreach (int i in Enum.GetValues(typeof(EstadoCivil)))
         {
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(EstadoCivil), i));
         }

         int output = 0;

         do
         {
            Console.WriteLine();
            Console.Write("Digite o número da opção: ");
            resultado = int.TryParse(Console.ReadLine(), out output);
         } while (!resultado);

         return Enum.GetName(typeof(EstadoCivil), output);
      }

      private static string FichaRapida()
      {
         Console.WriteLine("Ficha Rapida:");

         foreach (int i in Enum.GetValues(typeof(FichaRapida)))
         {
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(FichaRapida), i));
         }

         int output = 0;

         do
         {
            Console.WriteLine();
            Console.Write("Digite o número da opção: ");
            resultado = int.TryParse(Console.ReadLine(), out output);
         } while (!resultado);

         return Enum.GetName(typeof(FichaRapida), output);
      }

      private static string NormalizeCpf(string cpf)
      {
         string novo = cpf[..3] + "."
                     + cpf.Substring(3, 3) + "."
                     + cpf.Substring(6, 3) + "-"
                     + cpf.Substring(9, 2);
         return novo;
      }
   }
}