public record LoginRequestDTO
{
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}

