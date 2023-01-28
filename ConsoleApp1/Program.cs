using Common.Models;
using Common.Models.DataClasses;
using Common.Models.JsonClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1;

public static class Program
{
    private const string BASE_DIRECTORY = "JsonFiles";
    private const string OUTPUT_DIRECTORY = "DataFiles";

    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);

    public static async Task Main()
    {
        var genderDict = await ReadFileAsJson<Dictionary<string, PokemonGender>>("gender.json");
        var pokedexExtraData = await ConvertFile<PokemonJsonPokedexExtra, PokedexExtraData>("pokedex_extra.json");

        var expGrid = await ReadFileAsJson<Dictionary<string, Dictionary<string, int>>>("exp_grid.json");
        var expGridData = ExpGridData.GetFromDictionary(expGrid);
        await SaveJson(expGridData, "exp_grid.json");

        var habitat = await ReadFileAsJson<Dictionary<string, List<string>>>("habitat.json");
        var habitatData = HabitatData.GetFromDictionary(habitat);
        await SaveJson(habitatData, "habitat.json");

        var tms = await ReadFileAsJson<Dictionary<string, string>>("move_machines.json");
        var tmData = TMData.GetFromDictionary(tms);
        await SaveJson(tmData, "move_machines.json");

        var natures = await ReadFileAsJson<Dictionary<string, Dictionary<string, int>>>("natures.json");
        var naturesData = NatureData.GetFromDictionary(natures);
        await SaveJson(naturesData, "natures.json");

        var trainerClass = await ReadFileAsJson<Dictionary<string, List<string>>>("trainer_classes.json");
        var trainerCLassData = TrainerClassData.GetFromDictionary(trainerClass);
        await SaveJson(trainerCLassData, "trainer_classes.json");

        var variants = await ReadFileAsJson<Dictionary<string, List<string>>>("variant_map.json");
        var variantsData = VariantData.GetFromDictionary(variants);
        await SaveJson(variantsData, "variant_map.json");

        await ConvertAndSaveFile<PokemonJsonAbility, AbilityData>("abilities.json");
        await ConvertAndSaveFile<PokemonJsonEvolve, EvolveData>("evolve.json");
        await ConvertAndSaveFile<PokemonJsonFeat, FeatData>("feats.json");
        await ConvertAndSaveFile<PokemonJsonItem, ItemData>("items.json");
        await ConvertAndSaveFile<PokemonJsonLeveling, LevelingData>("leveling.json");

        await ConvertAndSaveDirectory<PokemonJsonMove, MoveData>("moves");

        var pokemon = await ConvertDirectory<PokemonJsonPokemon, PokemonData>("pokemon");
        await SaveJson(pokemon, "pokemon.json");

        Console.WriteLine("Done");
    }

    //private static void CheckAndConvertAllFiles()
    //{
    //await CheckAndSave<PokemonJsonMove>("Error_move.json");
    //await CheckConvertAndSaveFile<PokemonJsonFilterData, PokemonFilterData>("filter_data.json");
    //await CheckAndSave<Dictionary<string, List<string>>>("index_order.json");
    //await CheckAndSave<PokemonJsonPokemon>("MissingNo.json");
    //}

    private static async Task<List<TOutput>> ConvertFile<TInput, TOutput>(string fileName)
        where TInput : IPokemonJsonType<TOutput>
    {
        var fileJson = await ReadFileAsJson<Dictionary<string, TInput>>(fileName);
        var output = new List<TOutput>(fileJson.Count);
        foreach (var (key, value) in fileJson)
        {
            output.Add(value.ToOutput(key));
        }

        return output;
    }

    private static async Task ConvertAndSaveFile<TInput, TOutput>(string fileName)
        where TInput : IPokemonJsonType<TOutput>
    {
        var output = await ConvertFile<TInput, TOutput>(fileName);
        await SaveJson(output, fileName);
    }

    private static async Task<List<TOutput>> ConvertDirectory<TInput, TOutput>(string directory)
        where TInput : IPokemonJsonType<TOutput>
    {
        var files = Directory.GetFiles(Path.Combine(BASE_DIRECTORY, directory));
        var dictionary = new List<TOutput>(files.Length);

        foreach (var file in files)
        {
            var instance = await ReadFileAsJson<TInput>(file, true);
            var name = Path.GetFileNameWithoutExtension(file);
            dictionary.Add(instance.ToOutput(name));
        }

        return dictionary;
    }

    private static async Task ConvertAndSaveDirectory<TInput, TOutput>(string directory)
        where TInput : IPokemonJsonType<TOutput>
    {
        var output = await ConvertDirectory<TInput, TOutput>(directory);
        await SaveJson(output, $"{directory}.json");
    }

    private static async Task<T> ReadFileAsJson<T>(string fileName, bool isCompletePath = false)
    {
        var path = isCompletePath ? fileName : Path.Combine(BASE_DIRECTORY, fileName);
        await using var fileStream = File.OpenRead(path);
        return (await JsonSerializer.DeserializeAsync<T>(fileStream, Options))!;
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