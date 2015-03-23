using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es7
{
    class GestoreAttivita
    {
        public List<Attivita> ListaAttivita { get; set; } // le attività sono ordinate nella lista in base al loro nome (A1, A2, A3...)

        public int Giorni { get; set; } // giorni impiegati dall'insieme delle attività
        public int Alunni { get; set; } // alunni necessari per svolgere le attività

        public Attivita PrimaAttivita  { get; set; }
        public Attivita UltimaAttivita { get; set; }

        public GestoreAttivita(List<Attivita> listaAttivita, int primaAttivita, int ultimaAttivita)
        {
            this.ListaAttivita = listaAttivita;
            this.Giorni = this.Alunni = 0;
            this.PrimaAttivita  = this.ListaAttivita[primaAttivita - 1];
            this.UltimaAttivita = this.ListaAttivita[ultimaAttivita - 1];
        }
    }
}
