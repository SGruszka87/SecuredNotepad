using SecuredNotepad.DB.models;
using SecuredNotepad.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SecuredNotepad.DB
{
    public class DBInit : BaseViewModel
    {
        public static string db_Note = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "Notes.db3");

        public DBInit()
        {
            if (!File.Exists(db_Note))
            {
                CreateDb();
            }
        }




        public static bool CreateDb()
        {
            bool bRet = true;

            if (File.Exists(db_Note))
            {
                try
                {
                    using SQLiteConnection db = new SQLiteConnection(db_Note);
                    db.CreateTable<notemodel>();
                }
                catch (Exception e)
                {
                    Device.BeginInvokeOnMainThread(async () => { await Application.Current.MainPage.DisplayAlert("Komunikat", "Nie mogę utworzyć bazy" + Environment.NewLine + "---" + Environment.NewLine + e.ToString(), "OK"); });
                    bRet = false;
                }
            }
            return bRet;
        }



        public static SQLiteConnection GetDbContext_Notes()
        {
            return new SQLiteConnection(db_Note);
        }




        public static bool Get_Notes(int _iId, string _Haslo)
        {
            using (var db = GetDbContext_Notes())
            {
                var table = db.Table<notemodel>();
                foreach (var t in table)
                {
                    return true;
                }
            }
            return false;
        }



        public static void Notes_Insert(notemodel note)
        {
            notemodel n = new notemodel
            {

                Title = note.Title,
                Note = note.Note,
                Date = note.Date
            };

            using (var dbu = new SQLiteConnection(db_Note))
            {
                dbu.Insert(n);
            };
        }

        public static void Notes_Update(notemodel note)
        {
            notemodel n = new notemodel
            {
                Id = note.Id,
                Title = note.Title,
                Note = note.Note,
                Date = note.Date
            };
            using (var dbu = new SQLiteConnection(db_Note))
            {
                dbu.Update(n);
            };
        }


        public static void Notes_Delete()
        {
            using (var dbu = new SQLiteConnection(db_Note))
            {
                dbu.DeleteAll<notemodel>();
            };
        }


    }

}
