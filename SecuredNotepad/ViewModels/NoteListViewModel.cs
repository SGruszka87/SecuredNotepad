using SecuredNotepad.DB;
using SecuredNotepad.DB.models;
using SecuredNotepad.Logs;
using SecuredNotepad.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SecuredNotepad.ViewModels
{
    public class NoteListViewModel : BaseViewModel
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



        private ObservableCollection<notemodel> _noteList;
        public ObservableCollection<notemodel> NoteList
        {
            get
            {
                if (_noteList == null) _noteList = new ObservableCollection<notemodel>();
                return _noteList;
            }
            set
            {
                _noteList = value;
                RaisePropertyChanged(nameof(NoteList));
            }
        }

        #region Models
        private string _title = string.Empty;
        public string Title
        {
            get
            {
                if (_title == null) _title = string.Empty;
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private string _note = string.Empty;
        public string Note
        {
            get
            {
                if (_note == null) _note = string.Empty;
                return _note;
            }
            set
            {
                _note = value;
                RaisePropertyChanged(nameof(Note));
            }
        }

          

        private bool _showAddNote = false;
        public bool ShowAddNote
        {
            get
            {
                return _showAddNote;
            }
            set
            {
                _showAddNote = value;
                RaisePropertyChanged(nameof(ShowAddNote));
            }
        }

       

        #endregion

        #region Commands

        Command _ShowAddFrameNote;
        public Command ShowAddFrameNote => _ShowAddFrameNote ?? (_ShowAddFrameNote = new Command(() => ShowFrameForNote()));

        Command _commandAddNote;
        public Command CommandAddNote
        {
            get
            {
                Command command = _commandAddNote ?? (_commandAddNote = new Command(() => AddNote(Title, Note)));
                return command;
            }
        }

        Command _commandDeleteNote;
        public Command CommandDeleteNote
        {
            get
            {
                Command command = _commandDeleteNote ?? (_commandDeleteNote = new Command(() => DeleteNote()));
                return command;
            }
        }

        private void DeleteNote()
        {
            DBInit.Notes_Delete();
            NoteList.Clear();
        }

        #endregion


        public NoteListViewModel()
        {

            RefreshNoteList();
        }

        private void ShowFrameForNote()
        {
            if (ShowAddNote == false)
                ShowAddNote = true;
            else
                ShowAddNote = false;
        }
       



        public bool AddNote(string sTitle, string sNote)
        {

            notemodel note = new notemodel();
            note.Title = CodingService.RSAEncrypt(sTitle);
            note.Note = CodingService.RSAEncrypt(sNote);
            note.Date = DateTime.Now;
            if (Settings.Password != string.Empty || Settings.Password != null)
            {
                note.Password = CodingService.RSAEncrypt(Settings.Password);
            }
            else
            {
                note.Password = string.Empty;
            }

            DBInit.Notes_Insert(note);
            Logger.Trace(AppEventCode.Notes, "Note has been added.");

            Title = string.Empty;
            Note = string.Empty;

            ShowFrameForNote();
            RefreshNoteList();
            Title = string.Empty;
            Note = string.Empty;
            return true;
        }

        public void RefreshNoteList()
        {
            NoteList.Clear();

            using (var db = DBInit.GetDbContext_Notes())
            {
                if (!File.Exists(DBInit.db_Note))
                {
                    PermissionService ps = new PermissionService();
                    ps.CheckStoragePermissions();
                    DBInit.CreateDb();
                }


                var table = db.Table<notemodel>().OrderBy(i => i.Date).ToList();
                foreach (var t in table)
                {
                    if (CodingService.RSADecrypt(t.Password) == Settings.Password)
                    {
                        NoteList.Add(new notemodel()
                        {
                            Title = CodingService.RSADecrypt(t.Title),
                            Note = CodingService.RSADecrypt(t.Note),
                            Date = t.Date,
                            Password = t.Password
                        });
                    }
                    else
                    {
                        NoteList.Add(new notemodel()
                        {
                            Title = "***",
                            Note = "***",
                            Date = t.Date,
                            Password = "***"
                        });
                    }

                }
            }
            RaisePropertyChanged(nameof(NoteList));
            Logger.Trace(AppEventCode.Notes, "Note lsit has been refreshed.");
        }
    }

}
