namespace Common.Models;

public record class PokemonFilterData
{
    public int Index { get; set; }

    public PokemonType Type1 { get; set; }

    public PokemonType? Type2 { get; set; }

    public decimal SpeciesRating { get; set; }

    public int MinimumFieldLevel { get; set; }
}