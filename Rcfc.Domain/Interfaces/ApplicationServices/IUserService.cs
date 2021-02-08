using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rcfc.Domain.EntityModels;

namespace Rcfc.Domain.Interfaces.ApplicationServices
{
    public interface IUserService : IBaseService
    {
        public List<User> GetAll();

        public List<User> GetAllWithAspNetIdentityUser();
    }
}
