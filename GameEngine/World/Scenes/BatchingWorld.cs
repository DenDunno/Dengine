using OpenTK.Mathematics;

public class BatchingWorld : WorldFactory
{
    protected override List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(new PerspectiveProjection()),
            CreateCube(),
            CreateSphere(),
        };
    }

    private GameObject CreateSphere()
    {
        Transform transform = new(new Vector3(0, 0, 0));

        return new GameObject(new GameObjectData("Sphere", transform)
        {
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(transform, Vector3.One, 0.2f)
            },
            
            Model = new Model(new RenderData()
            {
                Transform = transform,
                Mesh = MeshBuilder.Sphere(1, 24, 24),
                Material = new UnlitMaterial(new LitMaterialData())
            })
        });
    }

    private GameObject CreateCube()
    { 
        Transform transform = new(new Vector3(0, 0, -100));

        return new GameObject(new GameObjectData("Cube", transform)
        {
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(transform, Vector3.One, 0.2f)
            },
            
            Model = new Model(new RenderData()
            {
                Transform = transform,
                Mesh = GetCubeMesh(),
                Material = new UnlitMaterial(new LitMaterialData()
                {
                    Base = new Texture(Paths.GetTexture("wood.png"))
                })
            })
        });
    }

    private Mesh GetCubeMesh()
    {
        const int size = 20;
        MeshData[] cubes = new MeshData[size * size * size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    Vector3 position = (new Vector3(i, j, k) - Vector3.One * size / 2f) * 4;
                    
                    cubes[i * size * size + j * size + k] = new CubeMeshData(1f, position).GetMeshData();
                }
            }
        }

        return MeshBuilder.BuildMesh(StaticBatching.Concatenate(cubes));
    }
}