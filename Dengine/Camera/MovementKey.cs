using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class MovementKey
{
    public readonly Keys Key;
    public readonly Func<Vector3> Direction;

    public MovementKey(Keys key, Func<Vector3> direction)
    {
        Key = key;
        Direction = direction;
    }
}