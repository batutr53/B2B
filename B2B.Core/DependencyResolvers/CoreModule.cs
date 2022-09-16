using B2B.Core.CrossCuttingConcerns.Caching;
using B2B.Core.CrossCuttingConcerns.Caching.Microsoft;
using B2B.Core.Utilities.IoC;
using B2B.SharedTools.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<ISharedIdentityService, SharedIdentityService>();
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
