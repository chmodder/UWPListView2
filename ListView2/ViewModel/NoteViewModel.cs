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
        private RelayCommand _deleteNoteCommand;
        //private string _noteText;
        #endregion

        #region Constructors
        public NoteViewModel()
        {
            //adds sample data to Notes property (ObservableCollection<Note>)
            Notes = new ObservableCollection<Note>() { new Note("Sample text 1"), new Note("Sample text 2") };

            //Used for testing the deletion of items from ObservableCollection-------------------------------------
            Notes.RemoveAt(1);
            Notes.Add(new Note("Sample text 3"));
            //foreach (var item in Notes)
            //{
            //    if (item.NoteText == "Sample text 3")
            //    {
            //        DoDeleteNote(item);
            //        break;
            //    }
            //}
            //------------------------------------------------------

            //Button command methods are added to delegates
            AddNoteCommand = new RelayCommand(DoAddNote);
            DeleteNoteCommand = new RelayCommand(DoDeleteNote);
        }
        #endregion

        #region Properties
        public ObservableCollection<Note> Notes { get { return _notes; } set { _notes = value; OnPropertyChanged("Notes"); } }

        //public string NoteText { get { return _noteText; } set { _noteText = value; OnPropertyChanged("NoteText"); } }

        public RelayCommand AddNoteCommand { get { return _addNoteCommand; } set { _addNoteCommand = value; } }

        public RelayCommand DeleteNoteCommand { get { return _deleteNoteCommand; } set { _deleteNoteCommand = value; } }

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

        //Work in progress
        private void DoDeleteNote(object obj)
        {
            //Used when the XAML Delete Button invokes this method
            TextBlock textBlockSender = obj as TextBlock;
            //string myString = textBlockSender.Text;
            Note itemToDelete = textBlockSender.DataContext as Note;

            //Used when the constuctor invokes this method, for testing purposes------------
            //Note itemToDelete = obj as Note;
            //--------------------------------------------------------

            foreach (Note note in this.Notes)
            {
                if (note.NoteText == itemToDelete.NoteText)
                {
                    //int noteIndex = Notes.IndexOf(note);
                    //Notes.RemoveAt(noteIndex);
                    DeleteNote(note);
                    break;
                }
            }
            //if (Notes.Contains(itemToDelete))
            //{
            //    Notes.Remove(itemToDelete);
            //}
        }

        public void AddNote(string noteText)
        {
            this.Notes.Add(new Note(noteText));
        }

        public void DeleteNote(Note itemToDelete)
        {
            this.Notes.Remove(itemToDelete);
        }
        #endregion
    }
}
