using GraduationTracker.Models;

namespace GraduationTracker.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DiplomaRepository _diplomaRepository;
        private readonly RequirementRepository _requirementRepository;

        public StudentRepository(DiplomaRepository diplomaRepository, RequirementRepository requirementRepository)
        {
            this._diplomaRepository = diplomaRepository;
            this._requirementRepository = requirementRepository;
        }

        public IEnumerable<Student> GetStudents()
        {
            return new[]
            {
                new Student
                {
                    Id = 1,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                    }
                },
                new Student
                {
                    Id = 2,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                    }
                },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=50 },
                        new Course{Id = 2, Name = "Science", Mark=50 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                    }
                }
            };
        }

        public Student GetStudentByID(int studentId)
        {
            return GetStudents()
                .Single(s => s.Id == studentId);
        }

        public GraduationResult GetGraduationResult(int studentId)
        {
            Student student = GetStudentByID(studentId);

            return CalcualteGraduationResult(student);
        }

        public GraduationResult GetGraduationResult(Student student)
        {
            return CalcualteGraduationResult(student);
        }

        private GraduationResult CalcualteGraduationResult(Student student)
        {
            // TODO: check if student is null
            GraduationResult retval = null;
            var diploma = _diplomaRepository.GetDiplomas().FirstOrDefault();

            int averageMarks = CalculageAverageMarks(diploma.Requirements, student.Courses);

            switch (averageMarks)
            {
                case >= 95:
                    retval = new GraduationResult(student, true, STANDING.SumaCumLaude);
                    break;
                case >= 80:
                    retval = new GraduationResult(student, true, STANDING.MagnaCumLaude);
                    break;
                case >= 50:
                    retval = new GraduationResult(student, true, STANDING.Average);
                    break;
                case > 0:
                    retval = new GraduationResult(student, false, STANDING.Remedial);
                    break;
                default:
                    retval = new GraduationResult(student, false, STANDING.None);
                    break;
            }

            return retval;
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
