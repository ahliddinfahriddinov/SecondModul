using Pattern_project.DataAcces.Enums;

namespace Pattern_project.DataAcces.Entites;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public Status Status { get; set; }
}
