using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Rcfc.DataPersistence.DataSources.Postgres_Rcfc;
using Rcfc.Domain.EntityModels;
using Rcfc.Domain.Interfaces.DataPersistence.DataRepositories;

namespace Rcfc.DataPersistence.DataRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EntityFrameworkContext dbContext;

        public UserRepository(EntityFrameworkContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return dbContext.Users.ToList();
        }

        public IEnumerable<User> GetAllWithAspNetIdentityUser()
        {
            return dbContext.Users.Include(x => x.AspNetIdentityUser).ToList();
        }
    }
}
