namespace Lesson_6_Repo___Servise.Services.DTOs;

public class StudentUpdateDto : BaseStudentDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }

}
