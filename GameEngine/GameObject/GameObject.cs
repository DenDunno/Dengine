using OpenTK.Mathematics;

public class GameObject 
{
    private readonly IModel _model;
    private readonly IInitializable[] _initializables;
    private readonly IUpdatable[] _components;

    public GameObject(IUpdatable[] components, IModel model) : this(Array.Empty<IInitializable>(), components, model)
    {
    }

    public GameObject(IModel model) : this(Array.Empty<IInitializable>(), Array.Empty<IUpdatable>(), model)
    {
    }
    
    public GameObject(IUpdatable[] components) : this(Array.Empty<IInitializable>(), components, new Point())
    {
    }

    private GameObject(IInitializable[] initializables, IUpdatable[] components, IModel model)
    {
        _initializables = initializables;
        _components = components;
        _model = model;
    }
    
    public void Initialize()
    {
        _model.Initialize();
        _initializables.ForEach(initializables => initializables.Initialize());
    }

    public void Update(float deltaTime)
    {
        _components.ForEach(component => component.Update(deltaTime));
    }

    public void Draw(in Matrix4 projectionViewMatrix)
    {
        _model.Draw(in projectionViewMatrix);
    }
}