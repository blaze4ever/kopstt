using Autofac;

namespace Kopstt.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WndowsRegistry>().As<IWndowsRegistry>();
        }
    }
}
