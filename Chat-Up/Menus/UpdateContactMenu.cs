using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chat_Up.ContactManagment.ContactManager;
using static Chat_Up.InputHandler;

namespace Chat_Up.Menus
{
    class UpdateContactMenu
    {
        
        public static void SetUp()
        {
            Console.Clear();

            Console.WriteLine("Please input the Alias of the contact you wish to update.");
            Start(ConsoleToString());
        }

        public static void Start(string alias)
        {
            Console.Clear();

            int contactIndex = GetContactIndex(alias);

            if(ContactIsValid(contactIndex) != true)
            {
                MenuReset();
                return;
            }
            
            List<string> newContactInfo = new List<string>();
            var contact = ContactList[contactIndex];

            Console.WriteLine("Time to update your contact...");
            Console.WriteLine("\nSimply press enter without typing anything to leave at default(default = what is shown).");

            Console.WriteLine("\nFirst name: " + contact.FirstName);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nLast name: " + contact.LastName);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nAlias: " + contact.Alias);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nEmail: " + contact.Email);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nLinkedin: " + contact.Linkedin);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nFacebook: " + contact.Facebook);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nInstagram: " + contact.Instagram);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nTwitter: " + contact.Twitter);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nGithub: " + contact.Github);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nFavorite Food: " + contact.FavoriteFood);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nFavorite Animal: " + contact.FavoriteAnimal);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nFavorite Movie Genre: " + contact.FavoriteMovieGenre);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nHated Food: " + contact.HatedFood);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            Console.WriteLine("\nMisc: " + contact.Misc);
            newContactInfo.Add(ConsoleToString(obligatoryInput: false));

            UpdateContact(newContactInfo.ToArray(), ConsoleToBirthAge(), contactIndex);

            MenuReset();
        }
    }
}
