using System;
using static Chat_Up.ContactManagment.ContactManager;
using static Chat_Up.InputHandler;


namespace Chat_Up.Menus
{
    class CreateContactMenu
    {

        public static void Start()
        {
            Console.Clear();

            Console.WriteLine("Time to create a new contact...");
            string[] fullName = ConsoleToFullName();
            string alias = "";

            Console.Clear();

            do
            {
                Console.WriteLine("\nEnter an Alias for this contact.");
                alias = ConsoleToString();

                Console.WriteLine($"\nDo you wish to use \"{alias}\" as your Alias?");
                if (YesNoChoice() == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nLets try again.");
                }
            } while (true);

            CreateContact(fullName[0], fullName[1], alias);

            Console.WriteLine("\nContact created succesfully. Do you wish to fill out additional information now?");
            if (YesNoChoice() == true)
            {
                UpdateContactMenu.Start(alias);
            }
            else
            {
                MainMenu.Start();
            }
        }
    }
}
