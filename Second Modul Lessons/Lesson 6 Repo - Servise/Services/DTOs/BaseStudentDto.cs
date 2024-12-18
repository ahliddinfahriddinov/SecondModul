using Lesson_6_Repo___Servise.Services.DTOs.Enums;

namespace Lesson_6_Repo___Servise.Services.DTOs;

public class BaseStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public GenderDto Gender { get; set; }
    public DegreeDto Degree { get; set; }

}
