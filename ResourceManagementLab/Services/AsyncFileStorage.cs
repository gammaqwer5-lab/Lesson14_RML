public sealed class AsyncFileStorage : IAsyncDisposable
{
    private readonly FileStream _stream;

    public AsyncFileStorage(string path)
    {
        _stream = new FileStream(
            path,
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite,
            FileShare.None,
            bufferSize: 4096,
            useAsync: true);
    }
    public async Task WriteAsync(string text)
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes(text);

        await _stream.WriteAsync(data);
        await _stream.FlushAsync();
    }
    public async ValueTask DisposeAsync()
    {
        await _stream.DisposeAsync();
    }
}