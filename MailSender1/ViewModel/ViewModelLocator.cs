/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MailSender1"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data;
using MailSender.lib.Services;
using MailSender.lib.Services.EF;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;
using MailSender1.Infrastructure.Services;
using MailSender1.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MailSender1.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}


           // SimpleIoc.Default.Register(() => App.Configuration);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IRecipientsManager, RecipientsManager>();
            //SimpleIoc.Default.Register<IRecipientsStore, RecipientsStoreInMemory>();
            SimpleIoc.Default.Register<IRecipientsStore, RecipientsStoreEF>();
            SimpleIoc.Default.Register<ISenderStore, SendersStoreInMemory>();
            SimpleIoc.Default.Register<IServerStore, ServersStoreInMemory>();
            SimpleIoc.Default.Register<IMailStore, MailsStoreInMemory>();
            SimpleIoc.Default.Register<ISenderEditor, WindowSenderEditor>();
            SimpleIoc.Default.Register<MailSenderDBContext>();
            // SimpleIoc.Default.Register(() => new DbContextOptionsBuilder<MailSenderDBContext>().UseSqlServer(App.Configuration.GetConnectionString("DefaultConnection")).Options);
            SimpleIoc.Default.Register<MailSenderDBInitializer>();

            var db_init = (MailSenderDBInitializer) SimpleIoc.Default.GetService(typeof(MailSenderDBInitializer));
            var init_task = Task.Run(() => db_init.InitializeAsync());
            init_task.Wait();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}