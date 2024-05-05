using Store.Model;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Store
{
    public partial class App : Application
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);
            ApplicationContext context = new ApplicationContext();
        }
    }

}
