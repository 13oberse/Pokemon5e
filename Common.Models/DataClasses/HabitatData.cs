using System.Collections.Generic;
using System.Linq;

namespace Common.Models.DataClasses;

public record HabitatData
{
    public string Habitat { get; init; } = string.Empty;

    public List<string> Pokemon { get; init; } = DefaultValues.ListStringDefault;

    public static List<HabitatData> GetFromDictionary(Dictionary<string, List<string>> input) => input
        .Select(x => new HabitatData
        {
            Habitat = x.Key,
            Pokemon = x.Value
        })
        .ToList();
}