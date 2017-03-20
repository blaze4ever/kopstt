using Autofac;
using Kopstt.Classes;

namespace Kopstt
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>();
            builder.RegisterType<SetOnStartup>();
        }
    }
}
