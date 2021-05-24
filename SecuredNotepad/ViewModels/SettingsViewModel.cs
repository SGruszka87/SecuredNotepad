using SecuredNotepad.Logs;
using SecuredNotepad.Resources;
using SecuredNotepad.Services;
using SecuredNotepad.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SecuredNotepad.ViewModels
{
    public class SettingsViewModel : BaseViewModel
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

        #region Models            

        private string _password = string.Empty;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }


        #endregion


        public SettingsViewModel() { }



        #region Commands


        Command _changeLanguagePL;
        public Command ChangeLanguagePL
        {
            get
            {
                Command command = _changeLanguagePL ?? (_changeLanguagePL = new Command(() => ChangeLanguage("Polish")));
                return command;
            }
        }

       

        Command _changeLanguageEN;
        public Command ChangeLanguageEN
        {
            get
            {
                Command command = _changeLanguageEN ?? (_changeLanguageEN = new Command(() => ChangeLanguage("English")));
                return command;
            }
        }

        Command _commandPassword;
        public Command CommandPassword
        {
            get
            {
                Command command = _commandPassword ?? (_commandPassword = new Command(() => AddPasswordToNotes()));
                return command;
            }
        }

        private void AddPasswordToNotes()
        {
            if (Password != string.Empty)
            {

                Settings.Password = Password;
                Logger.Trace(AppEventCode.Password, "Password has beed added...");
                Device.BeginInvokeOnMainThread(() => { Application.Current.MainPage.DisplayAlert(AppResources.DisplayAlertPasswordAdded, "", "OK"); });              
            }    
        }


        private void ChangeLanguage(string lang)
        {
            try
            {
                var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().First(element => element.EnglishName.Contains(lang));
                AppResources.Culture = language;
                Device.BeginInvokeOnMainThread(() => { App.Current.MainPage = new NavigationPage(new SettingsPage());  });
                Logger.Trace(AppEventCode.ChangeLanguage, String.Format("Language has beed changed to {0}", lang));
            }
            catch (Exception ex)
            {
                Logger.Error(AppEventCode.ChangeLanguage, ex.ToString());
            }
        }


        

        #endregion


   





    }
}
