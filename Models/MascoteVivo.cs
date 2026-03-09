public class MascoteVivo
{
    public string Nome      { get; private set; }
    public string Especie   { get; private set; }
    public string SpriteUrl { get; private set; }

    private int _alimentacao;
    private int _humor;
    private int _energia;
    private int _saude;

    public int Alimentacao => _alimentacao;
    public int Humor       => _humor;
    public int Energia     => _energia;
    public int Saude       => _saude;

    private static readonly Random _random = new Random();

    public MascoteVivo(string especie, string nomeDado, string spriteUrl)
    {
        Especie      = especie;
        Nome         = nomeDado;
        SpriteUrl    = spriteUrl;   // ✅ salva a URL do sprite
        _alimentacao = _random.Next(5, 11);
        _humor       = _random.Next(5, 11);
        _energia     = _random.Next(5, 11);
        _saude       = _random.Next(5, 11);
    }

    private int Clamp(int valor) => Math.Clamp(valor, 0, 10);

    private void Alterar(ref int atributo, int quantidade)
    {
        atributo = Clamp(atributo + quantidade);
    }

    public string StatusEmoji(int valor)
    {
        return valor switch
        {
            >= 8 => "🟢",
            >= 5 => "🟡",
            >= 3 => "🟠",
            _    => "🔴"
        };
    }

    public void Alimentar()
    {
        if (_alimentacao == 10) return;
        Alterar(ref _alimentacao, +3);
        Alterar(ref _saude,       +1);
        Alterar(ref _energia,     -1);
    }

    public void Brincar()
    {
        if (_energia < 2) return;
        Alterar(ref _humor,       +3);
        Alterar(ref _energia,     -2);
        Alterar(ref _alimentacao, -1);
    }

    public void Dormir()
    {
        if (_energia == 10) return;
        Alterar(ref _energia, +4);
        Alterar(ref _humor,   -1);
    }

    public void Medicar()
    {
        if (_saude == 10) return;
        Alterar(ref _saude, +4);
        Alterar(ref _humor, -2);
    }

    public void UsarItem(int bonus)
    {
        Alterar(ref _saude,       +bonus);
        Alterar(ref _alimentacao, +bonus);
    }

    public bool EstaCritico() => _alimentacao <= 2 || _saude <= 2;
}