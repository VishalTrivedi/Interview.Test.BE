using GraduationTracker.Entities;

namespace GraduationTracker.BLL
{
    public class GraduationTracker : IGraduationTracker
    {
        public GraduationResult GetGraduationResult(IEnumerable<StudentGrade> studentGrade, Diploma diploma)
        {
            return CalcualteGraduationResult(studentGrade, diploma);
        }

        private GraduationResult CalcualteGraduationResult(IEnumerable<StudentGrade> studentGrade, Diploma diploma)
        {
            // TODO: check for null objects
            IEnumerable<Course> diplomaCourses = diploma.Requirements
                                            .Select(d => d.Course);

            int averageMarks = CalculageAverageMarks(diplomaCourses, studentGrade);

            switch (averageMarks)
            {
                case >= 95:
                    return new GraduationResult(true, STANDING.SumaCumLaude);
                case >= 80:
                    return new GraduationResult(true, STANDING.MagnaCumLaude);
                case >= 50:
                    return new GraduationResult(true, STANDING.Average);
                case > 0:
                    return new GraduationResult(false, STANDING.Remedial);
                default:
                    return new GraduationResult(false, STANDING.None);
            }
        }

        private int CalculageAverageMarks(IEnumerable<Course> courses, IEnumerable<StudentGrade> studentGrade)
        {
            // TODO: Will credits be used for weighted average (Credits is currently not used)
            var credits = 0;
            var totalMarks = 0;

            List<StudentGrade> studentGradeList = studentGrade.ToList();

            foreach (var course in courses)
            {
                var studentCourse = studentGradeList.Find(d => d.Course == course);
                
                if (studentCourse != null)
                {
                    totalMarks += studentCourse.Mark;

                    if (studentCourse.Mark > course.MiminumMark)
                    {
                        credits += studentCourse.Credits;
                    }
                }
            }

            return totalMarks / studentGrade.Count();
        }
    }
}
