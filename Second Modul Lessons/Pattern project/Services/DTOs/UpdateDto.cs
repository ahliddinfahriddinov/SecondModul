namespace Pattern_project.Services.DTOs
{
    public class UpdateDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}
