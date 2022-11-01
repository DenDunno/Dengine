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
            CreateSkybox(),
            CreateStaticPoint(),
            CreateCube(new Vector3(-2, 2, 0), true),
            CreateCube(new Vector3(2, 2, 0), false),
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

    private GameObject CreateCube(Vector3 position, bool isControlling)
    {
        Mesh mesh = Primitives.Cube(0.5f);
        var lightData = new LightData(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        var transform = new Transform(position);
        var renderData = new RenderData()
        {
            Transform = transform,
            Mesh = mesh,
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = new LightningShaderProgram(lightData, _camera, "Shaders/vert.glsl", "Shaders/lightning.glsl"),
        };
        
        var components = new List<IUpdatable>();

        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, _window.KeyboardState));
        }
        else
        {
            components.Add(new RotationAnimation(transform, new Vector3(0, 1, 1), 1f));
        }

        var meshWorldView = new MeshWorldView(transform, mesh);
        _rigidbodies.Add(new Rigidbody(transform, meshWorldView)
        {
            LightningShaderProgram = (LightningShaderProgram)renderData.ShaderProgram
        });

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData),
            Components = components.ToArray()
        });
    }
    
    private GameObject CreateSkybox()
    {
        var transform = new Transform(new Vector3(0, 0, 0));
        var paths = new List<string>()
        {
            "Resources/Storm/right.jpg",
            "Resources/Storm/left.jpg",
            "Resources/Storm/top.jpg",
            "Resources/Storm/bottom.jpg",
            "Resources/Storm/back.jpg",
            "Resources/Storm/front.jpg",   
        };
        var renderData = new RenderData()
        {
            Transform = transform,
            Mesh = Primitives.Cube(50f),
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = new ShaderProgramWithTexture(new Cubemap(paths), "Shaders/skyboxVert.glsl", "Shaders/skyboxFrag.glsl"),
        };

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData),
            Components = new IUpdatable[]
            {
                new Skybox(_camera, transform)
            },
        });
    }
}