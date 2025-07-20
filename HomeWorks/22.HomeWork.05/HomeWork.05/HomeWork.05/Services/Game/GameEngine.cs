using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Core.Models;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Services.Game;

/// <summary>
/// Улучшенный движок игры с разделенными ответственностями
/// </summary>
public class GameEngine : IGameEngine
{
    private readonly GameSettings _settings;
    private readonly IPlayerFactory _playerFactory;
    private readonly IPlayerInterface _ui;
    private readonly IRoundManager _roundManager;
    private readonly IGameCalculator _gameCalculator;

    /// <summary>
    /// Создать движок игры
    /// </summary>
    /// <param name="settings">Настройки игры</param>
    /// <param name="playerFactory">Фабрика игроков</param>
    /// <param name="ui">Интерфейс пользователя</param>
    /// <param name="roundManager">Менеджер раундов</param>
    /// <param name="calculator">Калькулятор игровых параметров</param>
    public GameEngine(
        IOptions<GameSettings> settings,
        IPlayerFactory playerFactory,
        IPlayerInterface ui,
        IRoundManager roundManager,
        IGameCalculator calculator)
    {
        _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
        _ui = ui ?? throw new ArgumentNullException(nameof(ui));
        _roundManager = roundManager ?? throw new ArgumentNullException(nameof(roundManager));
        _gameCalculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
    }

    /// <summary>
    /// Запустить игру в указанном режиме
    /// </summary>
    /// <param name="mode">Режим игры</param>
    public void Play(GameMode mode = GameMode.ComputerAsRiddlerVsPlayer)
    {
        var riddler = _playerFactory.CreateRiddler(mode);
        var guesser = _playerFactory.CreateGuesser(mode);

        var maxAttempts = _gameCalculator.CalculateMaxAttempts(_settings.MinNumber, _settings.MaxNumber)
                          + _settings.AdditionalTriesCountLimiter;
        var roundResult = _roundManager.PlayRound(riddler, guesser, maxAttempts);
        _ui.ShowMessage(
            roundResult.IsSuccess
                ? $"Поздравляем! Число {roundResult.SecretNumber} угадано за {roundResult.AttemptsUsed} попыток!"
                : $"Число {roundResult.SecretNumber} не удалось угадать. Количество попыток: {maxAttempts}.");
    }
}