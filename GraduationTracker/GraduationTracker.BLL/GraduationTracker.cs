using GraduationTracker.DAL;
using GraduationTracker.Models;

namespace GraduationTracker.BLL
{
    public class GraduationTracker : IGraduationTracker
    {
        private readonly IStudentRepository _studentRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IDiplomaRepository _diplomaRepo;
        private readonly IRequirementRepository _requirmentRepo;

        public GraduationTracker(IStudentRepository studentRepo, 
            ICourseRepository courseRepo,
            IDiplomaRepository diplomaRepo,
            IRequirementRepository requirmentRepo)
        {
            this._studentRepo = studentRepo;
            this._courseRepo = courseRepo;
            this._diplomaRepo = diplomaRepo;
            this._requirmentRepo = requirmentRepo;
        }

        public GraduationResult[] GetGraduationResults()
        {
            var retval = new List<GraduationResult>();
            var diplomas = _diplomaRepo.GetDiplomas();
            var students = _studentRepo.GetStudents().ToArray();
            var requirements = _requirmentRepo.GetRequirements();
            var courses = _courseRepo.GetCourses();
            
            foreach(var student in students)
            {
                int average = CalculageAverageMarksv2(diplomas, student.Courses);
                GraduationResult result;

                switch (average)
                {
                    case >= 95:
                        result = new GraduationResult(student, true, STANDING.SumaCumLaude);
                        break;
                    case >= 80:
                        result = new GraduationResult(student, true, STANDING.MagnaCumLaude);
                        break;
                    case >= 50:
                        result = new GraduationResult(student, true, STANDING.Average);
                        break;
                    case > 0:
                        result = new GraduationResult(student, false, STANDING.Remedial);
                        break;
                    default:
                        result = new GraduationResult(student, false, STANDING.None);
                        break;
                }

                retval.Add(result);
            }

            return retval.ToArray();
        }


        private int CalculageAverageMarksv2(IEnumerable<Diploma> diplomas, IEnumerable<Course> courses)
        {
            // Vishal: Credits is never used, why?
            var credits = 0;
            var totalMarks = 0;
            var reqs = diplomas.ToArray();
            var cours = courses.ToArray();


            for (int i = 0; i < reqs.Length; i++)
            {
                for (int j = 0; j < cours.Length; j++)
                {
                    var requirement = _requirmentRepo.GetRequirementById(reqs[i].Id);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == cours[j].Id)
                        {
                            totalMarks += cours[j].Mark;

                            if (cours[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            return totalMarks / cours.Length;
        }

        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            int average = CalculageAverageMarks(diploma.Requirements, student.Courses);

            switch (average)
            {
                case >= 95:
                    return new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);
                case >= 80:
                    return new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
                case >= 50:
                    return new Tuple<bool, STANDING>(true, STANDING.Average);
                case > 0:
                    return new Tuple<bool, STANDING>(false, STANDING.Remedial);
                default:
                    return new Tuple<bool, STANDING>(false, STANDING.None);
            }
        }
        private int CalculageAverageMarks(int[] requirements, Course[] studentCourses)
        {
            // Vishal: Credits is never used, why?
            var credits = 0;
            var totalMarks = 0;

            for (int i = 0; i < requirements.Length; i++)
            {
                for (int j = 0; j < studentCourses.Length; j++)
                {
                    var requirement = Repository.GetRequirement(requirements[i]);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == studentCourses[j].Id)
                        {
                            totalMarks += studentCourses[j].Mark;

                            if (studentCourses[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            return totalMarks / studentCourses.Length;
        }

    }
}
