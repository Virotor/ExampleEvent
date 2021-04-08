using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleEvent
{
    public class StudentCollection
    {

        public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);

        public event StudentListHandler StudentsCountChanged;
        public event StudentListHandler StudentReferenceChanged;

       public string CollectionName { get; set; }

        private List<Student> students;

        public Student this [int index] {
            get 
            {
                if(students is null || index > students.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return students[index];
            }
            set
            {
                if(students is null  || index > students.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                students[index] = value;
                StudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(value, "Change value", CollectionName));
            }
        }

        public void AddDefaults()
        {
            students = new List<Student>();
            Student student = new("Pay",3131, new ArrayList() { (true, "PE"), (false, "Economics") }, new ArrayList() { (10, "SPO"), (5, "Physics") });
            Student student1 = new("Free",3131, new ArrayList() { (false, "PE"), (false, "Economics") }, new ArrayList() { (7, "SPO"), (8, "Physics") });
            Student student2 = new("Free",3131, new ArrayList() { (false, "PE"), (true, "Economics") }, new ArrayList() { (9, "SPO"), (4, "Physics") });
            Student student3 = new("Pay",3131, new ArrayList() { (true, "PE"), (false, "Economics") }, new ArrayList() { (4, "SPO"), (10, "Physics") });
            AddStudents(student, student1, student2, student3);
        }

        public void AddStudents(params Student[] studentsToAdd)
        {
            if(studentsToAdd == null)
            {
                return;
            }
            foreach(Student student in studentsToAdd)
            {
                students.Add(student);
                StudentsCountChanged?.Invoke(source: this, new StudentListHandlerEventArgs(student: student, typeOfChange: "Add new student", collectionName: CollectionName));
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if((students is null) || (students.Count is 0))
            {
                return "Empty list of student";
            }
            foreach(var student in students)
            {
                result.Append($"{student}\n\n");
            }
            return result.ToString();
        }


        public string ToShortString()
        {
            StringBuilder result = new StringBuilder();
            if ((students is null) || (students.Count is 0))
            {
                return "Empty list of student";
            }
            foreach (var student in students)
            {
                result.Append($"{student.ToShortString()}\n");
            }
            return result.ToString();
        }

        public bool Remove (int j)
        {
            if (j > students.Count - 1)
            {
                return false;
            }
            else
            {
                StudentsCountChanged?.Invoke(this, new StudentListHandlerEventArgs(students[j], "Remove student",CollectionName ));
                students.RemoveAt(j);
                return true;
            }
        }

        
    }
}
