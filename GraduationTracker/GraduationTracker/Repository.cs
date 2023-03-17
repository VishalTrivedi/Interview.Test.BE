using GraduationTracker.Models;

namespace GraduationTracker
{
    public class Repository
    {
        public static Student GetStudent(int id)
        {
            var students = GetStudents();
            Student student = null;

            for (int i = 0; i < students.Length; i++)
            {
                if (id == students[i].Id)
                {
                    student = students[i];
                    break; 
                }
            }
            return student;
        }

        public static Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            Diploma diploma = null;

            for (int i = 0; i < diplomas.Length; i++)
            {
                if (id == diplomas[i].Id)
                {
                    diploma = diplomas[i];
                    break;
                }
            }
            return diploma;

        }

        public static Requirement GetRequirement(int id)
        {
            var requirements = GetRequirements();
            Requirement requirement = null;

            for (int i = 0; i < requirements.Length; i++)
            {
                if (id == requirements[i].Id)
                {
                    requirement = requirements[i];
                    break;
                }
            }
            return requirement;
        }


        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[]{100,102,103,104}
                }
            };
        }

        public static Requirement[] GetRequirements()
        {
            return new[]
            {
                new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1}, Credits=1 },
                new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new int[]{2}, Credits=1 },
                new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new int[]{3}, Credits=1},
                new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }
            };
        }

        private static Student[] GetStudents()
        {
            return new[]
            {
                new Student
                {
                    Id = 1,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Marks=95 },
                        new Course{Id = 2, Name = "Science", Marks=95 },
                        new Course{Id = 3, Name = "Literature", Marks=95 },
                        new Course{Id = 4, Name = "Physichal Education", Marks=95 }
                    }
                },
                new Student
                {
                    Id = 2,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Marks=80 },
                        new Course{Id = 2, Name = "Science", Marks=80 },
                        new Course{Id = 3, Name = "Literature", Marks=80 },
                        new Course{Id = 4, Name = "Physichal Education", Marks=80 }
                    }
                },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Marks=50 },
                        new Course{Id = 2, Name = "Science", Marks=50 },
                        new Course{Id = 3, Name = "Literature", Marks=50 },
                        new Course{Id = 4, Name = "Physichal Education", Marks=50 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Marks=40 },
                        new Course{Id = 2, Name = "Science", Marks=40 },
                        new Course{Id = 3, Name = "Literature", Marks=40 },
                        new Course{Id = 4, Name = "Physichal Education", Marks=40 }
                    }
                }
            };
        }
    }
}
