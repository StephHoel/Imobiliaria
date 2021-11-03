using System;
using System.Collections.Generic;
using System.IO;
using Imobiliaria.Classes;
using Imobiliaria.Repositorio;

namespace Imobiliaria
{
   public class Program
   {
      static readonly List<Contrato> contrato = ContratoRepositorio.Lista();
      static readonly List<Endereco> endereco = EnderecoRepositorio.Lista();
      static readonly List<Imovel> imovel = ImovelRepositorio.Lista();
      static readonly List<Usuario> usuario = UsuarioRepositorio.Lista();
      static readonly List<Telefone> telefone = TelefoneRepositorio.Lista();
      static readonly List<Pessoa> pessoa = PessoaRepositorio.Lista();

      static string opcao;

      static void Main()
      {
         string user;

         LimparTela();
         Console.WriteLine("Bem vinde ao Cadastro de Clientes e Contratos");
         Console.WriteLine("Cadastre seus clientes e seus contratos e não perca mais nada!");
         Console.WriteLine();

         do
         {
            Console.WriteLine("1- Novo Usuário");
            Console.WriteLine("2- Login");
            Console.WriteLine("3- Esqueci a Senha");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            Console.Write("Informe a opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
               case "1":
                  Usuarios.NovoUsuario();
                  break;
               case "2":
                  user = Usuarios.Login();
                  if (user != "")
                  {
                     /* TODO - Menu com:
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
                              Cliente.AtualizarCliente(pessoa);
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
                              Console.WriteLine("Opção Inválida");
                              break;
                        }

                     } while (opcao.ToUpper() != "X");
                  }
                  break;
               case "3":
                  Usuarios.EsqueciSenha();
                  break;
               case "X":
                  break;
               default:
                  Console.WriteLine("**Opção Inválida**");
                  break;
            }
            Console.WriteLine();
         } while (opcao.ToUpper() != "X");

         Console.WriteLine(Environment.NewLine + "Obrigada por utilizar nossos serviços. Até a próxima!");
         Console.WriteLine("Pressione ENTER para sair");
         Console.ReadLine();
      }

      private static void LimparTela()
      {
         try
         {
            Console.Clear();
         }
         catch (IOException)
         {
         }
      }
   }
}
