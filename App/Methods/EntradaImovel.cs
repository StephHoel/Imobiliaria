using System;
using Lib.Classes;
using Lib.Enums;
using Lib.Methods;
using Lib.Repositorio;

namespace App.Methods
{
   public class EntradaImovel
   {
      static readonly ImovelRepositorio repositorio = new();
      protected internal static void NovoImovel(string cpfProprietario)
      {
         int id = repositorio.ProximoId();

         // Situação - Aluguel ou Venda?
         string situacao;
         Console.WriteLine("O imóvel está destinado à:");
         foreach (int i in Enum.GetValues(typeof(Situacao)))
            Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Situacao), i));

         do
         {
            Console.Write("Digite o número da opção: ");
            situacao = Geral.Enums(Console.ReadLine(), "Situação");

            if (situacao == "")
               Console.WriteLine("**Digite uma opção válida**");
         } while (situacao == "");

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

         Imovel imovel = new(id, cpfProprietario, situacao, cep, logradouro, int.Parse(numero), complemento, bairro, cidade, uf, pais);

         string imovel2 = $"{id}|{cpfProprietario}|{situacao}|{cep}|{logradouro}|{numero}|{complemento}|{bairro}|{cidade}|{uf}|{pais}|{false}";

         repositorio.Insere(imovel, imovel2);
      }
   }
}