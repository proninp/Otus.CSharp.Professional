namespace HomeWork._05.Abstractions;

public interface IPlayerInterface
{
    void ShowMessage(string message);
    
    int PromptForNumber(string prompt, int min, int max);
    
    string PromptForMenu(params string[] options);

    void WaitForKey();
}