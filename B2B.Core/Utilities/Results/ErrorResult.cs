using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(object message) : base(success: false, message)
        {
        }
        public ErrorResult() : base(success: false)
        {
        }


    }
}
