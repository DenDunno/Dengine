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
            CreateStaticPoint(),
            CreateCube(Vector3.One),
            CreateObstacle(true, Primitives.Quad(0.5f), new Vector3(-1.5f, 0, 0)),
            CreateObstacle(false, Primitives.Quad(0.75f), new Vector3(1.5f, -1f, 0)),
        };
        
        var world = new World(_camera, gameObjects);
        return new UpdateCycle(_window, world, _rigidbodies);
    }
    
    private GameObject CreateStaticPoint()
    {
        return new GameObject(new GameObjectData()
        {
            Components = new IUpdatable[]
            {
                new Timer(), 
                new CameraControlling(_camera, _window.MouseState, _window.KeyboardState),
                new FPSCounter(_window)
            } 
        });
    }
    
    private GameObject CreateCube(Vector3 position)
    {
        var lightData = new LightData(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        var transform = new Transform(position);
        var renderData = new RenderData()
        {
            Transform = transform,
            Mesh = Primitives.Cube(0.5f),
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = new LightningShaderProgram(lightData, _camera, "Shaders/vert.glsl", "Shaders/lightning.glsl"),
        };
        
        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData),
            Components = new IUpdatable[]
            {
                new RotationAnimation(transform, new Vector3(0, 1, 1), 1f)
            }
        });
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
                ShaderProgram = shaderProgram
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