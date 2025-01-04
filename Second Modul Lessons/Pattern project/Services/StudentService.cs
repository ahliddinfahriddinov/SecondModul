using Pattern_project.DataAcces.Entites;
using Pattern_project.Repositories;
using Pattern_project.Services.DTOs;
using Pattern_project.Services.DTOs.Enums;

namespace Pattern_project.Services;

public class StudentService : IStudentService
{
    private StudentRepository _studentRepository;
    public StudentService()
    {
        _studentRepository = new StudentRepository();
    }
    public Guid Add(CreateDto createDto)
    {
        var result = ValidateStudentCreateDto(createDto);
        if (result == false)
        {
            throw new Exception("An error occurred during addition");
        }
        var entity = ConvertToEntity(createDto);
        var id = _studentRepository.Write(entity);
        return id;

    }

    public void Delete(Guid studentId)
    {
        _studentRepository.Delete(studentId);
    }

    public List<GetDto> GetAll()
    {
        var students = _studentRepository.ReadAll();
        var result = students.Select(st => ConvertToDto(st)).ToList();
        return result;
    }
    public List<GetDto> GetByGender(GenderDto genderDto)
    {
        var students = _studentRepository.ReadAll();
        var studentsDto = new List<GetDto>();
        foreach (var student in students)
        {
            if((GenderDto)student.Gender == genderDto)
            {
                studentsDto.Add(ConvertToDto(student));
            }
        }
       return studentsDto;
    }

    public GetDto GetById(Guid studentId)
    {
        var entity = _studentRepository.GetById(studentId);
        var dto = ConvertToDto(entity);
        return dto;
    }

    public List<GetDto> GetByStatus(StatusDto statusDto)
    {
        var students = _studentRepository.ReadAll();
        var studentsDto = new List<GetDto>();
        foreach(var student in students)
        {
            if((StatusDto)student.Status == statusDto)
            {
                studentsDto.Add(ConvertToDto(student));
            }
        }
        return studentsDto;
    }

    public void Update(UpdateDto updateDto)
    {
        var entity = ConvertToEntity(updateDto);
        _studentRepository.Update(entity);
    }
    private Student ConvertToEntity(CreateDto createDto)
    {
        return new Student
        {
            Id = Guid.NewGuid(),
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Age = createDto.Age,
            Email = createDto.Email,
            Password = createDto.Password,
            Gender = (DataAcces.Enums.Gender)createDto.Gender,
            Status = (DataAcces.Enums.Status)createDto.Status,
        };
    }
    private Student ConvertToEntity(UpdateDto updateDto)
    {
        return new Student
        {
            Id = updateDto.Id,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            Age = updateDto.Age,
            Email = updateDto.Email,
            Password = updateDto.Password,
            Gender = (DataAcces.Enums.Gender)updateDto.Gender,
            Status = (DataAcces.Enums.Status)updateDto.Status,
        };
    }
    private GetDto ConvertToDto(Student student)
    {
        return new GetDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            Email = student.Email,
            Gender = (GenderDto)student.Gender,
            Status = (StatusDto)student.Status
        };
    }
    private bool ValidateStudentCreateDto(CreateDto obj)
    {
        _studentRepository.EmailCheck(obj.Email);

        if (string.IsNullOrWhiteSpace(obj.FirstName) || obj.FirstName.Length > 50)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.LastName) || obj.LastName.Length > 50)
        {
            return false;
        }
        if (obj.Age > 15 || obj.Age < 90)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Email) || obj.Email.Length <= 10
            || obj.Email.Length > 100 || !obj.Email.EndsWith("@gmail.com"))
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Password) || obj.Password.Length > 50
            || obj.Password.Length < 8)
        {
            return false;
        }
        return true;

    }
}
