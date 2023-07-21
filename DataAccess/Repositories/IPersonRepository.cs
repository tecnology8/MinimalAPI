using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPersonRepository
    {
        Task<bool> Update(Person person);
        Task<bool> Add(Person person);
        Task<Person> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<Person>> GetAll();
    }
}
