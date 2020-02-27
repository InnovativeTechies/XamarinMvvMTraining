using Ninject;
using Ninject.Modules;
using TripLogEntryApp.Interfaces;
using TripLogEntryApp.Modules;
using TripLogEntryApp.Services;
using TripLogEntryApp.ViewModels;
using TripLogEntryApp.Views;
using Xamarin.Forms;

namespace TripLogEntryApp
{
    public partial class App : Application
    {

            public IKernel Kernel { get; set; }

        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();

            // Register core services
            Kernel = new StandardKernel(
                new TripLogCoreModule(),
                new TripLogNavModule());

            // Register platform specific services
            Kernel.Load(platformModules);

            SetMainPage();
        }

        void SetMainPage()
        {
            var mainPage = new NavigationPage(new MainPage())
            {
                BindingContext = Kernel.Get<MainViewModel>()
            };

            var navService = Kernel.Get<INavService>() as XamarinFormsNavService;

            navService.XamarinFormsNav = mainPage.Navigation;

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

}

