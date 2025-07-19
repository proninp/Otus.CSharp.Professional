namespace HomeWork._05.Core.Abstractions.UI;

public interface IPlayerInterface
{
    void ShowMessage(string message);
    
    int PromptForNumber(string prompt, int min, int max);
    
    string PromptForMenu(params string[] options);
    
    string PromptForGameMode(params string[] options);
}