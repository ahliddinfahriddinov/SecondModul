using Pattern_project.DataAcces.Entites;
using System.Text.Json;

namespace Pattern_project.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly string _path;
    private List<Student> _students;

    public StudentRepository()
    {
        _path = "../../../DataAccess/Data/Student.json";
        _students = new List<Student>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _students = ReadAll();
    }
    public Student GetById(Guid studentId)
    {
        foreach (var student in _students)
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }
        throw new Exception($"there is no student with {studentId} such an ID");
    }
    public void Delete(Guid studentId)
    {
        var student = GetById(studentId);
        _students.Remove(student);
        SaveData();
    }
    public List<Student> ReadAll()
    {
        var studentsJson = File.ReadAllText(_path);
        var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return students;
    }

    public void Update(Student student)
    {
        var updatingStudent = GetById(student.Id);
        var index = _students.IndexOf(student);
        _students[index] = student;
        SaveData();
    }
    public Guid Write(Student student)
    {
        _students.Add(student);
        SaveData();
        return student.Id;
    }
    private void SaveData()
    {
        var studentJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(_path, studentJson);
    }

    public void EmailCheck(string email)
    {
        foreach (var student in _students)
        {
            if (student.Email == email)
            {
                throw new Exception("you can't add an email that already exsist");
            }
        }
    }
}
