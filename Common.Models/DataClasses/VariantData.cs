using System.Collections.Generic;
using System.Linq;

namespace Common.Models.DataClasses;

public record VariantData
{
    public string Name { get; init; } = string.Empty;

    public List<string> Variants { get; init; } = DefaultValues.ListStringDefault;

    public static List<VariantData> GetFromDictionary(Dictionary<string, List<string>> input) => input
        .Select(x => new VariantData
        {
            Name = x.Key,
            Variants = x.Value
        })
        .ToList();
}