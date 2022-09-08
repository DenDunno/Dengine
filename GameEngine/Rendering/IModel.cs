using OpenTK.Mathematics;

public interface IModel : IInitializable
{
    void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix);
}