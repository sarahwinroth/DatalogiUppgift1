using System;
using System.Collections.Generic;

namespace DatalogiUppgift1
{
    internal class Program
    {
        //Valde en linjär datastruktur för att lägga in och spara alla primtal i
        public static List<int> list = new List<int>();

        /// <summary>
        /// Kollar först om listan är tom. Är den det så läggs nummer 2 in som är det minsta primtalet.
        /// Om listan inte är tom så hämtas sista värdet i listan och adderar det med 1.
        /// Detta görs fortsättningsvis genom en while-loop som körs tills nästa primtal har hittats. 
        /// När nästa primtal hittats läggs den till i listan.
        /// </summary>
        public static void AddNextPrimeNum()
        {
            if (!ListIsEmpty())
            {
                int lastPrimeNum = list[list.Count - 1];
                lastPrimeNum = lastPrimeNum + 1;

                while (!CheckIfPrimeNumber(lastPrimeNum))
                {
                    lastPrimeNum++;
                }

                list.Add(lastPrimeNum);
                Console.WriteLine();
                Console.WriteLine(lastPrimeNum + " är det nästa högsta primtal och har lagts till i listan");
                PressEnterAndReturnToMenu();
            }
            else
            {
                int num = 2;
                list.Add(num);
                Console.WriteLine();
                Console.WriteLine("Listan är tom så minsta primtalet nummer " + num + " har lagts till i listan");
                PressEnterAndReturnToMenu();
            }
        }

        /// <summary>
        /// Lägger till talet som skickats in som parameter i listan och sorterar listan.
        /// </summary>
        /// <param name="input">Ett primtal</param>
        public static void AddNumberToListAndSort(int num)
        {
            list.Add(num);
            list.Sort();
        }

        /// <summary>
        /// Här nedan är ett exempel på en sekventiell sökning där metoden letar efter värdet som användaren matat in i listan. 
        /// Värdena i listan behöver inte vara sorterade för att göra en sån sökning.
        /// </summary>
        /// <param name="input">Ett tal</param>
        /// <returns>Returnerar true om talet redan existerar i listan annars false</returns>
        public static bool CheckIfNumberExistInList(int input)
        {
            foreach (var num in list)
            {
                if (num == input)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kollar om talet som skickats in som parameter är ett primtal. Metoden kollar om talet är mindre än 2, isåfall är talet inte ett primtal.
        /// Annars så körs en loop, där variabeln i är satt till 2 och så länge i är mindre eller lika med hälften av talet. 
        /// Om talet delbart med sig själv är lika med 0 så är talet inte ett primtal.
        /// Om inte påståendet för loopen stämmer så är talet ett primtal. 
        /// </summary>
        /// <param name="num">Ett tal</param>
        /// <returns>Returnerar true om numret är ett primtal annars false</returns>
        public static bool CheckIfPrimeNumber(int num)
        {
            if (num < 2) return false;
            
            else
            {
                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }              
                return true;
            }
        }

        /// <summary>
        /// Kollar om antalet element i listan är lika med 0.
        /// </summary>
        /// <returns>Returnerar true om listan är tom annars false</returns>
        public static bool ListIsEmpty()
        {
            if (list.Count == 0) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Första metoden som anropas när programmet körs.
        /// Visar en meny med valmöjligheter för användaren att välja mellan som anropar passande metoder.
        /// </summary>
        public static void Menu()
        {
            try
            {
                bool run = true;
                while (run)
                {
                    Console.Clear();
                    Console.WriteLine("[MENY]");
                    Console.WriteLine("1. Lägg till ett tal");
                    Console.WriteLine("2. Skriv ut alla primtal");
                    Console.WriteLine("3. Lägg till nästa högsta primtal i listan");
                    Console.WriteLine("4. Avsluta");
                    Console.Write("> ");

                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            UserAddNumber();
                            break;

                        case 2:
                            PrintList();
                            break;

                        case 3:
                            AddNextPrimeNum();
                            break;

                        case 4:
                            run = false;
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Fel inmatning, vänligen försök igen.");
                PressEnterAndReturnToMenu();
            }
        }

        /// <summary>
        /// Metod som skriver ut anvisning till användaren att trycka enter, för att sedan återgå till Menyn genom att anropa metoden Menu()
        /// </summary>
        public static void PressEnterAndReturnToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("[TRYCK ENTER]");
            Console.ReadLine();
            Menu();
        }

        /// <summary>
        /// Kollar om listan är tom om inte så skrivs alla element/värden ur listan ut med hjälp av en loop
        /// </summary>
        public static void PrintList()
        {
            Console.Clear();
            Console.WriteLine("[ALLA PRIMTAL]");
            if (ListIsEmpty())
            {
                Console.WriteLine();
                Console.WriteLine("Listan är tom..");
            }
            else
            {
                foreach (var num in list)
                {
                    Console.WriteLine(num);
                }
            }
            PressEnterAndReturnToMenu();
        }

        /// <summary>
        /// Låter användare mata in ett tal för att kolla om det inmatade talet är ett primtal. 
        /// Om talet är ett primtal så kollas om primtalet redan existerar i listan med primtal, om inte så läggs talet in i listan och listan sorteras.
        /// Om talet redan existerar i listan så skrivs ett meddelande ut till användaren samma gäller om talet inte är ett primtal men låter användaren 
        /// skriva in ett tal tills ett primtal har matats in.
        /// </summary>
        public static void UserAddNumber()
        {
            Console.Clear();
            Console.WriteLine("Skriv in ett nummer: ");
            Console.Write("> ");

            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                bool isPrimeNumber = CheckIfPrimeNumber(input);
                if (isPrimeNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine(input + " är ett primtal!");

                    if (CheckIfNumberExistInList(input))
                    {
                        Console.WriteLine("Primtalet existerar redan i listan, vänligen försök igen");
                        UserAddNumber();
                    }
                    else
                    {
                        AddNumberToListAndSort(input);
                        PressEnterAndReturnToMenu();
                    }                  
                }
                else if (!isPrimeNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine(input + " är INTE ett primtal!");
                    Console.WriteLine("[TRYCK ENTER]");
                    Console.ReadLine();
                    UserAddNumber();
                }
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Fel inmatning, vänligen försök igen.");
                PressEnterAndReturnToMenu();
            }
        }

        private static void Main(string[] args)
        {
            Menu();
        }
    }
}