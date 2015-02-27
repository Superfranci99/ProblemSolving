using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Regola> regole = LeggiRegole();
            Richiesta richiesta = LeggiRichiesta();
        }




        static List<Regola> LeggiRegole()
        {
            List<Regola> result = new List<Regola>();
            string reg;
            while (true)
            {
                reg = Console.ReadLine();
                if (reg == "stop")
                    break;
                result.Add(new Regola(reg));
            }
            return result;
        }

        static Richiesta LeggiRichiesta()
        {
            Console.Write("Inserisci il risultato... ");
            char risultato = Console.ReadLine()[0];

            Console.Write("Inserisci i parametri... ");
            string[] parametriStr = Console.ReadLine().Replace(" ", "").Split(',');
            List<char> parametri = new List<char>();
            foreach (string s in parametriStr)
                parametri.Add(s[0]);

            return new Richiesta(parametri, risultato);
        }


        class Regola
        {
            public int Sigla { get; set; }
            public List<char> Antecedenti { get; set; }
            public char Conseguente { get; set; }

            public Regola(string reg)
            {
                reg = reg.Replace("regola(", "").Replace(")", "");
                string[] sep = reg.Split(',');

                Sigla       = int.Parse(sep[0]);
                Conseguente = (sep[2])[0];

                Antecedenti = new List<char>();
                sep[1] = sep[1].Replace("[", "").Replace("]", "");
                foreach (string ant in sep[1].Split(';'))
                    Antecedenti.Add(ant[0]);
            }
        }

        class Richiesta
        {
            public List<char> Parametri { get; set; }
            public char Risultato { get; set; }

            public Richiesta(List<char> parametri, char risultato)
            {
                Parametri = parametri;
                Risultato = risultato;
            }
        }
    }
}
