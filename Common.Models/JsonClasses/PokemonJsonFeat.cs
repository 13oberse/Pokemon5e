using Common.Models.DataClasses;

namespace Common.Models.JsonClasses;

public record class PokemonJsonFeat : IPokemonJsonType<FeatData>
{
    public string Description { get; set; } = string.Empty;

    public FeatData ToOutput(string input) => new()
    {
        Name = input,
        Description = Description
    };
}