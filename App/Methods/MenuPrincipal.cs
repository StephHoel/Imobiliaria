using System;
using System.Collections.Generic;
using Lib.Classes;
using Lib.Repositorio;
using Microsoft.CSharp.RuntimeBinder;

namespace App.Methods
{
   public class MenuPrincipal
   {
      static readonly List<Contrato> contrato = ContratoRepositorio.Lista();
      static readonly List<Endereco> endereco = EnderecoRepositorio.Lista();
      static readonly List<Imovel> imovel = ImovelRepositorio.Lista();
      static readonly List<Usuario> usuario = UsuarioRepositorio.Lista();
      static readonly List<Telefone> telefone = TelefoneRepositorio.Lista();
      static readonly List<Pessoa> pessoa = PessoaRepositorio.Lista();
      static string opcao;
      public static void Menu()
      {
         do
         {
            Output.MenuPrincipal();
            opcao = Output.RetornoMenu();


            switch (opcao)
            {
               case "1":
                  Interno(1);
                  break;
               case "2":
                  Interno(2);
                  break;
               case "3":
                  Interno(3);
                  break;
               case "4":
                  Interno(4);
                  break;
               case "X":
                  break;
               default:
                  Console.WriteLine("**Opção Inválida**");
                  break;
            }

         } while (opcao.ToUpper() != "X");
      }

      public static void Interno(int o)
      {
         do
         {
            Output.MenuInterno(o);
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            opcao = Output.RetornoMenu();

            switch (o)
            {
               case 1:
                  switch (opcao)
                  {
                     case "1": // Listar Clientes
                        EntradaCliente.Listar(pessoa, telefone);
                        break;
                     case "2": // Listar Imóvel
                        EntradaImovel.Listar(imovel);
                        break;
                     case "3": // Listar Contratos
                        EntradaContrato.Listar(contrato);
                        break;
                     case "4": // Listar Usuários
                        EntradaUsuario.Listar(usuario);
                        break;
                     case "X":
                        break;
                     default:
                        Console.WriteLine("**Opção Inválida**");
                        break;
                  }
                  break;
               case 2:
                  switch (opcao)
                  {
                     case "1": // Novo Cliente
                        EntradaCliente.Novo();
                        break;
                     case "2": // Novo Endereço
                        EntradaEndereco.Novo("");
                        break;
                     case "3": // Novo Telefone
                        EntradaTelefone.Novo("");
                        break;
                     case "4": // Novo Imovel
                        EntradaImovel.Novo("");
                        break;
                     case "5": // Novo Contrato
                        EntradaContrato.Novo();
                        break;
                     case "6": // Novo Usuario
                        EntradaUsuario.Novo();
                        break;
                     case "X":
                        break;
                     default:
                        Console.WriteLine("**Opção Inválida**");
                        break;
                  }
                  break;
               case 3:
                  switch (opcao)
                  {
                     case "1": // Editar Cliente
                        EntradaCliente.Atualizar(pessoa);
                        break;
                     case "2": // Editar Endereco
                        EntradaEndereco.Atualizar(endereco);
                        break;
                     case "3": // Editar Telefone
                        EntradaTelefone.Atualizar(telefone);
                        break;
                     case "4": // Editar Imovel
                        EntradaImovel.Atualizar(imovel);
                        break;
                     case "5": // Editar Contrato
                        EntradaContrato.Atualizar(contrato);
                        break;
                     case "6": // Editar Usuario
                        EntradaUsuario.Atualizar(usuario);
                        break;
                     case "X":
                        break;
                     default:
                        Console.WriteLine("**Opção Inválida**");
                        break;
                  }
                  break;
               case 4:
                  switch (opcao)
                  {
                     case "1": // Excluir Cliente
                        EntradaCliente.Excluir(pessoa);
                        break;
                     case "2": // Excluir Endereco
                        EntradaEndereco.Excluir(endereco);
                        break;
                     case "3": // Excluir Telefone
                        EntradaTelefone.Excluir(telefone);
                        break;
                     case "4": // Excluir Imovel
                        EntradaImovel.Excluir(imovel);
                        break;
                     case "5": // Excluir Contrato
                        EntradaContrato.Excluir(contrato);
                        break;
                     case "6": // Excluir Usuario
                        EntradaUsuario.Excluir(usuario);
                        break;
                     case "X":
                        break;
                     default:
                        Console.WriteLine("**Opção Inválida**");
                        break;
                  }
                  break;
               default:
                  opcao = "X";
                  break;
            }

         } while (opcao.ToUpper() != "X");
      }
   }
}