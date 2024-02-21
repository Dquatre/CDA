
using testMongo.Models;

namespace testMongo.Dto
{
    public class LoginDto
    {
   
        public int Id { get; set; }

        public string Email { get; set; }

        public Adresse Password { get; set; }
    }
}
