using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Demo2D : WorldFactory
{
    public Demo2D(Window window) : base(window)
    {
    }

    protected override List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            CreateObstacle("Controlling Quad", true, MeshBuilder.Quad(1f), Vector3.Zero, 0),
            CreateObstacle("Quad", false, MeshBuilder.Quad(1.5f), new Vector3(-1.75f, 1f, 0), 45),
            CreateObstacle("Triangle", false, MeshBuilder.Triangle(1.5f), new Vector3(1.75f, -1f, 0), 45),
            CreateObstacle("Hexagon", false, MeshBuilder.Hexagon(1.15f), new Vector3(-1.75f, -1f, 0), 45),
        };
    }
    
    private GameObject CreateObstacle(string name, bool isControlling, Mesh mesh, Vector3 position, float rotation)
    {
        Transform transform = new(position, Quaternion.FromEulerAngles(0, 0, rotation));
        ColorShaderProgram shaderProgram = new("Shaders/vert.glsl", "Shaders/uv.glsl");

        AddRigidbody(new Rigidbody(transform)
        {
            ShaderProgram = shaderProgram,
            Collider = new MeshCollider(mesh, transform)
        });

        NormalsViewer.Add(transform, mesh);
        
        return new GameObject(new GameObjectData(name)
        {
            Model = new Model(new RenderData
            {
                Transform = transform,
                Mesh = mesh,
                BufferUsageHint = BufferUsageHint.StaticDraw,
                ShaderProgram = shaderProgram,
            }),
            
            Dependencies = GetComponents(isControlling, transform)
        });
    }

    private object[] GetComponents(bool isControlling, Transform transform)
    {
        List<object> components = new();

        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, KeyboardState));
        }
        else
        {
            components.Add(new RotationAnimation(transform, Vector3.UnitZ, 1f));
        }

        return components.ToArray();
    }
}