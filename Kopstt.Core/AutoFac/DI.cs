using System;
using System.Linq;
using Autofac.Core;

namespace Kopstt.Core.AutoFac
{
    using Autofac;

    public static class DI
    {
        public static ContainerBuilder CreateBuilder()
        {
            var builder = new ContainerBuilder();

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => t.IsAssignableTo<IModule>() && t.IsClass && !t.IsAbstract);

            foreach (var type in types)
            {
                builder.RegisterModule((IModule)Activator.CreateInstance(type));
            }

            return builder;
        }
    }
}
