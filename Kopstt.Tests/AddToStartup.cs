using Autofac;
using Kopstt.Classes;
using Kopstt.Core;
using Kopstt.Core.AutoFac;
using Xunit;

namespace Kopstt.Tests
{
    public class AddToStartup
    {
        IContainer container;
        public AddToStartup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppModule>();
            builder.RegisterModule<CoreModule>();
            container = builder.Build();
        }

        [Fact]
        public void test_add_chcheckbox_checked_to_registry()
        {
            //arragne
            var windows_registry = container.Resolve<IWndowsRegistry>();
            var set_on_startup = container.Resolve<SetOnStartup>();

            set_on_startup.AppName = "Kopstt";
            set_on_startup.ExecutablePath = @"D:\PROJECTS\kopstt\Kopstt\bin\Debug\Kopstt.exe";
            var check_box = true;

            //act
            set_on_startup.setAppOnStartup(check_box);

            //assert
            var value = windows_registry.GetValue(set_on_startup.AppName);
            Assert.NotNull(value);
            Assert.Equal(set_on_startup.ExecutablePath, value);
        }

        [Fact]
        public void test_delete_autostart_from_registry()
        {
            //arragne
            var windows_registry = new WndowsRegistry();
            var set_on_startup = new SetOnStartup(windows_registry);
            set_on_startup.AppName = "Kopstt";
            set_on_startup.ExecutablePath = @"D:\PROJECTS\kopstt\Kopstt\bin\Debug\Kopstt.exe";

            //act
            set_on_startup.setAppOnStartup(true);
            set_on_startup.setAppOnStartup(false);

            //assert
            var value = windows_registry.GetValue(set_on_startup.AppName);
            Assert.Null(value);

        }
    }
}
