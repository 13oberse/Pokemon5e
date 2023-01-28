using System.Collections.Generic;

namespace Common.Models.DataClasses;

public record HabitatData
{
    public string Habitat { get; init; } = string.Empty;

    public List<string> Pokemon { get; init; } = DefaultValues.ListStringDefault;
}