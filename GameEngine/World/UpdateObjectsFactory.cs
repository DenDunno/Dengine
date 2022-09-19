using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class UpdateObjectsFactory
{
    private readonly Window _window;
    private readonly Camera _camera;
    private readonly List<Rigidbody> _rigidbodies = new();    
    
    public UpdateObjectsFactory(Window window, Camera camera)
    {
        _window = window;
        _camera = camera;
    }
    
    public UpdateObjects Create()
    {
        var gameObjects = new List<GameObject>()
        {
            CreateStaticPoint(),
            CreatePlane(),
            CreateSkybox(),
            CreateControllingSphere(),
            CreateLeftSphere()
        };

        return new UpdateObjects(gameObjects, _rigidbodies.ToArray());
    }

    private GameObject CreateLeftSphere()
    {
        var transform = new Transform(new Vector3(-2, 2, 0));
        const float radius = 2f;
        var renderData = new RenderData(transform, Primitives.Sphere(radius, 24, 24), new[]
        {
            new AttributePointer(0, 3, 6, 0),
            new AttributePointer(1, 3, 6, 3),
        },
        new ShaderProgram(new Shader[]
        {
            new("Shaders/flatVert.glsl", ShaderType.VertexShader),
            new("Shaders/flatFrag.glsl", ShaderType.FragmentShader)
        }));

        _rigidbodies.Add(new Rigidbody(transform, new SphereCollider(transform, radius)));

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData, BufferUsageHint.StaticDraw),
            Components = new IUpdatable[]
            {
                new RotationAnimation(transform, new Vector3(1, 1, 0)),
            }
        });
    }

    private GameObject CreateControllingSphere()
    {
        var transform = new Transform(new Vector3(2, 2, 0));
        const float radius = 1f;
        var renderData = new RenderData(transform, Primitives.Sphere(radius, 24, 24), new[]
        {
            new AttributePointer(0, 3, 6, 0),
            new AttributePointer(1, 3, 6, 3),
        },
        new ShaderProgram(new Shader[]
        {
            new("Shaders/flatVert.glsl", ShaderType.VertexShader),
            new("Shaders/flatFrag.glsl", ShaderType.FragmentShader)
        }));

        var rigidbody = new Rigidbody(transform, new SphereCollider(transform, radius)); 
        _rigidbodies.Add(rigidbody);

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData, BufferUsageHint.StaticDraw),
            Components = new IUpdatable[]
            {
                new ObjectControlling(transform, _window.KeyboardState)
            }
        });
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
        var renderData = new RenderData(transform, Primitives.Cube(50f), new[]
        {
            new AttributePointer(0, 3, 8, 0)
        },
        new ShaderProgramWithTexture(new Cubemap(paths), new Shader[]
        {
            new("Shaders/skyboxVert.glsl", ShaderType.VertexShader),
            new("Shaders/skyboxFrag.glsl", ShaderType.FragmentShader)
        }));

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData, BufferUsageHint.DynamicDraw),
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
        
        var renderData = new RenderData(transform, Primitives.Quad(10), new[]
        {
            new AttributePointer(0, 3, 8, 0),
            new AttributePointer(1, 2, 8, 3),
            new AttributePointer(2, 3, 8, 5)
        },
        new LightningShaderProgram(lightData, _camera, new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/lightning.glsl", ShaderType.FragmentShader)
        }));

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData, BufferUsageHint.StaticDraw)
        });
    }

    private GameObject CreateCube(Vector3 position)
    {
        var lightData = new LightData(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        var transform = new Transform(position);
        var mesh = Primitives.Cube(0.5f);
        var renderData = new RenderData(transform, mesh, new[]
        {
            new AttributePointer(0, 3, 8, 0),
            new AttributePointer(1, 2, 8, 3),
            new AttributePointer(2, 3, 8, 5)
        },
        new LightningShaderProgram(lightData, _camera, new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/lightning.glsl", ShaderType.FragmentShader)
        }));

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData, BufferUsageHint.DynamicDraw)
        });
    }
}