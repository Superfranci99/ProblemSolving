using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es7
{
    static class GestoreAlunni
    {
        /// <summary>
        /// Confrontando le attività che avvengono contemporaneamente, ottiene il picco massimo di alunni necessari fra tutti i giorni
        /// </summary>
        /// <param name="listaAttivita">Lista delle attività</param>
        /// <param name="nGiorni">Numero di giorni totali</param>
        /// <returns>Alunni minimi per completare il progetto</returns>
        public static int AlunniMinimi(List<Attivita> listaAttivita, int nGiorni)
        {
            int[,] matrice = new int[listaAttivita.Count, nGiorni];
            foreach (Attivita attivita in listaAttivita)
                for (int i = 0; i < nGiorni; i++)
                    if (i >= attivita.GiornoInizio && i < attivita.GiornoInizio + attivita.Durata)
                        matrice[listaAttivita.IndexOf(attivita), i] = attivita.Alunni;
                    else
                        matrice[listaAttivita.IndexOf(attivita), i] = 0;

            int maxAlunni = -1;
            for (int i = 0; i < nGiorni; i++)
            {
                int somma = 0;
                for (int y = 0; y < listaAttivita.Count; y++)
                    somma += matrice[y, i];
                if (somma > maxAlunni)
                    maxAlunni = somma;
            }
            return maxAlunni;
        }
    }
}
