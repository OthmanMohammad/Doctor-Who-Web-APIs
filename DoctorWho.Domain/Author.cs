using System.Collections.Generic;

namespace DoctorWho.Domain
{
    // Declare the Author class
    public class Author
    {
        // Define a default constructor that initializes the Episodes property as a new List of Episode
        public Author()
        {
            this.Episodes = new List<Episode>();
        }

        // Define a constructor that takes in an AuthorName parameter and calls the default constructor
        public Author(string AuthorName) : this()
        {
            this.AuthorName = AuthorName;
        }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        // Declare the Episodes property of type List of Episode
        public List<Episode> Episodes { get; set; }
    }
}