using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance
{
    public class RepositoryActionResult<T> where T : class
    {
        public T Entity { get; set; }
        public RepositoryActionStatus Status { get; set; }

        public Exception Exeption { get; set; }

        public RepositoryActionResult(T entity, RepositoryActionStatus status, Exception exception) : this(entity, status)
        {
            Exeption = exception;     
        }

        public RepositoryActionResult(T entity, RepositoryActionStatus status)
        {
            Entity = entity;
            Status = status;
        }
    }
}
