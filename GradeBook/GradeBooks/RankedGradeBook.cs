using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public string minStudentMessage = "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.";
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }     

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("5 Students Required for Ranked Grade Book");
            }
            
            var ceiling = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[ceiling - 1] <= averageGrade)
                return 'A';
            else if (grades[(ceiling*2)-1]<= averageGrade)
                return 'B';
            else if (grades[(ceiling*3)-1]<= averageGrade)
                return 'C';
            else if (grades[(ceiling*4)-1]<= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine(minStudentMessage);
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine(minStudentMessage);
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}