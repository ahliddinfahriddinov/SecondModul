using Lesson_6_Repo___Servise.Services;
using Lesson_6_Repo___Servise.Services.DTOs;

namespace Lesson_6_Repo___Servise;

internal class Program
{
    static void Main(string[] args)
    {
        var firstStudentDto = new StudentCreateDto()
        {
            FirstName = "Abdulaziz",
            LastName = "Bahodirov",
            Age = 20,
            Email = "Abdulaziz@gmail.com",
            Password = "password1",
            Gender = 0,
            Degree = 0,

        };
        var secondStudentDto = new StudentCreateDto()
        {
            FirstName = "Yasina",
            LastName = "Bahtiyorova",
            Age = 18,
            Email = "Yasi@gmail.com",
            Password = "password2",
            Gender = (Services.DTOs.Enums.GenderDto)1,
            Degree = (Services.DTOs.Enums.DegreeDto)1,

        };

        IStudentService studentService = new StudentService();
        studentService.AddStudent(firstStudentDto);
        studentService.AddStudent(secondStudentDto);
        
    }
}
