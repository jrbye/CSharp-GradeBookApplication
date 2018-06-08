using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook:BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            //GradeBookType gradeBookType = new GradeBookType();
            Type = GradeBookType.Standard;
        }
    }
}