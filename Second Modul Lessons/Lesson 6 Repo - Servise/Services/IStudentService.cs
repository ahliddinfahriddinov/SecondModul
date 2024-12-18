using Lesson_6_Repo___Servise.Services.DTOs;
using Lesson_6_Repo___Servise.Services.DTOs.Enums;

namespace Lesson_6_Repo___Servise.Services;
public interface IStudentService
{
    Guid AddStudent(StudentCreateDto studentCreateDto);
    void DeleteStudent(Guid studentId);
    StudentGetDto GetStudentById(Guid studentId);
    void UpdateStudent(StudentUpdateDto studentUpdateDto);
    List<StudentGetDto> GetStudents();
    List<StudentGetDto> GetStudentsByDegree(DegreeDto degreeDto);
    List<StudentGetDto> GetStudentByGender(GenderDto genderDto);


}
