namespace Common.Models.DataClasses;

public record GenderData
{
    public string Name { get; init; } = string.Empty;

    public PokemonGender Gender { get; init; }
}