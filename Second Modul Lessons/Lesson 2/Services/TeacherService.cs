using Lesson_2.Models;
using System.Text.Json;
namespace Lesson_2.Services;
public class TeacherService
{
    private string teacherFilePath;
    private List<Teacher> _teachers;

    public TeacherService()
    {
        teacherFilePath = "../../../Data/Teachers.json";
        if (File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }
        _teachers = new List<Teacher>();
        _teachers = GetAllTeacher();
    }
    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        _teachers.Add(teacher);
        SaveData();
        return teacher;
    }

    public Teacher GetById(Guid teacherId)
    {
       
        foreach (var teacher in _teachers)
        {
            if (teacher.Id == teacherId)
            {
                return teacher;
            }
        }

        return null;
    }

    public bool DeleteTeacher(Guid teacherId)
    {
        var teacherFromDb = GetById(teacherId);
        if (teacherFromDb is null)
        {
            return false;
        }

        _teachers.Remove(teacherFromDb);
        SaveData();
        return true;
    }

    public bool UpdateTeacher(Teacher teacher)
    {
        var teacherFromDb = GetById(teacher.Id);
        if (teacherFromDb is null)
        {
            return false;
        }

        var index = _teachers.IndexOf(teacherFromDb);
        _teachers[index] = teacher;
        SaveData();
        return true;
    }
    public void AddLike(Guid id)
    {
        var teacherFromDb = GetById(id);
        if(teacherFromDb is null)
        {
            Console.WriteLine("Teacher is not found");
            return;
        }
        teacherFromDb.Likes++;
        SaveData();
    }
    public void AddDislike(Guid id)
    {
        var teacherFromDb = GetById(id);
        if(teacherFromDb is null)
        {
            Console.WriteLine("Teacher is not found");
            return;
        }
        teacherFromDb.DisLikes++;
        SaveData();
    }

    public List<Teacher> GetAllTeacher()
    {
        return GetTeachers();
    }

    private void SaveData()
    {
        var teachersJson = JsonSerializer.Serialize(_teachers);
        File.WriteAllText(teacherFilePath, teachersJson);
    }

    private List<Teacher> GetTeachers()
    {
        var teachersJson = File.ReadAllText(teacherFilePath);
        var teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersJson);
        return teachers;
    }


}
