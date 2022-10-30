using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class UpdateCycleFactory
{
    private readonly Window _window;
    private readonly Camera _camera;
    private readonly List<Rigidbody> _rigidbodies = new();    
    
    public UpdateCycleFactory(Window window)
    {
        _window = window;
        _camera = new Camera(new Vector3(0, 0, 3), window.AspectRatio);
    }
    
    public UpdateCycle Create()
    {
        var gameObjects = new List<GameObject>()
        {
            CreateObstacle(true, Primitives.Quad(1), new Vector3(-1.5f, 0, 0)),
            CreateObstacle(false, Primitives.RandomPolygon(0.25f), new Vector3(1.5f, 1.75f, 0)),
            CreateObstacle(false, Primitives.Quad(0.75f), new Vector3(1.5f, -1f, 0)),
        };
        
        var world = new World(_camera, gameObjects);
        return new UpdateCycle(_window, world, _rigidbodies);
    }

    private GameObject CreateObstacle(bool isControlling, Mesh mesh, Vector3 position)
    {
        var transform = new Transform(position);
        var meshWorldView = new MeshWorldView(transform, mesh);
        var shaderProgram = new ColorShaderProgram("Shaders/vert.glsl", "Shaders/uv.glsl");
        
        _rigidbodies.Add(new Rigidbody(transform, meshWorldView)
        {
            ColorShaderProgram = shaderProgram
        });
        
        return new GameObject(new GameObjectData()
        {
            Model = new Model(new RenderData()
            {
                Transform = transform,
                Mesh = mesh,
                BufferUsageHint = BufferUsageHint.StaticDraw,
                ShaderProgram = shaderProgram,
                AttributePointers = new[]
                {
                    new AttributePointer(0, 3, 8, 0),
                    new AttributePointer(1, 2, 8, 3),
                    new AttributePointer(2, 3, 8, 5),
                }
            }),
            
            Components = GetComponents(isControlling, transform)
        });
    }

    private IUpdatable[] GetComponents(bool isControlling, Transform transform)
    {
        var components = new List<IUpdatable>();
        
        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, _window.KeyboardState));
        }
        
        else
        {
            components.Add(new RotationAnimation(transform, new Vector3(0, 0, 1), 1f));   
        }

        return components.ToArray();
    }
}