using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Up
{
    class Person
    {
        // Denominations
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Alias { get; set; } = "";

        // Contact info
        public string Email { get; set; } = "";
        public string Linkedin { get; set; } = "";
        public string Facebook { get; set; } = "";
        public string Instagram { get; set; } = "";
        public string Twitter { get; set; } = "";
        public string Github { get; set; } = "";

        // Likes and Dislikes. Misc
        public string FavoriteFood { get; set; } = "";
        public string FavoriteAnimal { get; set; } = "";
        public string FavoriteMovieGenre { get; set; } = "";
        public string HatedFood { get; set; } = "";
        public string Misc { get; set; } = "";

        // Numerical values
        public int Age { get; set; } = -1;
        public int Birthday { get; set; } = -1;

        // Boolean values
        public bool IsBlocked { get; set; } = false;
        public bool IsGhosted { get; set; } = false;
    }
}
