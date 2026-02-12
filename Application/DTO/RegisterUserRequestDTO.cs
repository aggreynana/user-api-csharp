using System.ComponentModel.DataAnnotations;

namespace UserApi.Application.DTO;

public record RegisterUserRequestDTO
{
    [Required]
    [MinLength(2)]
    public string Name { get; init; } = default!;

    [Range(12, 120)]
    public int Age { get; init; }

    [Required]
    [EmailAddress]
    public string Email { get; init; } = default!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; init; } = default!;
}