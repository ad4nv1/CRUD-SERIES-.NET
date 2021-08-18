using System;
using System.Collections.Generic;
using PrimeiroProjetoAvanade.Interfaces;

namespace PrimeiroProjetoAvanade
{
    public class SeriesRepositorio : InterfaceRepositorio<Series>
    {
        private List<Series> listaSerie = new List<Series>();
        public void Atualiza(int id, Series entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Series entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Series> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Series RetornaIdDigitado(int id)
        {
            return listaSerie[id];
        }
    }
}