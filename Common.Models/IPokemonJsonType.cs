namespace Common.Models;

public interface IPokemonJsonType<out TResult>
{
    TResult ToOutput(string input);
}