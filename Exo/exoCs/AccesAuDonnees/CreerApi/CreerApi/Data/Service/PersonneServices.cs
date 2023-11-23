using CreerApi.Data.Models;

namespace CreerApi.Data.Service
{
    public class PersonneServices
    {
        private readonly PersonneDbContext _context;

        public PersonneServices(PersonneDbContext context)
        {
            _context = context;
        }

        public void AddPersonnes(Personne p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Personnes.Add(p);
            _context.SaveChanges();
        }
        public void DeletePersonne(Personne p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Personnes.Remove(p);
            _context.SaveChanges();
        }
        public IEnumerable<Personne> GetAllPersonnes()
        {
            return _context.Personnes.ToList();
        }
        public Personne GetPersonneById(int id)
        {
            return _context.Personnes.FirstOrDefault(p => p.Id == id);
        }
        public void UpdatePersonne(Personne p)
        {

        }
    }
}
