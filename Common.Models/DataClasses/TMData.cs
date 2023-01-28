using System.Collections.Generic;
using System.Linq;

namespace Common.Models.DataClasses;

public record TMData
{
    public int Number { get; init; }

    public string Name { get; init; } = string.Empty;

    public static List<TMData> GetFromDictionary(Dictionary<string, string> input) => input
        .Select(x => new TMData
        {
            Number = int.Parse(x.Key),
            Name = x.Value
        })
        .ToList();
}