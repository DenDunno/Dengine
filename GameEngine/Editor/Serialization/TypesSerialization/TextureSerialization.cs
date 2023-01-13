using System.Numerics;
using ImGuiNET;

public class TextureSerialization : FieldSerialization<Texture?>
{
    private readonly TexturesViewer _texturesViewer = new();

    public TextureSerialization()
    {
        _texturesViewer.Init();
    }
    
    protected override object OnSerialize(string fieldInfoName, Texture? texture)
    {
        ImGui.Text(fieldInfoName);

        IntPtr id = (IntPtr)(texture?.Id ?? 0);
        
        if (ImGui.ImageButton(id, Vector2.One * 100))
        {
            ImGui.OpenPopup("TexturesPopUp");
        }

        ImGui.SameLine();
        ImGui.Text(Path.GetFileName(texture?.Path));
        
        if (TryGetNewTexturePath(out string newTexturePath))
        {
            SetupTexture(ref texture, newTexturePath);
        }

        return texture!;
    }

    private void SetupTexture(ref Texture? texture, string path)
    {
        texture?.Dispose();
            
        if (path == "NONE")
        {
            texture = null;
        }
        else
        {
            texture = new Texture(path);
            texture.Load();
        }
    }

    private bool TryGetNewTexturePath(out string newTexturePath)
    {
        newTexturePath = string.Empty;
        
        if (ImGui.BeginPopup("TexturesPopUp"))
        {
            ImGui.Text("Textures");
            ImGui.Separator();

            if (ImGui.Selectable("NONE"))
            {
                newTexturePath = "NONE";
            }
            
            foreach (string texturePath in _texturesViewer.Textures)
            {
                if (ImGui.Selectable(Path.GetFileNameWithoutExtension(texturePath)))
                {
                    newTexturePath = texturePath;
                }
            }

            ImGui.EndPopup();
        }

        return newTexturePath != string.Empty;
    }
}