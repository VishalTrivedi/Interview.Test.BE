using GraduationTracker.Models;

namespace GraduationTracker.DAL
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        
        Student GetStudentByID(int studentId);

        GraduationResult GetGraduationResult(int studentId);

        GraduationResult GetGraduationResult(Student student);

        /*
        
        void InsertStudent(Student student);
        
        void DeleteStudent(int studentID);
        
        void UpdateStudent(Student student);
        
        void Save();
        */
    }
}