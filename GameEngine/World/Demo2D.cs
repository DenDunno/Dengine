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
            CreateObstacle("Controlling Quad", true, MeshBuilder.Quad(0.5f), Vector3.Zero, 0),
            CreateObstacle("Quad", false, MeshBuilder.Quad(0.75f), new Vector3(-1.75f, 1f, 0), 45),
            //CreateObstacle("Triangle", false, MeshBuilder.Triangle(1.5f), new Vector3(1.75f, -1f, 0), 45),
        };
    }
    
    private GameObject CreateObstacle(string name, bool isControlling, Mesh mesh, Vector3 position, float rotation)
    {
        Transform transform = new(position, Quaternion.FromEulerAngles(0, 0, rotation));
        MeshWorldView meshWorldView = new(transform, mesh);
        ColorShaderProgram shaderProgram = new("Shaders/vert.glsl", "Shaders/uv.glsl");
        meshWorldView.CalculateNormals();

        AddRigidbody(new Rigidbody(transform, meshWorldView)
        {
            ShaderProgram = shaderProgram
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
        else
        {
            components.Add(new RotationAnimation(transform, Vector3.UnitZ, 1f));
        }

        return components.ToArray();
    }
}