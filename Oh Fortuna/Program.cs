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
            // Kommentera även bort player.Play() i koden i rad 102.
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\slotMachine.wav");

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

                // Har spelaren råd att spela spelet?
                if(pixAmount < 50)
                {
                    Console.WriteLine("You're too broke to play... Maybe try finding a different hobby?");
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                }

                // Placering av bet.
                while(true)
                {
                    Console.WriteLine($"You have: {pixAmount} pixs.");
                    Console.WriteLine("Minimum bet amount is 50 pixs.");
                    Console.Write("\nHow many pixs do you wish to bet?: ");
                    betAmount = consoleToInt();

                    if(betAmount >= 50)
                    {
                        break;
                    }

                    Console.WriteLine("You need to bet at least 50 pixs!");
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }

                if(betAmount > pixAmount)
                {
                    Console.WriteLine("You don't have that many pixs!! You can't bet what you don't have...");
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
                    Console.Clear();
                    for(int i = 0; i < 10; i++)
                    {
                        Random rnd = new Random();
                        diceNumber[0]  = rnd.Next(1, 6);
                        diceNumber[1]  = rnd.Next(1, 6);
                        diceNumber[2]  = rnd.Next(1, 6);
                        Console.WriteLine("   -----------");
                        Console.WriteLine($"  | {diceNumber[0]}   {diceNumber[1]}   {diceNumber[2]} |");
                        Console.WriteLine("   -----------");
                        Thread.Sleep(200);

                        if(i < 9)
                        {
                            Console.Clear();
                        }
                    }

                    // Kollar hur många pix spelaren van.
                    int preGamePixAmount = pixAmount;
                    pixAmount = pixAmount - betAmount;

                    for(int i = 0; i < 3; i++)
                    {
                        if(luckyNumber == diceNumber[i])
                        {
                            luckyNumberTally++;
                        }
                    }


                    if(luckyNumberTally != 0)
                    {
                        pixAmount += (luckyNumberTally + 1) * betAmount;
                    }

                    int postGamePixDifference = pixAmount - preGamePixAmount;
                    if(preGamePixAmount > pixAmount)
                    {
                        Console.WriteLine($"\nYou lost {postGamePixDifference} pixs. Better luck next time...");
                    }
                    else
                    {
                        Console.WriteLine($"\nCongratulations! You won {postGamePixDifference} pixs.");
                    }
                    
                    // Spela igen?
                    while(true)
                    {
                        Console.WriteLine("\nDo you wish to play again? y/n");
                        string playAgain = Console.ReadLine();
                        
                        if(playAgain == "n")
                        {
                            Console.WriteLine("Goodbye.");
                            System.Environment.Exit(1);
                        }
                        if(playAgain == "y")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid answer... Try again!");
                        }
                    }
                }
            }
        }
    }
}
