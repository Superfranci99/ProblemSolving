using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es1
{
    class Program
    {
        static string[] rr = {"regola(1,[b;t],f)",
"regola(2,[t],b)",
"regola(3,[a],u)",
"regola(4,[x],j)",
"regola(5,[f;t],p)",
"regola(6,[x;j],k)",
"regola(7,[j;h;k],e)",
"regola(8,[u;k],e)",
"regola(9,[a;u],k)",
"regola(10,[j;k],h)",
"regola(11,[f;t],u)",
"regola(12,[u;p],e)"};

        static void Main(string[] args)
        {
            //List<Regola> regole = LeggiRegole();
            List<Regola> regole= new List<Regola>();
            foreach (string r in rr)
                regole.Add(new Regola(r));

            Richiesta richiesta = LeggiRichiesta();
            Calcolatore c = new Calcolatore(regole, richiesta);
            c.Risolvi();
        }

        class Calcolatore
        {
            public List<Regola> Regole   { get; private set; }
            public Richiesta    Risposta { get; private set; }
            List<char> trovati = new List<char>();

            public Calcolatore(List<Regola> regole, Richiesta richiesta)
            {
                Regole = regole;
                Risposta = richiesta;
            }

            public void Risolvi()
            {
                /*
                trovati.Add('t');
                
                List<Regola> filoni  = new List<Regola>(); // lista che contiene le regole i cui risultati sono il risultato al problema

                //ottieni i due filoni
                foreach (Regola r in Regole)
                    if (r.Conseguente == Risposta.Risultato)
                        filoni.Add(r);
                Regole.Reverse();

                foreach (Regola r in filoni)
                {
                    string cc = SviluppaRegola(r);
                }*/
                string cc = Solve(Regole[6], "path_");
            }

            private string Solve(Regola regola, string path)
            {
                throw new NotImplementedException();

                // lista per le soluzioni degli antecedenti
                List<string> solutions = new List<string>(regola.Antecedenti.Count);     

                // per ogni antecedente della regola trova le regole che lo restituiscono come risultato
                foreach(char ant in regola.Antecedenti)
                {
                    if (Risposta.Parametri.Contains(ant) && (regola.Antecedenti.Count != Risposta.Parametri.Count))
                        continue;
                    // aggiungi la regola corrente al percorso
                    string currPath = path + regola.Sigla + "_";               


                    // TO FIX --> quando una regola ha come parametro un paramentro inserito dall'utente
                    /*List<Regola> withoutParams = new List<Regola>();
                    foreach (Regola r in Regole)
                    {
                        // TODO - controlla tutti i parametri e non solo col primo
                        if (r.Antecedenti.Contains(Risposta.Parametri[0]))
                        {
                            withoutParams.Add(new Regola(r));
                            withoutParams[withoutParams.Count - 1].Antecedenti.Remove(Risposta.Parametri[0]);
                        }                           
                    }*/
                        
                            
                    // ottiene la lista di regole utili e applicabili
                    List<Regola> searchIn = new List<Regola>();
                    foreach (Regola r in Regole) 
                        if ((r.Conseguente == ant)  && Applicabile(r)) //|| Risposta.Parametri.Contains(ant))
                            searchIn.Add(r);

                    // risolvi le regole plausibili
                    foreach (Regola r in searchIn)
                    {
                        currPath = Solve(r, currPath);
                    }

                    // controlla se il percorso è finito correttamente,
                    // cioè se gli antecedenti della regola sono solo parametri inseriti dall'utente
                    bool check = true;
                    foreach (char a in regola.Antecedenti)
                        if (!Risposta.Parametri.Contains(a))
                            check = false;
                    if (check)
                        return currPath + "!";

                    solutions.Add(currPath);
                }

                string fullPath = Unisci(solutions);
                if (fullPath.Contains("!") && Risposta.Risultato != regola.Conseguente)
                    return fullPath;

                // se il risultato della regola è uguale alla risposta, restituisci il percorso
                // altrimenti restituisci una stringa nulla --> il percorso non ha portato risultati
                //if (Risposta.Risultato == regola.Conseguente)
                return solutions[0] + "&&&&" + solutions[1] + "&&&&" + solutions[2];
                //else
                //    return string.Empty;
                

            }

            private string Unisci(List<String> paths)
            {
                throw new NotImplementedException();

                // dividi i due percorsi in liste di stringhe, inserendo in l1 la lista più corta
                List<string> l1, l2;
                if (paths[0].Length > paths[1].Length)
                {
                    l1 = paths[1].Replace("!", "").Split('_').ToList<string>();
                    l2 = paths[0].Replace("!", "").Split('_').ToList<string>();
                }
                else
                {
                    l1 = paths[0].Replace("!", "").Split('_').ToList<string>();
                    l2 = paths[1].Replace("!", "").Split('_').ToList<string>();
                }

                // elimina la regola iniziale perché è sempre uguale
                l1.RemoveAt(0);
                l2.RemoveAt(0);

                // ricerca di corrispondenze
                int start1, start2, end1, end2;
                for (int i = l1.Count; i > 0; i--)
                {
                    for (int pos = 0; pos < l1.Count; pos += i)
                    {
                        // TODO - estrai una serie di elementi da una lista e aggiungili ad una stringa
                        //        controlla poi se
                        string substr = l2.substring();
                    }
                        
                }



                
            }

            private bool Applicabile(Regola r)
            {
                bool flag = false;
                foreach (char c in r.Antecedenti)
                {
                    flag = false;
                    if (Risposta.Parametri.Contains(c))
                        flag = true;
                    else
                        foreach (Regola reg in Regole)
                            if (reg.Conseguente == c)
                            {
                                flag = true;
                                break;
                            }
                    if (!flag)
                        break;
                }
                return flag; 
            }

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

            public Regola(Regola reg)
            {
                this.Sigla = reg.Sigla;
                this.Conseguente = reg.Conseguente;
                this.Antecedenti = new List<char>();
                
                reg.Antecedenti.ForEach(x=> this.Antecedenti.Add(x));
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
