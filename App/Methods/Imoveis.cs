using System;
using Imobiliaria.Classes;
using Imobiliaria.Repositorio;

namespace Imobiliaria
{
   public class Imoveis
   {
      static readonly ImovelRepositorio repositorio = new();
        protected internal static void NovoImovel(string cpfProprietario)
        {
            int id = repositorio.ProximoId();

            if (id < 0)
            {
                Console.WriteLine("Erro no sistema, reinicie a aplicação");
                Console.ReadLine();
            }
            else
            {
                string situacao = Input.Situacao();
                string cep = Input.Cep(); // somente números - 8 dígitos
                string logradouro = Input.PedeString("Logradouro (sem número): ");
                int numero = Input.Numero(); // 0 para sem número ou S/N
                string complemento = Input.PedeString("Complemento (deixar vazio caso não exista complemento): ");
                string bairro = Input.PedeString("Bairro: ");
                string cidade = Input.PedeString("Cidade: ");
                string estado = Input.EstadoUF();
                string pais = Input.PedeString("País: ");


                Imovel imovel = new(id, cpfProprietario, situacao, cep, logradouro, numero, complemento, bairro, cidade, estado, pais);

                string imovel2 = $"{id}|{cpfProprietario}|{situacao}|{cep}|{logradouro}|{numero}|{complemento}|{bairro}|{cidade}|{estado}|{pais}|{false}";

                repositorio.Insere(imovel, imovel2);
            }
        }
    }
}