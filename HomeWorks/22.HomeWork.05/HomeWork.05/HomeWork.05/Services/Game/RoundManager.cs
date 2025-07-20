using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Core.Models;

namespace HomeWork._05.Services.Game;

/// <summary>
/// Менеджер игровых раундов
/// </summary>
public sealed class RoundManager : IRoundManager
{
    private readonly IGameResultEvaluator _evaluator;
    private readonly IPlayerInterface _ui;
    
    
    /// <summary>
    /// Создать менеджер раундов
    /// </summary>
    /// <param name="evaluator">Оценщик результатов игры</param>
    /// <param name="ui">Интерфейс пользователя</param>
    public RoundManager(IGameResultEvaluator evaluator, IPlayerInterface ui)
    {
        _evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator));
        _ui = ui ?? throw new ArgumentNullException(nameof(ui));
    }
    
    /// <summary>
    /// Провести раунд игры между загадывающим и угадывающим
    /// </summary>
    /// <param name="riddler">Игрок, который загадывает число</param>
    /// <param name="guesser">Игрок, который угадывает число</param>
    /// <param name="maxAttempts">Максимальное количество попыток</param>
    /// <returns>Результат раунда</returns>
    public GameRoundResult PlayRound(INumberRiddler riddler, INumberGuesser guesser, int maxAttempts)
    {
        ArgumentNullException.ThrowIfNull(riddler);
        ArgumentNullException.ThrowIfNull(guesser);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxAttempts);
        
        var secretNumber = riddler.RiddleNumber();
        _ui.ShowMessage("Число загадано. Начинаем угадывать!");
        
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            var guess = guesser.GuessNumber();
            var result = _evaluator.Evaluate(secretNumber, guess);

            if (result.IsCorrect)
            {
                return new GameRoundResult(secretNumber, attempt, true);
            }

            guesser.ReceiveHint(result.Outcome);
        }
        return new GameRoundResult(secretNumber, maxAttempts, false);
    }
}