using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SecuredNotepad.Slyles.Triggers
{
    class ButtonAnimationToRightTriggerAction : TriggerAction<Button>
    {
        protected override async void Invoke(Button sender)
        {
            uint czas = 100;

            await sender.TranslateTo(15, 0, czas);
            await sender.TranslateTo(5, 0, czas);
            await sender.TranslateTo(10, 0, czas);
            await sender.TranslateTo(3, 0, czas);
            await sender.TranslateTo(5, 0, czas);
            await sender.TranslateTo(1, 0, czas);

            sender.TranslationX = 0;
        }
    }
}
