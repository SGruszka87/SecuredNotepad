using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SecuredNotepad.Slyles.Triggers
{
    class EntryTriggerScaleAction : TriggerAction<Entry>
    {
        protected async override void Invoke(Entry entry)
        {
            await entry.ScaleTo(0.98, 50, Easing.CubicOut);
            await entry.ScaleTo(1, 50, Easing.CubicIn);
        }
    }
}
