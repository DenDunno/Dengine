using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Camera : IUpdatable
{
    private Vector2 _position;
    private float _size = 3;
    private const float _translationSpeed = 3f;
    private const int _width = 4;
    private const int _height = 3;

    public void Zoom(float delta)
    {
        _size += delta;
    }

    public void Translate(Vector2 delta)
    {
        _position += delta;
    }

    void IUpdatable.Update(float deltaTime)
    {
        var translation = new Vector3(-_position.X * _translationSpeed, -_position.Y * _translationSpeed, 0);
        Matrix4 proj = Matrix4.CreateTranslation(translation) *
                       Matrix4.CreateOrthographic(_width * _size, _height * _size, 0, 1000);
        
        GL.LoadMatrix(ref proj);
        GL.MatrixMode(MatrixMode.Modelview);
    }
}