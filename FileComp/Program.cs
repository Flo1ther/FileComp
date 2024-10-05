using System.Text;


Console.OutputEncoding = Encoding.UTF8;

Console.Write("Введіть назву папки: ");
string folderName = Console.ReadLine();

string folderPath = Path.Combine(Environment.CurrentDirectory, folderName);

Directory.CreateDirectory(folderPath);
Console.WriteLine($"Папка '{folderName}' створена за адресою: {folderPath}");

string filePath = Path.Combine(folderPath, "text.txt");

using (StreamWriter writer = new StreamWriter(filePath))
{
    for (int i = 1; i <= 5; i++)
    {
        Console.Write($"Введіть рядок {i}: ");
        string line = Console.ReadLine();
        writer.WriteLine(line);
    }
}
Console.WriteLine("5 рядків записано у файл 'text.txt'.");

Console.WriteLine("\nВміст файлу та кількість символів у кожному рядку:");
using (StreamReader reader = new StreamReader(filePath))
{
    string line;
    int lineNumber = 1;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine($"Рядок {lineNumber}: {line} (Кількість символів: {line.Length})");
        lineNumber++;
    }
}

File.Delete(filePath);
Console.WriteLine("\nФайл 'text.txt' видалено.");

Directory.Delete(folderPath);
Console.WriteLine($"Папка '{folderName}' видалена.");