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

        public string Nome { get; set; }

        public int Durata { get; private set; }
        public int Alunni { get; private set; }

        private int Stato { get; set; }  // rappresenta il contatore dei giorni per cui l'attività è stata attiva
                                         // viene incrementato grazie al metodo Step()

        public Attivita(string nome, int durata, int alunni)
        {
            this.Nome       = nome;
            this.Iniziata   = this.Conclusa = false;
            this.DaIniziare = true;
            this.Durata     = durata;
            this.Alunni     = alunni;
            this.Stato      = 0;
            this.Precedenti = new List<Attivita>();
            this.Successive = new List<Attivita>();
        }

        public Attivita(string nome, int durata, int alunni, List<Attivita> precedenti, List<Attivita> successive)
            : this(nome, durata, alunni)
        {
            this.Precedenti = precedenti;
            this.Successive = successive;
        }

        public bool Inizia()
        {
            // controlla se è possibile iniziare
            if (Iniziata || Conclusa || (!DaIniziare))
                return false;
            if ((this.Precedenti.Count == 0) && (this.Successive.Count == 0))
                return false;

            // controlla se le attività precedenti sono state completate
            if (this.Precedenti.Exists(x => !x.Conclusa))
                return false;

            this.DaIniziare = false;
            this.Iniziata   = true;
            return true;
        }

        public void Step()
        {
            // controlla se è possibile procedere al giorno successivo
            if (DaIniziare || Conclusa || (!Iniziata))
                return;
            if ((this.Precedenti.Count == 0) && (this.Successive.Count == 0))
                return;

            this.Stato++;

            // quando i giorni richiesti sono passati, concludi l'attività
            if (this.Stato == this.Durata)
                Concludi();
        }

        private void Concludi()
        {
            this.DaIniziare = this.Iniziata = false;
            this.Conclusa   = true;
        }
    }
}
