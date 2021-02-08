using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Rcfc.Domain.EntityModels;
using Rcfc.ApplicationServices.Services;
//using Rcfc.DataPersistence.DataSources.Postgres_Rcfc;
//using Microsoft.EntityFrameworkCore;

namespace Rcfc.WebApplication.Pages.Users
{
    public class ListModel : BasePageModel
    {
        //private readonly EntityFrameworkContext context;
        private readonly UserService userService;
        public List<User> AllUsers;

        //public ListModel(EntityFrameworkContext context) // This should not work under any circumstances
        //{
        //    this.context = context;
        //}
        public ListModel(UserService userService)
        {
            this.userService = userService;
        }

        public void OnGet()
        {
            //AllUsers = context.Users.Include(x => x.AspNetIdentityUser).ToList();
            AllUsers = userService.GetAllWithAspNetIdentityUser();
        }
    }
}
