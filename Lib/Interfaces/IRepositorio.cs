namespace Lib.Interfaces
{
   public interface IRepositorio<T>
   {
      T RetornaPorId(int id);

      void Insere(T entidade, string entidade2);

      void Exclui(int id);

      void Atualiza(int id, T entidade);

      int ProximoId();
   }
}