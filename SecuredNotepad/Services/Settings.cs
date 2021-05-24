using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecuredNotepad.Services
{
    public class Settings
    {
        public static string LogFileName = "logs.txt";
        public static string LogOnDevicePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "");
        public static string Password { get; set; }

        public Settings() 
        {            
            Password = string.Empty;

        }
    }
}
