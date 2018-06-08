using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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
    }
}