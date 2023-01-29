using Common.Models;
using Common.Models.DataClasses;
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
    private const string OUTPUT_DIRECTORY = "DataFiles";

    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);

    public static async Task Main()
    {
        var genderDict = await ReadFileAsJson<Dictionary<string, PokemonGender>>("gender.json");
        var pokedexExtra = await ReadFileAsJson<Dictionary<string, PokemonJsonPokedexExtra>>("pokedex_extra.json");

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

        var abilityData = await ConvertAndSaveFile<PokemonJsonAbility, AbilityData>("abilities.json");
        var evolveData = await ConvertAndSaveFile<PokemonJsonEvolve, EvolveData>("evolve.json");
        await ConvertAndSaveFile<PokemonJsonFeat, FeatData>("feats.json");
        await ConvertAndSaveFile<PokemonJsonItem, ItemData>("items.json");
        await ConvertAndSaveFile<PokemonJsonLeveling, LevelingData>("leveling.json");

        var moveData = await ConvertAndSaveDirectory<PokemonJsonMove, MoveData>("moves");

        var pokemon = await ConvertDirectory<PokemonJsonPokemon, PokemonData>("pokemon");
        var pokemonData = pokemon.ConvertAll(x => x.MakeNewWithExtra(pokedexExtra, genderDict));

        await SaveJson(pokemonData, "pokemon.json");
        CheckAllData(habitatData, tmData, trainerCLassData, variantsData, abilityData, evolveData, moveData, pokemonData);
        Console.WriteLine("Done");
    }

    private static void CheckAllData(List<HabitatData> habitatDatas, List<TMData> tms, List<TrainerClassData> trainerClassDatas, List<VariantData> variantDatas,
        List<AbilityData> abilityDatas, List<EvolveData> evolveDatas, List<MoveData> moveDatas, List<PokemonData> pokemonDatas)
    {
        foreach (var variants in variantDatas)
        {
            if (pokemonDatas.All(x => x.Name != variants.Name))
            {
                throw new Exception($"Variants: {variants.Name} not found");
            }
        }

        var variantsList = variantDatas.SelectMany(x => x.Variants).ToList();
        foreach (var mon in habitatDatas.SelectMany(x => x.Pokemon))
        {
            if (pokemonDatas.All(x => x.Name != mon && x.Name != $"{mon}-f" && x.Name != $"{mon}-m") && !variantsList.Contains(mon))
            {
                throw new Exception($"Habitat: {mon} not found");
            }
        }

        foreach (var trainerClassData in trainerClassDatas)
        {
            if (pokemonDatas.All(x => !trainerClassData.Pokemon.Contains(x.Name)))
            {
                throw new Exception($"Trainer Class: {trainerClassData.Name} not found {string.Join(";", trainerClassData.Pokemon)}");
            }
        }

        foreach (var tm in tms)
        {
            if (moveDatas.All(x => x.Name != tm.Name))
            {
                throw new Exception($"TM {tm} name not found");
            }
        }

        foreach (var pokemon in pokemonDatas)
        {
            if (pokemon.Moves.LearnByTM != null)
            {
                if (tms.All(x => !pokemon.Moves.LearnByTM.Contains(x.Number)))
                {
                    throw new Exception($"TM Move: {string.Join(",", pokemon.Moves.LearnByTM)} not found");
                }
            }

            if (pokemon.Moves.LearnByLevelUp != null)
            {
                foreach (var levelUp in pokemon.Moves.LearnByLevelUp)
                {
                    if (moveDatas.All(x => !levelUp.Value.Contains(x.Name)))
                    {
                        throw new Exception($"Level Up Moves {string.Join(",", levelUp.Value)} not found");
                    }
                }
            }

            foreach (var startingMove in pokemon.Moves.StartingMoves)
            {
                if (moveDatas.All(x => x.Name != startingMove))
                {
                    throw new Exception($"Starting Move {startingMove} not found");
                }
            }

            if (!string.IsNullOrWhiteSpace(pokemon.HiddenAbility) && abilityDatas.All(x => x.Name != pokemon.HiddenAbility))
            {
                throw new Exception($"Hidden Ability: {pokemon.HiddenAbility} not found");
            }

            foreach (var ability in pokemon.Abilities)
            {
                if (abilityDatas.All(x => x.Name != ability))
                {
                    throw new Exception($"Ability: {ability} not found. {pokemon.Name}");
                }
            }
        }

        foreach (var evolveData in evolveDatas)
        {
            if (pokemonDatas.All(x => x.Name != evolveData.Name))
            {
                throw new Exception($"Evolve Name: {evolveData.Name} not found");
            }

            if (evolveData.Into.Count > 0 && pokemonDatas.All(x => !evolveData.Into.Contains(x.Name)))
            {
                throw new Exception($"Evolve Into: {string.Join(",", evolveData.Into)} not found");
            }
        }
    }

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

    private static async Task<List<TOutput>> ConvertAndSaveFile<TInput, TOutput>(string fileName)
        where TInput : IPokemonJsonType<TOutput>
    {
        var output = await ConvertFile<TInput, TOutput>(fileName);
        await SaveJson(output, fileName);
        return output;
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

    private static async Task<List<TOutput>> ConvertAndSaveDirectory<TInput, TOutput>(string directory)
        where TInput : IPokemonJsonType<TOutput>
    {
        var output = await ConvertDirectory<TInput, TOutput>(directory);
        await SaveJson(output, $"{directory}.json");
        return output;
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