using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Es7
{
    class Program
    {
        static void Main(string[] args)
        {
            int primaAttivita  = int.Parse(Console.ReadLine());
            int ultimaAttivita = int.Parse(Console.ReadLine());
            List<Attivita> listaAttivita = Parse("test.txt");
            GestoreAttivita gestore = new GestoreAttivita(listaAttivita, primaAttivita, ultimaAttivita);
            gestore.EseguiProgetto();
            Console.WriteLine("Il numero di giorni è {0}", gestore.Giorni);
            Console.ReadLine();
        }

        public static List<Attivita> Parse(string filename)
        {
            List<Attivita> listaAttivita = new List<Attivita>();
            StreamReader reader = new StreamReader(filename);

            int numAttivita = int.Parse(reader.ReadLine());

            for (int i = 0; i < numAttivita; i++)
            {
                string[] s = reader.ReadLine().Split(',');
                int alunni = int.Parse(s[0]);
                int durata = int.Parse(s[1]);
                listaAttivita.Add(new Attivita((i+1).ToString(), durata, alunni));
            }

            for (int i = 0; i < numAttivita; i++)
            {
                string[] precedenti = reader.ReadLine().Replace(" ", "").Split(',');
                string[] successive = reader.ReadLine().Replace(" ", "").Split(',');
                if (precedenti[0] != "null")
                    foreach (string s in precedenti)
                        listaAttivita[i].Precedenti.Add(listaAttivita[int.Parse(s) - 1]);
                if (successive[0] != "null")
                    foreach (string s in successive)
                        listaAttivita[i].Successive.Add(listaAttivita[int.Parse(s) - 1]);
            }
            return listaAttivita;
        }
    }
}
