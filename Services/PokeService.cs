using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

public class PokeService
{
    private readonly RestClient _client;
    private static readonly Random _random = new Random();

    // Cache de todos os nomes
    private List<string> _todosOsPokemon = new();

    public readonly List<string> ItensDisponiveis = new()
    {
        "potion",
        "super-potion",
        "antidote",
        "fresh-water"
    };

    public PokeService()
    {
        _client = new RestClient("https://pokeapi.co/api/v2");
    }

    // ═══════════════════════════════════
    //  Busca todos os nomes da API
    // ═══════════════════════════════════
    public async Task<List<string>> GetTodosOsPokemonAsync()
    {
        if (_todosOsPokemon.Any())
            return _todosOsPokemon;

        // A API retorna até 10000 — mais que suficiente para pegar todos
        var request  = new RestRequest("/pokemon?limit=10000");
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful) return new List<string>();

        var resultado = JsonSerializer.Deserialize<PokemonListResult>(response.Content);
        _todosOsPokemon = resultado?.Results?.Select(p => p.Name).ToList() ?? new();

        return _todosOsPokemon;
    }

    // ═══════════════════════════════════
    //  Sorteia N pokémons aleatórios
    // ═══════════════════════════════════
    public async Task<List<string>> SortearPokemonsAsync(int quantidade = 3)
    {
        var todos = await GetTodosOsPokemonAsync();
        if (!todos.Any()) return new List<string>();

        return todos
            .OrderBy(_ => _random.Next())
            .Take(quantidade)
            .ToList();
    }

    // ═══════════════════════════════════
    //  Busca dados de um pokémon
    // ═══════════════════════════════════
    public async Task<Mascote> BuscarMascoteAsync(string nome)
    {
        var request  = new RestRequest($"/pokemon/{nome}");
        var response = await _client.ExecuteAsync(request);
        return response.IsSuccessful
            ? JsonSerializer.Deserialize<Mascote>(response.Content)
            : null;
    }

    // ═══════════════════════════════════
    //  Busca item
    // ═══════════════════════════════════
    public async Task<Item> BuscarItemAsync(string nome)
    {
        var request  = new RestRequest($"/item/{nome}");
        var response = await _client.ExecuteAsync(request);
        return response.IsSuccessful
            ? JsonSerializer.Deserialize<Item>(response.Content)
            : null;
    }

    public async Task<List<Item>> BuscarTodosItensAsync()
    {
        var itens = new List<Item>();
        foreach (var nome in ItensDisponiveis)
        {
            var item = await BuscarItemAsync(nome);
            if (item != null) itens.Add(item);
        }
        return itens;
    }
}

// Classes auxiliares para deserializar a lista de pokémons
public class PokemonListResult
{
    [JsonPropertyName("results")]
    public List<PokemonListItem> Results { get; set; }
}

public class PokemonListItem
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
