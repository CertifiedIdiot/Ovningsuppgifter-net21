using System;

namespace Chat_Up
{
    class InputHandler
    {

        public static string[] ConsoleToFullName()
        {
            do
            {
                string firstName = "";
                string lastName = "";

                Console.WriteLine("\nPlease write a First name.");
                firstName = ConsoleToString();

                Console.WriteLine("\nPlease write a Last name.");
                lastName = ConsoleToString();

                Console.WriteLine($"\nIs \"{firstName} {lastName}\" correct?");
                if (YesNoChoice() == true)
                {
                    string[] fullName = { firstName, lastName };
                    return fullName;
                }
                else
                {
                    Console.WriteLine("\nLets try this again.");
                }
            } while (true);
        }

        public static int[] ConsoleToBirthAge()
        {
            int year = 0, month = 0, day = 0, age = 0;
            string dateOfBirth = "";
            var currentDate = DateTime.Today;
            string currentDateStr = $"{currentDate.Year}{currentDate.Month}{currentDate.Day}";

            Console.WriteLine("\nDo you wish to update contact birthday? yyyy/mm/dd");

            if(YesNoChoice() == false)
            {
                int[] birthAgeEmpty = {-1, -1};
                return birthAgeEmpty;
            }

            Console.WriteLine("\nWhat year were you born in?");
            year = ConsoleToInt();

            Console.WriteLine("\nWhat month were you born in?");
            month = ConsoleToInt();

            Console.WriteLine("\nWhat day were you born on?");
            day = ConsoleToInt();

            dateOfBirth = year.ToString() + month.ToString("D2") + day.ToString("D2");
            Console.WriteLine(dateOfBirth);

            age = (int.Parse(currentDateStr) - int.Parse(dateOfBirth)) / 10000;

            int[] birthAge = {int.Parse(dateOfBirth), age};

            return birthAge;
        }

        public static bool YesNoChoice()
        {
            Console.WriteLine("y/n?");
            do
            {
                string yesNoChoice = Console.ReadLine().ToLower();
                if (yesNoChoice == "y")
                {
                    return true;
                }
                if (yesNoChoice == "n")
                {
                    return false;
                }

                Console.WriteLine("\nPlease choose either \"y\" for yes or \"n\" for no.");
            } while (true);
        }


        public static string ConsoleToString(bool obligatoryInput = true, bool singleInput = false)
        {
            string strInput = "";

            if (obligatoryInput || singleInput)
            {
                if (obligatoryInput && singleInput != true)
                {
                    do
                    {
                        strInput = Console.ReadLine();

                        if (strInput == "")
                        {
                            Console.WriteLine("\nYou have to enter something.");
                        }
                        else
                        {
                            return strInput;
                        }
                    } while (true);
                }
                else
                {
                    strInput = Console.ReadLine();

                    if (strInput == "" && strInput.Length == 1)
                    {
                        Console.WriteLine("\nYou have to enter something and it must be a single character.");
                    }
                    else
                    {
                        return strInput;
                    }
                }
            }

            return Console.ReadLine();
        }

        public static int ConsoleToInt()
        {
            while (true)
            {
                int number = -1;
                string consoleInput = Console.ReadLine();
                bool validInput = int.TryParse(consoleInput, out number);

                if (validInput && number > -1)
                {
                    return number;
                }
                Console.WriteLine("\nPlease type a valid number.");
            }
        }

        public static void MenuReset()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Menus.MainMenu.Start();
        }
    }
}