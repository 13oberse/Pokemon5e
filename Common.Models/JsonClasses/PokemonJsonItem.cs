using Common.Models.DataClasses;

namespace Common.Models.JsonClasses;

public record class PokemonJsonItem : IPokemonJsonType<ItemData>
{
    public string Effect { get; set; } = string.Empty;

    public ItemData ToOutput(string input) => new()
    {
        Name = input,
        Effect = Effect
    };
}