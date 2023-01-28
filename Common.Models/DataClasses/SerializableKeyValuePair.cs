namespace Common.Models.DataClasses;

public record SerializableKeyValuePair<TKey, TValue>
{
    public TKey Key { get; init; } = default!;

    public TValue Value { get; init; } = default!;
}