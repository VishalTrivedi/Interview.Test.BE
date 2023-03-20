using System.Collections.Generic;
using System.Linq;
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
        private GraduationContext _context;
        private IGraduationTracker _graduationTracker;
        private IStudentRepository _studentRepository;
        private IDiplomaRepository _diplomaRepository;
        private IStudentGradeRepository _studentGradeRepository;

        /// <summary>
        /// Initialize test data to be used by all tests
        /// </summary>
        [TestInitialize]
        public void Init()
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

        [TestCleanup]
        public void Cleanup()
        {
            return;

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
            List<StudentGrade> studentGrades = _studentGradeRepository
                .GetCoursesByStudent(student.Id)
                .ToList();

            Diploma diploma = _diplomaRepository.GetDiplomaById(1);

            GraduationResult result = _graduationTracker.GetGraduationResult(student, studentGrades, diploma);

            Assert.IsTrue(result.HasGraduated);
        }

        [TestMethod]
        public void TestAllStudents()
        {
            Diploma diploma = _diplomaRepository.GetDiplomaById(1);
            var students = _studentRepository.GetStudents();

            foreach(Student student in students)
            {
                List<StudentGrade> studentGrades = _studentGradeRepository
                    .GetCoursesByStudent(student.Id)
                    .ToList();

                GraduationResult result = _graduationTracker.GetGraduationResult(student, studentGrades, diploma);

                Assert.IsTrue(result.HasGraduated);
            }
        }

        // TODO: Add negative test cases, test with invalid data
        //       Check for marks outside range (0 - 100)
    }
}
