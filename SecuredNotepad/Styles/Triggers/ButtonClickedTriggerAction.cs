using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SecuredNotepad.Slyles.Triggers
{
    class ButtonClickedTriggerAction : TriggerAction<Button>
    {
        protected override async void Invoke(Button sender)
        {
            await sender.ScaleTo(0.98, 50, Easing.CubicOut);
            sender.BorderColor = Color.FromHex("#EF7373");
            sender.TextColor = Color.FromHex("#404ce6");
            await sender.ScaleTo(1, 50, Easing.CubicIn);
        }
    }
}
