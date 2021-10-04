using System;
using System.Collections.Generic;
using Imobiliaria.Classes;

namespace Imobiliaria
{
   public class Telefones
   {
      readonly private static List<Telefone> telefones = new();
        static bool resultado = true;
        static bool novoNumero = false;

        protected internal static void NovoTelefone(string cpf)
        {
            do
            {
                Console.WriteLine();
                Output.Titulo("Adicionando número de telefone");

                int cod = Codigo();
                int numero = Numero();
                bool whatsapp = Whatsapp();
                bool recado = Recado();

                Telefone telefone = new(cpf, cod, numero, whatsapp, recado);

                telefones.Add(telefone);

                novoNumero = NovoNumero();
            } while (novoNumero);

        }

        private static int Codigo()
        {
            int codigo;

            do
            {
                Console.Write("DDD (apenas números): ");
                string codigoInput = Console.ReadLine();
                codigoInput = codigoInput.Length > 2 ? codigoInput.Substring(1, 3) : codigoInput;

                resultado = Int32.TryParse(codigoInput, out codigo);

                if (codigoInput.Length < 2) resultado = false;
                if (!resultado) Console.WriteLine("**Digite apenas 2 dígitos**");
            } while (!resultado);

            return codigo;
        }

        private static int Numero()
        {
            int num;

            do
            {
                Console.Write("Número (8 digitos para fixo ou 9 dígitos para celular): ");
                string numInput = Console.ReadLine();
                numInput = numInput.Length > 9 ? numInput.Substring(0, 9) : numInput;

                resultado = Int32.TryParse(numInput, out num);

                if (numInput.Length < 8) resultado = false;
                if (!resultado) Console.WriteLine("**Digite de 8 a 9 dígitos**");
            } while (!resultado);

            return num;
        }

        private static bool Whatsapp()
        {
            bool whatsapp = false;

            do
            {
                Console.Write("Esse número é Whatsapp (S/N)? ");
                string input = Console.ReadLine();
                input = input.Length > 1 ? input.Substring(0, 1) : input;

                if (input.ToUpper() == "S")
                {
                    whatsapp = true;
                }

                if (input.Length != 1) resultado = false;
                if (!resultado) Console.WriteLine("**Digite S para sim ou N para não**");
            } while (!resultado);

            return whatsapp;
        }

        private static bool Recado()
        {
            bool recado = false;

            do
            {
                Console.Write("Esse número é apenas para recado (S/N)? ");
                string input = Console.ReadLine();
                input = input.Length > 1 ? input.Substring(0, 1) : input;

                if (input.ToUpper() == "S")
                {
                    recado = true;
                }

                if (input.Length != 1) resultado = false;
                if (!resultado) Console.WriteLine("**Digite S para sim ou N para não**");
            } while (!resultado);

            return recado;
        }

        private static bool NovoNumero()
        {
            bool novo = false;

            do
            {
                Console.Write("Adicionar outro número (S/N)? ");
                string input = Console.ReadLine();
                input = input.Length > 1 ? input.Substring(0, 1) : input;

                if (input.ToUpper() == "S")
                {
                    novo = true;
                }

                if (input.Length != 1) resultado = false;
                if (!resultado) Console.WriteLine("**Digite S para sim ou N para não**");
            } while (!resultado);

            return novo;
        }
    }
}