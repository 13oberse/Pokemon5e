using System.Collections.Generic;
using System.Linq;

namespace Common.Models.DataClasses;

public record TrainerClassData
{
    public string Name { get; init; } = string.Empty;

    public List<string> Pokemon { get; init; } = DefaultValues.ListStringDefault;

    public static List<TrainerClassData> GetFromDictionary(Dictionary<string, List<string>> input) => input
        .Select(x => new TrainerClassData
        {
            Name = x.Key,
            Pokemon = x.Value
        })
        .ToList();
}