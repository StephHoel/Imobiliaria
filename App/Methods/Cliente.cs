using System;
using System.Collections.Generic;
using Imobiliaria.Classes;
using Imobiliaria.Methods;
using Imobiliaria.Repositorio;

namespace Imobiliaria
{
   public class Cliente
   {
      static readonly PessoaRepositorio repositorio = new();

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

            {/* O que precisa para o cliente?
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
            }

            //Informação Básica do Cliente
            string cpf = Input.Cpf("CPF (apenas números): ");
            string nome = Input.PedeString("Nome Completo (sem abreviação): ");
            string rg = Input.Rg();
            string orgaouf = Input.OrgaoUF();
            string dataNasc = Input.DataNasc();
            string estadoCivil = Input.EstadoCivil();
            string naturalidade = Input.PedeString("Naturalidade: ");
            string nacionalidade = Input.PedeString("Nacionalidade: ");
            string pai = Input.PedeString("Nome do Pai: ");
            string mae = Input.PedeString("Nome da Mãe: ");
            string email = Input.Email();
            string fichaRapida = Input.FichaRapida();

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
         string inputCpf = Input.Cpf("Insira o CPF do cliente (apenas números): ");
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
            cpf = Encriptografia.Encrypt(Input.Cpf("CPF (apenas números): ", true, cpf));

            //Atualizar Nome
            Console.WriteLine($"O nome anterior era {nome} {manter}");
            nome = Input.PedeString("Nome Completo (sem abreviação): ", true, nome);

            //Atualizar RG
            Console.WriteLine($"O RG anterior era {rg} {manter}");
            rg = Encriptografia.Encrypt(Input.Rg(true, rg));

            //Atualizar Órgão e UF
            Console.WriteLine($"O Órgão e UF anterior eram {orgaouf} {manter}");
            orgaouf = Input.OrgaoUF(true, orgaouf);

            //Atualizar Data de Nascimento
            Console.WriteLine($"A data de nascimento anterior era {dataNasc} {manter}");
            dataNasc = Input.DataNasc(true, dataNasc);

            //Atualizar Estado Civil
            Console.WriteLine($"O estado civil anterior era {estadoCivil} {manter}");
            estadoCivil = Input.EstadoCivil(true, estadoCivil);

            //Atualizar Naturalidade
            Console.WriteLine($"A naturalidade anterior era {naturalidade} {manter}");
            naturalidade = Input.PedeString("Naturalidade: ", true, naturalidade);

            //Atualizar Nacionalidade
            Console.WriteLine($"A nacionalidade anterior era {nacionalidade} {manter}");
            nacionalidade = Input.PedeString("Nacionalidade: ", true, nacionalidade);

            //Atualizar Pai
            Console.WriteLine($"O nome do pai anterior era {pai} {manter}");
            pai = Input.PedeString("Nome do Pai: ", true, pai);

            //Atualizar Mãe
            Console.WriteLine($"O nome da mãe anterior era {mae} {manter}");
            mae = Input.PedeString("Nome da Mãe: ", true, mae);

            //Atualizar E-mail
            Console.WriteLine($"O e-mail anterior era {email} {manter}");
            email = Input.Email(true, email);

            //Atualizar Ficha Rápida
            Console.WriteLine($"A situação da ficha rápida anterior era {fichaRapida} {manter}");
            fichaRapida = Input.FichaRapida(true, fichaRapida);

            //Telefone(s) do Cliente
            // Telefones.AtualizaTelefone(cpf, id);

            //Endereço
            // Enderecos.AtualizaEndereco(cpf);

            Pessoa cliente = new(id, cpf, nome, rg, orgaouf, dataNasc, naturalidade, nacionalidade, pai, mae, estadoCivil, fichaRapida, email);

            repositorio.Atualiza(id, cliente);
         }


      }

   }
}