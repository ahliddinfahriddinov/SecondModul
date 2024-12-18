using Lesson_6_Repo___Servise.DataAccess.Enums;

namespace Lesson_6_Repo___Servise.DataAccess.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public DegreeStatus Degree { get; set; }

}
