
public class GizmoCommands
{
    private readonly Reflection _reflection;

    public GizmoCommands(Reflection reflection)
    {
        _reflection = reflection;
    }
    
    public void ShowNormals()
    {
        _reflection.EnableComponent<NormalsViewer>("Static point");
    }
    
    public void HideNormals()
    {
        _reflection.DisableComponent<NormalsViewer>("Static point");
    }

    public void ShowGizmo()
    {
        Gizmo.Instance.Enable();
    }
    
    public void HideGizmo()
    {
        Gizmo.Instance.Disable();
    }
}