using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook:BaseGradeBook
    {
        public StandardGradeBook(string name) : base(name)
        {
            //GradeBookType gradeBookType = new GradeBookType();
            Type = GradeBookType.Standard;
        }
    }
}