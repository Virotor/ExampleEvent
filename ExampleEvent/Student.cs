using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleEvent
{
    public class Student
    {

        private string formOfEducation;



        private int groupNumber;

        private ArrayList credits;

        private ArrayList exams;

        public Student(string formOfEducation = "Pay", int groupNumber =0, ArrayList credits = null,  ArrayList exams = null)
        {
            this.formOfEducation = formOfEducation;
            this.exams = exams;
            this.credits = credits;
            this.groupNumber = groupNumber;
        }

        public double AverrageMark()
        {
            if((exams is null) || (exams.Count is 0))
            {
                return 0;
            }
            int mark = 0;
            int countOfMark = 0;
            foreach(var obj in exams)
            {
                if(obj is (int, string))
                {
                    (int,string)? exam = obj as (int, string)?;
                    if(exam.HasValue)
                    {
                        mark += exam.Value.Item1;
                        countOfMark++;
                    }
                }
            }
            return Convert.ToDouble(mark) / countOfMark;
        }

        private int CountOfCredits()
        {

            if ((credits is  null) || (credits.Count is  0))
            {
                return 0;
            }
            int countOfCredits = 0;
            foreach (var obj in credits)
            {
                if (obj is (bool, string))
                {
                    (bool, string)? credit = obj as (bool, string)?;
                    if (credit.HasValue)
                    {
                        countOfCredits++;
                    }
                }
            }
            return countOfCredits;
        }


        private int CountOfExams()
        {

            if ((exams is null) || (exams.Count is 0))
            {
                return 0;
            }
            int countOfExams = 0;
            foreach (var obj in exams)
            {
                if (obj is (int, string))
                {
                    (int, string)? exam = obj as (int, string)?;
                    if (exam.HasValue)
                    {
                        countOfExams++;
                    }
                }
            }
            return countOfExams;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"Form: {formOfEducation} Group: {groupNumber}");
            if((credits is not null) &&(  credits.Count is not 0))
            {
                foreach(var credit in credits)
                {
                    result.Append($"\n{credit}");
                }
            }
            if ((exams is not null) && (exams.Count is not 0))
            {
                foreach (var exam in exams)
                {
                    result.Append($"\n{exam}");
                }
            }
            return result.ToString();

        }

        public string ToShortString()
        {
            return $"Form: {formOfEducation} Group: {groupNumber}" +
                $" Average marks: {this.AverrageMark()}" +
                $" Exams: {this.CountOfExams()} Credits: {this.CountOfCredits()}";
        }

    }
}
