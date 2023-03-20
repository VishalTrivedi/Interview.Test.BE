using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraduationTracker.DAL;
using GraduationTracker.BLL;
using GraduationTracker.Entities;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class StudentRepositoryTests
    {
        private static GraduationContext _context;
        private static IGraduationTracker _graduationTracker;
        private static IStudentRepository _studentRepository;
        private static IDiplomaRepository _diplomaRepository;
        private static IStudentGradeRepository _studentGradeRepository;

        /// <summary>
        /// Initialize test data to be used by all tests
        /// </summary>
        /// <param name="tc"></param>
        [ClassInitialize]
        public static void ClassSetup(TestContext tc)
        {
            var options = new DbContextOptionsBuilder<GraduationContext>()
                .UseInMemoryDatabase(databaseName: "GraduationTracker")
                .Options;

            _context = new GraduationContext(options);

            TestData.GenerateAllTestData(_context);

            _graduationTracker = new GraduationTracker.BLL.GraduationTracker();

            _studentRepository = new StudentRepository(_context);
            _studentGradeRepository = new StudentGradeRepository(_context);
            _diplomaRepository = new DiplomaRepository(_context);
        }

        /// <summary>
        /// Cleanup resources
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanUp()
        {
            _studentGradeRepository = null;
            _studentGradeRepository = null;
            _diplomaRepository = null;

            _context.Dispose();
            _context = null;
        }

        [TestMethod]
        public void TestStudent()
        {
            Student student = _studentRepository
                                    .GetStudentByID(1);
            IEnumerable<StudentGrade> studentGrades = _studentGradeRepository
                .GetCoursesByStudent(student.Id);

            Diploma diploma = _diplomaRepository.GetDiplomaById(1);

            GraduationResult result = _graduationTracker.GetGraduationResult(studentGrades, diploma);

            Assert.IsTrue(result.HasGraduated);
        }

        [TestMethod]
        public void TestAllStudents()
        {
            Diploma diploma = _diplomaRepository.GetDiplomaById(1);
            var students = _studentRepository.GetStudents();

            foreach(Student student in students)
            {
                IEnumerable<StudentGrade> studentGrades = _studentGradeRepository
                    .GetCoursesByStudent(student.Id);

                GraduationResult result = _graduationTracker.GetGraduationResult(studentGrades, diploma);

                Assert.IsTrue(result.HasGraduated);

                break;
            }
        }

        // TODO: Add negative test cases, test with invalid data
        //       Check for marks outside range (0 - 100)
    }
}
