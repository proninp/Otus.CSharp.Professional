namespace HomeWork._05.Settings;

/// <summary>
/// Настройки игры
/// </summary>
public sealed class GameSettings
{
    /// <summary>
    /// Количество попыток для угадывания
    /// </summary>
    public int GuessAttempts  { get; set; }
    
    /// <summary>
    /// Максимальное число диапазона
    /// </summary>
    public int MaxNumber { get; set; }
    
    /// <summary>
    /// Минимальное число диапазона
    /// </summary>
    public int MinNumber  { get; set; }
    
    /// <summary>
    /// Дополнительные попытки сверх оптимального количества
    /// </summary>
    public int AdditionalTriesCountLimiter { get; set; }
    
    /// <summary>
    /// Проверить корректность настроек
    /// </summary>
    /// <exception cref="InvalidOperationException">Если настройки некорректны</exception>
    public void Validate()
    {
        if (MinNumber >= MaxNumber)
            throw new InvalidOperationException("Минимальное число должно быть меньше максимального");
            
        if (GuessAttempts <= 0)
            throw new InvalidOperationException("Количество попыток должно быть положительным");
            
        if (AdditionalTriesCountLimiter < 0)
            throw new InvalidOperationException("Дополнительные попытки не могут быть отрицательными");
    }
}