using GraduationTracker.Entities;

namespace GraduationTracker.DAL
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        
        Student GetStudentByID(int studentId);

        /*
        
        void InsertStudent(Student student);
        
        void DeleteStudent(int studentID);
        
        void UpdateStudent(Student student);
        
        void Save();
        */
    }
}