using SecuredNotepad.DB;
using SecuredNotepad.Logs;
using SecuredNotepad.Services;
using SecuredNotepad.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecuredNotepad
{
    public partial class App : Application
    {

        public PermissionService appPermission;

        private ILoggingService _logger;
        public ILoggingService Logger
        {
            get
            {
                if (_logger == null) _logger = CrossLoggingService.Current;
                return _logger;
            }
        }


        public App()
        {
            Check_app_permissions();

            if (!DBInit.CreateDb())
            {
                Logger.Error(AppEventCode.AppDBCreate, "Error during creation DB");
            }

            InitializeComponent();

              
    
            MainPage = new AppShell();
        }

        private async Task Check_app_permissions()
        {

            await appPermission.CheckStoragePermissions();

            return;
        }

        protected override void OnStart()
        {
            Logger.Trace(AppEventCode.AppStart, "App Start");
        }

        protected override void OnSleep()
        {
            Logger.Trace(AppEventCode.AppStop, "App Sleep");
        }

        protected override void OnResume()
        {
            Logger.Trace(AppEventCode.AppResume, "App Resume");
            Check_app_permissions();
        }
    }
}
