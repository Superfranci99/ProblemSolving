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

        public GestoreAttivita(List<Attivita> listaAttivita, Attivita primaAttivita, Attivita ultimaAttivita)
        {
            this.ListaAttivita = listaAttivita;
            this.Giorni = this.Alunni = 0;
            this.PrimaAttivita  = primaAttivita;
            this.UltimaAttivita = ultimaAttivita;
        }

        public void EseguiProgetto()
        {
            while (!this.UltimaAttivita.Conclusa)
            {
                List<Attivita> correnti = new List<Attivita>(); // attività concluse in un giorno
                foreach (Attivita attivita in this.ListaAttivita)
                {
                    // se le attività successive che avvengono nello stesso giorno dipendono da quelle che sono
                    // avvenute prima sempre nello stesso giorno, saltale
                    bool test = false;
                    foreach(Attivita prec in attivita.Precedenti)
                        if (correnti.Contains(prec)) { test = true; break; }
                    if (test)
                        continue;

                    if (attivita.Inizia(this.Giorni) || attivita.Iniziata)
                        correnti.Add(attivita); // avanza al giorno successivo per questa attività

                    attivita.Step();
                }
                this.Giorni++;
            }
        }
    }
}
