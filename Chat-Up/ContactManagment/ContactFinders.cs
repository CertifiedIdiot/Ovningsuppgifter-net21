using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Up.ContactManagment
{
    class ContactFinders : ContactManager
    {
        public static void ContactFinder(int listAmount = 0, bool listAll = false)
        {
            if (listAll)
            {
                foreach (var contact in ContactList)
                {
                    Console.WriteLine($"\nName: \"{contact.FirstName} {contact.LastName}\" Alias: \"{contact.Alias}\"");
                }

                return;
            }
            else
            {
                int y = 0;
                foreach (var contact in ContactList)
                {
                    Console.WriteLine($"\nName: \"{contact.FirstName} {contact.LastName}\" Alias: \"{contact.Alias}\"");

                    y++;
                    if(listAmount == y)
                    {
                        return;
                    }
                }
            }
        }

        public static void ContactFinder(string alias, bool muteWriteLine = false)
        {
            foreach (var contact in ContactList)
            {
                if (contact.Alias.ToLower() == alias.ToLower())
                {
                    string[] contactInfo = GetContactInfo(alias);

                    if (muteWriteLine != true)
                    {
                        foreach(string infoStr in contactInfo)
                        {
                            Console.WriteLine(infoStr);
                        }
                    }
                }
            }
        }


        public static void ContactFinder(char keyChar)
        {
            string strTemp = keyChar.ToString().ToLower();
            keyChar = strTemp[0];

            foreach(var contact in ContactList)
            {
                strTemp = contact.FirstName.ToLower();
                char contactChar = strTemp[0];
                
                if (contactChar == keyChar)
                {
                    Console.WriteLine($"Name: \"{contact.FirstName} {contact.LastName}\" Alias: \"{contact.Alias}\"");
                }
            }
        }

        public static void ContactFinder(bool listBlocked = false, bool listGhosted = false)
        {
            if (listBlocked)
            {
                foreach(var contact in ContactList)
                {
                    if (contact.IsBlocked)
                    {
                        Console.WriteLine($"Name: \"{contact.FirstName} {contact.LastName}\" Alias: \"{contact.Alias}\"");
                    }
                }
            }

            if (listGhosted)
            {
                foreach (var contact in ContactList)
                {
                    if (contact.IsGhosted)
                    {
                        Console.WriteLine($"Name: \"{contact.FirstName} {contact.LastName}\" Alias: \"{contact.Alias}\"");
                    }
                }
            }
        }
    }
}
