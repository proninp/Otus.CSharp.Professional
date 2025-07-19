using HomeWork._05.Abstractions;

namespace HomeWork._05.Game.Abstractions;

public abstract class Player : IPlayer
{
    public bool IsShowUiNotifications { get; protected set; }
    
    public int MinNumber { get; set; }
    
    public int MaxNumber { get; set; }
    
    public abstract int TryGuessNumber();

    public abstract int RiddleTheNumber();
}