public class GameState
{
    public string NomeJogador  { get; set; } = "";
    public bool   JogoIniciado { get; set; } = false;

    public List<MascoteVivo>  MascotesAdotados   { get; set; } = new();

    // Os 3 pokémons sorteados para escolha inicial
    public List<string>  PokemonsSorteados  { get; set; } = new();
    public bool          SorteioFeito       { get; set; } = false;

    public void AdotarMascote(string especie, string nome, string spriteUrl)
    {
        MascotesAdotados.Add(new MascoteVivo(especie, nome, spriteUrl));
    }

    public void DefinirSorteio(List<string> pokemonsSorteados)
    {
        PokemonsSorteados = pokemonsSorteados;
        SorteioFeito      = true;
    }
}