using OpenTK.Graphics.OpenGL;

public static class OpenGLStopwatch
{
    private static readonly int _id = GL.GenQuery();
    
    public static void Start()
    {
        GL.BeginQuery(QueryTarget.TimeElapsed, _id);
    }

    public static float Stop()
    {
        GL.EndQuery(QueryTarget.TimeElapsed);
        GL.GetQueryObject(_id, GetQueryObjectParam.QueryResult, out int result);
        
        return result / 1000000f;
    }
}