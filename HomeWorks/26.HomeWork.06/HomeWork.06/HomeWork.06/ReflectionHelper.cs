using System.Globalization;
using System.Reflection;

namespace HomeWork._06;

/// <summary>
/// Утилиты для сериализации и десериализации объектов с использованием рефлексии.
/// </summary>
public static class ReflectionHelper
{
    private const string ElementsSeparator = ", ";
    
    private const string PairsSeparator = ": ";
    
    private const string NullLiteral = "null";
    
    private static readonly BindingFlags PropertyFlags = 
        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
    
    /// <summary>
    /// Сериализует объект в строку, включая значения всех его свойств (public и non-public).
    /// </summary>
    /// <typeparam name="T">Тип сериализуемого объекта.</typeparam>
    /// <param name="instance">Экземпляр объекта для сериализации.</param>
    /// <returns>Строковое представление объекта.</returns>
    /// <exception cref="ArgumentNullException">Если объект равен null.</exception>
    public static string Serialize<T>(T instance) where T : class
    {
        ArgumentNullException.ThrowIfNull(instance);
        
        var type = typeof(T);
        var properties = type.GetProperties(PropertyFlags);
        
        var serializedPairs = new List<string>(properties.Length);
        
        foreach (var property in properties)
        {
            var value = property.GetValue(instance);
            var valueString = value?.ToString() ?? NullLiteral;
            serializedPairs.Add($"{property.Name}{PairsSeparator}{valueString}");
        }

        return $"{{{string.Join(ElementsSeparator, serializedPairs)}}}";
    }

    /// <summary>
    /// Десериализует строку в новый экземпляр указанного типа, устанавливая значения свойств.
    /// </summary>
    /// <typeparam name="T">Тип объекта для десериализации.</typeparam>
    /// <param name="serialized">Строка, содержащая сериализованные данные.</param>
    /// <returns>Экземпляр объекта с заполненными свойствами.</returns>
    /// <exception cref="ArgumentException">Если строка пуста или содержит неверный формат.</exception>
    public static T Deserialize<T>(string serialized) where T : class, new()
    {
        if (string.IsNullOrWhiteSpace(serialized))
            throw new ArgumentException("Строка не может быть пустой", nameof(serialized));
        
        var instance = new T();
        var type = typeof(T);
        var properties = type.GetProperties(PropertyFlags)
            .Where(p => p.CanWrite)
            .ToDictionary(p => p.Name, p => p);

        var content = serialized.Trim('{', '}');
        if (string.IsNullOrEmpty(content))
            return instance;
        
        var pairs = content
            .Split(ElementsSeparator, StringSplitOptions.RemoveEmptyEntries)
            .Select(KeyValuePairSelector)
            .Where(kvp => kvp.HasValue)
            .ToDictionary(kvp => kvp!.Value.Key, kvp => kvp!.Value.Value);

        foreach (var (key, value) in pairs)
        {
            if (!properties.TryGetValue(key, out var property))
                continue;
            try
            {
                var convertedValue = ConvertValue(value, property.PropertyType);
                property.SetValue(instance, convertedValue);
            }
            catch (Exception e) when (e is InvalidCastException or FormatException or OverflowException)
            {
                Console.WriteLine($"Не удалось преобразовать значение '{value}' для свойства '{key}': {e.Message}");
            }
        }
        return instance;
    }

    /// <summary>
    /// Разбирает пару "ключ: значение" из строки.
    /// </summary>
    /// <param name="pair">Строка с одной парой ключ-значение.</param>
    /// <returns>Пара ключ и значение, либо null, если формат некорректный.</returns>
    private static (string Key, string Value)? KeyValuePairSelector(string pair)
    {
        var separatorIndex = pair.IndexOf(PairsSeparator, StringComparison.Ordinal);
        if (separatorIndex == -1)
            return null;
        
        var key = pair[..separatorIndex].Trim();
        var value = pair[(separatorIndex + PairsSeparator.Length)..].Trim();
        
        return (key, value);
    }

    /// <summary>
    /// Преобразует строковое значение к указанному типу.
    /// </summary>
    /// <param name="value">Строковое значение.</param>
    /// <param name="targetType">Тип, к которому нужно привести значение.</param>
    /// <returns>Преобразованное значение нужного типа, либо null.</returns>
    private static object? ConvertValue(string value, Type targetType)
    {
        if (value == NullLiteral)
            return null;
        
        var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

        return underlyingType.Name switch
        {
            nameof(String) =>  value,
            nameof(Char) when value.Length == 1 => value[0],
            nameof(Boolean) => bool.Parse(value),
            _ => Convert.ChangeType(value, underlyingType, CultureInfo.InvariantCulture)
        };
    }
}