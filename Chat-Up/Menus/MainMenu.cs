using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Chat_Up.InputHandler;
using static Chat_Up.ContactManagment.ContactManager;


namespace Chat_Up.Menus
{
    class MainMenu
    {
        public static void Start()
        {
            Console.Clear();

            do
            {
                Console.WriteLine(
                        "1) Create new contact. \n" +
                        "2) Contact listings. \n" +
                        "3) Update contact. \n" +
                        "4) Delete contact. \n" +
                        "5) Block or Ghost contact.");

                int choiceNum = ConsoleToInt();
                if (choiceNum < 6 && choiceNum > 0)
                {
                    switch (choiceNum)
                    {
                        case 1:
                            CreateContactMenu.Start();
                            return;

                        case 2:
                            ContactListMenu.Start();
                            return;

                        case 3:
                            UpdateContactMenu.SetUp();
                            return;

                        case 4:
                            Console.Clear();

                            Console.WriteLine("Input the alias of the contact you wish to delete.");
                            DeleteContact(ConsoleToString());

                            MenuReset();
                            return;

                        case 5:
                            Console.Clear();

                            Console.WriteLine("Input the alias of the contact you wish to block or ghost.");
                            string alias = ConsoleToString();

                            if (ContactIsValid(GetContactIndex(alias)))
                            {
                                int contactIndex = GetContactIndex(alias);
                                var contact = ContactList[contactIndex];
                                bool blockToggle = false, ghostToggle = false;
                                string isBlocked = "No", isGhosted = "No";

                                if(contact.IsBlocked)
                                {
                                    isBlocked = "Yes";
                                }
                                if(contact.IsGhosted)
                                {
                                    isGhosted = "Yes";
                                }

                                Console.WriteLine($"Do you wish to toggle the block status on \"{alias}\"?");
                                Console.WriteLine("\nBlocked: " + isBlocked);
                                blockToggle = YesNoChoice();

                                Console.WriteLine($"Do you wish to toggle the ghost status on \"{alias}\"?");
                                Console.WriteLine("\nGhosted: " + isGhosted);
                                ghostToggle = YesNoChoice();

                                toggleBlockGhost(contactIndex, blockToggle, ghostToggle);
                            }

                            MenuReset();
                            return;


                        default:
                            Console.WriteLine("Please ask (insert responsible person) to unfuck their code.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine($"\"{choiceNum}\" Is not a valid choice.");
                }
            } while (true);
        }
    }
}