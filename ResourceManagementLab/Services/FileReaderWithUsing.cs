namespace ResourceManagementLab.Services;

// Теперь оба объекта освобождаются автоматически.
// Порядок освобождения обратный порядку создания:
// 1. Сначала `StreamReader`.
// 2. Затем `FileStream`.
public static class FileReaderWithUsing
{
    public static string Read(string filePath)
    {
        using var stream = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read);

        // `StreamReader` владеет переданным потоком по умолчанию, 
        // поэтому в этом примере оба `using` допустимы, хотя закрытие потока происходит дважды. 
        // Повторный вызов `Dispose()` для стандартного `FileStream` безопасен.
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
    public static string ReadWithException(string filePath)
    {

        using var reader = new StreamReader(
            new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read));

        string content = reader.ReadToEnd();

        throw new InvalidOperationException(
            "Искусственная ошибка после чтения файла.");
    }
}