namespace ALIbrary.Application.Members.DTOs;

public class MemberResponse
{
    public Guid Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}