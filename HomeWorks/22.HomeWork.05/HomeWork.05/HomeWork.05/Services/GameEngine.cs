using HomeWork._05.Abstractions;

namespace HomeWork._05.Game;

public class GameEngine : IGameEngine
{
    private int _riddledNumber;
    private int _triesCount;
    public IPlayer? Player1 { get; private set; }
    public IPlayer? Player2 { get; private set; }
    
    public void StartNewGame(IPlayer player1, IPlayer player2)
    {
        Player1 = player1;
        Player2 = player2;
        _riddledNumber = Player1.RiddleTheNumber();
        _triesCount = 0;

        while (!MakeMove())
        {
            Console.WriteLine("Take one more try");
            _triesCount++;
        }
    }

    public void StartNewGame()
    {
        throw new NotImplementedException();
    }

    public bool MakeMove()
    {
        if (Player1 is null || Player2 is null)
            throw new NullReferenceException("Players have not been initialized");
        var guess = Player2.TryGuessNumber();
        if (guess == _riddledNumber)
        {
            Console.WriteLine($"Player wins with {_triesCount} tries");
            return true;
        }
        return false;
    }
}