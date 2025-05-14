// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

var path = Path.Combine(AppContext.BaseDirectory, "Resources");

if (!Directory.Exists(path))
{
    Console.WriteLine($"Директория '{path}' не существует.");
    return;
}

var directoryFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

var sw = new Stopwatch();
sw.Start();
ReadSpaces(directoryFiles);
sw.Stop();

Console.WriteLine($"Синхронная обработка: {sw.Elapsed.TotalMilliseconds} мс");
Console.WriteLine();

sw.Reset();

sw.Start();
await ReadSpacesAsync(directoryFiles);
sw.Stop();

Console.WriteLine($"Асинхронная обработка: {sw.Elapsed.TotalMilliseconds} мс");

return;

async Task ReadSpacesAsync(string[] files)
{
    await Task.WhenAll(files.Select(file => Task.Run(() =>
    {
        var fileInfo = new FileInfo(file);
        var spacesCount = CountSpaces(fileInfo.FullName);
        Console.WriteLine($"Пробелов в файле {fileInfo.Name}: {spacesCount}");
    })).ToArray());
}

void ReadSpaces(string[] files)
{
    foreach (var file in files)
    {
        var fileInfo = new FileInfo(file);
        var spacesCount = CountSpaces(fileInfo.FullName);
        Console.WriteLine($"Пробелов в файле {fileInfo.Name}: {spacesCount}");
    }
}

int CountSpaces(string file)
{
    var lines = File.ReadAllLines(file);
    return lines
        .SelectMany(s => s.ToCharArray())
        .Count(c => c == ' ');
}