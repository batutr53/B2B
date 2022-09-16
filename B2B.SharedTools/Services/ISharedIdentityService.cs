using System;
using System.Collections.Generic;
using System.Text;

namespace B2B.SharedTools.Services
{
    public interface ISharedIdentityService
    {
        public string GetUserId { get; }
    }
}
