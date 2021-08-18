using System.Collections.Generic;

namespace PrimeiroProjetoAvanade.Interfaces
{
    public interface InterfaceRepositorio<T>
    {
        List<T> Lista();
        T RetornaIdDigitado(int id);        
        void Insere(T entidade);        
        void Exclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
         
    }
