using SecuredNotepad.Logs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SecuredNotepad.Services
{
    public class PermissionService
    {
        private ILoggingService _logger;
        public ILoggingService Logger
        {
            get
            {
                if (_logger == null) _logger = CrossLoggingService.Current;
                return _logger;
            }
        }

        public PermissionService()
        {

        }

        public async Task CheckStoragePermissions()
        {

            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            var status_2 = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            Logger.Info(AppEventCode.AppPermissions, string.Format("Permission check status for Storage Read {0} and for Write {1}", status, status_2));


            if (status != PermissionStatus.Granted && status_2 != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.StorageRead>();
                status_2 = await Permissions.RequestAsync<Permissions.StorageWrite>();

            }

            Logger.Info(AppEventCode.AppPermissions, string.Format("Permission for Storage Read {0} and for Write {1}", status, status_2));

            if (status != PermissionStatus.Granted && status_2 != PermissionStatus.Granted)
            {
                return;
            }
        }


    }

}
