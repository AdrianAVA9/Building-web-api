using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance
{
    public enum Result
    {
        Updated = 1,
        Created = 2,
        Deleted = 3,
        NotFound = 4,
        Error = 5,
    }
}
