using System;
using System.Runtime.Serialization;
using Imobiliaria.Classes;

namespace Imobiliaria
{
    public class Cliente
    {
        protected internal static void NovoCliente()
		{
			Output.Titulo("Adicionando novo cliente");

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


            long cpf = Input.Cpf();
            string nome = Input.PedeString("Nome Completo (sem abreviação): ");
            long rg = Input.Rg();
            string orgaouf = Input.OrgaoUF("Órgão Expedidor/UF: ");


            DateTime dataNasc = new(); // DateTime
            string naturalidade = "";
            string nacionalidade = "";
            string pai = "";
            string mae = "";
            string email = "";

            Pessoa cliente = new(cpf, nome, rg, orgaouf, dataNasc, naturalidade, nacionalidade, pai, mae, email);



            //Endereco(long cpf, int cep, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string pais)

            //Telefone(long cpf, int cod, int numero, bool whatsapp, bool recado)

            //Imovel(long cpfProprietario, int cep, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string pais)

            //Contrato(long cpfLocatario, int idImovel, DateTime dataInicio, DateTime dataFim, double valorInicial, int vencimento)


            // string obj = $"{Arquivo.ProximoId()}|{titulo}|{(Genero)genero}|{ano}|{desc}|false";
            // Arquivo.Escrever(obj);
      }
    }
}