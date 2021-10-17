using System;
using System.Collections.Generic;
using System.IO;
using Imobiliaria.Classes;
using Imobiliaria.Methods;

namespace Imobiliaria
{
   public class Program
   {
      static void Main()
      {
         List<Contrato> contrato = ColetaContratos();
         List<Endereco> endereco = ColetaEnderecos();
         List<Imovel> imovel = ColetaImoveis();
         List<Pessoa> pessoa = ColetaPessoas();
         List<Telefone> telefone = ColetaTelefones();
         List<Usuario> usuario = ColetaUsuarios();


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

			Console.Write("Usuário: ");
         Console.ReadLine();
         Console.Write("Senha: ");
         Console.ReadLine();

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
                  Cliente.ListarCliente(pessoa, telefone);
						break;
					case "3": // Editar Cliente
                  Cliente.AtualizaCliente(pessoa);
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

      private static List<Contrato> ColetaContratos()
      {
         List<Contrato> contratos = new();
         string[] readContrato = File.ReadAllLines("DataBase/contrato.db");
         if (readContrato.Length != 0)
         {
            foreach (string line in readContrato)
            {
               string[] l = Output.Split(line);

               Contrato contrato1 = new(contratos.Count, Encriptografia.Decrypt(l[1]), int.Parse(l[2]), l[3], l[4], double.Parse(l[5]), int.Parse(l[6]), bool.Parse(l[7]), bool.Parse(l[8]));
               contratos.Add(contrato1);
            }
         }
         return contratos;
      }

      private static List<Endereco> ColetaEnderecos()
      {
         List<Endereco> lista = new();
         string[] readEndereco = File.ReadAllLines("DataBase/endereco.db");
         if (readEndereco.Length != 0)
         {
            foreach (string line in readEndereco)
            {
               string[] l = Output.Split(line);

               Endereco endereco1 = new(lista.Count, Encriptografia.Decrypt(l[1]), int.Parse(l[2]), l[3], int.Parse(l[4]), l[5], l[6], l[7], l[8], l[9], bool.Parse(l[10]));
               lista.Add(endereco1);
            }
         }
         return lista;
      }

      private static List<Imovel> ColetaImoveis()
      {
         List<Imovel> lista = new();
         string[] readImovel = File.ReadAllLines("DataBase/imovel.db");
         if (readImovel.Length != 0)
         {
            foreach (string line in readImovel)
            {
               string[] l = Output.Split(line);

               Imovel imovel1 = new(lista.Count, Encriptografia.Decrypt(l[1]), l[2], int.Parse(l[3]), l[4], int.Parse(l[5]), l[6], l[7], l[8], l[9], l[10], bool.Parse(l[11]));
               lista.Add(imovel1);
            }
         }
         return lista;
      }

      private static List<Pessoa> ColetaPessoas()
      {
         List<Pessoa> lista = new();
         string[] readPessoa = File.ReadAllLines("DataBase/pessoa.db");
         if (readPessoa.Length != 0)
         {
            foreach (string line in readPessoa)
            {
               string[] l = Output.Split(line);

               // Console.WriteLine(l[0]);
               // Console.WriteLine(Encriptografia.Decrypt(l[0]));
               string cpf = Encriptografia.Decrypt(l[1]);
               string rg = Encriptografia.Decrypt(l[3]);

               Pessoa cliente = new(lista.Count, cpf, l[2], rg, l[4], l[5], l[6], l[7], l[8], l[9], l[10], l[11], l[12]);
               lista.Add(cliente);
            }
         }
         return lista;
      }

      private static List<Telefone> ColetaTelefones()
      {
         List<Telefone> lista = new();
         string[] readTelefone = File.ReadAllLines("DataBase/telefone.db");
         if (readTelefone.Length != 0)
         {
            foreach (string line in readTelefone)
            {
               string[] l = Output.Split(line);

               Telefone tel = new(lista.Count, Encriptografia.Decrypt(l[1]), int.Parse(l[2]), int.Parse(l[3]), bool.Parse(l[4]), bool.Parse(l[5]), bool.Parse(l[6]));
               lista.Add(tel);
            }
         }
         return lista;
      }

      private static List<Usuario> ColetaUsuarios()
      {
         List<Usuario> lista = new();
         string[] readEndereco = File.ReadAllLines("DataBase/usuario.db");
         if (readEndereco.Length != 0)
         {
            foreach (string line in readEndereco)
            {
               string[] l = Output.Split(line);

               // Usuario endereco1 = new(lista.Count, Encriptografia.Decrypt(l[1]), int.Parse(l[2]), l[3], int.Parse(l[4]), l[5], l[6], l[7], l[8], l[9], bool.Parse(l[10]));
               // lista.Add(endereco1);
            }
         }
         return lista;
      }
   }
}
