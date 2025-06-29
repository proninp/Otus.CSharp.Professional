namespace HomeWork._04.Interfaces;

/// <summary>
/// Интерфейс для клонирования объектов.
/// </summary>
/// <typeparam name="T">Тип клонируемого объекта.</typeparam>
public interface IMyCloneable<T>
{
    /// <summary>
    /// Создаёт копию текущего объекта.
    /// </summary>
    /// <returns>Клон объекта типа <typeparamref name="T"/>.</returns>
    T Clone();
}