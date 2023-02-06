using System.Drawing;
using OpenTK.Mathematics;

class AnimationCurveDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(new OrthographicProjection()),
            CreateAnimatedQuad()
        };
    }

    private GameObject CreateAnimatedQuad()
    {
        Transform transform = new();
        UnlitMaterial material = new(new LitMaterialData());
    
        return new GameObject(new GameObjectData("Quad", transform)
        {
            Drawable = new Model(new RenderData()
            {
                Mesh = MeshBuilder.Quad(1f),
                Material = material,
                Transform = transform
            }),
            
            Components = new List<IGameComponent>()
            {
                new CurveAnimation(material.Bridge, transform, ParticleSystemData)
            }
        });
    }

    private ParticleSystemData ParticleSystemData => new()
    {
        Size = new AnimationCurve<float>(new CurvePart<float>[]
        {
            new()
            {
                FirstKey = new CurveKey<float>(1, 0),
                SecondKey = new CurveKey<float>(3, 0.5f),
                EasingFunction = EasingFunctions.InOutQuad
            },
        
            new()
            {
                FirstKey = new CurveKey<float>(3, 0.5f),
                SecondKey = new CurveKey<float>(2, 1),
                EasingFunction = EasingFunctions.InOutQuad
            }
        }),
        
        Rotation = new AnimationCurve<Vector3>(new CurvePart<Vector3>[]
        {
            new()
            {
                FirstKey = new CurveKey<Vector3>(Vector3.UnitZ * 0, 0),
                SecondKey = new CurveKey<Vector3>(Vector3.UnitZ * 1, 0.5f),
                EasingFunction = EasingFunctions.InOutQuad
            },
        
            new()
            {
                FirstKey = new CurveKey<Vector3>(Vector3.UnitZ * 1, 0.5f),
                SecondKey = new CurveKey<Vector3>(Vector3.UnitZ * -1, 1f),
                EasingFunction = EasingFunctions.InOutQuad
            }
        }),
        
        Color = new AnimationCurve<Color>(new CurvePart<Color>[]
        {
            new()
            {
                FirstKey = new CurveKey<Color>(Color.Red, 0),
                SecondKey = new CurveKey<Color>(Color.GreenYellow, 0.5f),
                EasingFunction = EasingFunctions.InOutQuad
            },
        
            new()
            {
                FirstKey = new CurveKey<Color>(Color.GreenYellow, 0.5f),
                SecondKey = new CurveKey<Color>(Color.Aqua, 1),
                EasingFunction = EasingFunctions.InOutQuad
            }
        })
    };
}