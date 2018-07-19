using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance
{
    public class ActionResult: where <T> is class
    {
        public Exception Exception { get; set; }
        public Result Result { get; set; }
        public T Entity { get; set; }

        public ActionResult(Exception ex, Result result, T entity):this(result,entity)
        {
            Exception = ex;
        }

        public ActionResult(Result result, T entity)
        {
            Result = result;
            Entity = entity;
        }
    }
}
