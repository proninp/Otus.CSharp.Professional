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
    private GameMode _mode = GameMode.ComputerAsRiddlerVsPlayer;

    private int _triesCount;

    private Player? _player1;
    private Player? _player2;

    public void Play(GameMode mode)
    {
        Initialize(mode);

        if (_player1 is null || _player2 is null)
            throw new NullReferenceException("Игроки не были созданы. Проверьте фабрику игроков.");

        var riddledNumber = Riddle();
        var maxGuessesCount = GetMaxDepthToGuessNumber() + _settings.AdditionalTriesCountLimiter;

        PlayRound(riddledNumber, maxGuessesCount);
    }

    private void Initialize(GameMode mode)
    {
        _mode = mode;
        _triesCount = 0;
        (_player1, _player2) = playerFactory.CreatePlayers(_mode);
    }

    private int Riddle()
    {
        var riddledNumber = _player1!.RiddleTheNumber();
        ui.ShowMessage("Игрок 1 загадал число. Игрок 2, попробуй отгадать его!");
        return riddledNumber;
    }

    private void PlayRound(int riddledNumber, int maxGuessesCount)
    {
        while (_triesCount < maxGuessesCount)
        {
            _triesCount++;
            var guessedNumber = _player2!.TryGuessNumber();
            var guessResult = evaluator.Evaluate(riddledNumber, guessedNumber);

            if (guessResult.IsCorrect)
            {
                ui.ShowMessage(
                    $"Поздравляем! Игрок 2 отгадал число {riddledNumber}. Количество попыток: {_triesCount}.");
                return;
            }

            _player2.Hint(guessResult.Outcome);
        }

        ui.ShowMessage(
            $"К сожалению, игрок 2 не смог отгадать число {riddledNumber}. Количество попыток: {_triesCount}.");
    }

    private int GetMaxDepthToGuessNumber() =>
        (int)Math.Ceiling(Math.Log2(_settings.MaxNumber - _settings.MinNumber + 1));
}