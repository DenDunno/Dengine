using OpenTK.Mathematics;

public interface IDrawable : IGameComponent, IDisposable
{
    void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix);
}