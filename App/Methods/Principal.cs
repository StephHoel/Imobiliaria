using System;

namespace Imobiliaria
{
   public class Principal
    {
      protected internal static void InserirSerie()
		{
			Console.WriteLine("**Inserir Nova Série**");

			/*
			var titulo = Input.Titulo();
			var genero = Input.Genero();
			var ano    = Input.Ano();
			var desc   = Input.Descricao();

			string obj = $"{Arquivo.ProximoId()}|{titulo}|{(Genero)genero}|{ano}|{desc}|false";
			Arquivo.Escrever(obj);
			*/
		}

		protected internal static void AtualizarSerie()
		{
			Console.WriteLine(Environment.NewLine + "**Atualizar Série**");

			/*
			int idSerie = Input.Id(); // informa qual serie será sendo editada
			Console.WriteLine();

			string[] readText = File.ReadAllLines(Arquivo.path);
			if(readText.Length != 0)
			{
				var linha = readText[idSerie].Split('|'); // dar split
				var novamente = " (Informar novamente caso não queira alterar)";

				Console.WriteLine($"Título Antigo: {linha[1]}" + novamente);
				var titulo = Input.Titulo();

				Console.WriteLine($"{Environment.NewLine}Gênero Antigo: {linha[2]}" + novamente);
				// var genero = Input.Genero();

				Console.WriteLine($"{Environment.NewLine}Ano Antigo: {linha[3]}" + novamente);
				var ano = Input.Ano();

				Console.WriteLine($"{Environment.NewLine}Descrição Antigo: {linha[4]}" + novamente);
				var desc = Input.Descricao();

				// readText[idSerie] = $"{idSerie}|{titulo}|{(Genero)genero}|{ano}|{desc}|{linha[5]}";

				Arquivo.Alterar(readText);
			}
			*/
		}

      protected internal static void ExcluirSerie()
		{
			/*
			int idSerie = Input.Id();

			string[] readText = File.ReadAllLines(Arquivo.path);
			if(readText.Length != 0)
			{
				var linha = readText[idSerie].Split('|'); // dar split

				Console.WriteLine($"{Environment.NewLine}**Série excluída da lista: {linha[1]}**");

				readText[idSerie] = $"{idSerie}|{linha[1]}|{linha[2]}|{linha[3]}|{linha[4]}|true";

				Arquivo.Alterar(readText);
			}
			*/
		}

      protected internal static void VisualizarSerie()
		{
			Console.WriteLine($"{Environment.NewLine}**Visualizar Série**");

			/*
			int idSerie = Input.Id();

			string[] readText = File.ReadAllLines(Arquivo.path);
			if(readText.Length != 0)
			{
				var linha = readText[idSerie].Split('|'); // dar split

				Console.WriteLine($"Título: {linha[1]}");
				Console.WriteLine($"Gênero: {linha[2]}");
				Console.WriteLine($"Ano: {linha[3]}");
				Console.WriteLine($"Descrição: {linha[4]}");
				Console.WriteLine($"Excluída? {(bool.Parse(linha[5]) ? "Sim" : "Não")}");
				Console.WriteLine();
			}
			*/
		}
    }
}