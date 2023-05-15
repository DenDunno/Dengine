
public interface IMeshProvider : IDisposable
{
    void Bind();
    Mesh Mesh { get; }
}