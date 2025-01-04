using Pattern_project.Services.DTOs;

namespace Pattern_project;

public class Program
{
    static void Main(string[] args)
    {
        var firstDto = new CreateDto()
        {
          FirstName = "Laziz",
          LastName = "Azizov",
          Age = 19,
          Email = "Laziz@gamil.com",
          Password = "password1",
          Gender = 0,
          Status = 0,
        };
        var secondDto = new CreateDto()
        {
            FirstName = "Tom",
            LastName = "McDonald",
            Age = 24,
            Email = "Tom@gmail.com",
            Password = "password2",
            Gender = 0,
            Status = (Services.DTOs.Enums.StatusDto)1,
        };
    }
}
