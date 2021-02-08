using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Rcfc.Domain.EntityModels;
using Rcfc.Domain.Interfaces.ApplicationServices;
using Rcfc.Domain.Interfaces.DataPersistence.DataRepositories;

namespace Rcfc.ApplicationServices.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IDataContext dataContext;

        // obsolete
        // using Rcfc.DataPersistence.DataSources.Postgres_Rcfc;
        //public UserService(EntityFrameworkContext dbContext)
        //{
        //    MainDbContext = dbContext;
        //}
        // /obsolete

        public UserService(IUserRepository userRepository, IDataContext dataContext)
        {
            this.userRepository = userRepository;
            this.dataContext = dataContext;
        }

        public List<User> GetAll()
        {
            //var allUsers = new List<User>();
            //try
            //{
            //    allUsers = userRepository.GetAll().ToList();
            //}
            //catch (Exception)
            //{
            //    // TODO
            //    //throw;
            //}
            //return allUsers;

            try
            {
                return userRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                // TODO
                throw;
            }
        }

        public List<User> GetAllWithAspNetIdentityUser()
        {
            try
            {
                return userRepository.GetAllWithAspNetIdentityUser().ToList();
            }
            catch (Exception)
            {
                return new List<User>(); // TODO: This, or that?
            }
        }
    }
}
