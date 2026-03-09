# 👾 PokéTama — Pokémon Tamagotchi em C# + Blazor

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![RestSharp](https://img.shields.io/badge/RestSharp-FF4500?style=for-the-badge&logo=nuget&logoColor=white)

> Projeto desenvolvido como desafio prático de C#, consumindo a [PokéAPI](https://pokeapi.co/) e evoluindo de um Console App até uma aplicação web interativa com visual de Tamagotchi.

</div>

---

## 📋 Índice

- [Sobre o Projeto](#-sobre-o-projeto)
- [Demonstração](#-demonstração)
- [Funcionalidades](#-funcionalidades)
- [Tecnologias](#-tecnologias)
- [Estrutura do Projeto](#-estrutura-do-projeto)
- [Pré-requisitos](#-pré-requisitos)
- [Como Rodar](#-como-rodar)
- [Arquitetura](#-arquitetura)
- [API Utilizada](#-api-utilizada)
- [Evolução do Projeto](#-evolução-do-projeto)
- [Conceitos Aplicados](#-conceitos-aplicados)

---

## 📖 Sobre o Projeto

O **PokéTama** é um jogo de bichinho virtual inspirado no Tamagotchi, onde o jogador pode adotar Pokémons, dar nomes a eles e cuidar de suas necessidades como alimentação, humor, energia e saúde.

O projeto foi desenvolvido de forma incremental em etapas, partindo de um simples `Console.WriteLine` até uma aplicação web moderna em **Blazor Server**, consumindo dados em tempo real da **PokéAPI**.

---

## 🎮 Demonstração

```
┌─────────────────────────────────┐
│         👾 POKÉTAMA             │
│                                 │
│    ╔═══════════════════╗        │
│    ║  [sprite pikachu] ║        │
│    ║  Bem-vindo!       ║        │
│    ║  Seu nome: ____   ║        │
│    ║  [ ▶ INICIAR ]    ║        │
│    ╚═══════════════════╝        │
│       ●        🔴       ●       │
└─────────────────────────────────┘
```

### Fluxo do Jogo

```
Tela Inicial → Digita o nome
     ↓
Sorteio de 3 Pokémons aleatórios (de toda a PokéAPI)
     ↓
Escolhe 1 Pokémon → Dá um nome
     ↓
Tela de Mascotes → Alimentar / Brincar / Dormir / Medicar
     ↓
Loja de Itens → Usa itens para recuperar atributos
```

---

## ✨ Funcionalidades

- 🎲 **Sorteio aleatório** de 3 Pokémons de toda a PokéAPI (mais de 1000 espécies)
- 🥚 **Adoção de mascotes** com nome personalizado pelo jogador
- 💗 **Sistema de atributos** — Alimentação, Humor, Energia e Saúde (0 a 10)
- 🎮 **Interações** — Alimentar, Brincar, Dormir e Medicar
- 🎒 **Loja de itens** consumida em tempo real da PokéAPI
- ⚠️ **Alerta de estado crítico** quando o mascote precisa de cuidados
- 🖼️ **Sprites reais** dos Pokémons direto da PokéAPI
- 🎨 **Visual Tamagotchi** com fonte pixelada, animações e tela verde
- 🔄 **Ressortear** — gera 3 novos Pokémons aleatórios a qualquer momento

---

## 🛠️ Tecnologias

| Tecnologia | Versão | Uso |
|---|---|---|
| C# | 12 | Linguagem principal |
| .NET | 8.0 | Framework |
| Blazor Server | 8.0 | Interface web interativa |
| RestSharp | 112.x | Requisições HTTP à PokéAPI |
| System.Text.Json | Built-in | Deserialização de JSON |
| Press Start 2P | Google Fonts | Fonte pixelada |
| PokéAPI | v2 | Dados dos Pokémons e itens |

---

## 📁 Estrutura do Projeto

```
PokeBlazor/
│
├── 📂 Components/
│   ├── 📂 Layout/
│   │   ├── MainLayout.razor     # Layout base com navbar
│   │   └── NavMenu.razor        # Barra de navegação
│   ├── 📂 Pages/
│   │   ├── Home.razor           # Tela inicial + menu principal
│   │   ├── Adocao.razor         # Escolha e adoção de Pokémons
│   │   ├── MeusMascotes.razor   # Mascotes adotados + interações
│   │   └── Itens.razor          # Loja de itens
│   ├── App.razor                # Componente raiz
│   └── Routes.razor             # Configuração de rotas
│
├── 📂 Models/
│   ├── Mascote.cs               # Classes do JSON da PokéAPI
│   └── MascoteVivo.cs           # Estado e comportamento do mascote
│
├── 📂 Services/
│   ├── PokeService.cs           # Comunicação com a PokéAPI
│   └── GameState.cs             # Estado global do jogo (Singleton)
│
├── 📂 wwwroot/                  # Arquivos estáticos
├── Program.cs                   # Configuração e injeção de dependências
└── PokeBlazor.csproj            # Configuração do projeto
```

---

## ✅ Pré-requisitos

Antes de começar, você precisará ter instalado:

- [**.NET 8 SDK**](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior
- [**VS Code**](https://code.visualstudio.com/) com as extensões:
  - C# Dev Kit
  - Razor Language Services
- Conexão com a internet (para consumir a PokéAPI)

Verifique sua versão do .NET:
```bash
dotnet --version
# Deve retornar 8.x.x
```

---

## 🚀 Como Rodar

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/poketama.git
cd poketama
```

### 2. Instale as dependências

```bash
dotnet restore
dotnet add package RestSharp
```

### 3. Execute o projeto

```bash
# Modo desenvolvimento com hot reload
dotnet watch

# Ou apenas rodar
dotnet run
```

### 4. Acesse no navegador

```
http://localhost:5000
```

---

## 🏗️ Arquitetura

### Fluxo de Dados

```
Blazor Page (@inject)
      │
      ▼
PokeService                    GameState
  BuscarMascoteAsync()    ←→   MascotesAdotados
  SortearPokemonsAsync()        PokemonsSorteados
  BuscarTodosItensAsync()       NomeJogador
      │
      ▼
  RestSharp (HTTP GET)
      │
      ▼
PokéAPI (JSON)
      │
      ▼
JsonSerializer.Deserialize<T>()
      │
      ▼
  Mascote / Item (Models)
```

### Padrão de Injeção de Dependência

```csharp
// Program.cs — registrados como Singleton (compartilhados entre páginas)
builder.Services.AddSingleton<PokeService>();
builder.Services.AddSingleton<GameState>();

// Nas páginas Blazor — injetados automaticamente
@inject PokeService PokeService
@inject GameState GameState
```

### Atributos do MascoteVivo

```
Alimentação  0 ══════════ 10
              fome        satisfeito

Humor        0 ══════════ 10
              triste      feliz

Energia      0 ══════════ 10
              exausto     animado

Saúde        0 ══════════ 10
              doente      saudável
```

### Tabela de Interações

| Ação | Alimentação | Humor | Energia | Saúde |
|---|---|---|---|---|
| 🍖 Alimentar | +3 | — | -1 | +1 |
| 🎾 Brincar | -1 | +3 | -2 | — |
| 😴 Dormir | — | -1 | +4 | — |
| 💊 Medicar | — | -2 | — | +4 |
| ✨ Usar Item | +2 | — | — | +2 |

> Todos os valores são limitados entre 0 e 10 pelo método `Clamp()`

---

## 🌐 API Utilizada

### PokéAPI — https://pokeapi.co/

API REST pública, gratuita e sem autenticação.

#### Endpoints consumidos

| Endpoint | Descrição |
|---|---|
| `GET /pokemon?limit=10000` | Lista todos os Pokémons disponíveis |
| `GET /pokemon/{nome}` | Dados completos de um Pokémon (sprite, altura, peso, habilidades) |
| `GET /item/{nome}` | Dados de um item (nome, custo, efeito) |

#### Exemplo de resposta — `/pokemon/pikachu`

```json
{
  "name": "pikachu",
  "height": 4,
  "weight": 60,
  "base_experience": 112,
  "sprites": {
    "front_default": "https://raw.githubusercontent.com/.../25.png"
  },
  "abilities": [
    {
      "ability": { "name": "static" },
      "is_hidden": false
    }
  ]
}
```

---

## 📈 Evolução do Projeto

O projeto foi desenvolvido em etapas incrementais:

```
Dia 1 — Console App
  └── Requisição GET com RestSharp
  └── Exibir JSON bruto no console

Dia 2 — Parsing de JSON
  └── Classes C# mapeando o JSON
  └── Deserialização com System.Text.Json
  └── Exibição formatada dos dados

Dia 3 — Orientação a Objetos + Menu
  └── Separação em classes e serviços
  └── Menu interativo no console
  └── Navegação entre telas

Dia 4 — Interações com o Mascote
  └── Atributos de vida com valores randômicos
  └── Métodos de interação (Alimentar, Brincar...)
  └── Sistema de itens consumindo a API

Dia 5 — Migração para Blazor
  └── Projeto Blazor Server (.NET 8)
  └── Sprites reais dos Pokémons
  └── Interface web interativa

Dia 6 — Visual Tamagotchi + Sorteio
  └── Fonte pixelada (Press Start 2P)
  └── Animações CSS por humor do mascote
  └── Sorteio de 3 Pokémons de toda a API
  └── Visual de dispositivo Tamagotchi
```

---

## 🧠 Conceitos Aplicados

| Conceito | Onde foi aplicado |
|---|---|
| **HTTP GET** | RestSharp consumindo a PokéAPI |
| **JSON Deserialização** | `System.Text.Json` + atributos `[JsonPropertyName]` |
| **Orientação a Objetos** | Classes `Mascote`, `MascoteVivo`, `PokeService`, `GameState` |
| **Encapsulamento** | Campos `private` com propriedades `public` somente leitura |
| **Async / Await** | Chamadas à API sem bloquear a interface |
| **Injeção de Dependência** | `@inject` no Blazor + `AddSingleton` no `Program.cs` |
| **Estado Global** | `GameState` como Singleton compartilhado entre páginas |
| **Generics** | `List<T>`, `Dictionary<K,V>`, `Task<T>` |
| **Pattern Matching** | `switch` expressions para emojis e cores |
| **ref parameters** | Método `Alterar(ref int atributo, int quantidade)` |
| **Componentes Blazor** | Páginas `.razor` com `@rendermode InteractiveServer` |
| **Reatividade** | `StateHasChanged()` para atualizar a UI |

---

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

<div align="center">
  Feito com 💚 e muito ☕ durante o desafio prático de C#
</div>
