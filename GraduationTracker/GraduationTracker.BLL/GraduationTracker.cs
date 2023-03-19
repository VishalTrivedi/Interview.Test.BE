using GraduationTracker.DAL;
using GraduationTracker.DAL.Entities;

namespace GraduationTracker.BLL
{
    public class GraduationTracker : IGraduationTracker
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IDiplomaRepository _diplomaRepo;

        public GraduationTracker(IStudentRepository studentRepo, 
            IDiplomaRepository diplomaRepo)
        {
            _studentRepo = studentRepo;
            _diplomaRepo = diplomaRepo;
        }

        public GraduationResult GetGraduationResult(int studentId)
        {
            Student student = _studentRepo.GetStudentByID(studentId);

            return CalcualteGraduationResult(student);
        }

        public GraduationResult GetGraduationResult(Student student)
        {
            return CalcualteGraduationResult(student);
        }

        private GraduationResult CalcualteGraduationResult(Student student)
        {
            // TODO: check if student is null
            var diploma = _diplomaRepo.GetDiplomas().FirstOrDefault();

            int averageMarks = CalculageAverageMarks(diploma.Requirements, student.Courses);

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

        private int CalculageAverageMarks(IEnumerable<Requirement> diplomaRequirements, Course[] studentCourses)
        {
            // Vishal: Credits is never used, why?
            var credits = 0;
            var totalMarks = 0;

            for (int i = 0; i < diplomaRequirements.Count(); i++)
            {
                for (int j = 0; j < studentCourses.Length; j++)
                {
                    var requirement = diplomaRequirements.Where(x => x.Id == i).FirstOrDefault();

                    if (requirement.Course == studentCourses[j])
                    {
                        totalMarks += studentCourses[j].Mark;

                        if (studentCourses[j].Mark > requirement.MinimumMark)
                        {
                            credits += requirement.Credits;
                        }
                    }
                }
            }

            return totalMarks / studentCourses.Length;
        }

    }
}
