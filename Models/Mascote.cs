using System.Text.Json.Serialization;

public class AbilityInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class AbilitySlot
{
    [JsonPropertyName("ability")]
    public AbilityInfo Ability { get; set; }

    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    [JsonPropertyName("slot")]
    public int Slot { get; set; }
}

public class Mascote
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; set; }

    [JsonPropertyName("abilities")]
    public List<AbilitySlot> Abilities { get; set; }

    // ✅ NOVO — sprite vem direto da API!
    [JsonPropertyName("sprites")]
    public MascoteSprites Sprites { get; set; }
}

// ✅ NOVO — classe para capturar a imagem do Pokémon
public class MascoteSprites
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }
}

public class ItemLanguage
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class ItemEffect
{
    [JsonPropertyName("effect")]
    public string Effect { get; set; }

    [JsonPropertyName("short_effect")]
    public string ShortEffect { get; set; }

    [JsonPropertyName("language")]
    public ItemLanguage Language { get; set; }
}

public class Item
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("cost")]
    public int Cost { get; set; }

    [JsonPropertyName("effect_entries")]
    public List<ItemEffect> EffectEntries { get; set; }
}