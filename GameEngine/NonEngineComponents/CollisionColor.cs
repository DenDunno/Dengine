using System.Drawing;

public class CollisionColor : IGameComponent
{
    private readonly StandartMaterial _material;

    public CollisionColor(StandartMaterial material)
    {
        _material = material;
    }
    
    void IGameComponent.Update(float deltaTime)
    {
        _material.Bridge.SetColor("lightColor", Color.White);
    }

    public void OnTriggerStay()
    {
        _material.Bridge.SetColor("lightColor", Color.Red);
    }
}