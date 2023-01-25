using System.Drawing;

class GradientDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects(PlayerInput playerInput)
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
                new GradientAnimation(material.Bridge, transform, ColorAnimationCurve, SizeAnimationCurve)
            }
        });
    }

    private AnimationCurve<Color> ColorAnimationCurve => new(new CurvePart<Color>[]
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
    });
    
    private AnimationCurve<float> SizeAnimationCurve => new(new CurvePart<float>[]
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
    });
}