using HomeWork._05.Abstractions.Models;
using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Services.Game;

public class GameMenu(IGameEngine gameEngine, IPlayerInterface ui, IOptions<GameSettings> settings) : IGameMenu
{
    private readonly GameSettings _settings = settings.Value;

    private const string StratNewGame = "Начать игру";
    private const string Instructions = "Интрукции";
    private const string Exit = "Выход";

    private const string ComputerAsRiddlerVsPlayer = "Загадывает компьютер, отгадывает игрок";
    private const string PlayerAsRiddlerVsComputer = "Загадывает игрок, отгадывает компьютер";
    private const string PlayerVsPlayer = "Игрок против игрока";

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