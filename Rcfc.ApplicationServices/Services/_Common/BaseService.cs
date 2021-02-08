using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using Rcfc.DataPersistence.DataSources;
using Rcfc.DataPersistence.DataSources.Postgres_Rcfc;
using Rcfc.Domain.Interfaces.ApplicationServices;

namespace Rcfc.ApplicationServices
{
    public abstract class BaseService : IBaseService
    {
        // TODO: Review; not all services may need the DB Context
        [Obsolete("This is kept for reference purposes but should NOT be used.", true)]
        protected internal EntityFrameworkContext MainDbContext;

        public BaseService()
        {
        }

        IConfiguration IBaseService.Configuration { get; } = Application.GetConfiguration();
    }
}
