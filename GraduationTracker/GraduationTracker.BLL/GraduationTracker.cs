using GraduationTracker.DAL;
using GraduationTracker.Entities;

namespace GraduationTracker.BLL
{
    public class GraduationTracker : IGraduationTracker
    {
        public GraduationResult GetGraduationResult(Student student, List<StudentGrade> studentGrade, Diploma diploma)
        {
            return CalcualteGraduationResult(student, studentGrade, diploma);
        }

        private GraduationResult CalcualteGraduationResult(Student student, List<StudentGrade> studentGrade, Diploma diploma)
        {
            // TODO: check for null objects
            List<Course> diplomaCourses = diploma.Requirements
                                            .Select(d => d.Course)
                                            .ToList();

            int averageMarks = CalculageAverageMarks(diplomaCourses, studentGrade);

            switch (averageMarks)
            {
                case >= 95:
                    return new GraduationResult(student, true, STANDING.SumaCumLaude);
                case >= 80:
                    return new GraduationResult(student, true, STANDING.MagnaCumLaude);
                case >= 50:
                    return new GraduationResult(student, true, STANDING.Average);
                case > 0:
                    return new GraduationResult(student, false, STANDING.Remedial);
                default:
                    return new GraduationResult(student, false, STANDING.None);
            }
        }

        private int CalculageAverageMarks(IEnumerable<Course> courses, List<StudentGrade> studentGrade)
        {
            // TODO: Will credits be used for weighted average (Credits is currently not used)
            var credits = 0;
            var totalMarks = 0;

            foreach (var course in courses)
            {
                var studentCourse = studentGrade.Find(d => d.Course == course);
                
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
