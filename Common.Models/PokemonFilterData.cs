namespace Common.Models;

public record class PokemonFilterData
{
    public int Index { get; init; }

    public PokemonType Type1 { get; init; }

    public PokemonType? Type2 { get; init; }

    public decimal SpeciesRating { get; init; }

    public int MinimumFieldLevel { get; init; }
}