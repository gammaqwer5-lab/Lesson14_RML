using ResourceManagementLab.Services;

namespace ResourceManagementLab;

internal class Program
{
    private static void Main()
    {
        string dataDirectory = Path.Combine(
            AppContext.BaseDirectory,
            "Data");

        Directory.CreateDirectory(dataDirectory);

        string filePath = Path.Combine(
            dataDirectory,
            "sample.txt");

        File.WriteAllText(
            filePath,
            "Hello from C#!\nResource management example.");

        Console.WriteLine("=== RESOURCE MANAGEMENT LAB ===");
        Console.WriteLine();

        Console.WriteLine("1. Чтение без using");

        string content1 =
            FileReaderWithoutUsing.Read(filePath);

        Console.WriteLine(content1);

        Console.WriteLine();
        Console.WriteLine("2. Чтение с using");

        string content2 =
            FileReaderWithUsing.Read(filePath);

        Console.WriteLine(content2);

        Console.WriteLine();
        Console.WriteLine("Поведение при исключении");

        try
        {
            FileReaderWithUsing.ReadWithException(filePath);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Перехвачена ошибка: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("3. Проверка Dispose");

        using (var storage = new FileStorage(filePath))
        {
            storage.Write(
                "Данные записаны через FileStorage.");

            Console.WriteLine(storage.Read());
        }

        Console.WriteLine();
        Console.WriteLine("4. Проверка повторного Dispose");

        var secondStorage = new FileStorage(filePath);

        secondStorage.Dispose();
        secondStorage.Dispose();

        Console.WriteLine();
        Console.WriteLine("5. Демонстрация GC");

        MemoryDemo.Run();

        Console.WriteLine();
        Console.WriteLine("Работа программы завершена.");
    }
}