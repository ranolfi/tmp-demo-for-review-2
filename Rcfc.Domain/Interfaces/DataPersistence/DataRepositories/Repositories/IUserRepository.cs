using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rcfc.Domain.EntityModels;

namespace Rcfc.Domain.Interfaces.DataPersistence.DataRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAllWithAspNetIdentityUser();
    }
}
