using OpenTK.Mathematics;

public class StaticBatchingDemo : IWorldFactory
{
    private GameObject _origin = null!;
    
    public List<GameObject> CreateGameObjects(PlayerInput input)
    {
        Camera camera = new(new PerspectiveProjection());
        BigObjectData[] data = GetDataForObjects();
        _origin = CreateOrigin();

        return new List<GameObject>()
        {
            GameObjectFactory.CreateSkybox("Storm", camera),
            GameObjectFactory.CreateCamera(camera, input),
            CreateBigObject(data[0]),
            CreateBigObject(data[1]),
            CreateBigObject(data[2]),
            _origin
        };
    }

    private GameObject CreateOrigin()
    {
        Transform transform = new();

        return new GameObject(new GameObjectData("Origin", transform)
        {
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(transform, Vector3.UnitZ, 0.2f)
            }
        });
    }

    private BigObjectData[] GetDataForObjects()
    {
        Vector3[] positions = new TriangleMeshData(100).GetMeshData().Positions;

        for (int i = 0; i < positions.Length; i++)
        {
            positions[i].Z = -75;
            positions[i].Y -= 10;
        }

        return new BigObjectData[]
        {
            new(positions[0], "Cube", GetBigCubeMesh(), new UnlitMaterial(Paths.GetTexture("wood.png"))),
            new(positions[1], "Sphere", GetBigSphereMesh(), new Material(Paths.GetShader("vert"), Paths.GetShader("uv"))),
            new(positions[2], "Tetrahedron", GetBigCubeMesh(), new UnlitMaterial(Paths.GetTexture("crate.png"))),
        };
    }

    private GameObject CreateBigObject(BigObjectData data)
    {
        Transform transform = new(data.InitialPosition, _origin.Data.Transform);

        return new GameObject(new GameObjectData(data.Name, transform)
        {
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(transform, Vector3.One, 0.2f)
            },
            
            Drawable = new Model(new RenderData()
            {
                Transform = transform,
                Mesh = data.Mesh,
                Material = data.Material
            })
        });
    }

    private Mesh GetBigCubeMesh()
    {
        const int size = 10;
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

    private Mesh GetBigSphereMesh()
    {
        const int size = 1000;
        Random random = new();
        MeshData[] cubes = new MeshData[size];

        for (int i = 0; i < size; i++)
        {
            double u = random.NextDouble();
            double v = random.NextDouble();
            double theta = u * 2.0 * Math.PI;
            double phi = Math.Acos(2.0 * v - 1.0);
            double r = Math.Cbrt(random.NextDouble()) * 40;
            double sinTheta = Math.Sin(theta);
            double cosTheta = Math.Cos(theta);
            double sinPhi = Math.Sin(phi);
            double cosPhi = Math.Cos(phi);
            float x = (float)(r * sinPhi * cosTheta);
            float y = (float)(r * sinPhi * sinTheta);
            float z = (float)(r * cosPhi);
            
            cubes[i] = new SphereMeshData(1f, 24, 24, new Vector3(x, y, z)).GetMeshData();
        }

        return MeshBuilder.BuildMesh(StaticBatching.Concatenate(cubes));
    }
}