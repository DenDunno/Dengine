using OpenTK.Mathematics;

public interface IModel : IGameComponent
{
    void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix);
}