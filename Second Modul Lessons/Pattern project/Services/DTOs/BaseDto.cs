using Pattern_project.DataAcces.Enums;
using Pattern_project.Services.DTOs.Enums;

namespace Pattern_project.Services.DTOs;

public class BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public GenderDto Gender { get; set; }
    public StatusDto Status { get; set; }
}
