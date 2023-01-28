namespace Common.Models.DataClasses;

public record ItemData
{
    public string Name { get; init; } = string.Empty;

    public string Effect { get; init; } = string.Empty;
}