namespace Imobiliaria
{
   public class Imoveis
    {
        protected internal static void NovoImovel(long cpfProprietario)
        {
            string situacao = Input.Situacao();
            int cep = Input.Cep(); // somente números - 8 dígitos
            string logradouro = Input.PedeString("Logradouro (sem número): ");
            int numero = Input.Numero(); // 0 para sem número ou S/N
            string complemento = Input.PedeString("Complemento (deixar vazio caso não exista complemento): ");
            string bairro = Input.PedeString("Bairro: ");
            string cidade = Input.PedeString("Cidade: ");
            string estado = Input.EstadoUF();
            string pais = Input.PedeString("País: ");

            Classes.Imovel imovel = new(cpfProprietario, situacao, cep, logradouro, numero, complemento, bairro, cidade, estado, pais);
        }
    }
}