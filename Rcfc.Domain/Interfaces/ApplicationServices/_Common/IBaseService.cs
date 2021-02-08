using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Rcfc.Domain.Interfaces.ApplicationServices
{
    public interface IBaseService
    {
        // protected internal EntityFrameworkContext MainDbContext; // TODO: repository (?)

        protected internal IConfiguration Configuration { get; } // TODO: If I don't have this here I won't need the
                                                                 // 'Microsoft.Extensions.Configuration.JSON' dependency
                                                                 // in this project ('Rcfc.Domain').
    }
}
