using System;
using System.Collections.Generic;
using System.Text;

namespace SecuredNotepad.Logs
{
    public enum AppEventCode
    {
        /// <summary>
        /// Default Value = 0
        /// </summary>
        DefaultValue = 0,
        /// <summary>
        /// AppStart, when app will be started
        /// </summary>
        AppStart = 0100,
        /// <summary>
        /// AppStop, when app will go to sleep mode
        /// </summary>
        AppStop = 0101,
        /// <summary>
        /// AppResume, when app will be rewoke from sleep mode
        /// </summary>
        AppResume = 0102,
        /// <summary>
        /// AppClose, when app will be closed/ended/terminated
        /// </summary>
        AppClose = 0103,
        /// <summary>
        /// AppPermissions, when app will be check granted permissions
        /// </summary>
        AppPermissions = 0200,

        /// <summary>
        /// AppDB, Main database code
        /// </summary>
        AppDB = 0300,

        /// <summary>
        /// AppDBCreate, Create database code
        /// </summary>
        AppDBCreate = 0301,

        /// <summary>
        /// ChangeLanguage, Main change language code
        /// </summary>
        ChangeLanguage = 0400,
        /// <summary>
        /// AppDB, Main database code
        /// </summary>
        Notes = 0500,
        /// <summary>
        /// AppDB, Main database code
        /// </summary>
        Password = 0600




    }

}
