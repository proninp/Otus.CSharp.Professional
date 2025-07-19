namespace HomeWork._05.Abstractions;

public interface IGameEngine
{
    public IPlayer? Player1 { get; }
    
    public IPlayer? Player2 { get; }
    
    void StartNewGame();
    
    bool MakeMove();
}