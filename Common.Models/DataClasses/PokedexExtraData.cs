namespace Common.Models.DataClasses;

public record PokedexExtraData
{
    public static PokedexExtraData Default = new();

    public string Flavor { get; set; } = string.Empty;

    public int Height { get; set; }

    public int Weight { get; set; }

    public string Genus { get; set; } = string.Empty;
}