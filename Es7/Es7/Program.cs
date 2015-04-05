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

            // legge i dati da file
            List<Attivita> listaAttivita = Parser.Parse("test8.txt", true); 
            
            // crea ed avvia la gestione delle attività
            GestoreAttivita gestoreAttivita = new GestoreAttivita(
                listaAttivita,
                Gerarchia.PrimaAttivita(listaAttivita),
                Gerarchia.UltimaAttivita(listaAttivita));
            gestoreAttivita.EseguiProgetto();

            // mostra risultati
            Console.WriteLine("Il numero di giorni è {0}", gestoreAttivita.Giorni);
            Console.WriteLine("Il numero di alunni è {0}", GestoreAlunni.AlunniMinimi(listaAttivita, gestoreAttivita.Giorni));
            Console.ReadLine();
        }

    }
}
