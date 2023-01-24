using OpenTK.Mathematics;

public class Demo2D : IWorldFactory
{
    public List<GameObject> CreateGameObjects(PlayerInput playerInput)
    {
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(new OrthographicProjection()),
            CreateObstacle("Controlling Quad", MeshBuilder.Quad(1f), Vector3.Zero, 0),
            CreateObstacle("Quad", MeshBuilder.Quad(1.5f), new Vector3(-1.75f, 1f, 0), 45),
            CreateTriangle(),
            CreateObstacle("Hexagon", MeshBuilder.Hexagon(1.15f), new Vector3(-1.75f, -1f, 0), 45),
        };
    }

    private GameObject CreateTriangle()
    {
        GameObject triangle = CreateObstacle("Triangle", MeshBuilder.Triangle(1.5f), new Vector3(1.75f, -1f, 0), 45);
        Transform transform = triangle.Data.Transform;
        triangle.Data.Components.Add(new MovementAnimation(transform, Vector3.UnitX));

        return triangle;
    }
    
    private GameObject CreateObstacle(string name, Mesh mesh, Vector3 position, float rotation)
    {
        Transform transform = new(position, Quaternion.FromEulerAngles(0, 0, rotation));

        return new GameObject(new GameObjectData(name, transform)
        {
            Drawable = new Drawable(new RenderData
            {
                Transform = transform,
                Mesh = mesh,
                Material = new UnlitMaterial(new LitMaterialData()
                {
                    Base = new Texture(Paths.GetTexture("crate.png"))
                })
            }),
            
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(transform, Vector3.UnitZ, 1f)
            }
        });
    }
}