using System;
using System.Collections.Generic;
using Imobiliaria.Classes;

namespace Imobiliaria
{
   public class Enderecos
   {
      static readonly EnderecoRepositorio repositorio = new();
      protected internal static void NovoEndereco(string cpf)
      {
         int id = repositorio.ProximoId();

         if (id < 0)
         {
            Console.WriteLine("Erro no sistema, reinicie a aplicação");
            Console.ReadLine();
         }
         else
         {
            string cep = Input.Cep(); // somente números - 8 dígitos
            string logradouro = Input.PedeString("Logradouro (sem número): ");
            int numero = Input.Numero(); // 0 para sem número ou S/N
            string complemento = Input.PedeString("Complemento (deixar vazio caso não exista complemento): ");
            string bairro = Input.PedeString("Bairro: ");
            string cidade = Input.PedeString("Cidade: ");
            string estado = Input.EstadoUF();
            string pais = Input.PedeString("País: ");

            Endereco endereco = new(id, cpf, cep, logradouro, numero, complemento, bairro, cidade, estado, pais);

            string endereco2 = $"{id}|{cpf}|{cep}|{logradouro}|{numero}|{complemento}|{bairro}|{cidade}|{estado}|{pais}|{false}";

            repositorio.Insere(endereco, endereco2);
         }
      }
      protected internal static void AtualizaEndereco(string cpf)
      {
         string cep = Input.Cep(); // somente números - 8 dígitos
         string logradouro = Input.PedeString("Logradouro (sem número): ");
         int numero = Input.Numero(); // 0 para sem número ou S/N
         string complemento = Input.PedeString("Complemento (deixar vazio caso não exista complemento): ");
         string bairro = Input.PedeString("Bairro: ");
         string cidade = Input.PedeString("Cidade: ");
         string estado = Input.EstadoUF();
         string pais = Input.PedeString("País: ");

         int id = repositorio.ProximoId();

         Endereco endereco = new(id, cpf, cep, logradouro, numero, complemento, bairro, cidade, estado, pais);

         string endereco2 = $"{id}|{cpf}|{cep}|{logradouro}|{numero}|{complemento}|{bairro}|{cidade}|{estado}|{pais}|{false}";

         repositorio.Insere(endereco, endereco2);
      }


   }
}