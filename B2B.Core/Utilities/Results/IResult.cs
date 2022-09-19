using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        object Message { get; }
    }
}
