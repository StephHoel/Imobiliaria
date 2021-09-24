using System;
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


            var cpf = Input.Cpf();
            var nome = Input.PedeString("Nome Completo (sem abreviação): ");
            var rg = Input.Rg();
            var orgao = Input.PedeString("Órgão Expedidor: ");

            var uf = "";
            var dataNasc = "";
            var naturalidade = "";
            var nacionalidade = "";
            var pai = "";
            var mae = "";
            //

            Pessoa cliente = new(cpf, rg, nome, orgao, uf, dataNasc, naturalidade, nacionalidade, pai, mae);

            

            // string obj = $"{Arquivo.ProximoId()}|{titulo}|{(Genero)genero}|{ano}|{desc}|false";
            // Arquivo.Escrever(obj);
        }
    }
}