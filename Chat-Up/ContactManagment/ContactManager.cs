using System;
using System.Collections.Generic;
using System.Threading;

namespace Chat_Up.ContactManagment
{
    class ContactManager
    {
        public static List<Person> ContactList = new List<Person>
        {
            new Person() {FirstName = "John", LastName = "Doe", Alias = "Johnny Cash", Email = "Hello.World@gmail.com", Misc = "Foobar"}
        };

        public static void CreateContact(string firstName, string lastName, string alias)
        {
            ContactList.Add(new Person { FirstName = firstName, LastName = lastName, Alias = alias });
        }

        public static void DeleteContact(string alias)
        {
            try
            {
                ContactList.Remove(ContactList[GetContactIndex(alias)]);
                Console.WriteLine("\nContact successfully removed!");
            }
            catch
            {
                Console.WriteLine("\nError: Delete operation unsuccessfull.");
            }
        }

        public static void UpdateContact(string[] newContactInfo, int[] newBirthAge, int contactIndex)
        {
            string[] oldContactInfo = {
            ContactList[contactIndex].FirstName,
            ContactList[contactIndex].LastName,
            ContactList[contactIndex].Alias,
            ContactList[contactIndex].Email,
            ContactList[contactIndex].Linkedin,
            ContactList[contactIndex].Facebook,
            ContactList[contactIndex].Instagram,
            ContactList[contactIndex].Twitter,
            ContactList[contactIndex].Github,
            ContactList[contactIndex].FavoriteFood,
            ContactList[contactIndex].FavoriteAnimal,
            ContactList[contactIndex].FavoriteMovieGenre,
            ContactList[contactIndex].HatedFood,
            ContactList[contactIndex].Misc,
            };

            int[] oldBirthAge = { 
                ContactList[contactIndex].Birthday, 
                ContactList[contactIndex].Age 
            };

            for (int i = 0; i < oldBirthAge.Length; i++)
            {
                if (newBirthAge[i] == -1)
                {
                    newBirthAge[i] = oldBirthAge[i];
                }
            }

            for (int i = 0; i < oldContactInfo.Length; i++)
            {
                if(newContactInfo[i] == "")
                {
                    newContactInfo[i] = oldContactInfo[i];
                }
            }   

            ContactList[contactIndex].FirstName = newContactInfo[0];
            ContactList[contactIndex].LastName = newContactInfo[1];
            ContactList[contactIndex].Alias = newContactInfo[2];
            ContactList[contactIndex].Email = newContactInfo[3];
            ContactList[contactIndex].Linkedin = newContactInfo[4];
            ContactList[contactIndex].Facebook = newContactInfo[5];
            ContactList[contactIndex].Instagram = newContactInfo[6];
            ContactList[contactIndex].Twitter = newContactInfo[7];
            ContactList[contactIndex].Github = newContactInfo[8];
            ContactList[contactIndex].FavoriteFood = newContactInfo[9];
            ContactList[contactIndex].FavoriteAnimal = newContactInfo[10];
            ContactList[contactIndex].FavoriteMovieGenre = newContactInfo[11];
            ContactList[contactIndex].HatedFood = newContactInfo[12];
            ContactList[contactIndex].Misc = newContactInfo[13];

            ContactList[contactIndex].Birthday = newBirthAge[0];
            ContactList[contactIndex].Age = newBirthAge[1];
        }

        public static int GetContactIndex(string alias)
        {
            foreach (var contact in ContactList)
            {
                if (alias.ToLower() == contact.Alias.ToLower())
                {
                    return ContactList.IndexOf(contact);
                }
            }

            Console.WriteLine("\nError: Contact Index not found. Alias invalid!");
            return -1;
        }

        public static string[] GetContactInfo(string alias)
        {
            var contact = ContactList[GetContactIndex(alias)];
            string isBlocked = "No";
            string isGhosted = "No";

            if (contact.IsBlocked)
            {
                isBlocked = "Yes";
            }
            if (contact.IsGhosted)
            {
                isGhosted = "Yes";
            }

            string[] contactInfo = {
                "\nName: " + contact.FirstName + " " + contact.LastName,
                "\nAlias: "  + contact.Alias,
                "\nEmail: " + contact.Email,
                "\nLinkedin: " + contact.Linkedin,
                "\nFacebook: " + contact.Facebook,
                "\nInstagram: " + contact.Instagram,
                "\nTwitter: " + contact.Twitter,
                "\nGithub: " + contact.Github,
                "\nFavorite Food: " + contact.FavoriteFood,
                "\nFavorite Animal: " + contact.FavoriteAnimal,
                "\nFavorite Movie Genre: " + contact.FavoriteMovieGenre,
                "\nHated Food: " + contact.HatedFood,
                "\nMisc: " + contact.Misc,
                "\nAge: " + contact.Age,
                "\nBirthday " + contact.Birthday,
                "\nBlocked: " + isBlocked,
                "\nGhosted: " + isGhosted
            };

            return contactInfo;
        }

        public static bool ContactIsValid(int contactIndex)
        {
            try
            {
                if (ContactList[contactIndex] != null)
                {
                    return true;
                }
            }
            catch
            {

                return false;
            }

            return false;
        }

        public static void toggleBlockGhost(int contactIndex, bool toggleBlock = false, bool toggleGhost = false)
        {
            if (toggleBlock)
            {
                if (ContactList[contactIndex].IsBlocked == true)
                {
                    ContactList[contactIndex].IsBlocked = false;
                }
                else
                {
                    ContactList[contactIndex].IsBlocked = true;
                }
            }

            if (toggleGhost)
            {
                if (ContactList[contactIndex].IsGhosted == true)
                {
                    ContactList[contactIndex].IsGhosted = false;
                }
                else
                {
                    ContactList[contactIndex].IsGhosted = true;
                }
            }
        }
    }
}
