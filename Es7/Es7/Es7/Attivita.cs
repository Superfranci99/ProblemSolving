using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es7
{
    class Attivita
    {
        public bool Iniziata   { get; private set; }
        public bool Conclusa   { get; private set; }
        public bool DaIniziare { get; private set; }

        public List<Attivita> Precedenti { get; set; }
        public List<Attivita> Successive { get; set; }

        public int Durata { get; private set; }
        public int Alunni { get; private set; }

        public Attivita(int durata, int alunni)
        {
            this.Iniziata   = this.Conclusa = false;
            this.DaIniziare = true;
            this.Durata     = durata;
            this.Alunni     = alunni;
        }

        public Attivita(int durata, int alunni, List<Attivita> precedenti, List<Attivita> successive)
            : this(durata, alunni)
        {
            this.Precedenti = precedenti;
            this.Successive = successive;
        }
    }
}
