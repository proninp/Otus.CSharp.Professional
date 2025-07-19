using HomeWork._05.Abstractions.Models;
using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.Utils;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Services;

public class GameEngine(
    IOptions<GameSettings> settings,
    INumberGenerator numberGenerator,
    INumberGuesser numberGuesser,
    IPlayerFactory playerFactory)
    : IGameEngine
{
    private readonly GameSettings _settings = settings.Value;
    private readonly IPlayerFactory _playerFactory = playerFactory;
    private readonly INumberGenerator _numberGenerator = numberGenerator;
    private readonly INumberGuesser _numberGuesser = numberGuesser;
    private GameMode _mode = GameMode.PlayerVsComputer;
    
    private int _triesCount;

    private Player? _player1;
    private Player? _player2;

    public bool Play(GameMode mode)
    {
        
        
        if (_player1 is null || _player2 is null)
            throw new NullReferenceException("Игроки не были созданы. Проверьте фабрику игроков.");

        var riddledNumber = _player1.RiddleTheNumber();
        
        

        return false;
    }

    private void Initialize(GameMode mode)
    {
        _mode = mode;
        (_player1, _player2) = _playerFactory.CreatePlayers(_mode);
        
    }
}