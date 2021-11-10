using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lib.Classes;
using Lib.Enums;
using Lib.Methods;
using Lib.Repositorio;

namespace App.Methods
{
   public class EntradaCliente
   {
      static readonly PessoaRepositorio repositorio = new();

      protected internal static void Novo()
      {
         int id = repositorio.ProximoId();

         Console.WriteLine("**Adicionando Novo Cliente**");

         // Informação Básica do Cliente

         // CPF
         string cpf = Output.DoWhile("CPF (apenas números): ", "Add cpf");

         // NOME
         string nome = Output.DoWhile("Nome Completo (sem abreviação): ", "Add texto");

         // RG
         string rg = Output.DoWhile("RG (apenas números): ", "Add rg");

         // Órgão e UF
         string orgaouf = Output.DoWhile("Órgão Expedidor: ", "Add texto");

         orgaouf += "/";

         Console.WriteLine("Estado (UF)");
         foreach (int i in Enum.GetValues(typeof(EstadosUF)))
            Console.WriteLine(Enum.GetName(typeof(EstadosUF), i));

         orgaouf += Output.DoWhile("UF: ", "Add uf");

         //Data de Nascimento
         string dataNasc = Output.DoWhile("Digite a data de nascimento (dd/mm/aaaa): ", "Add data");

         // Estado Civil
         Console.WriteLine("Estado Civil:");
         foreach (int i in Enum.GetValues(typeof(EstadoCivil)))
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(EstadoCivil), i));
         string estadoCivil = Output.DoWhile("Digite o número da opção: ", "Add opção", "Estado Civil");

         // Naturalidade
         string nat = Output.DoWhile("Naturalidade: ", "Add texto");

         // Nacionalidade
         string nac = Output.DoWhile("Nacionalidade: ", "Add texto");

         // Pai
         string pai = Output.DoWhile("Nome do Pai: ", "Add texto");

         // Mãe
         string mae = Output.DoWhile("Nome do Mãe: ", "Add texto");

         // Email
         string email = Output.DoWhile("E-mail (ex@exemp.lo): ", "Add email");

