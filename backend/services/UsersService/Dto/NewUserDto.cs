namespace UsersService.Dto
{
    public class NewUserDto
    {
        public string Email { get; set; }
        public required string Username { get; set; }
        public required string Token { get; set; }
    }
}
