using OpenTK.Mathematics;

public class GameObject : IModel, IUpdatable
{
    private readonly IModel _model;
    private readonly IInitializable[] _initializables;
    private readonly IUpdatable[] _components;

    public GameObject(IInitializable[] initializables, IUpdatable[] components, IModel model)
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