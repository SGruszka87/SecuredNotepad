using System;
using System.Collections.Generic;
using System.Text;

namespace SecuredNotepad.Logs
{
    public interface ILoggingService
    {


        void Info(AppEventCode appEvent, string message);
        void Info(AppEventCode appEvent, string format, params object[] args);

        void Error(AppEventCode appEvent, string message);
        void Error(AppEventCode appEvent, string format, params object[] args);
        void Error(AppEventCode appEvent, Exception e, string message);
        void Error(AppEventCode appEvent, Exception e, string format, params object[] args);

        void Fatal(AppEventCode appEvent, string message);
        void Fatal(AppEventCode appEvent, string format, params object[] args);
        void Fatal(AppEventCode appEvent, Exception e, string message);
        void Fatal(AppEventCode appEvent, Exception e, string format, params object[] args);

        void Debug(AppEventCode appEvent, string message);
        void Debug(AppEventCode appEvent, string format, params object[] args);

        void Trace(AppEventCode appEvent, string message);
        void Trace(AppEventCode appEvent, string format, params object[] args);

        void Warn(AppEventCode appEvent, string message);
        void Warn(AppEventCode appEvent, string format, params object[] args);


    }

}
