using OpenTK.Mathematics;

public interface IModel
{
    void Initialize();
    void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix);
}