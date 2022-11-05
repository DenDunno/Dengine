using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Demo2DFactory : WorldFactory
{
    public Demo2DFactory(Window window) : base(window)
    {
    }

    protected override List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            CreateObstacle(true, Primitives.Quad(0.5f), Vector3.Zero, 0),
            CreateObstacle(false, Primitives.Quad(0.75f), new Vector3(-1.75f, 1f, 0), 45),
            CreateObstacle(false, Primitives.Quad(0.75f), new Vector3(1.75f, -1f, 0), -45),
        };
    }
    
    private GameObject CreateObstacle(bool isControlling, Mesh mesh, Vector3 position, float rotation)
    {
        Transform transform = new(position, Quaternion.FromEulerAngles(0, 0, rotation));
        MeshWorldView meshWorldView = new(transform, mesh);
        ColorShaderProgram shaderProgram = new("Shaders/vert.glsl", "Shaders/uv.glsl");
        
        AddRigidbody(new Rigidbody(transform, meshWorldView)
        {
            ShaderProgram = shaderProgram
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
            components.Add(new ObjectControlling(transform, KeyboardState));
        }

        return components.ToArray();
    }
}