using HomeWork._05.Core.Abstractions.UI;
using Spectre.Console;

namespace HomeWork._05.Services.UI;

/// <summary>
/// Реализация интерфейса игрока с использованием Spectre.Console
/// </summary>
public sealed class SpectreConsoleInterface : IPlayerInterface
{
    /// <summary>
    /// Отображает цветное сообщение игроку
    /// </summary>
    /// <param name="message">Текст сообщения (поддерживается Markup Spectre.Console)</param>
    public void ShowMessage(string message)
    {
        AnsiConsole.MarkupLine($"[green]{message}[/]");
    }

    /// <summary>
    /// Запрашивает число с валидацией диапазона
    /// </summary>
    /// <param name="prompt">Текст запроса (поддерживается Markup)</param>
    /// <param name="min">Минимальное значение (включительно)</param>
    /// <param name="max">Максимальное значение (включительно)</param>
    /// <returns>Введенное число, гарантированно находящееся в диапазоне [min, max]</returns>
    public int PromptForNumber(string prompt, int min, int max)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<int>($"[cyan]{prompt}[/]")
                .ValidationErrorMessage("[red]Введите корректное число[/]")
                .Validate(n => n >= min && n <= max));
    }

    /// <summary>
    /// Отображает интерактивное меню выбора действия
    /// </summary>
    /// <param name="options">Варианты выбора (поддерживается Markup)</param>
    /// <returns>Выбранный вариант</returns>
    public string PromptForMenu(params string[] options)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold yellow]Выберите действие:[/]")
                .AddChoices(options));
    }

    /// <summary>
    /// Отображает интерактивное меню выбора режима игры
    /// </summary>
    /// <param name="options">Доступные режимы игры (поддерживается Markup)</param>
    /// <returns>Выбранный режим игры</returns>
    public string PromptForGameMode(params string[] options)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold yellow]Выберите режим игры:[/]")
                .AddChoices(options));
    }

    /// <summary>
    /// Приостанавливает выполнение до нажатия любой клавиши
    /// </summary>
    /// <param name="isShowMessage">Показывать ли подсказку (по умолчанию true)</param>
    public void WaitForKey(bool isShowMessage = true)
    {
        if (isShowMessage)
        {
            AnsiConsole.MarkupLine("[grey]Нажмите любую клавишу...[/]");
        }
        Console.ReadKey();
    }
}