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
    }
}
