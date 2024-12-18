using Lesson_6_Repo___Servise.DataAccess.Entities;

namespace Lesson_6_Repo___Servise.Repositories;

public interface IStudentRepository
{
    Guid Write (Student student);
    void Delete (Guid id);
    void Update (Student student);
    void CheckEmail (string email);
    Student ReadById (Guid id);
    List<Student> ReadAllStudents ();

}