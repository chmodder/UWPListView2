using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListView2.Model;

namespace ListView2.ViewModel
{
    class NoteViewModel : Notification
    {
        #region Instance Fields
        private ObservableCollection<Note> _notes;
        private RelayCommand _addNoteCommand;
        private string _noteText;
        #endregion

        #region Constructors
        public NoteViewModel()
        {
            Notes = new ObservableCollection<Note>() { new Note("This the notetext in note 1") };
            AddNoteCommand = new RelayCommand(DoAddNote);
        }
        #endregion

        #region Properties
        public ObservableCollection<Note> Notes { get { return _notes; } set { _notes = value; OnPropertyChanged("Notes"); } }

        public RelayCommand AddNoteCommand { get { return _addNoteCommand; } set { _addNoteCommand = value; } }

        public string NoteText { get { return _noteText; } set { _noteText = value; OnPropertyChanged("NoteText"); } }

        #endregion

        #region methods

        private void DoAddNote(object obj)
        {
            var newItem = obj as string;
            if (!string.IsNullOrEmpty(newItem))
            {
                AddNote(newItem);
            }
        }

        public void AddNote(string noteText)
        {
            Notes.Add(new Note(noteText));
        }
        #endregion
    }
}
