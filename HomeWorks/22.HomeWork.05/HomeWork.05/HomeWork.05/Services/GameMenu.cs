using HomeWork._05.Abstractions.Models;
using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Services;

public class GameMenu(IGameEngine gameEngine, IPlayerInterface ui, IOptions<GameSettings> settings) : IGameMenu
{
    private readonly IGameEngine _gameEngine = gameEngine;
    private readonly IPlayerInterface _ui = ui;
    private readonly GameSettings _settings = settings.Value;

    private const string StratNewGame = "Начать игру";
    private const string Instructions = "Интрукции";
    private const string Exit = "Выход";

    private const string PlayerVsComputer = "Игрок против компьютера";
    private const string PlayerVsPlayer = "Игрок против игрока";

    public void Run()
    {
        var running = true;
        while (running)
        {
            Console.Clear();
            var choices = _ui.PromptForMenu(StratNewGame, Instructions, Exit);
            switch (choices)
            {
                case StratNewGame:
                    StartNewGame();
                    break;
                case Instructions:
                    _ui.ShowMessage(
                        $"Угадайте число т {_settings.MinNumber} до {_settings.MaxNumber}. После каждой попытки получите подсказку.");
                    break;
                case Exit:
                    _ui.ShowMessage("До свидания.");
                    running = false;
                    break;
            }
        }
    }

    private void StartNewGame()
    {
        var gameModeChoice = _ui.PromptForGameMode(PlayerVsComputer, PlayerVsPlayer);
        var gameMode = gameModeChoice switch
        {
            PlayerVsComputer => GameMode.PlayerVsComputer,
            PlayerVsPlayer => GameMode.PlayerVsPlayer,
            _ => throw new ArgumentOutOfRangeException(nameof(gameModeChoice),
                $"Неподдерживаемый режим игры: {gameModeChoice}")
        };
        _gameEngine.Play(gameMode);
    }
}