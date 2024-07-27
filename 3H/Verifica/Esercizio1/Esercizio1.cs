using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Esercizio1
{
    internal class Esercizio1
    {
        static void Main(string[] args)
        {
            string[] zona = { "Abruzzo", "Basilicata", "Calabria", "Campania", "Emilia-Romagna", "Friuli-Venezia Giulia", "Lazio", "Liguria" };
            string[] periodo = { "Primavera 2022", "Estate 2022", "Autunno 2022", "Inverno 2022", "Primavera 2023", "Estate 2023" };

            int[,] pioggia = {
                //Abr  Bas  Cal  Cam  Emi  fvg  laz   lig
                { 119,  89, 126, 176, 264, 226, 173,  29 },  // Pri 2022
                {  56, 112,  72, 236, 269, 260,  52,  34 },  // Est 2022
                { 214,  44,  47, 216, 279,  24, 299,  12 },  // Aut 2022
                { 164,  51, 111, 263, 279, 163, 147, 181 },  // Inv 2022
                { 163,  16, 125,  77, 295,  32, 137,  34 },  // Pri 2023
                { 186, 132,  71, 204, 284, 181, 197, 127 },  // Est 2023
            };

            Debug.Assert(pioggia.GetLength(0) == periodo.Length);  // periodo[] è "prallelo" alle righe
            Debug.Assert(pioggia.GetLength(1) == zona.Length);  // zona[] è "prallelo" alle colonne

            // Punto (a)
            StampaPiovositaMax(pioggia, zona, periodo);

            // Punto (b)
            string periodo_voluto = "Primavera 2023";
            StampaZonaMaggiorePiovosita(pioggia, zona, periodo, periodo_voluto);

            // Punto (c)
            int i_periodo, i_zona;
            IndividuaPiovositaMinAssoluta(pioggia, zona, periodo, out i_periodo, out i_zona);
            Console.WriteLine($"Il perido di piovosità min assoluta è {periodo[i_periodo]} e la zona è {zona[i_zona]}");
        }

        #region Punto A
        static void StampaPiovositaMax(int[,] pioggia, string[] zona, string[] periodo)
        {
            double mediaMassima = 0.0;
            int periodoMediaMassima = 0;

            for (int i = 0; i < pioggia.GetLength(0); i++)
            {
                int sommaPeriodoCorrente = 0;
                double mediaCorrente = 0.0;

                for (int j = 0;  j < pioggia.GetLength(1); j++)
                {
                    sommaPeriodoCorrente += pioggia[i,j];
                }

                mediaCorrente = sommaPeriodoCorrente / pioggia.GetLength(1);
                if (mediaCorrente > mediaMassima)
                {
                    mediaMassima = mediaCorrente;
                    periodoMediaMassima = i;
                }
            }

            Console.WriteLine($"La piovosità massima è avvenuta nel periodo di: {periodo[periodoMediaMassima]}");
        }
        #endregion

        #region Punto B
        static void StampaZonaMaggiorePiovosita(int[,] pioggia, string[] zona, string[] periodo, string periodo_voluto)
        {
            // Cerco l'indice del periodo
            int indicePeriodo = -1;
            for (int i = 0; i < periodo.Length; i++)
            {
                if (periodo[i] == periodo_voluto)
                {
                    indicePeriodo = i;
                    break;
                }
            }

            // se si inserisce un periodo sbagliato esce dalla funzione con un messaggio di errore.
            if (indicePeriodo < 0)
            {
                Console.WriteLine("Il periodo inserito non è stato registrato.");
                return;
            }

            // Cerco il valore tra le zone con maggiore piovosità
            int massimaPiovosita = int.MinValue;
            int indiceZonaMassima = 0;
            for (int i = 0; i < pioggia.GetLength(1); i++) 
            {
                if (pioggia[indicePeriodo, i] > massimaPiovosita)
                {
                    indiceZonaMassima = i;
                    massimaPiovosita = pioggia[indicePeriodo, i];
                }
            }

            Console.WriteLine($"La zona con maggiore piovosità durante il periodo {periodo_voluto} è: {zona[indiceZonaMassima]}");
        }
        #endregion

        #region Punto C
        static void IndividuaPiovositaMinAssoluta(int[,] pioggia, string[] zona, string[] periodo, out int i_periodo, out int i_zona)
        {
            int minimaPiovosita = int.MaxValue;
            int indiceZonaMinima = 0;
            int indicePeriodoMinimo = 0;

            for (int i = 0; i < pioggia.GetLength(0); i++)
            {
                for (int j = 0; j < pioggia.GetLength(1); j++)
                {
                    if (minimaPiovosita > pioggia[i,j])
                    {
                        minimaPiovosita = pioggia[i, j];
                        indicePeriodoMinimo = i;
                        indiceZonaMinima = j;
                    }
                }
            }

            i_periodo = indicePeriodoMinimo;
            i_zona = indiceZonaMinima;
        }
        #endregion
    }
}
