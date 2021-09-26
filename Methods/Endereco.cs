namespace Imobiliaria
{
    public class Endereco
    {
      protected internal static void NovoEndereco(long cpf)
      {
        int cep = Input.Cep(); // somente números - 8 dígitos
        string logradouro = Input.PedeString("Logradouro (sem número): ");
        int numero = Input.Numero(); // 0 para sem número ou S/N
        string complemento = Input.PedeString("Complemento (deixar vazio caso não exista complemento): ");
        string bairro = Input.PedeString("Bairro: ");
        string cidade = Input.PedeString("Cidade: ");
        string estado = Input.EstadoUF();
        string pais = Input.PedeString("País: ");

        Classes.Endereco endereco = new(cpf, cep, logradouro, numero, complemento, bairro, cidade, estado, pais);



        //Endereco(long cpf, int cep, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string pais)
      }
    }
}