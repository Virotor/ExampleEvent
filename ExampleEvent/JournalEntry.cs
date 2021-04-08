namespace ExampleEvent
{
    public class JournalEntry
    {

        public string CollectionName { get; set; }



        public string TypeOfEvent { get; set; }

        public Student Student { get; set; }

        public string ChangedData { get; set; }


        public JournalEntry(string collectionName, string typeOfEvent, Student student)
        {
            CollectionName = collectionName;
            TypeOfEvent = typeOfEvent;
            Student = student;
        }

        public JournalEntry(string collectionName, string typeOfEvent, Student student, string changedData)
        {
            CollectionName = collectionName;
            TypeOfEvent = typeOfEvent;
            Student = student;
            ChangedData = changedData;
        }


        public override string ToString()
        {
            return $"{CollectionName} : {TypeOfEvent} : {Student} - {(ChangedData is null ? string.Empty : ChangedData)}";
        }
    }
}