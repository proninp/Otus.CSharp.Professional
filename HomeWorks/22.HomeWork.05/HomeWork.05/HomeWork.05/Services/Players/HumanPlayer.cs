using HomeWork._05.Abstractions.Models;
using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Services.Players;

public class HumanPlayer(
    IOptions<GameSettings> settings,
    IPlayerInterface ui
) : Player(settings)
{
    private readonly GameSettings _settings = settings.Value;

    public override int TryGuessNumber()
    {
        return ui.PromptForNumber($"Угадайте число от {_settings.MinNumber} до {_settings.MaxNumber}:",
            _settings.MinNumber,
            _settings.MaxNumber);
    }

    public override int RiddleTheNumber() =>
        ui.PromptForNumber($"Загадайте число от {_settings.MinNumber} до {_settings.MaxNumber}:",
            _settings.MinNumber,
            _settings.MaxNumber);

    public override void Hint(GuessOutcome outcome)
    {
        switch (outcome)
        {
            case GuessOutcome.TooHigh:
                ui.ShowMessage("Загаданное число меньше. Попробуйте еще раз.");
                break;
            case GuessOutcome.TooLow:
                ui.ShowMessage("Загаданное число больше. Попробуйте еще раз.");
                break;
            case GuessOutcome.Correct:
                ui.ShowMessage("Поздравляем! Вы отгадали число!");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(outcome),
                    $"Неподдерживаемый результат угадывания: {outcome}");
        }
    }
}