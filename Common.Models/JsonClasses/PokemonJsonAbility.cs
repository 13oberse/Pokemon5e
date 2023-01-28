using Common.Models.DataClasses;

namespace Common.Models.JsonClasses;

public record PokemonJsonAbility : IPokemonJsonType<AbilityData>
{
    public string Description { get; set; } = string.Empty;

    public AbilityData ToOutput(string input) => new()
    {
        Name = input,
        Description = Description
    };
}