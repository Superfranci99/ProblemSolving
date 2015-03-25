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
            GestoreAttivita gestore = new GestoreAttivita(listaAttivita, primaAttivita, ultimaAttivita);
            gestore.EseguiProgetto();
            Console.WriteLine("Il numero di giorni è {0}", gestore.Giorni);
            Console.ReadLine();
        }

            List<Attivita> listaAttivita = Parser.Parse("test.txt"); // legge i dati da file



        }
    }
}
