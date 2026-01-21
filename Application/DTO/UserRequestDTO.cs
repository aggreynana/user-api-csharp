namespace UserApi.Application.DTO;
public record UserRequestDTO
{
    public string Name { get; init; } = default!;
    public int Age { get; init; }
    public string Email { get; init; } = default!;
}