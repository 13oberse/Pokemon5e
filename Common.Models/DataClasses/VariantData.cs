using System.Collections.Generic;

namespace Common.Models.DataClasses;

public record VariantData
{
    public string Name { get; init; } = string.Empty;

    public List<string> Variants { get; init; } = DefaultValues.ListStringDefault;
}