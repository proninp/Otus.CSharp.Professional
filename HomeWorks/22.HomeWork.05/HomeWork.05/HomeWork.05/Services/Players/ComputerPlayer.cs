using HomeWork._05.Abstractions.Models;
using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Core.Abstractions.Utils;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Services.Players;

public class ComputerPlayer(
    IOptions<GameSettings> settings,
    INumberGenerator numberGenerator,
    INumberGuesser numberGuesser,
    IPlayerInterface ui)
    : Player(settings)
{
    private int _lastGuessedNumber = 0;

    public override int TryGuessNumber()
    {
        Task.Delay(1000).Wait(); // Имитация задержки для "размышления" компьютера
        _lastGuessedNumber = numberGuesser.Guess(MinNumber, MaxNumber);
        return _lastGuessedNumber;
    }

    public override int RiddleTheNumber() =>
        numberGenerator.GetRandomNumber(MinNumber, MaxNumber);

    public override void Hint(GuessOutcome outcome)
    {
        switch (outcome)
        {
            case GuessOutcome.TooHigh:
                MaxNumber = _lastGuessedNumber - 1;
                break;
            case GuessOutcome.TooLow:
                MinNumber = _lastGuessedNumber + 1;
                break;
            case GuessOutcome.Correct:
            default:
                return;
        }
        ui.ShowMessage(
            $"Компьютер предположил, что загаданно число: {_lastGuessedNumber}, но не угадал и получил подсказку: " +
            $"число должно быть в диапазоне от {MinNumber} до {MaxNumber}.");
    }
}