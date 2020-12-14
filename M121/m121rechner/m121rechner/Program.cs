using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace m121rechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            char[] zahlen;
            using (StreamReader sr = File.OpenText(@"C:\Users\ursin\Desktop\GIBZ\Gibzcode\GibzAufgaben\M121\m121rechner\m121rechner\Datei\Rand10000001.txt"))
            {
                string s = sr.ReadToEnd();
                zahlen = s.ToCharArray();
            }
            int leser = 0;
            int vorkommaSumme = 0;
            double summe = 0;
            int nachkommastelle = 0;
            int vorzeichen = 1;
            int vorkomma = 1;
            int anzahlZahlen = 10000000;
            int stelle = 0;
            int[] zahlenspeicher = new int[20];
            Regex _regex = new Regex(@"\-");

            while (leser < zahlen.Length - 1 && stelle < anzahlZahlen)
            {
                char zeichen = zahlen[leser];
                if (Char.IsDigit(zeichen))
                {
                    if(vorkomma == 1)
                    {
                        vorkommaSumme *= 10;
                        vorkommaSumme += zeichen - '0';
                    }
                    else
                    {
                        zahlenspeicher[nachkommastelle] += vorzeichen*(zeichen - '0');
                        zahlenspeicher = zahlenspeicher;
                        nachkommastelle++;
                    }
                    leser++;
                }
                else if (zeichen == '-')
                {
                    vorzeichen = -1;
                    leser++;
                }
                else if(zeichen == '.'){
                    vorkomma = 0;
                    leser++;
                }
                else if (zeichen == ',')
                {
                    summe += vorzeichen * vorkommaSumme;
                    vorkommaSumme = 0;
                    nachkommastelle = 0;
                    vorkomma = 1;
                    vorzeichen = 1;
                    leser++;
                    stelle++;
                }
                else
                {
                    leser++;
                }

            }
            for(int i = 0; i < zahlenspeicher.Length - 1; i++)
            {
                summe += (double)zahlenspeicher[i] / Math.Pow(10, i + 1);
            }
            stopWatch.Stop();
            Console.WriteLine("Summe: " + summe + " vergangene Zeit: " + stopWatch.Elapsed);
        }
    }
}
