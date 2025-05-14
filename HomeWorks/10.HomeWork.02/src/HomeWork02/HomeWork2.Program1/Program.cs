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
            var spaces = CountSpaces(path);
            Console.WriteLine($"Пробелов в файле {file}: {spaces}");
        }));
    }

    await Task.WhenAll(tasks.ToArray());
}

void ReadSpaces(string[] files)
{
    foreach (var file in files)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Resources", file);
    
        var spaces = CountSpaces(path);
        Console.WriteLine($"Пробелов в файле {file}: {spaces}");
    }
}

int CountSpaces(string path)
{
    var lines = File.ReadAllLines(path);
    return lines
        .SelectMany(s => s.ToCharArray())
        .Count(c => c == ' ');
}