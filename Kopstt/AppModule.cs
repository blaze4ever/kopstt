using Autofac;
using Kopstt.Classes;
using Kopstt.Classes.SwitchingModules;
using Kopstt.Modules;

namespace Kopstt
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>();
            builder.RegisterType<SetOnStartup>();
            builder.RegisterType<Inbox>().SingleInstance();
            builder.RegisterType<SevenDays>().SingleInstance();
            builder.RegisterType<Today>().SingleInstance();
            builder.RegisterType<FadeAnimation>();
            builder.RegisterType<ClearModules>();
        }
    }
}
