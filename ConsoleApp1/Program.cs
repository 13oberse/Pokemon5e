using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Models.JsonClasses;

namespace ConsoleApp1;

public static class Program
{
    private const string BASE_DIRECTORY = "JsonFiles";
    private const string OUTPUT_DIRECTORY = "Output";

    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);

    public static async Task Main()
    {
        const string ABILITIES = "abilities.json";
        await using var abilityFileStream = File.OpenRead(Path.Combine(BASE_DIRECTORY, ABILITIES));
        var abilities = await JsonSerializer.DeserializeAsync<Dictionary<string, PokemonJsonAbility>>(abilityFileStream, Options);
        await SaveJson(abilities!, ABILITIES);

        var files = Directory.GetFiles(Path.Combine(BASE_DIRECTORY, "pokemon"));
        var pokemon = new Dictionary<string, PokemonJsonPokemon>(files.Length);

        foreach (var file in files)
        {
            await using var pokemonFileStream = File.OpenRead(file);
            var mon = await JsonSerializer.DeserializeAsync<PokemonJsonPokemon>(pokemonFileStream, Options);
            pokemon.Add(Path.GetFileNameWithoutExtension(file), mon!);
        }

        await SaveJson(pokemon, "pokemon.json");
        Console.WriteLine("Done");
    }

    private static async Task SaveJson<T>(T model, string fileName)
    {
        if (!Directory.Exists(OUTPUT_DIRECTORY))
        {
            Directory.CreateDirectory(OUTPUT_DIRECTORY);
        }

        var file = Path.Combine(OUTPUT_DIRECTORY, fileName);
        if (File.Exists(file))
        {
            File.Delete(file);
        }

        var json = JsonSerializer.Serialize(model, Options);
        await File.WriteAllTextAsync(file, json);
    }
}