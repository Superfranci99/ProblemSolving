using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Francesco Bozzo - Esercizio 7\r\n");

            // ottiene la prima e l'ultima attività
            Console.Write("Inserisci la prima attività del progetto... ");
            int primaAttivita  = int.Parse(Console.ReadLine());
            Console.Write("Inserisci l'ultima attività del progetto... ");
            int ultimaAttivita = int.Parse(Console.ReadLine());

            List<Attivita> listaAttivita = Parser.Parse("test.txt"); // legge i dati da file

            // crea ed avvia la gestione delle attività
            GestoreAttivita gestoreAttivita = new GestoreAttivita(listaAttivita, primaAttivita, ultimaAttivita);
            gestoreAttivita.EseguiProgetto();

            Console.WriteLine();

            // mostra risultati
            Console.WriteLine("Il numero di giorni è {0}", gestoreAttivita.Giorni);
            Console.WriteLine("Il numero di alunni è {0}", GestoreAlunni.AlunniMinimi(listaAttivita, gestoreAttivita.Giorni));
            Console.ReadLine();
        }

    }
}
