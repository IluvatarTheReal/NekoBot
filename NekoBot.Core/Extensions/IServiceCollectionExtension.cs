using Microsoft.Extensions.DependencyInjection;
using NekoBot.Core.Services;
using NekoBot.Infrastructure;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NekoBot.Core.Extensions
{
    public static class IServiceCollectionExtension
    {
        private static readonly Logger logger = LogManager.GetLogger("NekoBot");

        /// <summary>
        /// Add singleton from every class and interface implementing the specified interface type
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="assembly">Assembly to search in</param>
        /// <param name="interfaceType">Type of the interface to search for</param>
        /// <returns>Collection of type that were added as singleton</returns>
        public static IEnumerable<Type> LoadTypeFrom(this IServiceCollection serviceCollection, Assembly assembly, Type interfaceType)
        {
            // list of all the types which are added with this method
            List<Type> addedTypes = new List<Type>();

            Type[] serviceTypesArray;
            try
            {                
                serviceTypesArray = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                NekoLog.Log(logger, ex);
                return Enumerable.Empty<Type>();
            }

            var serviceTypesList = new List<Type>(serviceTypesArray
                .Where(x => x.GetInterfaces().Contains(interfaceType) && !x.GetTypeInfo().IsInterface && !x.GetTypeInfo().IsAbstract)
                .ToArray());

            addedTypes.AddRange(serviceTypesList);

            var serviceInterfacesHash = new HashSet<Type>(serviceTypesArray
                .Where(x => x.GetInterfaces().Contains(interfaceType) && x.GetTypeInfo().IsInterface));

            foreach (var serviceType in serviceTypesList)
            {
                if (serviceCollection.FirstOrDefault(x => x.ServiceType == serviceType) != null)
                    continue;
                
                var interfaceT = serviceInterfacesHash.FirstOrDefault(x => serviceType.GetInterfaces().Contains(x));
                if (interfaceT != null)
                {
                    addedTypes.Add(interfaceT);
                    serviceCollection.AddSingleton(interfaceT, serviceType);
                }
                else                
                    serviceCollection.AddSingleton(serviceType, serviceType);                
            }                        

            return addedTypes;
        }

    }
}
