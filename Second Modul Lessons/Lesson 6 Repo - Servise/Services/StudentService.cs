using Lesson_6_Repo___Servise.DataAccess.Entities;
using Lesson_6_Repo___Servise.DataAccess.Enums;
using Lesson_6_Repo___Servise.Repositories;
using Lesson_6_Repo___Servise.Services.DTOs;
using Lesson_6_Repo___Servise.Services.DTOs.Enums;

namespace Lesson_6_Repo___Servise.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService()
    {
        _studentRepository = new StudentRepository();
    }

    public Guid AddStudent(StudentCreateDto studentCreateDto)
    {
        var response = ValidateStudentCreateDto(studentCreateDto);
        if (response == false)
        {
            throw new Exception("an error occured while adding");
        }
        var entity = ConvertToEntity(studentCreateDto);
        var id = _studentRepository.Write(entity);
        return id;
    }

    public void DeleteStudent(Guid studentId)
    {
        _studentRepository.Delete(studentId);
    }

    public List<StudentGetDto> GetStudentByGender(GenderDto genderDto)
    {
        var students = _studentRepository.ReadAllStudents();
        var studentsDto = new List<StudentGetDto>();
        foreach (var student in students)
        {
            if ((GenderDto)student.Gender == genderDto)
            {
                studentsDto.Add(ConvertToDto(student));
            }
        }
        return studentsDto;
    }

    public StudentGetDto GetStudentById(Guid studentId)
    {
        var entity = _studentRepository.ReadById(studentId);
        var dto = ConvertToDto(entity);
        return dto;
    }

    public List<StudentGetDto> GetStudents()
    {
        var students = _studentRepository.ReadAllStudents();
        var studentDto = new List<StudentGetDto>();
        foreach (var student in students)
        {
          studentDto.Add(ConvertToDto(student));
        }
        return studentDto;
    }

    public List<StudentGetDto> GetStudentsByDegree(DegreeDto degreeDto)
    {
        var students = _studentRepository.ReadAllStudents();
        var studentsDto = new List<StudentGetDto>();
        foreach(var student in students)
        {
            if ((DegreeDto)student.Degree == degreeDto)
            {
                studentsDto.Add(ConvertToDto(student));
            }
        }
        return studentsDto;
    }

    public void UpdateStudent(StudentUpdateDto studentUpdateDto)
    {
        var responce = ValidateStudentUpdateDto(studentUpdateDto);
        if (responce == false)
        {
            throw new Exception("an error occured while updating");
        }
        var entity = ConvertToEntity(studentUpdateDto);
        _studentRepository.Update(entity);
    }
    private Student ConvertToEntity(StudentCreateDto studentCreateDto)
    {
        return new Student
        {
            Id = Guid.NewGuid(),
            FirstName = studentCreateDto.FirstName,
            LastName = studentCreateDto.LastName,
            Age = studentCreateDto.Age,
            Password = studentCreateDto.Password,
            Email = studentCreateDto.Email,
            Degree = (DataAccess.Enums.DegreeStatus)studentCreateDto.Degree,
            Gender = (DataAccess.Enums.Gender)studentCreateDto.Gender
        };
    }
    private Student ConvertToEntity(StudentUpdateDto studentUpdateDto)
    {
        return new Student
        {
            Id = studentUpdateDto.Id,
            FirstName = studentUpdateDto.FirstName,
            LastName = studentUpdateDto.LastName,
            Age = studentUpdateDto.Age,
            Password = studentUpdateDto.Password,
            Email = studentUpdateDto.Email,
            Degree = (DataAccess.Enums.DegreeStatus)studentUpdateDto.Degree,
            Gender = (DataAccess.Enums.Gender)studentUpdateDto.Gender
        };
    }
    private StudentGetDto ConvertToDto(Student student)
    {
        return new StudentGetDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            Email = student.Email,
            Degree = (DegreeDto)student.Degree,
            Gender = (GenderDto)student.Gender
        };
    }

    private bool ValidateStudentCreateDto(StudentCreateDto dto)
    {
        _studentRepository.CheckEmail(dto.Email);

        if (string.IsNullOrWhiteSpace(dto.FirstName) || dto.FirstName.Length > 50)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(dto.LastName) || dto.LastName.Length > 50)
        {
            return false;
        }
        if (dto.Age > 16 || dto.Age < 100)
        {
            return false;
        }
        if ( string.IsNullOrWhiteSpace(dto.Email)
            || dto.Email.Length > 50 || dto.Email.EndsWith("@gmail.com"))
        {
            return false;

        }
        if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 8)
        {
            return false;
        }
        return true;
    }

    private bool ValidateStudentUpdateDto(StudentUpdateDto dto)
    {
        _studentRepository.CheckEmail(dto.Email);

        if (string.IsNullOrWhiteSpace(dto.FirstName) || dto.FirstName.Length > 50)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(dto.LastName) || dto.LastName.Length > 50)
        {
            return false;
        }
        if (dto.Age > 16 || dto.Age < 100)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(dto.Email)
            || dto.Email.Length > 50 || dto.Email.EndsWith("@gmail.com"))
        {
            return false;

        }
        if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 8)
        {
            return false;
        }
        return true;
    }

    
}
