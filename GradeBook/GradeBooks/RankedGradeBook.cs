using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            char grade = 'F';

            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            SortedList<double, string> slStudents = new SortedList<double, string>(Students.Count);
            foreach (Student student in Students)
            {
                slStudents.Add(student.AverageGrade, student.Name);
            }

            int step = Convert.ToInt32(Math.Floor(Students.Count / 5.0));
            int intIndexOfGrade = slStudents.IndexOfKey(averageGrade);

            if (intIndexOfGrade >= 4 * step)
                grade = 'A';
            else if (intIndexOfGrade >= 3 * step)
                grade = 'B';
            else if (intIndexOfGrade >= 2 * step)
                grade = 'C';
            else if (intIndexOfGrade >= step)
                grade = 'D';
            else
                grade = 'F';

            return grade;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}