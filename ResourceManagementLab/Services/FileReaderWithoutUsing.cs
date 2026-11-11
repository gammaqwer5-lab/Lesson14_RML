namespace ResourceManagementLab.Services;

// Начнём с намеренно неправильного варианта.
// Здесь создаются два объекта:
// - `FileStream` - управляет файловым ресурсом;
// - `StreamReader` - читает текст из потока.
// и неправильный вариант в том, что мы не освобождаем ни один из объектов явно.
// eсли во время чтения возникнет исключение, ресурс также не будет закрыт этим методом.
public static class FileReaderWithoutUsing
{
    public static string Read(string filePath)
    {
        var stream = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read);

        var reader = new StreamReader(stream);

        string content = reader.ReadToEnd();

        stream.Dispose();
        return content;
    }
}