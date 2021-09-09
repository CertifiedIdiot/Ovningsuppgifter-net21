using System;
// Används för Thread.Sleep()
using System.Threading;

// Kan ej köras på andra system än windows tack vare Nugeten som är inkluderad för att spela ljud.
namespace Oh_Fortuna
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
                string consoleOutput = Console.ReadLine();
                bool validInput = int.TryParse(consoleOutput, out number);

                if (validInput && number > -1 ? true : false)
                {
                    return number;
                }
                Console.WriteLine("Invalid Input! Try again.");
            }
        }

        static void Main()
        {
            // Olika Stack Overflow inlägg ihop klistrade för att spela ljud. :^)
            // Glöm inte att kommentera bort denna raden ifall du inte ändrar dens PATH till ljud filen.
            // Kommentera även bort player.Play() i koden i rad 108.
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Unknown\Desktop\OwlsRepo-net21\Oh Fortuna\slotMachine.wav");

            // Starta med 500 pix.
            // Minst 50 pix per bet.
            // Tre tärningar skall kastas.
            // En tärning med lyckotal = dubbel insats.
            // Två tärningar med lyckotal = tripel insats.
            // Tre tärningar med lyckotal = fyrdubbel insats.
            
            // Spel-loop
            // Deklarering av variabler i scope av hela spelet.
            int pixAmount = 500;
            int betAmount = 0;
            while(true)
            {
                Console.Clear();

                // Placering av bet.
                while(true)
                {
                    Console.WriteLine($"You have: {pixAmount} pix.");
                    Console.WriteLine("Minimum bet amount is 50 pix.");
                    Console.Write("\nHow many pixs do you wish to bet?: ");
                    betAmount = consoleToInt();

                    if(betAmount >= 50)
                    {
                        break;
                    }

                    Console.WriteLine("You need to bet at least 50 pix!");
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
                if(betAmount > pixAmount)
                {
                    Console.WriteLine("You don't have that many pix!! You can't bet what you don't have...");
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }

                // Kast av tärningar och val av lucky number.
                else
                {
                    int luckyNumber = 0;
                    Console.Clear();

                    // Val av lucky number.
                    while(true)
                    {
                        Console.Write("\nWhat is your lucky number? Must be between 1 and 6: ");
                        luckyNumber = consoleToInt();
                        if(luckyNumber >= 1 && luckyNumber <= 6)
                        {
                            break;
                        }
                        Console.WriteLine("Number is not between 1 and 6, try again.");
                    }
                    
                    Console.Clear();
                    Console.WriteLine("Rolling the dice of fate...");
                    Thread.Sleep(2000);

                    int[] diceNumber = {0, 0, 0};
                    int luckyNumberTally = 0;

                    // Kast av tärningar.
                    player.Play();
                    for(int i = 10; i != 0; i--)
                    {
                        Random rnd = new Random();
                        diceNumber[0]  = rnd.Next(1, 6);
                        diceNumber[1]  = rnd.Next(1, 6);
                        diceNumber[2]  = rnd.Next(1, 6);
                        Console.WriteLine("   -----------");
                        Console.WriteLine($"  | {diceNumber[0]}   {diceNumber[1]}   {diceNumber[2]} |");
                        Console.WriteLine("   -----------");
                        Thread.Sleep(200);
                        if(i > 1)
                        {
                            Console.Clear();
                        }
                    }

                    // Kollar hur många pix spelaren van.
                    int preGamePixAmount = pixAmount;

                    if(diceNumber[0] == luckyNumber)
                    {
                        luckyNumberTally++;
                    }
                    if(diceNumber[1] == luckyNumber)
                    {
                        luckyNumberTally++;
                    }
                    if(diceNumber[2] == luckyNumber)
                    {
                        luckyNumberTally++;
                    }


                    if(luckyNumberTally == 0)
                    {
                        pixAmount -= betAmount;
                    }
                    if(luckyNumberTally == 1)
                    {
                        pixAmount += betAmount * 2;
                    }
                    if(luckyNumberTally == 2)
                    {
                        pixAmount += betAmount * 3;
                    }
                    if(luckyNumberTally == 3)
                    {
                        pixAmount += betAmount * 4;
                    }

                    int postGamePixDifference = pixAmount - preGamePixAmount;
                    if(preGamePixAmount > pixAmount)
                    {
                        Console.WriteLine($"\nYou lost {postGamePixDifference}. Better luck next time...");
                    }
                    else
                    {
                        {
                            Console.WriteLine($"\nCongratulations! You won {postGamePixDifference}.");
                        }
                    }
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}
