using HomeWork._05.Core.Models;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Core.Abstractions.Players;

/// <summary>
/// Базовый класс для игроков с общей функциональностью
/// </summary>
public abstract class PlayerBase
{
    /// <summary>
    /// Создать базового игрока
    /// </summary>
    /// <param name="settings">Настройки игры</param>
    protected PlayerBase(IOptions<GameSettings> settings)
    {
        ArgumentNullException.ThrowIfNull(settings);
        var gameSettings = settings.Value;
        GameRange = new NumberRange(gameSettings.MinNumber, gameSettings.MaxNumber);
    }
    
    /// <summary>
    /// Диапазон чисел для игры
    /// </summary>
    protected NumberRange GameRange { get; private set; }
    
    /// <summary>
    /// Обновить диапазон чисел
    /// </summary>
    /// <param name="newRange">Новый диапазон</param>
    protected void UpdateRange(NumberRange newRange)
    {
        ArgumentNullException.ThrowIfNull(newRange);
        GameRange = newRange;
    }
}