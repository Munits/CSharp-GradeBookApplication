using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            char grade = 'F';

            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            SortedList<double, string> slStudents = new SortedList<double, string>();
            foreach (Student student in Students)
            {
                slStudents.Add(student.AverageGrade, student.Name);
            }

            int step = Convert.ToInt32(Math.Floor(Students.Count / 5.0));
            int intIndexOfGrade = slStudents.IndexOfKey(averageGrade);

            if (intIndexOfGrade >= step)
                grade = 'A';
            else if (intIndexOfGrade >= 2 * step)
                grade = 'B';
            else if (intIndexOfGrade >= 3 * step)
                grade = 'C';
            else if (intIndexOfGrade >= 4 * step)
                grade = 'D';
            else
                grade = 'F';

            return grade;
        }
    }
}