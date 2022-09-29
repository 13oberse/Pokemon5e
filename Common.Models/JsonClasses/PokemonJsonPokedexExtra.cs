namespace Common.Models.JsonClasses;

public record class PokemonJsonPokedexExtra
{
    public string Flavor { get; set; } = string.Empty;

    public int Height { get; set; }

    public int Weight { get; set; }

    public string Genus { get; set; } = string.Empty;
}