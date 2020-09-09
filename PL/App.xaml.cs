using BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using PL.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // внедрение зависимостей
            NinjectModule serviceModule = new ServiceModule();
            NinjectModule uowModule = new UnitOfWorkModule("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebStoreDb;Integrated Security=True");
            var kernel = new StandardKernel(uowModule, serviceModule);

            var mainVM = kernel.Get<AppViewModel>();
            MainWindow = new MainWindow();
            MainWindow.DataContext = mainVM;
            MainWindow.Show();
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
        }
    }
}
