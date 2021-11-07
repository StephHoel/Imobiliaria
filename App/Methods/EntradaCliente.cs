using System;
using System.Collections.Generic;
using Lib.Classes;
using Lib.Enums;
using Lib.Methods;
using Lib.Repositorio;

namespace App.Methods
{
   public class EntradaCliente
   {
      static readonly PessoaRepositorio repositorio = new();

      protected internal static void NovoCliente()
      {
         int id = repositorio.ProximoId();

         Console.WriteLine("**Adicionando Novo Cliente**");

         // Informação Básica do Cliente

         // CPF
         string cpf;
         do
         {
            Console.Write("CPF (apenas números): ");
            cpf = MCliente.Cpf(Console.ReadLine());

            if (cpf == "")
               Console.WriteLine("**Digite apenas números**");
         } while (cpf == "");

         // NOME
         string nome;
         do
         {
            Console.Write("Nome Completo (sem abreviação): ");
            nome = Geral.RetornaString(Console.ReadLine());

            if (nome == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (nome == "");

         // RG
         string rg;
         do
         {
            Console.Write("RG (apenas números): ");
            rg = MCliente.Rg(Console.ReadLine());

            if (rg == "")
               Console.WriteLine("**Digite apenas números**");
         } while (rg == "");

         // Órgão e UF
         string orgaouf, orgao, uf;
         do
         {
            Console.Write("Órgão Expedidor: ");
            orgao = Geral.RetornaString(Console.ReadLine());

            if (orgao == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (orgao == "");

         orgaouf = orgao + "/";

         Console.WriteLine("Estado (UF)");
         foreach (int i in Enum.GetValues(typeof(EstadosUF)))
            Console.WriteLine(Enum.GetName(typeof(EstadosUF), i));

         do
         {
            Console.Write("UF: ");
            uf = Geral.Uf(Console.ReadLine());

            if (uf == "")
               Console.WriteLine("**UF Inválido**");
         } while (uf == "");

         orgaouf += uf;

         //Data de Nascimento
         string dataNasc;
         do
         {
            Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
            dataNasc = MCliente.DataNasc(Console.ReadLine());

            if (dataNasc == "")
               Console.WriteLine("**Use o formato correto (dd/mm/aaaa)**");
         } while (dataNasc == "");

         // Estado Civil
         string estadoCivil;
         Console.WriteLine("Estado Civil:");
         foreach (int i in Enum.GetValues(typeof(EstadoCivil)))
         {
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(EstadoCivil), i));
         }
         do
         {
            Console.Write("Digite o número da opção: ");
            estadoCivil = Geral.Enums(Console.ReadLine(), "Estado Civil");

            if (estadoCivil == "")
               Console.WriteLine("**Digite uma opção válida**");
         } while (estadoCivil == "");

         // Naturalidade
         string nat;
         do
         {
            Console.Write("Naturalidade: ");
            nat = Geral.RetornaString(Console.ReadLine());

            if (nat == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (nat == "");

         // Nacionalidade
         string nac;
         do
         {
            Console.Write("Nacionalidade: ");
            nac = Geral.RetornaString(Console.ReadLine());

            if (nac == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (nac == "");

         // Pai
         string pai;
         do
         {
            Console.Write("Nome do Pai: ");
            pai = Geral.RetornaString(Console.ReadLine());

            if (pai == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (pai == "");

         // Mãe
         string mae;
         do
         {
            Console.Write("Nome do Mãe: ");
            mae = Geral.RetornaString(Console.ReadLine());

            if (mae == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (mae == "");

         // Email
         string email;
         do
         {
            Console.Write("E-mail (ex@exemp.lo): ");
            email = Geral.Email(Console.ReadLine());

            if (email == "")
               Console.WriteLine("**Digite corretamente o e-mail**");
         } while (email == "");

         // Ficha Rápida
         string fichaRapida;
         Console.WriteLine("Ficha Rápida:");
         foreach (int i in Enum.GetValues(typeof(FichaRapida)))
         {
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(FichaRapida), i));
         }
         do
         {
            Console.Write("Digite o número da opção: ");
            fichaRapida = Geral.Enums(Console.ReadLine(), "Ficha Rápida");

            if (fichaRapida == "")
               Console.WriteLine("**Digite uma opção válida**");
         } while (fichaRapida == "");

         // Criando objeto
         Pessoa cliente = new(id, cpf, nome, rg, orgaouf, dataNasc, nat, nac, pai, mae, estadoCivil, fichaRapida, email);

         // Criando string
         string cliente2 = $"{id}|{cpf}|{nome}|{rg}|{orgaouf}|{dataNasc}|{nat}|{nac}|{pai}|{mae}|{estadoCivil}|{fichaRapida}|{email}|{false}";

         // Inserindo no repositório
         repositorio.Insere(cliente, cliente2);

         // Adicionando Telefone(s) do Cliente
         EntradaTelefone.NovoTelefone(cpf);

         // Adicionando Endereço do Cliente
         EntradaEndereco.NovoEndereco(cpf);
      }

      protected internal static void ListarCliente(List<Lib.Classes.Pessoa> objeto, List<Lib.Classes.Telefone> telefone)
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


      /*
            protected internal static void AtualizarCliente(List<Lib.Classes.Pessoa> pessoa)
            {
               Output.Titulo("Atualizando Cliente");

               //Pergunta qual cliente será editado
               string inputCpf = InputCliente.Cpf("Insira o CPF do cliente (apenas números): ");
               int id = -1;
               string cpf = "", nome = "", rg = "", orgaouf = "", dataNasc = "", estadoCivil = "", naturalidade = "", nacionalidade = "", pai = "", mae = "", email = "", fichaRapida = "";

               //Pegar Posição do Cliente escolhido
               foreach (var person in pessoa)
               {
                  if (person.RetornaCpf() == Encriptografia.Decrypt(inputCpf) && !person.RetornaExcluido())
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

               // Console.WriteLine(id);

               if (id < 0)
               {
                  Console.WriteLine("Erro no sistema, reinicie a aplicação");
                  Console.ReadLine();
               }
               else
               {
                  string manter = "e para mantê-lo, basta deixar em branco";

                  //Atualizar CPF
                  Console.WriteLine($"O CPF anterior era {cpf} {manter}");
                  cpf = Encriptografia.Encrypt(InputCliente.Cpf("CPF (apenas números): ", true, cpf));

                  //Atualizar Nome
                  Console.WriteLine($"O nome anterior era {nome} {manter}");
                  nome = InputComum.PedeString("Nome Completo (sem abreviação): ", true, nome);

                  //Atualizar RG
                  Console.WriteLine($"O RG anterior era {rg} {manter}");
                  rg = Encriptografia.Encrypt(InputCliente.Rg(true, rg));

                  //Atualizar Órgão e UF
                  Console.WriteLine($"O Órgão e UF anterior eram {orgaouf} {manter}");
                  orgaouf = InputCliente.OrgaoUF(true, orgaouf);

                  //Atualizar Data de Nascimento
                  Console.WriteLine($"A data de nascimento anterior era {dataNasc} {manter}");
                  dataNasc = InputCliente.DataNasc(true, dataNasc);

                  //Atualizar Estado Civil
                  Console.WriteLine($"O estado civil anterior era {estadoCivil} {manter}");
                  estadoCivil = InputCliente.EstadoCivil(true, estadoCivil);

                  //Atualizar Naturalidade
                  Console.WriteLine($"A naturalidade anterior era {naturalidade} {manter}");
                  naturalidade = InputComum.PedeString("Naturalidade: ", true, naturalidade);

                  //Atualizar Nacionalidade
                  Console.WriteLine($"A nacionalidade anterior era {nacionalidade} {manter}");
                  nacionalidade = InputComum.PedeString("Nacionalidade: ", true, nacionalidade);

                  //Atualizar Pai
                  Console.WriteLine($"O nome do pai anterior era {pai} {manter}");
                  pai = InputComum.PedeString("Nome do Pai: ", true, pai);

                  //Atualizar Mãe
                  Console.WriteLine($"O nome da mãe anterior era {mae} {manter}");
                  mae = InputComum.PedeString("Nome da Mãe: ", true, mae);

                  //Atualizar E-mail
                  Console.WriteLine($"O e-mail anterior era {email} {manter}");
                  email = InputComum.Email(true, email);

                  //Atualizar Ficha Rápida
                  Console.WriteLine($"A situação da ficha rápida anterior era {fichaRapida} {manter}");
                  fichaRapida = InputCliente.FichaRapida(true, fichaRapida);

                  //Telefone(s) do Cliente
                  // Telefones.AtualizaTelefone(cpf, id);

                  //Endereço
                  // Enderecos.AtualizaEndereco(cpf);

                  Pessoa cliente = new(id, cpf, nome, rg, orgaouf, dataNasc, naturalidade, nacionalidade, pai, mae, estadoCivil, fichaRapida, email);

                  repositorio.Atualiza(id, cliente);
               }


            }
       */
   }
}