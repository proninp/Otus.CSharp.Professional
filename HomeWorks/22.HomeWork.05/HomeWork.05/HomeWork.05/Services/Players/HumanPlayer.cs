using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Core.Models;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Services.Players;

/// <summary>
/// Человеческий игрок, взаимодействующий через пользовательский интерфейс
/// </summary>
public sealed class HumanPlayer(
    IOptions<GameSettings> settings,
    IPlayerInterface ui
) : PlayerBase(settings), IPlayer
{
    private readonly GameSettings _settings = settings.Value;

    /// <summary>
    /// Запросить у пользователя число для угадывания
    /// </summary>
    /// <returns>Число, введенное пользователем</returns>
    public int GuessNumber()
    {
        return ui.PromptForNumber($"Угадайте число от {GameRange.Min} до {GameRange.Max}:",
            GameRange.Min,
            GameRange.Max);
    }

    /// <summary>
    /// Запросить у пользователя число для загадывания
    /// </summary>
    /// <returns>Число, введенное пользователем</returns>
    public int RiddleNumber() =>
        ui.PromptForNumber($"Загадайте число от {GameRange.Min} до {GameRange.Max}:",
            GameRange.Min,
            GameRange.Max);

    /// <summary>
    /// Показать пользователю подсказку о результате угадывания
    /// </summary>
    /// <param name="outcome">Результат попытки угадывания</param>
    public void ReceiveHint(GuessOutcome outcome)
    {
        var message = outcome switch
        {
            GuessOutcome.TooHigh => "Загаданное число меньше. Попробуйте еще раз.",
            GuessOutcome.TooLow => "Загаданное число больше. Попробуйте еще раз.",
            GuessOutcome.Correct => "Поздравляем! Вы отгадали число!",
            _ => throw new ArgumentOutOfRangeException(nameof(outcome),
                $"Неподдерживаемый результат угадывания: {outcome}")
        };
        ui.ShowMessage(message);
    }
}