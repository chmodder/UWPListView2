using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using ListView2.Model;

namespace ListView2.ViewModel
{
    class NoteViewModel : Notification
    {
        #region Instance Fields
        private ObservableCollection<Note> _notes;
        private RelayCommand _addNoteCommand;
        private RelayCommandGenericType<Note> _deleteNoteCommand;
        #endregion

        #region Constructors
        public NoteViewModel()
        {
            //adds sample data to Notes property (ObservableCollection<Note>)
            Notes = new ObservableCollection<Note>() { new Note("Sample text 1"), new Note("Sample text 2") };
                        
            //Button command methods are added to delegates
            AddNoteCommand = new RelayCommand(DoAddNote);
            DeleteNoteCommand = new RelayCommandGenericType<Note>(DoDeleteNote);
        }
        #endregion

        #region Properties
        public ObservableCollection<Note> Notes { get { return _notes; } set { _notes = value; OnPropertyChanged("Notes"); } }

        public RelayCommand AddNoteCommand { get { return _addNoteCommand; } set { _addNoteCommand = value; } }

        public RelayCommandGenericType<Note> DeleteNoteCommand { get { return _deleteNoteCommand; } set { _deleteNoteCommand = value; } }

        #endregion

        #region methods

        private void DoAddNote(object obj)
        {
            var newItem = obj as string;
            if (!string.IsNullOrEmpty(newItem))
            {
                this.Notes.Add(new Note(noteText));
            }
        }

        private void DoDeleteNote(Note note)
        {
            this.Notes.Remove(note);
        }
        #endregion
    }
}
