using Pattern_project.Services.DTOs;
using Pattern_project.Services.DTOs.Enums;

namespace Pattern_project.Services;
public interface IStudentService
{
    Guid Add (CreateDto createDto);
    void Delete (Guid studentId);
    GetDto GetById (Guid studentId);
    List<GetDto> GetAll();
    void Update (UpdateDto updateDto);
    List<GetDto> GetByStatus(StatusDto statusDto);
    List<GetDto> GetByGender(GenderDto genderDto);
}