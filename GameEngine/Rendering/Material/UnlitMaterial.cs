using System.Drawing;

public class UnlitMaterial : LitMaterial
{
    public UnlitMaterial(LitMaterialData data) : base(data)
    {
    }
    
    public UnlitMaterial(string texturePath) : base(new LitMaterialData() { Base = new Texture2D(texturePath)})
    {
    }

    protected override void OnInit()
    {
        base.OnInit();
        Bridge.SetColor("lightColor", Color.White);
        Bridge.SetFloat("ambientValue", 1f);
    }
}