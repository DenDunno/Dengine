using OpenTK.Mathematics;

public interface IModel : IGameComponent, IDisposable
{
    void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix);
}