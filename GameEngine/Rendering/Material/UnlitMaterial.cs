using System.Drawing;

public class UnlitMaterial : LitMaterial
{
    public UnlitMaterial(LitMaterialData data) : base(data)
    {
    }

    protected override void OnInit()
    {
        base.OnInit();
        Bridge.SetColor("lightColor", Color.White);
        Bridge.SetFloat("ambientValue", 1);
    }
}