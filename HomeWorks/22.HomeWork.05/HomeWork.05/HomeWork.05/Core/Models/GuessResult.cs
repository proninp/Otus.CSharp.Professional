namespace HomeWork._05.Abstractions.Models;

public class GuessResult(GuessOutcome outcome)
{
    public GuessOutcome Outcome { get; set; } = outcome;
    
    public bool IsCorrect => Outcome == GuessOutcome.Correct;
}