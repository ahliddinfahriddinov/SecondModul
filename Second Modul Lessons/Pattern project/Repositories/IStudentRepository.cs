using Pattern_project.DataAcces.Entites;

namespace Pattern_project.Repositories;

public interface IStudentRepository
{
    Guid Write(Student student);
    List<Student> ReadAll();
    Student GetById(Guid studentId);
    void Delete(Guid studentId);
    void Update(Student student);
    void EmailCheck(string email);

}