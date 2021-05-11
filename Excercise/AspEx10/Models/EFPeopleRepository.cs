using System.Linq;

namespace AspEx10.Models
{
    public class EFPeopleRepository : IPeopleRepository
    {
        private PeopleDBContext context;
        public EFPeopleRepository(PeopleDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Person> People => context.People;

        public void CreatePerson(Person p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeletePerson(Person p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SavePerson(Person p)
        {
            context.SaveChanges();
        }
    }
}
