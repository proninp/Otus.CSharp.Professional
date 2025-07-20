namespace HomeWork._05.Core.Abstractions.UI;

/// <summary>
/// Интерфейс для взаимодействия с игроком через пользовательский интерфейс
/// </summary>
public interface IPlayerInterface
{
    /// <summary>
    /// Отображает сообщение игроку
    /// </summary>
    /// <param name="message">Текст сообщения для отображения</param>
    void ShowMessage(string message);
    
    /// <summary>
    /// Запрашивает у игрока число в указанном диапазоне
    /// </summary>
    /// <param name="prompt">Текст подсказки для игрока</param>
    /// <param name="min">Минимальное допустимое значение</param>
    /// <param name="max">Максимальное допустимое значение</param>
    /// <returns>Введенное игроком число</returns>
    int PromptForNumber(string prompt, int min, int max);
    
    /// <summary>
    /// Отображает меню выбора и возвращает выбранный вариант
    /// </summary>
    /// <param name="options">Доступные варианты выбора</param>
    /// <returns>Выбранный игроком вариант</returns>
    string PromptForMenu(params string[] options);
    
    /// <summary>
    /// Отображает меню выбора режима игры
    /// </summary>
    /// <param name="options">Доступные режимы игры</param>
    /// <returns>Выбранный режим игры</returns>
    string PromptForGameMode(params string[] options);
    
    /// <summary>
    /// Ожидает нажатия любой клавиши игроком
    /// </summary>
    /// <param name="isShowMessage">Показывать ли сообщение о необходимости нажать клавишу (по умолчанию true)</param>
    void WaitForKey(bool isShowMessage = true);
}