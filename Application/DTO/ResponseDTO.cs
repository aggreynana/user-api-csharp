namespace UserApi.Application.DTO;
public record UserResponseDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public int Age { get; init; }
    public string Email { get; init; } = default!;
}