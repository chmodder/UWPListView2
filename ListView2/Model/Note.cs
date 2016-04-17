namespace ListView2.Model
{
    class Note
    {
        private string _noteText;

        public Note(string noteText)
        {
            NoteText = noteText;
        }

        public string NoteText { get { return _noteText; } set { _noteText = value; } }
    }
}
