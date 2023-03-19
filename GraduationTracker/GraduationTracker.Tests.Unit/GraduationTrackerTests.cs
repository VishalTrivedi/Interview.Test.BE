using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraduationTracker.DAL;
using GraduationTracker.DAL.Entities;

/*
namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private Student[] _students;
        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;
        private readonly IDiplomaRepository _diplomaRepo;
        private readonly IRequirementRepository _requirmentRepo;
        private Diploma _diploma;
        private IGraduationTracker _tracker;

        /// <summary>
        /// Initialize test data to be  used by all test
        /// </summary>
        [TestInitialize] 
        public void Init() 
        {
            _students = GetStudentTestData();
            _studentRepository = new StudentRepository();
            _diploma = GetDiplomaTestData();
            _tracker = new GraduationTracker.BLL.GraduationTracker(_studentRepository, _courseRepository, _diplomaRepo, _requirmentRepo);
        }

        /// <summary>
        /// Cleanup resources
        /// </summary>
        [TestCleanup] 
        public void Cleanup()
        {
            _students = null;
            _diploma = null;
            _tracker = null;
        }

        [TestMethod]
        public void TestHasCredits()
        {
            // Arrange
            var graduated = new List<Tuple<bool, STANDING>>();

            // Act
            foreach (var student in _students)
            {
                graduated.Add(_tracker.HasGraduated(_diploma, student));
            }

            // Assert
            Assert.IsTrue(graduated.Any());
        }

        // Vishal: Add more tests

        private static Student[] GetStudentTestData()
        {
            // Vishal: Add more test data
            var students = new[]
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

                //tracker.HasGraduated()
            };
            return students;
        }

        private static Diploma GetDiplomaTestData()
        {
            return new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };
        }
    }
}
*/