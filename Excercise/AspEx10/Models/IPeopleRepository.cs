using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspEx10.Models
{

    public interface IPeopleRepository
    {
        IQueryable<Person> People { get; }

        void CreatePerson(Person p);
        void DeletePerson(Person p);
        void SavePerson(Person p);
    }

}