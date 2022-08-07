using OpenTK.Mathematics;

public interface IDrawable
{
    void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix);
}