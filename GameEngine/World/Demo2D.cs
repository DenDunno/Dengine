using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Demo2D : WorldFactory
{
    public Demo2D(PlayerInput playerInput) : base(playerInput)
    {
    }

    protected override List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            CreateObstacle("Controlling Quad", true, MeshBuilder.Quad(1f), Vector3.Zero, 0),
            CreateObstacle("Quad", false, MeshBuilder.Quad(1.5f), new Vector3(-1.75f, 1f, 0), 45),
            CreateTriangle(),
            CreateObstacle("Hexagon", false, MeshBuilder.Hexagon(1.15f), new Vector3(-1.75f, -1f, 0), 45),
        };
    }

    private GameObject CreateTriangle()
    {
        GameObject triangle = CreateObstacle("Triangle", false, MeshBuilder.Triangle(1.5f), new Vector3(1.75f, -1f, 0), 45);
        Transform transform = triangle.Data.Transform;
        triangle.Data.Components.Add(new MovementAnimation(transform, Vector3.UnitX));

        return triangle;
    }
    
    private GameObject CreateObstacle(string name, bool isControlling, Mesh mesh, Vector3 position, float rotation)
    {
        Transform transform = new(position, Quaternion.FromEulerAngles(0, 0, rotation));
        ColorMaterial material = new("Shaders/standartVert.glsl", "Shaders/uv.glsl");
        Rigidbody rigidbody = new(transform)
        {
            Collider = new MeshCollider(mesh, transform),
        };
        
        AddRigidbody(rigidbody);
        NormalsViewer.Add(transform, mesh);
        
        return new GameObject(new GameObjectData(name, transform)
        {
            Model = new Model(new RenderData
            {
                Transform = transform,
                Mesh = mesh,
                BufferUsageHint = BufferUsageHint.StaticDraw,
                Material = material,
            }),
            
            Components = GetComponents(isControlling, transform)
        });
    }

    private List<IGameComponent> GetComponents(bool isControlling, Transform transform)
    {
        List<IGameComponent> components = new();

        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, Input.Keyboard));
        }
        else
        {
            components.Add(new RotationAnimation(transform, Vector3.UnitZ, 1f));
        }

        return components;
    }
}