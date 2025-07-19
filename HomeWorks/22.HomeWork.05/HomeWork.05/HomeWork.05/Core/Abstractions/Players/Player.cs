namespace HomeWork._05.Core.Abstractions.Players;

public abstract class Player(int minNumber, int maxNumber) : IPlayer
{
    public bool IsShowUiNotifications { get; protected set; }

    public int MinNumber { get; set; } = minNumber;

    public int MaxNumber { get; set; } = maxNumber;
    
    public abstract int TryGuessNumber();

    public abstract int RiddleTheNumber();
}