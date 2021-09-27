using System;
using System.Globalization;
using System.Net.Mail;
using Imobiliaria.Classes;

namespace Imobiliaria
{
   public class Cliente
   {
        static bool resultado = true;

        protected internal static void NovoCliente()
		{
			Output.Titulo("**Adicionando novo cliente**");

            /* O que precisa para o cliente?
                -> CPF (encriptografado) [int] [primary key]
                -> Nome Completo [string]
                -> RG (encriptografado) [int]
                -> Órgão/UF (RG) [string]
                -> Data de Nascimento [string]
                -> Nacionalidade [string]
                -> Naturalidade [string]
                -> Filiação Pai [string]
                -> Filiação Mãe [string]
                ->
                -> Endereço (talvez em outra table)
                -> Telefone (talvez em outra table)
                -> Email (outra table?)
                ->
                -> EstadoCivil [Enum] [Solteiro, Casado, Viuvo, Divorciado, Separado, UniaoEstavel] (criado)
                ->
                -> FichaRapida [Enum] [NaoEnviada, EmAnálise, Aprovada, Reprovada] (criado)
            */

            //Informação Básica do Cliente
            long cpf = Cpf();
            string nome = Input.PedeString("Nome Completo (sem abreviação): ");
            long rg = Rg();
            string orgaouf = OrgaoUF();
            string dataNasc = DataNasc();
            string estadoCivil = EstadoCivil();
            string naturalidade = Input.PedeString("Naturalidade: ");
            string nacionalidade = Input.PedeString("Nacionalidade: ");
            string pai = Input.PedeString("Nome do Pai: ");
            string mae = Input.PedeString("Nome da Mãe: ");
            string email = Email();
            string fichaRapida = FichaRapida();

            //Telefone(s) do Cliente
            Telefone.NovoTelefone(cpf);

            //Endereço
            Endereco.NovoEndereco(cpf);

            Pessoa cliente = new(cpf, nome, rg, orgaouf, dataNasc, naturalidade, nacionalidade, pai, mae, estadoCivil, fichaRapida, email);

         // string obj = $"{Arquivo.ProximoId()}|{titulo}|{(Genero)genero}|{ano}|{desc}|false";
         // Arquivo.Escrever(obj);
        }

        private static long Cpf()
        {
            long cpf;
            do
            {
                Console.Write("CPF (apenas números): ");
                string cpfInput = Console.ReadLine();
                cpfInput = cpfInput.Length > 11 ? cpfInput.Substring(0, 11) : cpfInput;
                resultado = Int64.TryParse(cpfInput, out cpf);
                if (!resultado) Console.WriteLine("**Digite apenas números**");
            } while (!resultado);

            return cpf;
        }

        private static long Rg()
        {
            long rg;
            do
            {
                Console.Write("RG (apenas números): ");
                string rgInput = Console.ReadLine();
                rgInput = rgInput.Length > 9 ? rgInput.Substring(0, 9) : rgInput;
                resultado = Int64.TryParse(rgInput, out rg);
                if (resultado == false) Console.WriteLine("**Digite apenas números**");
            } while (resultado == false);

            return rg;
        }

        private static string OrgaoUF()
        {
            string[] output;
            string orgaouf;

            do
            {
                Console.Write("Órgão Expedidor/UF: ");
                orgaouf = Console.ReadLine();

                output = orgaouf.Split('/');

                if (output.Length != 2)
                Console.WriteLine("**Use uma barra (/) entre o Órgão Expedidor e o UF**");

            } while (output.Length != 2);

            return orgaouf;
        }

        private static string DataNasc()
        {
            DateTime data;
            string linha;

            do
            {
                Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
                linha = Console.ReadLine();

                resultado = DateTime.TryParse(linha, new CultureInfo("pt-BR"), DateTimeStyles.None, out data);

                if (!resultado)
                {
                Console.WriteLine("**Use o formato correto (dd/mm/aaaa)**");
                }

            } while (!resultado);

            return data.ToString("dd/MM/yyyy");
        }

        private static string Email()
        {
            string email;

            do
            {
                Console.Write("Email (exemplo@exemplo.com): ");
                email = Console.ReadLine();

                var addr = new MailAddress(email);
                resultado = addr.Address.Equals(email);

                if (!resultado)
                Console.WriteLine("**Digite corretamente o email**");

            } while (!resultado);

            return email;
        }

        private static string EstadoCivil()
        {
            Console.WriteLine("Estado Civil:");

            foreach (int i in Enum.GetValues(typeof(EstadoCivil)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(EstadoCivil), i));
            }

            int output = 0;

            do
            {
                Console.WriteLine();
                Console.Write("Digite o número da opção: ");
                resultado = int.TryParse(Console.ReadLine(), out output);
            } while (!resultado);

            return Enum.GetName(typeof(EstadoCivil), output);
        }

        private static string FichaRapida()
        {
            Console.WriteLine("Ficha Rapida:");

            foreach (int i in Enum.GetValues(typeof(FichaRapida)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(FichaRapida), i));
            }

            int output = 0;

            do
            {
                Console.WriteLine();
                Console.Write("Digite o número da opção: ");
                resultado = int.TryParse(Console.ReadLine(), out output);
            } while (!resultado);

            return Enum.GetName(typeof(FichaRapida), output);
        }

        //

   }
}