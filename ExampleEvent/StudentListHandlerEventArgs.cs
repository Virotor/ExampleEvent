using System;

namespace ExampleEvent
{
    public class StudentListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }

        public string TypeOfChange { get; set; }

        public Student Student { get; set;}

        public StudentListHandlerEventArgs(Student student, string typeOfChange, string collectionName)
        {
            Student = student;
            TypeOfChange = typeOfChange;
            CollectionName = collectionName;
        }

        public StudentListHandlerEventArgs() { }

        public override string ToString()
        {
            return $"{CollectionName} {TypeOfChange} {Student}";
        }



    }
}