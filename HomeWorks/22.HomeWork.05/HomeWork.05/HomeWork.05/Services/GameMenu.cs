using HomeWork._05.Abstractions;

namespace HomeWork._05.Services;

public class GameMenu(IGameEngine gameEngine, IPlayerInterface ui) : IGameMenu
{
    private readonly IGameEngine _gameEngine = gameEngine;
    private readonly IPlayerInterface _ui = ui;
    
    private const string StratNewGame = "Начать игру";
    private const string Instructions = "Интрукции"; 
    private const string Exit = "Выход";

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
                    _gameEngine.StartNewGame();
                    break;
                case Instructions:
                    _ui.ShowMessage("Угадайте число т 1 до 100. После каждой попытки получите подсказку.");
                    break;
                case Exit:
                    _ui.ShowMessage("До свидания.");
                    running = false;
                    break;
            }
        }
    }
}