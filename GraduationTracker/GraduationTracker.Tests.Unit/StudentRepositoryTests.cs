using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraduationTracker.DAL;
using GraduationTracker.DAL.Entities;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class StudentRepositoryTests
    {
        private GraduationContext _context;
        private IStudentRepository _studentRepository;

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

            _studentRepository = new StudentRepository(_context);
        }

        [TestMethod]
        public void TestStudents()
        {
            List<Student> students = _studentRepository.GetStudents().ToList();

            Assert.IsTrue(students.Count() > 1);
        }
    }
}
