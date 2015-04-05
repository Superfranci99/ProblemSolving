using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es7
{
    static class Gerarchia
    {
        public static Attivita PrimaAttivita(List<Attivita> listaAttivita)
        {
            Attivita primaAttivita = null;
            listaAttivita.ForEach(x =>
            {
                if (x.Precedenti.Count == 0)
                    primaAttivita = x;
            });

            return primaAttivita;
        }

        public static Attivita UltimaAttivita(List<Attivita> listaAttivita)
        {
            Attivita ultimaAttivita = null;
            listaAttivita.ForEach(x =>
            {
                if (x.Successive.Count == 0)
                    ultimaAttivita = x;
            });

            return ultimaAttivita;
        }
    }
}
