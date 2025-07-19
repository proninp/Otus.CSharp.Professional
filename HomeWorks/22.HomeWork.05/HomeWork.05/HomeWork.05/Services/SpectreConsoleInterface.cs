using HomeWork._05.Abstractions;
using Spectre.Console;

namespace HomeWork._05.Services;

public class SpectreConsoleInterface : IPlayerInterface
{
    public void ShowMessage(string message)
    {
        AnsiConsole.MarkupLine($"[green]{message}[/]");
    }

    public int PromptForNumber(string prompt, int min, int max)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<int>($"[cyan]{prompt}[/]")
                .ValidationErrorMessage("[red]Введите корректное число[/]")
                .Validate(n => n >= min && n <= max));
    }

    public string PromptForMenu(params string[] options)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold yellow]Выберите действие:[/]")
                .AddChoices(options));
    }

    public void WaitForKey()
    {
        AnsiConsole.MarkupLine("[grey]Нажмите любую клавишу...[/]");
        Console.ReadKey();
    }
}