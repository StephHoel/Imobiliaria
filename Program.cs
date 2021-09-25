using System;

namespace Imobiliaria
{
   public class Program
   {
		static void Main()
		{
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

			Output.MenuPrincipal();
			string opcao = Output.RetornoMenu();

			while (opcao.ToUpper() != "X")
			{
				switch (opcao)
				{
					case "1": // Novo Cliente
						Cliente.NovoCliente();
						break;
					case "2": // Listar Clientes
						Arquivo.ListarNaoExcluida();
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
					default:
						// throw new ArgumentOutOfRangeException();
						Console.WriteLine("Opção inválida");
						break;
				}

				Output.MenuPrincipal();
				opcao = Output.RetornoMenu();
			}

			Console.WriteLine(Environment.NewLine + "Obrigada por utilizar nossos serviços. Até a próxima!");
			Console.WriteLine("Pressione ENTER para sair");
			Console.ReadLine();
		}
   }
}
