using SecuredNotepad.ViewModels;
using SecuredNotepad.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SecuredNotepad
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteListPage), typeof(NoteListPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(AppShell), typeof(AppShell));

        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
