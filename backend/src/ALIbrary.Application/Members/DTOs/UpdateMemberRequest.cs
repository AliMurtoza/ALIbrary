namespace ALIbrary.Application.Members.DTOs;

public class UpdateMemberRequest
{
    public string UserId { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}