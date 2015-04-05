using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Es7
{
    static class Parser
    {
        public static List<Attivita> Parse(string filename, bool coppiaDipendenze)
        {
            List<Attivita> listaAttivita = new List<Attivita>();
            StreamReader reader = new StreamReader(filename);

            int numAttivita = int.Parse(reader.ReadLine());

            for (int i = 0; i < numAttivita; i++)
            {
                string[] s = reader.ReadLine().Split(',');
                int alunni = int.Parse(s[0]);
                int durata = int.Parse(s[1]);
                listaAttivita.Add(new Attivita((i + 1).ToString(), durata, alunni));
            }

            // se coppiaDipendenze è true, leggi le coppie di dipendenze come indicate nella consegna
            // altrimenti leggi per ogni attività tutte le attività precedenti e successive tramite una lista per ciascuno
            if (!coppiaDipendenze)
            {
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
            }
            else
            {
                while (!reader.EndOfStream)
                {
                    string[] dip = reader.ReadLine().Replace(" ", "").Split(',');
                    int prec = int.Parse(dip[0]);
                    int succ = int.Parse(dip[1]);
                    listaAttivita[prec - 1].Successive.Add(listaAttivita[succ - 1]);
                    listaAttivita[succ - 1].Precedenti.Add(listaAttivita[prec - 1]);
                }
            }

            return listaAttivita;
        }
    }
}
