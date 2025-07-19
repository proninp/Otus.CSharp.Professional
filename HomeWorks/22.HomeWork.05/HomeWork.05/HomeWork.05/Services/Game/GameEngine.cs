using HomeWork._05.Abstractions.Models;
using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Services.Game;

public class GameEngine(
    IOptions<GameSettings> settings,
    IPlayerFactory playerFactory,
    IGameResultEvaluator evaluator,
    IPlayerInterface ui
    )
    : IGameEngine
{
    private readonly GameSettings _settings = settings.Value;
    private GameMode _mode = GameMode.PlayerVsComputer;
    
    private int _triesCount;

    private Player? _player1;
    private Player? _player2;

    public void Play(GameMode mode)
    {
        Initialize(mode);
        if (_player1 is null || _player2 is null)
            throw new NullReferenceException("Игроки не были созданы. Проверьте фабрику игроков.");

        var riddledNumber = _player1.RiddleTheNumber();
        ui.ShowMessage("Игрок 1 загадал число. Игрок 2, попробуй отгадать его!");
        
        while (true)
        {
            _triesCount++;
            var guessedNumber = _player2.TryGuessNumber();
            var guessResult = evaluator.Evaluate(riddledNumber, guessedNumber);
            
            if (guessResult.IsCorrect)
            {
                ui.ShowMessage($"Поздравляем! Игрок 2 отгадал число {riddledNumber} за {_triesCount} попыток.");
                return;
            }
            _player2.Hint(guessResult.Outcome);
        }
    }

    private void Initialize(GameMode mode)
    {
        _mode = mode;
        _triesCount = 0;
        (_player1, _player2) = playerFactory.CreatePlayers(_mode);
    }
}