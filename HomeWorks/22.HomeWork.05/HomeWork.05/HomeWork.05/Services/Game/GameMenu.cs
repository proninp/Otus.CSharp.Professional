using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Core.Models;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Services.Game;

/// <summary>
/// Реализация главного меню игры "Угадай число"
/// </summary>
/// <remarks>
/// Предоставляет пользователю:
/// - Возможность начать новую игру в разных режимах
/// - Просмотреть инструкции
/// - Выйти из приложения
/// </remarks>
/// <param name="gameEngine">Движок игры для управления игровыми сессиями</param>
/// <param name="ui">Интерфейс пользователя для ввода/вывода</param>
/// <param name="settings">Настройки игры (диапазон чисел)</param>
public sealed class GameMenu(IGameEngine gameEngine, IPlayerInterface ui, IOptions<GameSettings> settings) : IGameMenu
{
    private readonly GameSettings _settings = settings.Value;

    private const string StratNewGame = "Начать игру";
    private const string Instructions = "Интрукции";
    private const string Exit = "Выход";

    private const string ComputerAsRiddlerVsPlayer = "Загадывает компьютер, отгадывает игрок";
    private const string PlayerAsRiddlerVsComputer = "Загадывает игрок, отгадывает компьютер";
    private const string PlayerVsPlayer = "Игрок против игрока";

    /// <summary>
    /// Запускает и управляет главным циклом меню
    /// </summary>
    /// <remarks>
    /// Цикл продолжается до выбора пользователем пункта "Выход".
    /// При каждом проходе очищает консоль и отображает главное меню.
    /// </remarks>
    public void Run()
    {
        var running = true;
        while (running)
        {
            Console.Clear();
            var choices = ui.PromptForMenu(StratNewGame, Instructions, Exit);
            switch (choices)
            {
                case StratNewGame:
                    StartNewGame();
                    ui.WaitForKey();
                    break;
                case Instructions:
                    ui.ShowMessage(
                        $"Угадайте число от {_settings.MinNumber} до {_settings.MaxNumber}. После каждой попытки получите подсказку.");
                    ui.WaitForKey();
                    break;
                case Exit:
                    ui.ShowMessage("До свидания.");
                    running = false;
                    break;
            }
        }
    }

    /// <summary>
    /// Обрабатывает запуск новой игры
    /// </summary>
    /// <remarks>
    /// Запрашивает у пользователя выбор режима игры и запускает соответствующий режим через игровой движок.
    /// Поддерживает три режима игры:
    /// 1. Компьютер загадывает - игрок угадывает
    /// 2. Игрок загадывает - компьютер угадывает
    /// 3. Игрок против игрока
    /// </remarks>
    private void StartNewGame()
    {
        var gameModeChoice =
            ui.PromptForGameMode(ComputerAsRiddlerVsPlayer, PlayerAsRiddlerVsComputer, PlayerVsPlayer);
        var gameMode = gameModeChoice switch
        {
            ComputerAsRiddlerVsPlayer => GameMode.ComputerAsRiddlerVsPlayer,
            PlayerAsRiddlerVsComputer => GameMode.PlayerAsRiddlerVsComputer,
            PlayerVsPlayer => GameMode.PlayerVsPlayer,
            _ => throw new ArgumentOutOfRangeException(nameof(gameModeChoice),
                $"Неподдерживаемый режим игры: {gameModeChoice}")
        };
        gameEngine.Play(gameMode);
    }
}