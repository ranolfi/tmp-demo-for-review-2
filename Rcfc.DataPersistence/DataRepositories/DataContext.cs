using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rcfc.DataPersistence.DataSources.Postgres_Rcfc;
using Rcfc.Domain.Interfaces.DataPersistence.DataRepositories;

namespace Rcfc.DataPersistence.DataRepositories
{
    public class DataContext : IDataContext
    {
        private readonly EntityFrameworkContext dbContext;

        public DataContext(EntityFrameworkContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
