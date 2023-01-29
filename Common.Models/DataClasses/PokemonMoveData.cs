using System.Collections.Generic;

namespace Common.Models.DataClasses;

public record PokemonMoveData
{
    public static readonly PokemonMoveData Default = new();

    public List<SerializableKeyValuePair<int, List<string>>>? LearnByLevelUp { get; init; }

    public List<string> StartingMoves { get; init; } = DefaultValues.ListStringDefault;

    public List<int>? LearnByTM { get; init; }
}