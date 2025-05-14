using System.Diagnostics;

var filesArray = new[] { "NewFile1.txt", "NewFile2.txt", "NewFile3.txt" };

var sw = new Stopwatch();
sw.Start();
ReadSpaces(filesArray);
sw.Stop();

Console.WriteLine($"Синхронная обработка: {sw.Elapsed.TotalMilliseconds} мс");
Console.WriteLine();

sw.Reset();

sw.Start();
await ReadSpacesAsync(filesArray);
sw.Stop();

Console.WriteLine($"Асинхронная обработка: {sw.Elapsed.TotalMilliseconds} мс");

return;

async Task ReadSpacesAsync(string[] files)
{
    var tasks = new List<Task>(files.Length);

    foreach (var file in files)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Resources", file);
    
        tasks.Add(Task.Run(() =>
        {
            var spacesCount = CountSpaces(path);
            Console.WriteLine($"Пробелов в файле {file}: {spacesCount}");
        }));
    }

    await Task.WhenAll(tasks.ToArray());
}

void ReadSpaces(string[] files)
{
    foreach (var file in files)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Resources", file);
    
        var spacesCount = CountSpaces(path);
        Console.WriteLine($"Пробелов в файле {file}: {spacesCount}");
    }
}

int CountSpaces(string path)
{
    var lines = File.ReadAllLines(path);
    return lines
        .SelectMany(s => s.ToCharArray())
        .Count(c => c == ' ');
}