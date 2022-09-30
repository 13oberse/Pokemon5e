using Common.Models;
using Common.Models.JsonClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1;

public static class Program
{
    private const string BASE_DIRECTORY = "JsonFiles";
    private const string OUTPUT_DIRECTORY = "Output";

    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);

    public static async Task Main()
    {
        await CheckAndConvertAllFiles();
        Console.WriteLine("Done");
    }

    private static async Task CheckAndConvertAllFiles()
    {
        await CheckAndSave<Dictionary<string, PokemonJsonAbility>>("abilities.json");
        await CheckAndSave<PokemonJsonMove>("Error_move.json");
        await CheckAndSave<Dictionary<string, PokemonJsonEvolve>>("evolve.json");
        await CheckAndSave<Dictionary<string, Dictionary<string, int>>>("exp_grid.json");
        await CheckAndSave<Dictionary<string, PokemonJsonFeat>>("feats.json");
        await CheckConvertAndSaveFile<PokemonJsonFilterData, PokemonFilterData>("filter_data.json");
        await CheckAndSave<Dictionary<string, PokemonGender>>("gender.json");
        await CheckAndSave<Dictionary<string, List<string>>>("habitat.json");
        await CheckAndSave<Dictionary<string, List<string>>>("index_order.json");
        await CheckAndSave<Dictionary<string, PokemonJsonItem>>("items.json");
        await CheckAndSave<Dictionary<string, PokemonJsonLeveling>>("leveling.json");
        await CheckAndSave<PokemonJsonPokemon>("MissingNo.json");
        await CheckAndSave<Dictionary<string, string>>("move_machines.json");
        await CheckAndSave<Dictionary<string, Dictionary<string, int>>>("natures.json");
        await CheckAndSave<Dictionary<string, PokemonJsonPokedexExtra>>("pokedex_extra.json");
        await CheckAndSave<Dictionary<string, List<string>>>("trainer_classes.json");
        await CheckAndSave<Dictionary<string, List<string>>>("variant_map.json");

        await CheckConvertAndSaveDirectory<PokemonJsonMove, PokemonMoveData>("moves");
        await CheckConvertAndSaveDirectory<PokemonJsonPokemon, PokemonPokemonData>("pokemon");
    }

    private static async Task<Dictionary<string, TOutput>> CheckAndConvertFile<TInput, TOutput>(string fileName)
        where TInput : IPokemonJsonType<TOutput>
    {
        var fileJson = await ReadFileAsJson<Dictionary<string, TInput>>(fileName);
        var returnValue = new Dictionary<string, TOutput>(fileJson.Count);
        foreach (var (key, value) in fileJson)
        {
            returnValue.Add(key, value.ToOutput());
        }

        return returnValue;
    }

    private static async Task CheckConvertAndSaveFile<TInput, TOutput>(string fileName)
        where TInput : IPokemonJsonType<TOutput>
    {
        var jsonFile = await CheckAndConvertFile<TInput, TOutput>(fileName);
        await SaveJson(jsonFile, fileName);
    }

    private static async Task<Dictionary<string, TOutput>> CheckAndConvertDirectory<TInput, TOutput>(string directory)
        where TInput : IPokemonJsonType<TOutput>
    {
        var files = Directory.GetFiles(Path.Combine(BASE_DIRECTORY, directory));
        var dictionary = new Dictionary<string, TOutput>(files.Length);

        foreach (var file in files)
        {
            var instance = await ReadFileAsJson<TInput>(file, true);
            dictionary.Add(Path.GetFileNameWithoutExtension(file), instance.ToOutput());
        }

        return dictionary;
    }

    private static async Task CheckConvertAndSaveDirectory<TInput, TOutput>(string directory)
        where TInput : IPokemonJsonType<TOutput>
    {
        var jsonFile = await CheckAndConvertDirectory<TInput, TOutput>(directory);
        await SaveJson(jsonFile, $"{directory}.json");
    }

    private static async Task CheckAllFiles()
    {
        await CheckAndSave<Dictionary<string, PokemonJsonAbility>>("abilities.json");
        await CheckAndSave<PokemonJsonMove>("Error_move.json");
        await CheckAndSave<Dictionary<string, PokemonJsonEvolve>>("evolve.json");
        await CheckAndSave<Dictionary<string, Dictionary<string, int>>>("exp_grid.json");
        await CheckAndSave<Dictionary<string, PokemonJsonFeat>>("feats.json");
        await CheckAndSave<Dictionary<string, PokemonJsonFilterData>>("filter_data.json");
        await CheckAndSave<Dictionary<string, PokemonGender>>("gender.json");
        await CheckAndSave<Dictionary<string, List<string>>>("habitat.json");
        await CheckAndSave<Dictionary<string, List<string>>>("index_order.json");
        await CheckAndSave<Dictionary<string, PokemonJsonItem>>("items.json");
        await CheckAndSave<Dictionary<string, PokemonJsonLeveling>>("leveling.json");
        await CheckAndSave<PokemonJsonPokemon>("MissingNo.json");
        await CheckAndSave<Dictionary<string, string>>("move_machines.json");
        await CheckAndSave<Dictionary<string, Dictionary<string, int>>>("natures.json");
        await CheckAndSave<Dictionary<string, PokemonJsonPokedexExtra>>("pokedex_extra.json");
        await CheckAndSave<Dictionary<string, List<string>>>("trainer_classes.json");
        await CheckAndSave<Dictionary<string, List<string>>>("variant_map.json");

        await CheckAndSaveDirectory<PokemonJsonMove>("moves");
        await CheckAndSaveDirectory<PokemonJsonPokemon>("pokemon");
    }

    private static async Task<T> ReadFileAsJson<T>(string fileName, bool isCompletePath = false)
    {
        var path = isCompletePath ? fileName : Path.Combine(BASE_DIRECTORY, fileName);
        await using var fileStream = File.OpenRead(path);
        return (await JsonSerializer.DeserializeAsync<T>(fileStream, Options))!;
    }

    private static async Task CheckAndSave<T>(string fileName)
    {
        var jsonFile = await ReadFileAsJson<T>(fileName);
        await SaveJson(jsonFile, fileName);
    }

    private static async Task CheckAndSaveDirectory<T>(string directory)
    {
        var files = Directory.GetFiles(Path.Combine(BASE_DIRECTORY, directory));
        var dictionary = new Dictionary<string, T>(files.Length);

        foreach (var file in files)
        {
            var instance = await ReadFileAsJson<T>(file, true);
            dictionary.Add(Path.GetFileNameWithoutExtension(file), instance);
        }

        await SaveJson(dictionary, $"{directory}.json");
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