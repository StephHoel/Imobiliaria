using System;
using Lib.Classes;
using Lib.Enums;
using Lib.Methods;
using Lib.Repositorio;

namespace App.Methods
{
   public class EntradaEndereco
   {
      static readonly EnderecoRepositorio repositorio = new();
      protected internal static void NovoEndereco(string cpf)
      {
         int id = repositorio.ProximoId();

         // CEP - somente números - 8 dígitos
         string cep;
         do
         {
            Console.Write("CEP (apenas números): ");
            cep = MEndereco.Cep(Console.ReadLine());

            if (cep == "")
               Console.WriteLine("**Digite apenas 8 números**");
         } while (cep == "");

         // LOGRADOURO
         string logradouro;
         do
         {
            Console.Write("Logradouro (sem número): ");
            logradouro = Geral.RetornaString(Console.ReadLine());

            if (logradouro == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (logradouro == "");

         // NÚMERO
         string numero;
         do
         {
            Console.Write("Número (digite 0 para S/N): ");
            numero = MEndereco.Numero(Console.ReadLine());

            if (numero == "")
               Console.WriteLine("**Digite apenas números**");
         } while (numero == "");

         // COMPLEMENTO
         string complemento;
         Console.Write("Complemento (deixar vazio caso não exista complemento): ");
         complemento = Geral.RetornaString(Console.ReadLine());

         // BAIRRO
         string bairro;
         do
         {
            Console.Write("Bairro: ");
            bairro = Geral.RetornaString(Console.ReadLine());

            if (bairro == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (bairro == "");

         // CIDADE
         string cidade;
         do
         {
            Console.Write("Cidade: ");
            cidade = Geral.RetornaString(Console.ReadLine());

            if (cidade == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (cidade == "");

         // UF do Estado
         string uf;
         Console.WriteLine("Sigla dos Estados");
         foreach (int i in Enum.GetValues(typeof(EstadosUF)))
            Console.WriteLine(Enum.GetName(typeof(EstadosUF), i));

         do
         {
            Console.Write("Sigla do Estado: ");
            uf = Geral.Uf(Console.ReadLine());

            if (uf == "")
               Console.WriteLine("**Sigla Inválido**");
         } while (uf == "");

         // PAÍS
         string pais;
         do
         {
            Console.Write("País: ");
            pais = Geral.RetornaString(Console.ReadLine());

            if (pais == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (pais == "");

         Endereco endereco = new(id, cpf, cep, logradouro, int.Parse(numero), complemento, bairro, cidade, uf, pais);

         string endereco2 = $"{id}|{cpf}|{cep}|{logradouro}|{numero}|{complemento}|{bairro}|{cidade}|{uf}|{pais}|{false}";

         repositorio.Insere(endereco, endereco2);
      }


      /*
      protected internal static void AtualizaEndereco(string cpf)
      {
         string cep = Input.Cep(); // somente números - 8 dígitos
         string logradouro = InputComum.PedeString("Logradouro (sem número): ");
         int numero = Input.Numero(); // 0 para sem número ou S/N
         string complemento = InputComum.PedeString("Complemento (deixar vazio caso não exista complemento): ");
         string bairro = InputComum.PedeString("Bairro: ");
         string cidade = InputComum.PedeString("Cidade: ");
         string estado = Input.EstadoUF();
         string pais = InputComum.PedeString("País: ");

         int id = repositorio.ProximoId();

         Endereco endereco = new(id, cpf, cep, logradouro, numero, complemento, bairro, cidade, estado, pais);

         string endereco2 = $"{id}|{cpf}|{cep}|{logradouro}|{numero}|{complemento}|{bairro}|{cidade}|{estado}|{pais}|{false}";

         repositorio.Insere(endereco, endereco2);
      }
 */

   }
}