using System.Drawing;
using OpenTK.Mathematics;

public class LODGroupDemo : IWorldFactory
{
    private readonly int _axisSize = 15;
    private readonly float _distanceBetweenTrees = 10;
    
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new(new Transform(new Vector3(-20, 35, -15)));
        camera.Transform.Yaw = 45;
        
        List<GameObject> gameObjects = new()
        {
            GameObjectFactory.CreateCamera(camera, 10),
            GameObjectFactory.CreateSkybox("Storm"),
            CreateLight(),
            CreatePlane(),
        };

        AddObjects(gameObjects, camera);

        return gameObjects;
    }

    private GameObject CreatePlane()
    {
        return GameObjectFactory.WithRenderData("Plane", new RenderData(MeshBuilder.Quad(100f), new GridMaterial())
        {
            Transform = new Transform(new Vector3(70, 1, 70), Quaternion.FromAxisAngle(Vector3.UnitX, -MathF.PI / 2), Vector3.One * 1.55f)
        });
    }

    private GameObject CreateLight()
    {
        Light light = new(new Transform(new Vector3(-1, 1, -1) * 10000), new LightData()
        {
            Color = new ColorVector4(Color.FromArgb(255, 216, 128, 54)),
            Specular = 1,
            Diffuse = 2.8f,
        });

        return GameObjectFactory.CreateLight(light);
    }

    private void AddObjects(List<GameObject> gameObjects, Camera camera)
    {
        LODMesh[] lodMeshes = 
        {
            new(MeshBuilder.FromObj("tree/lod_0"), 20),
            new(MeshBuilder.FromObj("tree/lod_1"), 40),
            new(MeshBuilder.FromObj("tree/lod_2"), 60),
            new(MeshBuilder.FromObj("tree/lod_3"), 80),
        };
        
        Material material = new LitMaterial(new LitMaterialData()
        {
            Base = new Texture2D(Paths.GetTexture("tree.png"))
        });

        for (int i = 0; i < _axisSize; ++i)
        {
            for (int j = 0; j < _axisSize; ++j)
            {
                gameObjects.Add(CreateTree(i, j, camera, lodMeshes, material));
            }
        }
    }

    private GameObject CreateTree(int row, int column, Camera camera, LODMesh[] lodMeshes, Material material)
    {
        float rotationSpeed = Algorithms.RandomFloat(0.5f, 0.75f) * Algorithms.RandomSign();
        Transform transform = new(new Vector3(row * _distanceBetweenTrees, 1, column * _distanceBetweenTrees));
        LODGroup lodGroup = new(transform, camera, lodMeshes);
        RenderData renderData = new(lodGroup, material)
        {
            Transform = transform
        };

        return new GameObject(new GameObjectData($"Tree {row * _axisSize + column}", renderData.Transform)
        {
            Drawable = new Model(renderData),
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(renderData.Transform, Vector3.UnitY, rotationSpeed)
            }
        });
    }
}