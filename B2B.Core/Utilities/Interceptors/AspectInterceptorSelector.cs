using B2B.Core.Aspects.Autofac.Exception;
using B2B.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts.Loggers;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {

        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes =
                type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            //Dışlanacak Methodlar. Bu method isimleri çakışmaya sebep olabiliyor.
            string[] methodsToExclude = { "Validate", "Info", "Debug", "Warning", "Warn", "Error", "Fatal", "Localize", "GetStringResource", "GetResourceValue" };

            if (!methodsToExclude.Contains(method.Name))
            {
                try
                {
                    var methodAttributes =
                        type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

                    classAttributes.AddRange(methodAttributes);
                    classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
                }
                catch (Exception ex)
                {
                    // ignored 
                }
            }
            //classAttributes.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}