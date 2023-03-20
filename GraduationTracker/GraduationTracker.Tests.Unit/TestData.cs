using System.Collections.Generic;
using System.Linq;
using GraduationTracker.DAL;
using GraduationTracker.Entities;

namespace GraduationTracker.Tests.Unit
{
    public static class TestData
    {
        public static void GenerateAllTestData(GraduationContext context)
        {
            // Add Courses
            Course courseMath = new Course()
            {
                Id = 1,
                Name = "Math",
                MiminumMark = 50,
                RequiredCredits = 1
            };
            context.Courses.Add(courseMath);

            Course courseScience = new Course()
            {
                Id = 2,
                Name = "Science",
                MiminumMark = 50,
                RequiredCredits = 1
            };
            context.Courses.Add(courseScience);

            Course courseLiterature = new Course()
            {
                Id = 3,
                Name = "Literature",
                MiminumMark = 50,
                RequiredCredits = 1
            };
            context.Courses.Add(courseLiterature);

            Course coursePE = new Course()
            {
                Id = 4,
                Name = "Physichal Education",
                MiminumMark = 50,
                RequiredCredits = 1
            };
            context.Courses.Add(coursePE);

            // Add Students
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Mark",
                    LastName = "Snow"
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Chris",
                    LastName = "Wood"
                }
            };

            foreach (var student in students)
            {
                context.Students.Add(student);
            }

            // Add Diploma
            var diploma = new Diploma()
            {
                Id = 1,
                Credits = 4
            };
                
            context.Diplomas.Add(diploma);

            // Add Requirements
            List<Requirement> requirements = new List<Requirement>()
            {
                new Requirement
                {
                    Id = 100,
                    Course = courseMath,
                    Diploma = diploma
                },
                new Requirement
                {
                    Id = 102,
                    Course = courseScience,
                    Diploma = diploma
                },
                new Requirement
                {
                    Id = 103,
                    Course = courseLiterature,
                    Diploma = diploma
                },
                new Requirement
                {
                    Id = 104,
                    Course = coursePE,
                    Diploma = diploma
                }
            };

            foreach (var requirement in requirements)
            {
                context.Requirements.Add(requirement);
            }
            
            // Save changes so make adding related entities possible to StudentGrade
            context.SaveChanges();

            // Add Student Grades
            List<StudentGrade> studentGrades = new List<StudentGrade>()
            {
                new StudentGrade()
                {
                    Id = 1,
                    Student = context.Students.Single(s => s.Id == 1),
                    Course = courseMath,
                    Mark = 95,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 2,
                    Student = context.Students.Single(s => s.Id == 1),
                    Course = courseScience,
                    Mark = 95,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 3,
                    Student = context.Students.Single(s => s.Id == 1),
                    Course = courseLiterature,
                    Mark = 95,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 4,
                    Student = context.Students.Single(s => s.Id == 1),
                    Course = coursePE,
                    Mark = 95,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 5,
                    Student = context.Students.Single(s => s.Id == 2),
                    Course = courseMath,
                    Mark = 80,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 6,
                    Student = context.Students.Single(s => s.Id == 2),
                    Course = courseScience,
                    Mark = 80,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 7,
                    Student = context.Students.Single(s => s.Id == 2),
                    Course = courseLiterature,
                    Mark = 80,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 8,
                    Student = context.Students.Single(s => s.Id == 2),
                    Course = coursePE,
                    Mark = 80,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 9,
                    Student = context.Students.Single(s => s.Id == 3),
                    Course = courseMath,
                    Mark = 50,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 10,
                    Student = context.Students.Single(s => s.Id == 3),
                    Course = courseScience,
                    Mark = 50,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 11,
                    Student = context.Students.Single(s => s.Id == 3),
                    Course = courseLiterature,
                    Mark = 50,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 12,
                    Student = context.Students.Single(s => s.Id == 3),
                    Course = coursePE,
                    Mark = 50,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 13,
                    Student = context.Students.Single(s => s.Id == 4),
                    Course = courseMath,
                    Mark = 40,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 14,
                    Student = context.Students.Single(s => s.Id == 4),
                    Course = courseScience,
                    Mark = 40,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 15,
                    Student = context.Students.Single(s => s.Id == 4),
                    Course = courseLiterature,
                    Mark = 40,
                    Credits = 1
                },
                new StudentGrade()
                {
                    Id = 16,
                    Student = context.Students.Single(s => s.Id == 4),
                    Course = coursePE,
                    Mark = 40,
                    Credits = 1
                },
            };

            foreach(var studentGrade in studentGrades)
            {
                context.StudentGrades.Add(studentGrade);
            }

            context.SaveChanges();
        }
    }
}
