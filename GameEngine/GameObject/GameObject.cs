
public class GameObject : IDrawable, IUpdatable
{
    private readonly IDrawable _modelRenderer;
    private readonly IUpdatable[] _components;

    public GameObject() : this(new Transform(), new Model(), Array.Empty<IUpdatable>())
    {
    }

    public GameObject(Model model) : this(new Transform(), model, Array.Empty<IUpdatable>())
    {
    }

    public GameObject(IUpdatable[] components) : this(new Transform(), new Model(), components)
    {
    }

    public GameObject(Transform transform, IUpdatable[] components) : this(transform, new Model(), components)
    {
    }
    
    public GameObject(Transform transform, Model model, IUpdatable[] components)
    {
        _modelRenderer = new ModelRenderer(model, transform);
        _components = components;
    }

    public void Draw()
    {
        _modelRenderer.Draw();
    }

    public void Update(float deltaTime)
    {
        _components.ForEach(component => component.Update(deltaTime));
    }
}