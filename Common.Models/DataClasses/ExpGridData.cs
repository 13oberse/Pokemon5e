using System.Collections.Generic;
using System.Linq;

namespace Common.Models.DataClasses;

public record ExpGridData
{
    public int Level { get; init; }

    public List<SerializableKeyValuePair<double, int>> SRExperience { get; init; } = DefaultValues.DoubleIntPairListDefault;

    public static List<ExpGridData> GetFromDictionary(Dictionary<string, Dictionary<string, int>> input) => input
        .Select(x => new ExpGridData
        {
            Level = int.Parse(x.Key),
            SRExperience = x.Value
                .Select(v => new SerializableKeyValuePair<double, int>
                {
                    Key = double.Parse(v.Key),
                    Value = v.Value
                })
                .ToList()
        })
        .ToList();
}