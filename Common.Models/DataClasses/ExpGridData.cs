using System.Collections.Generic;

namespace Common.Models.DataClasses;

public record ExpGridData
{
    public int Level { get; init; }

    public List<SerializableKeyValuePair<double, int>> SRExperience { get; init; } = DefaultValues.DoubleIntPairListDefault;
}