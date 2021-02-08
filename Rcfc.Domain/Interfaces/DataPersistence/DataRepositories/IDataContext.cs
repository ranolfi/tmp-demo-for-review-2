using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rcfc.Domain.Interfaces.DataPersistence.DataRepositories
{
    public interface IDataContext
    {
        void SaveChanges();
    }
}
