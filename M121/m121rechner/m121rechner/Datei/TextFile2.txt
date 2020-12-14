using System;
using System.Text.RegularExpressions;

namespace m121rechner
{
    class Program
    {
        static void Main(string[] args)
        {
            string vorzahlen = System.IO.File.ReadAllText(@"C:\Users\ursin\Desktop\GIBZ\Gibzcode\GibzAufgaben\M121\m121rechner\m121rechner\Datei\Rand1000001.txt");
            string[] zahlen = vorzahlen.Split(",");
            double summe = 0;
            foreach(string str in zahlen)
            {
                summe += Double.Parse(str);
            }
            Console.WriteLine(summe/2);
        }
    }
}
