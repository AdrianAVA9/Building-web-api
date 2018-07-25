using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance
{
    public enum RepositoryActionStatus
    {
        Ok = 1,
        Updated = 2,
        Created = 3,
        Deleted = 4,
        NotFound = 5,
        NothingModified = 6,
        Error = 7,
    }
}
