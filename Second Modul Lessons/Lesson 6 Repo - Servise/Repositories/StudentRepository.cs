using Lesson_6_Repo___Servise.DataAccess.Entities;
using System.Text.Json;
namespace Lesson_6_Repo___Servise.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly string _path;
    private List<Student> _students;

    public StudentRepository()
    {
        _path = "../../../DataAccess/Data/Students.json";
        _students = new List<Student>();
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _students = ReadAllStudents();
    }

    public void CheckEmail(string email)
    {
        foreach (var student in _students)
        {
            if (student.Email == email)
            {
                throw new Exception("You cannot add such an existing email");
            }
        }
    }

    public void Delete(Guid id)
    {
        var deletedStudent = ReadById(id);
        _students.Remove(deletedStudent);
        SaveData();
    }

    public List<Student> ReadAllStudents()
    {
        var studentsJson = File.ReadAllText(_path);
        var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return students;
    }

    public Student ReadById(Guid id)
    {
        foreach (var student in _students)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        throw new Exception($"not such student exists{id}");
    }

    public void Update(Student student)
    {
        var updatingStudent = ReadById(student.Id);
        var index = _students.IndexOf(student);
        _students[index] = updatingStudent;
    }

    public Guid Write(Student student)
    {
        _students.Add(student);
        SaveData();
        return student.Id;
    }
    private void SaveData()
    {
        var jsonData = JsonSerializer.Serialize(_path);
        File.WriteAllText(_path, jsonData);
    }
}
