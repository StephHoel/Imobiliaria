using System;
using System.Collections.Generic;
using System.IO;
using Imobiliaria.Classes;
using Imobiliaria.Interfaces;
using Imobiliaria.Methods;

namespace Imobiliaria
{
   public class Program
   {
      static void Main()
      {

         // Criar um void para criar as listas
         List<Contrato> contrato = new();
         string[] readContrato = File.ReadAllLines("DataBase/contrato.db");
         if (readContrato.Length != 0)
         {
            foreach (string line in readContrato)
            {
               string[] l = Output.Split(line);

               Contrato contrato1 = new(Encriptografia.Decrypt(l[0]), int.Parse(l[1]), l[2], l[3], double.Parse(l[4]), int.Parse(l[5]), bool.Parse(l[6]), bool.Parse(l[7]));
               contrato.Add(contrato1);
            }
         }

         List<Endereco> endereco = new();
         string[] readEndereco = File.ReadAllLines("DataBase/endereco.db");
         if (readEndereco.Length != 0)
         {
            foreach (string line in readEndereco)
            {
               string[] l = Output.Split(line);

               Endereco endereco1 = new(Encriptografia.Decrypt(l[0]), int.Parse(l[1]), l[2], int.Parse(l[3]), l[4], l[5], l[6], l[7], l[8], bool.Parse(l[9]));
               endereco.Add(endereco1);
            }
         }

         List<Imovel> imovel = new();
         string[] readImovel = File.ReadAllLines("DataBase/imovel.db");
         if (readImovel.Length != 0)
         {
            foreach (string line in readImovel)
            {
               string[] l = Output.Split(line);

               Imovel imovel1 = new(Encriptografia.Decrypt(l[0]), l[1], int.Parse(l[2]), l[3], int.Parse(l[4]), l[5], l[6], l[7], l[8], l[9], bool.Parse(l[10]));
               imovel.Add(imovel1);
            }
         }

         List<Pessoa> pessoa = new();
         string[] readPessoa = File.ReadAllLines("DataBase/pessoa.db");
         if (readPessoa.Length != 0)
         {
            foreach (string line in readPessoa)
            {
               string[] l = Output.Split(line);

               Pessoa cliente = new(Encriptografia.Decrypt(l[0]), l[1], Encriptografia.Decrypt(l[2]), l[3], l[4], l[6], l[7], l[8], l[9], l[10], l[11], l[12]);
               pessoa.Add(cliente);
            }
         }

         List<Telefone> telefone = new();
         string[] readTelefone = File.ReadAllLines("DataBase/telefone.db");
         if (readTelefone.Length != 0)
         {
            foreach (string line in readTelefone)
            {
               string[] l = Output.Split(line);

               Telefone tel = new(Encriptografia.Decrypt(l[0]), int.Parse(l[1]), int.Parse(l[2]), bool.Parse(l[3]), bool.Parse(l[4]), bool.Parse(l[5]));
               telefone.Add(tel);
            }
         }

			/* TODO
				Menu com:
					[x]Novo Cliente
					[]Listar Cliente (baseado em algum critério)
					[]Editar Cliente
					[]Excluir Cliente (desativar, nunca excluir)

					[]Novo Imóvel
					[]Listar Imóvel
					[]Editar Imóvel
					[]Excluir Imóvel (desativar, nunca excluir)

					[]Novo Contrato
					[]Listar Contrato
					[]Editar Contrato
					[]Excluir Contrato (desativar, nunca excluir)
			*/

         Console.Clear();
			Console.WriteLine("Bem vindx ao Cadastro de Clientes e Contratos");
			Console.WriteLine("Cadastre seus clientes e seus contratos e não perca mais nada!");
			string opcao;

			do
			{
            Output.Titulo("Menu Principal");
				Console.WriteLine("1- Novo Cliente");
				Console.WriteLine("2- Listar Clientes");
				Console.WriteLine("3- Editar Cliente");
				Console.WriteLine("4- Novo Contrato");
				Console.WriteLine("5- Listar Contratos");
				Console.WriteLine("6- Editar Contrato");
				Console.WriteLine("X- Sair");

				opcao = Output.RetornoMenu();

				switch (opcao)
				{
					case "1": // Novo Cliente
						Cliente.NovoCliente();
						break;
					case "2": // Listar Clientes
						// Arquivo.ListarNaoExcluida();
						Console.WriteLine();
						Console.WriteLine("=====================");
						Console.WriteLine("**Listando Clientes**");
						foreach (var person in pessoa)
						{
							Console.WriteLine(person.RetornaNome());
						}
						Console.WriteLine("=====================");
						break;
					case "3": // Editar Cliente
						Arquivo.ListarExcluida();
						break;
					case "4": // Novo Contrato
						Principal.InserirSerie();
						break;
					case "5": // Listar Contratos
						Principal.AtualizarSerie();
						break;
					case "6": // Editar Contrato
						Principal.ExcluirSerie();
						break;
					case "X":

						break;
					default:
						// throw new ArgumentOutOfRangeException();
						Console.WriteLine("Opção inválida");
						break;
				}

			} while (opcao.ToUpper() != "X");

			Console.WriteLine(Environment.NewLine + "Obrigada por utilizar nossos serviços. Até a próxima!");
			Console.WriteLine("Pressione ENTER para sair");
			Console.ReadLine();
		}
	}
}
