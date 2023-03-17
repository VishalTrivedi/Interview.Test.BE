using System.Collections.Generic;
using System.Linq;
using GraduationTracker.DAL;
using GraduationTracker.Models;

namespace GraduationTracker.Tests.Unit
{
    public class StudentRepository : IStudentRepository
    {
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
            var students = GetStudents().ToArray();
            Student student = null;

            for (int i = 0; i < students.Length; i++)
            {
                if (studentId == students[i].Id)
                {
                    student = students[i];
                    break;
                }
            }
            return student;
        }

        public GraduationResult GetGraduationResult(int studentId)
        {
            throw new System.NotImplementedException();
        }

        public GraduationResult GetGraduationResult(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}
