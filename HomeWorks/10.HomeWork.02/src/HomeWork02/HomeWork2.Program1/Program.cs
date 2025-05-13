var files = new[] { "NewFile1.txt", "NewFile2.txt", "NewFile3.txt" };

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
return;

int CountSpaces(string path)
{
    return File 
        .ReadLines(path)
        .SelectMany(s => s.ToCharArray())
        .Count(c => c == ' ');
}