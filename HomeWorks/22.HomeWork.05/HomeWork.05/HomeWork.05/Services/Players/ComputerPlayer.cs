using Microsoft.Extensions.Options;
using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Core.Abstractions.Utils;
using HomeWork._05.Core.Models;
using HomeWork._05.Settings;

namespace HomeWork._05.Services.Players;

public sealed class ComputerPlayer(
    IOptions<GameSettings> settings,
    INumberGenerator numberGenerator,
    IPlayerInterface ui)
    : PlayerBase(settings), IPlayer
{
    private int _lastGuess;

    /// <summary>
    /// Угадать число, используя стратегию бинарного поиска
    /// </summary>
    /// <returns>Предполагаемое число</returns>
    public int GuessNumber()
    {
        Task.Delay(1000).Wait(); // Имитация задержки для "размышления" компьютера
        _lastGuess = (GameRange.Min + GameRange.Max) / 2;
        ui.ShowMessage($"Компьютер предполагает число: {_lastGuess}");
        
        return _lastGuess;
    }
    
    /// <summary>
    /// Загадать случайное число в диапазоне
    /// </summary>
    /// <returns>Загаданное число</returns>
    public int RiddleNumber() =>
        numberGenerator.GetRandomNumber(GameRange.Min, GameRange.Max);

    /// <summary>
    /// Получить подсказку и скорректировать стратегию поиска
    /// </summary>
    /// <param name="outcome">Результат предыдущей попытки</param>
    public void ReceiveHint(GuessOutcome outcome)
    {
        var newRange = outcome switch
        {
            GuessOutcome.TooHigh => GameRange.WithMax(_lastGuess - 1),
            GuessOutcome.TooLow => GameRange.WithMin(_lastGuess + 1),
            GuessOutcome.Correct => GameRange,
            _ => throw new ArgumentOutOfRangeException(nameof(outcome), 
                $"Неизвестный результат угадывания: {outcome}")
        };
        if (outcome != GuessOutcome.Correct)
        {
            UpdateRange(newRange);
            ui.ShowMessage(
                $"Компьютер предположил, что загаданно число: {_lastGuess}, но не угадал и получил подсказку: " +
                $"число должно быть в диапазоне от {GameRange.Min} до {GameRange.Max}.");
        }
    }
}