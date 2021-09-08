using System;
using System.Linq;

// Överkomplicerad version av Fredagens övningsuppgifter för att lära sig om sakerna vi går igenom(eller "låna" kod).
namespace Övningsuppgifter_Fredag
{
    class Program
    {
        // Hämtar inmatning från konsolen och konverterar till en integer, accepterar ej negativa tal.
        // Kommer att fråga efter ett nytt tal ifall det inte går att konvertera till en integer.
        static int consoleToInt()
        {
            while (true)
            {
                int number = -1;
                string consoleInput = Console.ReadLine();
                bool validInput = int.TryParse(consoleInput, out number);

                if (validInput && number > -1 ? true : false)
                {
                    return number;
                }
                Console.WriteLine("Invalid Input! Try again.");
            }
        }

        // Kollar hur månge element i en string array som skall hoppas över och skriver sedan ut resten till konsolen.
        static void strArrPrint(string[] strArrIn, int skipNum = 0)
        {
            // ↓ Använder sig av System.Linq! ↓
            string[] strArrOut = strArrIn.Skip(skipNum).ToArray();
            // ↑ Använder sig av System.Linq! ↑

            foreach(string str in strArrOut)
            {
                Console.Write(str);
            }
            return;
        }

        static void Main()
        {
            Console.Clear();
            // Program loop
            while (true)
            {
                
                Console.WriteLine("Pick a number and hit enter to choose an exercise. \n" + 
                "1) \"Age and Vehicles\" \n" +
                "2) \"Cat and Dog Years\" \n" +
                "3) \"Ball Game\" \n"
                );

                // Val av uppgift.
                Console.Write("Exercise: ");
                switch (consoleToInt())
                {
                    // Uppgift: Ålder och Fordon.
                    case 1:
                        string[] vehicles = { "Bus (24 years), ", "Heavy Truck (21 years), ",
                            "Passenger Car (18 years), ", "EU Moped (15 years)" };
                        Console.Write("State your age: ");
                        double age = consoleToInt();
                        Console.WriteLine("\nYou are allowed to drive: ");

                        if (age >= 24)
                        {
                            strArrPrint(vehicles, 0);
                            break;
                        }
                        if (age >= 21)
                        {
                            strArrPrint(vehicles, 1);
                            break;
                        }
                        if (age >= 18)
                        {
                            strArrPrint(vehicles, 2);
                            break;
                        }
                        if (age >= 15)
                        {
                            strArrPrint(vehicles, 3);
                            break;
                        }
                        Console.WriteLine("Nothing. You're too young to drive much of anything if I'm gonna be honest with you...");
                        break;

                    // Uppgift: Katt år och Hund år.
                    case 2:
                        Console.Write("Please input your age: ");
                        while(true)
                        {
                            age = consoleToInt();
                            if(age == 0)
                            {
                                Console.WriteLine("Really? You are not 0 years old, at least give me something to work with like 1 or maybe 2?");
                            }
                            else 
                            {
                                break;
                            }
                        }

                        double dogYears = Math.Round(16 * Math.Log(age) + 31);
                        double catYears = 0;

                        if(age == 1)
                        {
                            catYears = 14;
                        }
                        else
                        {
                            if(age == 2)
                            {
                                catYears = 24;
                            }
                            else
                            {
                                catYears += Math.Round(age * 4 + 16);
                            }
                        }
                        
                        Console.WriteLine($"Age in dog years: {dogYears}.\nAge in cat years: {catYears}.");
                        break;

                    // Uppgift: Boll! (Nästan helt kopierad från facit repo)
                    // Notera konsolen måste vara på helskärm ifall du kör VScode!
                    case 3:
                        Console.Clear();
                        Console.CursorVisible = false;
                        // Bollens position
                        int bollX = 10;
                        int bollY = 10;

                        // Bollens riktning / hastighet
                        int bollXH = -2;
                        int bollYH = 2;

                        // Skärmgränser
                        int maxX = 100;
                        int maxY = 25;
                        int minX = 1;
                        int minY = 1;
                        for(int i = 300; i > 0; i--)
                        {

                            bollX += bollXH;
                            bollY += bollYH;

                            if (bollX>=maxX)
                            {
                                bollXH = -bollXH;
                                continue;
                            }
                            if (bollY >= maxY)
                            {
                                bollYH = -bollYH;
                                continue;
                            }

                            if (bollY < minY)
                            {
                                bollYH = -bollYH;
                                continue;
                            }

                            if (bollX < minX)
                            {
                                bollXH = -bollXH;
                                continue;
                            }

                            Console.SetCursorPosition(bollX, bollY);
                            Console.WriteLine(".-.");
                            Console.SetCursorPosition(bollX, bollY+1);
                            Console.WriteLine("'-'");
                            System.Threading.Thread.Sleep(50);
                            Console.SetCursorPosition(bollX, bollY);
                            Console.WriteLine("     ");
                            Console.SetCursorPosition(bollX, bollY+1);
                            Console.WriteLine("     ");
                        }
                        break;

                    // Körs endast ifall uppgifts-numret inte finns i switchen!
                    default:
                        Console.WriteLine("That exercise doesn't exist!");
                        break;
                }

                // Ränsar inför omstart...
                Console.WriteLine("\n\nPress enter to continue...");
                Console.ReadLine();
                Console.CursorVisible = true;
                Console.Clear();
            }
        }
    }
}