         // Ficha Rápida
         Console.WriteLine("Ficha Rápida:");
         foreach (int i in Enum.GetValues(typeof(FichaRapida)))
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(FichaRapida), i));
         string fichaRapida = Output.DoWhile("Digite o número da opção: ", "Add opção", "Ficha Rápida");

         // Criando objeto
         Pessoa cliente = new(id, cpf, nome, rg, orgaouf, dataNasc, nat, nac, pai, mae, estadoCivil, fichaRapida, email);

         // Criando string
         string cliente2 = $"{id}|{cpf}|{nome}|{rg}|{orgaouf}|{dataNasc}|{nat}|{nac}|{pai}|{mae}|{estadoCivil}|{fichaRapida}|{email}|{false}";

         // Inserindo no repositório
         repositorio.Insere(cliente, cliente2);

         // Adicionando Telefone(s) do Cliente
         EntradaTelefone.Novo(cpf);

         // Adicionando Endereço do Cliente
         EntradaEndereco.Novo(cpf);
      }

      protected internal static void Listar(List<Lib.Classes.Pessoa> objeto, List<Lib.Classes.Telefone> telefone)
      {
         Console.WriteLine("=====================");
         Console.WriteLine("**Listando Clientes**");
         Console.WriteLine("=====================");

         Output.Vazio(objeto.Count);

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
                     Console.WriteLine();
            }
         }
         Console.WriteLine();
         Console.WriteLine("=====================");
         Console.WriteLine();
      }

      protected internal static void Atualizar(List<Lib.Classes.Pessoa> pessoa)
      {
         Console.WriteLine("**Atualizando Cliente**");
         string manter = "e para mantê-lo, deixe como está e pressione ENTER";

         //Pergunta qual cliente será editado
         string cpf = Output.DoWhile("Insira o CPF do cliente (apenas números): ", "Add cpf");

         int id = -1;
         string nome = "", rg = "", orgaouf = "", dataNasc = "", estadoCivil = "", nat = "", nac = "", pai = "", mae = "", email = "", fichaRapida = "";

         //Pegar Posição do Cliente escolhido
         foreach (var person in pessoa)
         {
            if (person.RetornaCpf() == Encriptografia.Decrypt(cpf) && !person.RetornaExcluido())
            {
               id = person.RetornaId();
               cpf = person.RetornaCpf();
               nome = person.RetornaNome();
               rg = person.RetornaRg();
               orgaouf = person.RetornaOrgaoUF();
               dataNasc = person.RetornaDataNasc();
               estadoCivil = person.RetornaEstadoCivil();
               nat = person.RetornaNaturalidade();
               nac = person.RetornaNacionalidade();
               pai = person.RetornaPai();
               mae = person.RetornaMae();
               email = person.RetornaEmail();
               fichaRapida = person.RetornaFichaRapida();
               break;
            }

            if (id == -1)
               Console.WriteLine("CPF não encontrado");
         }

         // Espaço
         Console.WriteLine();

         // Atualizar CPF
         Console.WriteLine($"O CPF anterior era \"{cpf}\" {manter}");
         cpf = Output.DoWhile("CPF (apenas números): ", "Editar cpf", cpf);

         // Atualizar Nome
         Console.WriteLine($"O nome anterior era \"{nome}\" {manter}");
         nome = Output.DoWhile("Nome Completo (sem abreviação): ", "Editar texto", nome);

         // Atualizar RG
         Console.WriteLine($"O RG anterior era {rg} {manter}");
         rg = Output.DoWhile("RG (apenas números): ", "Editar rg", rg);

         // Atualizar Órgão e UF
         string orgao = orgaouf.Split('/')[0];
         string uf = orgaouf.Split('/')[1];


         Console.WriteLine($"O Órgão e UF anterior eram {orgaouf} {manter}");
         orgaouf = Output.DoWhile("Órgão Expedidor: ", "Editar texto", orgao);

         orgaouf += "/";

         Console.WriteLine("Estado (UF)");
         foreach (int i in Enum.GetValues(typeof(EstadosUF)))
            Console.WriteLine(Enum.GetName(typeof(EstadosUF), i));

         orgaouf += Output.DoWhile("UF: ", "Editar uf", uf);

         // Atualizar Data de Nascimento
         Console.WriteLine($"A data de nascimento anterior era {dataNasc} {manter}");
         dataNasc = Output.DoWhile("Digite a data de nascimento (dd/mm/aaaa): ", "Editar data", dataNasc);

         // Atualizar Estado Civil
         Console.WriteLine($"O estado civil anterior era {estadoCivil} {manter}");
         Console.WriteLine("Estado Civil:");
         foreach (int i in Enum.GetValues(typeof(EstadoCivil)))
         {
            string n = Enum.GetName(typeof(EstadoCivil), i);
            Console.WriteLine("{0}- {1}", i, n);

            if (n == estadoCivil)
               estadoCivil = i.ToString();

         }
         estadoCivil = Output.DoWhile("Digite o número da opção: ", "Editar opção", estadoCivil, "Estado Civil");

         // Atualizar Naturalidade
         Console.WriteLine($"A naturalidade anterior era {nat} {manter}");
         nat = Output.DoWhile("Naturalidade: ", "Editar texto", nat);

         // Atualizar Nacionalidade
         Console.WriteLine($"A nacionalidade anterior era {nac} {manter}");
         nac = Output.DoWhile("Nacionalidade: ", "Editar texto", nac);

         // Atualizar Pai
         Console.WriteLine($"O nome do pai anterior era {pai} {manter}");
         pai = Output.DoWhile("Nome do Pai: ", "Editar texto", pai);

         // Atualizar Mãe
         Console.WriteLine($"O nome da mãe anterior era {mae} {manter}");
         mae = Output.DoWhile("Nome do Mãe: ", "Editar texto", mae);

         // Atualizar E-mail
         Console.WriteLine($"O e-mail anterior era {email} {manter}");
         email = Output.DoWhile("E-mail (ex@exemp.lo): ", "Editar email", email);

         // Atualizar Ficha Rápida
         Console.WriteLine($"A situação da ficha rápida anterior era {fichaRapida} {manter}");
         Console.WriteLine("Ficha Rápida:");
         foreach (int i in Enum.GetValues(typeof(FichaRapida)))
         {
            string n = Enum.GetName(typeof(FichaRapida), i);
            Console.WriteLine("{0}- {1}", i, n);

            if (n == fichaRapida)
               fichaRapida = i.ToString();
         }
         fichaRapida = Output.DoWhile("Digite o número da opção: ", "Editar opção", fichaRapida, "Ficha Rápida");

         // Criando objeto
         Pessoa cliente = new(id, cpf, nome, rg, orgaouf, dataNasc, nat, nac, pai, mae, estadoCivil, fichaRapida, email);

         repositorio.Atualiza(id, cliente);

      }

      public static void Excluir(List<Lib.Classes.Pessoa> list)
      {

      }
   }
}