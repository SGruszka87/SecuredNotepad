using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecuredNotepad.Slyles.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHeaderView : ContentView
    {
        public FlyoutHeaderView()
        {
            InitializeComponent();
        }
    }
}