using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vue.Data
{

    public class PeopleRepository
    {
        private string _connectionString;

        public PeopleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> GetPeople()
        {
            using (var context = new PeopleDbDataContext(_connectionString))
            {
                return context.Persons.ToList();
            }
        }

        public void Add(Person person)
        {
            using (var context = new PeopleDbDataContext(_connectionString))
            {
                context.Persons.InsertOnSubmit(person);
                context.SubmitChanges();
            }
        }

        public void Update(Person person)
        {
            using (var context = new PeopleDbDataContext(_connectionString))
            {
                context.Persons.Attach(person);
                context.Refresh(RefreshMode.KeepCurrentValues, person);
                context.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new PeopleDbDataContext(_connectionString))
            {
                context.ExecuteCommand("DELETE FROM People WHERE Id = {0}", id);
            }
        }
    }
}
