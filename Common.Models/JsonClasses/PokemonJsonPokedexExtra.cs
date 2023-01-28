using Common.Models.DataClasses;

namespace Common.Models.JsonClasses;

public record class PokemonJsonPokedexExtra : IPokemonJsonType<PokedexExtraData>
{
    public string Flavor { get; set; } = string.Empty;

    public int Height { get; set; }

    public int Weight { get; set; }

    public string Genus { get; set; } = string.Empty;

    public PokedexExtraData ToOutput(string input) => new()
    {
        Flavor = Flavor,
        Genus = Genus,
        Height = Height,
        Weight = Weight
    };
}