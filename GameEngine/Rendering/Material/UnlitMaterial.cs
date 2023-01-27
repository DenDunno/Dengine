using System.Drawing;

public class UnlitMaterial : LitMaterial
{
    public UnlitMaterial(LitMaterialData data) : base(data)
    {
    }
    
    public UnlitMaterial(string texturePath) : base(new LitMaterialData() { Base = new Texture(texturePath)})
    {
    }

    protected override void OnInit()
    {
        base.OnInit();
        Bridge.SetValue("lightColor", Color.White);
        Bridge.SetValue("ambientValue", 1f);
    }
}