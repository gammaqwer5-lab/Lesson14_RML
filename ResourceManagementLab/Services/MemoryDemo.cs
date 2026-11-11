namespace ResourceManagementLab.Services;

// Здесь мы демонстрируем, что объект может перестать быть доступным через переменную.
// Но не вызываем `GC.Collect()`, потому что хотим показать естественное поведение GC.

// `GC.GetTotalMemory(false)` возвращает приблизительную оценку объёма управляемой памяти, 
// а не размер всей памяти процесса и не точное количество памяти, занятой конкретным массивом.
public static class MemoryDemo
{
    public static void Run()
    {
        Console.WriteLine("=== MEMORY DEMO ===");

        var first = new byte[1024 * 1024];
        var second = new byte[1024 * 1024];
        var third = new byte[1024 * 1024 * 5];

        Console.WriteLine($"first: {GC.GetGeneration(first)}");
        Console.WriteLine($"second: {GC.GetGeneration(second)}");
        Console.WriteLine($"third: {GC.GetGeneration(third)}");

        Console.WriteLine(
            $"Gen 0: {GC.CollectionCount(0)}");

        Console.WriteLine(
            $"Gen 1: {GC.CollectionCount(1)}");

        Console.WriteLine(
            $"Gen 2: {GC.CollectionCount(2)}");

        first = null!;
        second = null!;
        third = null!;

        Console.WriteLine("Ссылка на массив потеряна.");

        Console.WriteLine(
            $"Память, выделенная под объекты в куче: " +
            $"{GC.GetTotalMemory(false) / 1024} KB");
    }
}