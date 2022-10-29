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
        _camera = new Camera(new Vector3(0, 1.5f, 3), window.AspectRatio);
    }
    
    public UpdateCycle Create()
    {
        var gameObjects = new List<GameObject>()
        {
            CreateStaticPoint(),
            CreatePlane(),
            CreateSkybox(),
            CreateCube(new Vector3(2, 2, 0), false), 
            CreateCube(new Vector3(-2, 2, 0), true),
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

    private GameObject CreateSphere(Vector3 position, float radius, float mass, bool isControlling)
    {
        var transform = new Transform(position);
        var renderData = new RenderData()
        {
            Transform = transform,
            Mesh = Primitives.Sphere(radius, 24, 24),
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = new ShaderProgram("Shaders/flatVert.glsl", "Shaders/flatFrag.glsl"),
            AttributePointers = new[]
            {
                new AttributePointer(0, 3, 6, 0),
                new AttributePointer(1, 3, 6, 3),
            }
        };

        _rigidbodies.Add(new Rigidbody(transform)
        {
            Mass = mass,
            Collider = new SphereCollider(transform, radius)
        });

        var components = new List<IUpdatable>();

        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, _window.KeyboardState));
        }
        
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
            AttributePointers = new[]
            {
                new AttributePointer(0, 3, 8, 0)
            },
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

    private GameObject CreatePlane()
    {
        var lightData = new LightData(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        var transform = new Transform();
        
        var renderData = new RenderData()
        {
            Transform = transform,
            Mesh = Primitives.Quad(10),
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = new LightningShaderProgram(lightData, _camera, "Shaders/vert.glsl", "Shaders/lightning.glsl"),
            AttributePointers = new[]
            {
                new AttributePointer(0, 3, 8, 0),
                new AttributePointer(1, 2, 8, 3),
                new AttributePointer(2, 3, 8, 5)
            }
        };

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData)
        });
    }

    private GameObject CreateCube(Vector3 position, bool isControlling)
    {
        var lightData = new LightData(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        var transform = new Transform(position);
        var renderData = new RenderData()
        {
            Transform = transform,
            Mesh = Primitives.Cube(0.5f),
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = new LightningShaderProgram(lightData, _camera, "Shaders/vert.glsl", "Shaders/lightning.glsl"),
            AttributePointers = new[]
            {
                new AttributePointer(0, 3, 8, 0),
                new AttributePointer(1, 2, 8, 3),
                new AttributePointer(2, 3, 8, 5)
            },
        };
        
        var components = new List<IUpdatable>();

        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, _window.KeyboardState));
        }

        var boundingBox = new BoundingBox(renderData.Mesh.VerticesData, 8, transform);
        _rigidbodies.Add(new Rigidbody(transform)
        {
            Collider = new BoxCollider(boundingBox)
        });

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData),
            Components = components.ToArray()
        });
    }
}