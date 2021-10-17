using System.Collections.Generic;

namespace Imobiliaria.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();

         T RetornaPorId(int id);

         void Insere (T entidade, string entidade2);

         void Exclui(int id);

         void Atualiza(int id, T entidade, List<T> entidade2);

         int ProximoId();
    }
}