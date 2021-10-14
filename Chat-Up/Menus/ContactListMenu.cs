using System;
using static Chat_Up.ContactManagment.ContactFinders;
using static Chat_Up.InputHandler;

namespace Chat_Up.Menus
{
    class ContactListMenu
    {
        public static void Start()
        {
            Console.Clear();

            do
            {
                Console.WriteLine("How do you want to find your contact?\n" +
                    "The Alias option will show all information related to the contact found.\n\n" +
                    "1) First letter of name.\n" +
                    "2) Alias.\n" +
                    "3) List a certain amount of contacts.\n" +
                    "4) List all contacts.\n" +
                    "5) Find all blocked contacts.\n" +
                    "6) Find all ghosted contacts.\n"
                    );

                int choiceNum = ConsoleToInt();
                Console.Clear();
                if (choiceNum < 7 && choiceNum > 0)
                {
                    switch (choiceNum)
                    {
                        case 1:
                            Console.WriteLine("Please input desired letter to search for in the beginning of a contacts first name.");
                            ContactFinder(ConsoleToString(singleInput: true)[0]);

                            MenuReset();
                            return;

                        case 2:
                            Console.WriteLine("Please input desired Alias to search for.");
                            ContactFinder(ConsoleToString());

                            MenuReset();
                            return;

                        case 3:
                            Console.WriteLine("Please input how many contacts you wish to display.");
                            ContactFinder(ConsoleToInt());

                            MenuReset();
                            return;

                        case 4:
                            ContactFinder(listAll: true);

                            MenuReset();
                            return;

                        case 5:
                            ContactFinder(listBlocked: true);

                            MenuReset();
                            return;

                        case 6:
                            ContactFinder(listGhosted: true);

                            MenuReset();
                            return;

                        default:
                            Console.WriteLine("Please ask (insert responsible person) to unfuck their code.");
                            break;
                    }
                }

                Console.WriteLine($"\"{choiceNum}\" Is not a valid choice.");
            } while (true);
        }
    }
}
