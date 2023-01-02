
public abstract class UIElement
{
    public bool Enabled = true;
    
    public virtual void Update(float deltaTime) {}

    public void Draw()
    {
        if (Enabled)
        {
            OnDraw();   
        }
    }

    protected abstract void OnDraw();
}