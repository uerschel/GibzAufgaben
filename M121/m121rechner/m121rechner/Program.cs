using System;
using System.Text.RegularExpressions;

namespace m121rechner
{
    class Program
    {
        static void Main(string[] args)
        {
            string zahlen = System.IO.File.ReadAllText(@"C:\Users\ursin\Desktop\m121rechner\m121rechner\Datei\Rand1000001.txt");
            int leser = 0;
            double summe = 0;
            double zahl = 0;
            int stelle = 10;
            int vorzeichen = 1;
            int vorkomma = 1;
            while(leser <= zahlen.Length - 1)
            {
                if(zahlen[leser] == '-')
                {
                    vorzeichen = -1;
                }
                if (Char.IsNumber(zahlen[leser]) && vorkomma == 1)
                {
                    zahl *= 10;
                    zahl += zahlen[leser];
                }
                if (zahlen[leser] == '.')
                {
                    vorkomma = 0;
                }
                if (Char.IsNumber(zahlen[leser]) && vorkomma == 0)
                {
                    zahl += zahlen[leser]/stelle;
                    stelle *= 10;
                }
                if(zahlen[leser] == ',')
                {
                    stelle = 10;
                    vorkomma = 1;
                    summe += zahl * vorzeichen;
                    zahl = 0;
                    vorzeichen = 1;
                }
                leser++;
            }
            Console.WriteLine(summe);
        }
    }
}
