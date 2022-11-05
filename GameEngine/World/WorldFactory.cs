using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class WorldFactory
{
    private readonly Window _window;
    private readonly Camera _camera;
    private readonly List<Rigidbody> _rigidbodies = new();    
    
    public WorldFactory(Window window)
    {
        _window = window;
        _camera = new Camera(new Vector3(0, 0, 3), window.AspectRatio);
    }
    
    public World Create()
    {
        List<GameObject> gameObjects = new()
        {
            CreateStaticPoint(),
            CreateObstacle(true, Primitives.Quad(0.5f), Vector3.Zero, 0),
            CreateObstacle(false, Primitives.Quad(0.75f), new Vector3(-1.75f, 1f, 0), 45),
            CreateObstacle(false, Primitives.Quad(0.75f), new Vector3(1.75f, -1f, 0), -45),
        };
        
        return new World(_camera, gameObjects);
    }

    private GameObject CreateStaticPoint()
    {
        return new GameObject(new GameObjectData
        {
            Components = new IUpdatable[]
            {
                new Timer(), 
                new FPSCounter(_window),
                new CameraControlling(_camera, _window.MouseState, _window.KeyboardState),
                new PhysicsSimulation(1 / 60f, _rigidbodies),
                _camera,
            },
            
            Model = new Gizmo()
        });
    }

    private GameObject CreateObstacle(bool isControlling, Mesh mesh, Vector3 position, float rotation)
    {
        Transform transform = new(position, Quaternion.FromEulerAngles(0, 0, rotation));
        MeshWorldView meshWorldView = new(transform, mesh);
        ColorShaderProgram shaderProgram = new("Shaders/vert.glsl", "Shaders/uv.glsl");
        
        _rigidbodies.Add(new Rigidbody(transform, meshWorldView)
        {
            ColorShaderProgram = shaderProgram
        });
        
        return new GameObject(new GameObjectData
        {
            Model = new Model(new RenderData
            {
                Transform = transform,
                Mesh = mesh,
                BufferUsageHint = BufferUsageHint.StaticDraw,
                ShaderProgram = shaderProgram,
            }),
            
            Components = GetComponents(isControlling, transform)
        });
    }

    private IUpdatable[] GetComponents(bool isControlling, Transform transform)
    {
        List<IUpdatable> components = new();
        
        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, _window.KeyboardState));
        }

        return components.ToArray();
    }
}